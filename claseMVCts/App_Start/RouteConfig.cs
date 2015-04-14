using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace claseMVCts
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

           // routes.MapRoute(
           //    name: "deportesruta",
           //    url: "deportes/{action}",
           //    defaults: new { controller = "deportes", action = "Index", id = UrlParameter.Optional }
           //);

            //routes.MapRoute(
            //      "deportescontroller", "deportescontroller/{categoria}",
            //      new { controller = "deportes", action = "Index" },
            //      new { categoria = @"\w+" });

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

            //routes.MapRoute(
            //                    "CustomRoute",
            //                    "{*url}",
            //                    new { controller = "deportes", action = "index" }
            //     );

            //deportes
            // deportes/cualquiera
            //routes.MapRoute(
            //    name: "DeporteProperty",
            //    url: "Deportes/{categoria}",
            //    defaults: new
            //    {
            //        controller = "Deportes",
            //        action = "Index",
            //    }
            //);
            //deportes/deporte/softball
            routes.MapRoute(
               name: "Deporteruta2",
               url: "deportes/deporte/{categoria}",
               defaults: new
               {
                   controller = "Deportes",
                   action = "index",
                   categoria = UrlParameter.Optional
               }
           );







            // rentalProperties/
            //----------------------------------------
            // RentalProperties/Boardwalk/Units/4A
            routes.MapRoute(
                name: "rutaralquiler1",
                url: "RentalProperties/{rentalPropertyName}/Units/{unitNo}",
                defaults: new
                {
                    controller = "RentalProperties",
                    action = "Unit",
                }
            );


            // RentalProperties/cualquiera
            routes.MapRoute(
                name: "RentalProperty",
                url: "RentalProperties/{rentalPropertyName}",
                defaults: new
                {
                    controller = "RentalProperties",
                    action = "RentalProperty",
                }
            );


            // RentalProperties/
            routes.MapRoute(
                name: "RentalProperties",
                url: "RentalProperties",
                defaults: new
                {
                    controller = "RentalProperties",
                    action = "All",
                    id = UrlParameter.Optional
                }
            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );

        }
    }
}