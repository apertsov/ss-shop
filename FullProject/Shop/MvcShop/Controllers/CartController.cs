using System;
using System.Collections.Generic;
using System.Resources;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using MvcShop.ServiceShop;
using ShopModel.Entities;

namespace MvcShop.Controllers
{
    public class CartController : Controller
    {
        private readonly List<Recept> _receptRepository;

        public CartController()
        {
            var ss = new ServiceShopClient();
            _receptRepository = ss.LoadAllRecept().ToList();
        }
        private Cart GetUserCart()
        {
            var cart = (Cart)Session["Cart"] ?? new Cart{ShippingDetails = new ShippingDetails()};
            return cart;
        }

        public RedirectToRouteResult AddToCart(int receptId, string returnUrl, int? quantity)
        {
            var r = _receptRepository.Find(rf=>rf.Id==receptId);//Recept.Load(Id);
            var cart = GetUserCart();
            cart.AddItem(r,quantity??1);
            Session["Cart"] = cart;
            return RedirectToAction("Index", new {returnUrl});
        }

        private static string FormResponseTable(Cart cart)
        {
            var rm = new ResourceManager("Resources.Recept", System.Reflection.Assembly.Load("App_GlobalResources"));
            var s = "<table width=\"90%\" id=\"tableCart\"><tr><td>Your cart is empty</td></tr></table>";
            if (cart.Lines.Count > 0)
            {
                s = "<table height=\"100px\" width=\"90%\" id=\"tableCart\"><thead><tr><td><b>Quantity</b></td><td><b>Item<b></td><td><b>Price<b></td><td><b>SubTotal</b></td><td></td></tr></thead><tbody>";
                foreach (var cartLine in cart.Lines)
                {
                    s += string.Format("<tr><td><a href=\"#\" id=\"{1}\" class=\"addItemCart\"><img src=\"../../images/plus.png\" alt=\"add\"/></a>{0}", cartLine.Quantity, cartLine.Recept.Id);
                    s += string.Format("<a href=\"#\" id=\"{0}\" class=\"minusItemCart\"><img src=\"../../images/minus.png\" alt=\"minus\"/></a></td>", cartLine.Recept.Id);
                    s += string.Format("<td>{0}</td>", rm.GetString("r"+cartLine.Recept.Id));
                    s += string.Format("<td>{0}</td>", cartLine.Recept.Price.ToString("N"));
                    s += string.Format("<td>{0}</td>", (cartLine.Recept.Price * cartLine.Quantity).ToString("N"));
                    s += string.Format("<td><a href=\"#\" id=\"{0}\" class=\"removeItemCart\"><img src=\"../../images/remove.png\" alt=\"remove\"/></a></td></tr>", cartLine.Recept.Id);
                }
                s += "</tbody><tfoot><tr><td colspan=\"3\" align=\"right\">Total</td>";
                s += string.Format("<td>{0}</td><td></td></tr></tfoot></table>", cart.ComputeTotalValue().ToString("N"));
            }
            return s;
        }

        public string AddToCartAsync(string receptId, string quantity)
        {
            var r = _receptRepository.Find(rf => rf.Id == int.Parse(receptId));//Recept.Load(Id);
            var cart = GetUserCart();
            int c;
            if (int.TryParse(quantity, out c))
            {
                cart.AddItem(r, int.Parse(quantity));
                Session["Cart"] = cart;
            }
            return FormResponseTable(cart);
        }

        public string RemoveFromCartAsync(string receptId, string quantity)
        {
            var r = _receptRepository.Find(rf => rf.Id == int.Parse(receptId));//Recept.Load(Id);
            var cart = GetUserCart();
            cart.MinusItem(r, int.Parse(quantity));
            Session["Cart"] = cart;
            return FormResponseTable(cart);
        }

        public string RemoveFromCartRecept(int id)
        {
            var r = _receptRepository.Find(rf => rf.Id == id);//Recept.Load(Id);
            var cart = GetUserCart();
            cart.RemoveItem(r);
            Session["Cart"] = cart;
            return FormResponseTable(cart);
        }

        public string GetInfoAboutCartAsync()
        {
            var cart = GetUserCart();
            var s = "Shopping cart<br/>";
            s += string.Format("Items:{0}<br/>", cart.Lines.Sum(x => x.Quantity));
            s += string.Format("Total:{0}", cart.ComputeTotalValue().ToString("N"));
            return s;
        }

        public string ClearCart()
        {
            var cart = GetUserCart();
            cart.Lines.Clear();
            return FormResponseTable(cart);
        }

        public RedirectToRouteResult RemoveFromCart(int receptId,string returnUrl)
        {
            var r = _receptRepository.Find(rf => rf.Id == receptId);//Recept.Load(Id);
            var cart = GetUserCart();
            cart.RemoveItem(r);
            Session["Cart"] = cart;
            return RedirectToAction("Index", new { returnUrl });
        }

        public ActionResult Index(string returnUrl)
        {
            ViewData["returnUrl"] = returnUrl;
            ViewData["CurrentCategory"] = 0;
            var cart = GetUserCart();
            return View(cart);
        }

        public ViewResult Summary()
        {
            var cart = GetUserCart();
            return View(cart);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ViewResult CheckOut()
        {
            var cart = GetUserCart();
            return View(cart.ShippingDetails);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ViewResult CheckOut(FormCollection formCollection)
        {
            var cart = GetUserCart();
            if (cart.Lines.Count==0)
            {
                ModelState.AddModelError("Cart",@"Sorry your cart is empty");
                return View();
            }
            if (TryUpdateModel(cart.ShippingDetails,formCollection.ToValueProvider()))
            {
                try
                {
                    DateTime dt;
                    var order = new Order
                                    {
                                        Name = cart.ShippingDetails.Name,
                                        Phone = cart.ShippingDetails.NumberPhone,
                                        Address = cart.ShippingDetails.Address,
                                        OrderStatus = OrderStatus.Taken,
                                        Finish = DateTime.Now.AddYears(50),
                                        OrderLines = new List<OrderLine>(),
                                        UserName = User.Identity.Name??""
                                    };
                    if (!DateTime.TryParse(cart.ShippingDetails.OnDateTime, out dt))
                    {
                        dt = DateTime.Now;
                        order.Start = dt;
                        order.OnDateTime = dt;
                    }
                    else
                    {
                        order.OnDateTime = dt;
                        order.Start = DateTime.Now;
                    }
                    foreach (var orderLine in cart.Lines.Select(cartLine => new OrderLine { Recept = cartLine.Recept, Quantity = cartLine.Quantity}))
                    {
                        order.OrderLines.Add(orderLine);
                    }
                    var sc = new ServiceShopClient();
                    var id = sc.CreateOrder(order);
                    cart.Clear();
                    if (User.Identity.IsAuthenticated == false)
                    {
                        ViewData["idOrder"] = id;
                        var cookie = new HttpCookie("mvcShop") { Value = id.ToString(), Expires = DateTime.Now.AddYears(1) };
                        Response.Cookies.Add(cookie);
                    }
                    return View("Completed");
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

    }
}
