﻿using System;
using System.Collections.Generic;
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

        public string AddToCartAsync(string receptId, string quantity)
        {
            var r = _receptRepository.Find(rf => rf.Id == int.Parse(receptId));//Recept.Load(Id);
            var cart = GetUserCart();
            cart.AddItem(r, int.Parse(quantity));
            Session["Cart"] = cart;
            var s="<table id=\"tableCart\" align=\"center\"><tr><th colspan=\"2\">Cart</th></tr>";
            s += string.Format("<tr><td>Items</td><td>{0}</td></tr>", cart.Lines.Sum(x => x.Quantity));
            s += string.Format("<tr><td>Total</td><td>{0}</td></tr></table>", cart.ComputeTotalValue());
            return s;
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
                    }
                    var cookie = new HttpCookie("mvcShop") {Value = id.ToString(), Expires = DateTime.Now.AddYears(1)};
                    Response.Cookies.Add(cookie);
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
