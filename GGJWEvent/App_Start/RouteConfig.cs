using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GGJWEvent
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Account Controller
            routes.MapRoute(name: "Index", url: "Index", defaults: new { Controller = "Account", Action = "Index" });

            //DashBoard
            routes.MapRoute(name: "Dashboard", url: "Dashboard", defaults: new { Controller = "Home", Action = "Dashboard" });

            //AssignCoupon
            routes.MapRoute(name: "AssignCoupon", url: "AssignCoupon", defaults: new { Controller = "Home", Action = "AssignCoupon" });
            routes.MapRoute(name: "AssignCouponExhibitorList", url: "AssignCouponExhibitorList", defaults: new { Controller = "Home", Action = "AssignCouponExhibitorList" });

            //Exhibitor
            routes.MapRoute(name: "Exhibitor", url: "Exhibitor", defaults: new { Controller = "Home", Action = "Exhibitor" });
            routes.MapRoute(name: "ExhibitorList", url: "ExhibitorList", defaults: new { Controller = "Home", Action = "ExhibitorList" });
            routes.MapRoute(name: "ExhibitorOffer", url: "ExhibitorOffer", defaults: new { Controller = "Home", Action = "ExhibitorOffer" });

            //Draw
            routes.MapRoute(name: "Draw", url: "Draw", defaults: new { Controller = "Home", Action = "Draw" });
            routes.MapRoute(name: "DailyDraw", url: "DailyDraw", defaults: new { Controller = "Home", Action = "DailyDraw" });
            routes.MapRoute(name: "DrawList", url: "DrawList", defaults: new { Controller = "Home", Action = "DrawList" });
            routes.MapRoute(name: "DrawWinner", url: "DrawWinner", defaults: new { Controller = "Home", Action = "DrawWinner" });
            routes.MapRoute(name: "MegaDraw", url: "MegaDraw", defaults: new { Controller = "Home", Action = "MegaDraw" });
            routes.MapRoute(name: "MegaDraws", url: "MegaDraws", defaults: new { Controller = "Home", Action = "MegaDraws" });
            routes.MapRoute(name: "MegaDrawWinnerList", url: "MegaDrawWinnerList", defaults: new { Controller = "Home", Action = "MegaDrawWinnerList" });

            //CustomerReport
            routes.MapRoute(name: "CustomerList", url: "CustomerList", defaults: new { Controller = "Home", Action = "CustomerList" });
            routes.MapRoute(name: "CustomerCouponHistory", url: "CustomerCouponHistory", defaults: new { Controller = "Home", Action = "CustomerCouponHistory" });

            //HistoryCouponReport
            routes.MapRoute(name: "HistoryCoupon", url: "HistoryCoupon", defaults: new { Controller = "Home", Action = "HistoryCoupon" });
            
            //ApplyCouponList
            routes.MapRoute(name: "CustomerCouponDetail", url: "CustomerCouponDetail", defaults: new { Controller = "Home", Action = "CustomerCouponDetail" });

            //ApplyCouponList
            routes.MapRoute(name: "ApplyCouponList", url: "ApplyCouponList", defaults: new { Controller = "Home", Action = "ApplyCouponList" });

            //Notificaiion
            routes.MapRoute(name: "SendNotification", url: "SendNotification", defaults: new { Controller = "Home", Action = "SendNotification" });
            routes.MapRoute(name: "RequestAndAssign", url: "RequestAndAssign", defaults: new { Controller = "Home", Action = "RequestAndAssign" });
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
