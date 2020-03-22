using GGJWEvent.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GGJWEvent.Controllers
{
    public class HomeController : Controller
    {
        StudyField sf = new StudyField();
        // GET: Home
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult StateCity()
        {
            return View();
        }
        public ActionResult Exhibitor()
        {
            return View();
        }
        public ActionResult ExhibitorOffer()
        {
            return View();
        }
        public ActionResult RequestCoupon()
        {
            return View();
        }
        public ActionResult HistoryCoupon()
        {
            return View();
        }
        public ActionResult AssignCoupon()
        {
            return View();
        }
        public ActionResult ExhibitorList()
        {
            return View();
        }
        public ActionResult CustomerList()
        {
            return View();
        }
        public ActionResult RequestForCouponList()
        {
            return View();
        }
        public ActionResult AssignCouponExhibitorList()
        {
            return View();
        }
        public ActionResult DailyDraw()
        {
            return View();
        }
        public ActionResult Draw()
        {
            return View();
        }
        public ActionResult TodayDrawList()
        {
            return View();
        }
        public ActionResult DrawList()
        {
            return View();
        }
        public ActionResult DrawCoupon()
        {
            return View();
        }
        public ActionResult ExhibitorCustomerAssignCoupon()
        {
            return View();
        }
        public ActionResult SendNotification()
        {
            return View();
        }
        public ActionResult DrawResult()
        {
            return View();
        }
        public ActionResult DrawWinner()
        {
            return View();
        }
        public ActionResult RequestAndAssign()
        {
            return View();
        }
        public ActionResult ApplyCouponList()
        {
            return View();
        }
        public ActionResult CustomerCouponDetail()
        {
            return View();
        }
        public ActionResult MegaDraw()
        {
            return View();
        }
        public ActionResult MegaDraws()
        {
            return View();
        }
        public ActionResult MegaDrawResult()
        {
            return View();
        }
        public ActionResult MegaDrawWinnerList()
        {
            return View();
        }
        public ActionResult CustomerCouponHistory()
        {
            return View();
        }
    }
}