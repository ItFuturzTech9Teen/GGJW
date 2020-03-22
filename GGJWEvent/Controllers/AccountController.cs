using GGJWEvent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GGJWEvent.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }


        // this code is for session management 
        public class MyObject
        {
            public string success { get; set; }
        }

        public static class Constants
        {
            public static string User = "user";
        }
        public static class SessionManagement
        {
            public static UserLogin user
            {
                get
                {
                    return
                        System.Web.HttpContext.Current.Session[Constants.User] != null ?
                        System.Web.HttpContext.Current.Session[Constants.User] as UserLogin : null;
                }
                set
                {
                    System.Web.HttpContext.Current.Session[Constants.User] = value;
                }
            }
        }

        [HttpPost]
        public JsonResult SetLoginSession(UserLogin user)
        {
            SessionManagement.user = user as UserLogin;
            return new JsonResult { Data = { } };
        }

        public JsonResult GetLoginSession()
        {
            return Json(new JsonResult { Data = SessionManagement.user }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DestoryLoginSession()
        {
            SessionManagement.user = null;
            return new JsonResult { Data = { } };
        }
    }
}