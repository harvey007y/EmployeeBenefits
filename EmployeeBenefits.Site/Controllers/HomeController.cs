using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeBenefits.Site.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Free tool for calculating employee benefit deductions.";
            var version = typeof(Controller).Assembly.GetName().Version.ToString();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Employee Benefits is a Free Tool that allows a company to calculate employee benefits for employees.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Wade Harvey.";

            return View();
        }
    }
}
