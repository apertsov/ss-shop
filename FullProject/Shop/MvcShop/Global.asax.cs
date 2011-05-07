using System.Web.Mvc;
using System.Web.Routing;
using ShopModel.Entities;

namespace MvcShop
{
    
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                null, // Route name
                "Cat{category}", // URL with parameters
                new { controller = "Recepts", action = "List", page = 1 }, // Parameter defaults
                new { category = @"\d+" }
                );

            routes.MapRoute(
                null, // Route name
                "Cat{category}/Page{page}", // URL with parameters
                new { controller = "Recepts", action = "List" }, // Parameter defaults
                new { category = @"\d+", page = @"\d+" }
                );

            routes.MapRoute(
                null, // Route name
                "", // URL with parameters
                new {controller = "Recepts", action = "List", category = 1, page = 1} // Parameter defaults
                );

            routes.MapRoute(
                null, // Route name
                "Page{page}", // URL with parameters
                new {controller = "Recepts", action = "List", category = 1}, // Parameter defaults
                new {page = @"\d+"}
                );

            routes.MapRoute(null, "{controller}/{action}/{id}");

            routes.MapRoute(null, "{controller}/{action}");
        }

        
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            //var rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/");
            //ConnectionDb.Connection = new SqlConnection(@rootWebConfig.ConnectionStrings.ConnectionStrings["ConnectionStringShop"].ConnectionString);
            //ConnectionDb.Connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\shop.mdf;Integrated Security=True;User Instance=True");
            //ConnectionDb.Open();
        }

        protected void Application_End()
        {
            //if (ConnectionDb.IsOpened) ConnectionDb.Close();
        }
    }
}