using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using MvcShop.ServiceShop;
using ShopModel.Entities;

namespace MvcShop.Controllers
{
    public class NavigationLink
    {
        public string Text { get; set; }
        public RouteValueDictionary RouteValues { get; set; }
        public bool IsSelected { get; set; }
    }

    public class CategoryLink : NavigationLink
    {
        public CategoryLink(Category category)
        {
            if (category==null)
            {
                Text = "Home";
                RouteValues = new RouteValueDictionary(new { controller = "Home", action = "Index" });
            }
            else
            {
                Text = category.CategoryName;
                RouteValues = new RouteValueDictionary(new { controller = "Recepts", action = "List", category = category.Id, page = 1 });
            }
        }
    }

    public class NavigationController : Controller
    {
        private readonly List<Category> _categoryRepository;
        public NavigationController()
        {
            var ss = new ServiceShopClient();
            _categoryRepository = ss.LoadAllCategory().ToList();
        }

        public ViewResult Menu(int? idSelectedCategory)
        {
            var navigationLinks = new List<NavigationLink> {new CategoryLink(null){IsSelected = (idSelectedCategory==null)}};
            navigationLinks.AddRange(_categoryRepository.Select(category => new CategoryLink(category){IsSelected = (idSelectedCategory==category.Id)}));
            navigationLinks.Add(new NavigationLink { IsSelected = false, RouteValues = new RouteValueDictionary(new { controller = "Orders", action = "Index" }), Text = "Orders"});
            return View(navigationLinks);
        }

    }
}
