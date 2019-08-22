using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TableauAPI.Models;

namespace TableauAPI.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpPost]
        public JsonResult Index(string data)
        {
            ViewBag.Title = "Home Page";
            var skillData = new AlexaSKill
            {
                DashboardData = data,
                DashboardUrl = string.Empty
            };

            db.AlexaSKill.Add(skillData);
            db.SaveChanges();
            
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SalesDashboard()
        {
            ViewBag.Title = "Home Page";

            return View();
        }



        [HttpPost]
        public JsonResult SalesDashboard(string data)
        {
            ViewBag.Title = "Home Page";
            var skillData = new SalesSkill
            {
                DashboardData = data,
                DashboardUrl = string.Empty
            };

            db.SalesSkill.Add(skillData);
            db.SaveChanges();

            return Json(data, JsonRequestBehavior.AllowGet);
        }


        public ActionResult CustomerDashboard()
        {
            ViewBag.Title = "Home Page";

            return View();
        }


        [HttpPost]
        public JsonResult CustomerDashboard(string data)
        {
            ViewBag.Title = "Home Page";
            var skillData = new SalesSkill
            {
                DashboardData = data,
                DashboardUrl = string.Empty
            };

            db.SalesSkill.Add(skillData);
            db.SaveChanges();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DynamicDashboard()
        {
            ViewBag.Title = "Tableau Dynamic";

            return View();
        }

        [HttpPost]
        public JsonResult DynamicDashboard(string data)
        {
            ViewBag.Title = "Tableau Dynamic";
            var skillData = new AlexaSKill
            {
                DashboardData = data,
                DashboardUrl = string.Empty
            };

            db.AlexaSKill.Add(skillData);
            db.SaveChanges();

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }


   
}
