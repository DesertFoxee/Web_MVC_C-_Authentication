using Authrz.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Authrz.Models;

namespace Authrz.Controllers
{
    /*====================
       N.V.T -- Sử dụng session xác thực đăng nhập
       - Các action không có AuthorizationFilter : mặc định có thể truy cập
       - Các action có AuthorizationFilter : phụ thuộc quy tắc 

        [!] Có thể sử dụng cho cả controller (1)
    ====================*/

    // [AuthorizationFilter(Roles.ADMIN)] <== Ex (1)

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            User user = new User(Roles.USER);
            user.Username = "User";

            Session.Add("User", user);
            return View();
        }


        [AuthorizationFilter(Roles.USER)]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.UserName = (Session["User"] as User).Username;
            return View();
        }

        [AuthorizationFilter(Roles.ADMIN)]
        public ActionResult Contact()
        {

            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}