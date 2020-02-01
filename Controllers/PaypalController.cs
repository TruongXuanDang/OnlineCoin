using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCoin.Controllers
{
    public class PaypalController : Controller
    {
        private static int ipnRequestCount = 0;
        // GET: Paypal
        public ActionResult Index()
        {
            return View("~/Views/Paypal/About.cshtml");
        }

        public ActionResult Ipn()
        {
            ipnRequestCount++;
            ViewBag.Message = "Count ipn request. " + ipnRequestCount;
            return View("~/Views/Paypal/About.cshtml");
        }

        public ActionResult Success()
        {
            ViewBag.Message = "Check out success.";
            return View("~/Views/Paypal/About.cshtml");
        }
    }
}