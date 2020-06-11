using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Authrz.Models
{
    public class ErrorController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Err404()
        {
            return View();
        }
        public ActionResult Err403()
        {
            return View();
        }
    }
}
