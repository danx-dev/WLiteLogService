using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WLiteLogService.Models;

namespace WLiteLogService.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(UserProfile user)
        {
            if (ModelState.IsValid)
            {
                if (user.Username == "admin" && user.Password == "12345678")
                {
                    RedirectToAction("Index", "Dashboard");
                }
            }
            return View("~/Views/Login/Index.cshtml", user);
        }
    }
}