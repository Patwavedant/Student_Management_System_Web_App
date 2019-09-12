using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.Models;

namespace SMS.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Login()
        {
            Session["Staff"] = null;
            return View();
        }

        [HttpPost]
        public ActionResult LoginSubmit()
        {
            Staff S = new Models.Staff();
            S.Username = Request.Form["Username"];
            S.Password = Request.Form["Password"];
            if (S.Authenticate())
            {
                Session["Staff"] = S;
                return RedirectToAction("Index", "Staff");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}
