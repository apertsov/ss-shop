using System.Web.Mvc;
using System.Web.Routing;
using ShopModel.Entities;
using System.Globalization;
using System;
using System.Web;
using System.Threading;

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
                "Page{page}", // URL with parameters
                new {controller = "Recepts", action = "List", category = 1}, // Parameter defaults
                new {page = @"\d+"}
                );

            routes.MapRoute(
                null, // Route name
                "", // URL with parameters
                new { controller = "Home", action = "Index" } // Parameter defaults
                );

            routes.MapRoute(null, "{controller}/{action}");

            routes.MapRoute(null, "{controller}/{action}/{id}");

            routes.MapRoute(null, "{controller}/{action}/{receptId}/{quantity}");
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

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            //Очень важно проверять готовность объекта сессии
            if (HttpContext.Current.Session != null)
            {
                CultureInfo ci = (CultureInfo)this.Session["Culture"];
                //Вначале проверяем, что в сессии нет значения
                //и устанавливаем значение по умолчанию
                //это происходит при первом запросе пользователя
                if (ci == null)
                {
                    //Устанавливает значение по умолчанию - базовый английский
                    string langName = "en";
                    //Пытаемся получить значения с HTTP заголовка
                    if (HttpContext.Current.Request.UserLanguages != null && HttpContext.Current.Request.UserLanguages.Length != 0)
                    {
                        //Получаем список 
                        langName = HttpContext.Current.Request.UserLanguages[0].Substring(0, 2);
                    }
                    ci = new CultureInfo(langName);
                    this.Session["Culture"] = ci;
                }
                //Устанавливаем культуру для каждого запроса
                Thread.CurrentThread.CurrentUICulture = ci;
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(ci.Name);
            }
        }
    }
}