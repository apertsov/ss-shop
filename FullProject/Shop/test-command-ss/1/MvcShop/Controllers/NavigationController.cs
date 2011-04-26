using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using ShopModel.Abstract;
using ShopModel.Concrete;
using ShopModel.Entities;

namespace MvcShop.Controllers
{
    public class NavigationLink
    {
        public string Text { get; set; }
        public RouteValueDictionary RouteValues { get; set; }
    }

    public class CategoryLink : NavigationLink
    {
        public CategoryLink(Category category)
        {
            Text = (category == null) ? "Home" : category.CategoryName;
            var cat = (category == null) ? (int?) null : category.Id;
            RouteValues = new RouteValueDictionary(new { controller = "Recepts", action = "List", category = cat, page = 1 });
        }
    }

    public class NavigationController : Controller
    {
        private readonly ICategoriesRepository _categoryRepository;
        public NavigationController()
        {
            _categoryRepository = new FakeCategoriesRepository();
        }

        public ViewResult Menu()
        {
            var navigationLinks = new List<NavigationLink> {new CategoryLink(null)};
            navigationLinks.AddRange(_categoryRepository.Categories.Select(category => new CategoryLink(category)));
            return View(navigationLinks);
        }

    }
}
