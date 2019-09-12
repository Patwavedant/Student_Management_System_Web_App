using System;
using System.Web.Mvc;

namespace SMS.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["Staff"] == null)
            {
                filterContext.Result = RedirectToAction("Login", "Access");
                return;
            }

            base.OnActionExecuting(filterContext);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyProfile()
        {
            return View();
        }
    }
}