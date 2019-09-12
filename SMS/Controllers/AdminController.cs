using SMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Controllers
{
    public class AdminController : Controller
    {
        Staff CURRENTStaff = new Staff();

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(Session["Staff"] == null)
            {
                filterContext.Result = RedirectToAction("Login", "Access");
                return;
            }

            CURRENTStaff = (Staff)Session["Staff"];
            if (CURRENTStaff.StaffType != "ADMIN")
            {
                filterContext.Result = RedirectToAction("Index", "Staff");
                return;
            }

            base.OnActionExecuting(filterContext);
        }

        public ActionResult StaffNew()
        {
            Department d = new Department();
            DataTable dt = d.SelectAll();
            return View(dt);            
        }
        [HttpPost]
        public ActionResult SubmitStaffNew()
        {
            Staff s = new Staff();
            s.SName = Request.Form["SName"];
            s.Email = Request.Form["Email"];
            s.Phone = Request.Form["Phone"];
            s.Username = Request.Form["Username"];
            s.Password = Request.Form["Password"];
            s.DepartmentID = Convert.ToInt32(Request.Form["DepartmentID"]);
            s.IsActive = (Request.Form["IsActive"] == "1") ? true : false;

            s.Insert();

            return RedirectToAction("StaffSearch");
        }

        public ActionResult StaffSearch()
        {
            return View(new DataTable());
        }

        [HttpPost]
        public ActionResult StaffSearchResult()
        {
            Staff S = new Staff();
            DataTable dt = S.Search(Request.Form["SName"]);

            return View("StaffSearch", dt);
        }

        public ActionResult StaffEdit()
        {
            Staff s = new Staff();
            s.StaffID = Convert.ToInt32(Request.QueryString["ID"]);
            s.SelectByPK();

            Department d = new Department();
            DataTable dt2 = d.SelectAll();

            ViewBag.abc = dt2;

            return View(s);
            
        }

        [HttpPost]
        public ActionResult SubmitStaffEdit()
        {
            Staff s = new Staff();
            s.StaffID = Convert.ToInt32(Request.Form["ID"]);
            s.SName = Request.Form["SName"];
            s.Email = Request.Form["Email"];
            s.Phone = Request.Form["Phone"];
            s.Username = Request.Form["Username"];
            s.Password = Request.Form["Password"];
            s.StaffType = Request.Form["StaffType"];
            s.DepartmentID = Convert.ToInt32(Request.Form["DepartmentID"]);
            s.IsActive = (Request.Form["IsActive"] == "1") ? true : false;

            s.Update();

            return RedirectToAction("StaffSearch");
        }    

        public ActionResult StudentNew()
        {
            Department d = new Department();
            DataTable dt = d.SelectAll();
            return View(dt);            
        }
        [HttpPost]
        public ActionResult SubmitStudentNew()
        {
            Student s = new Student();
            s.Name  = Request.Form["Name"];
            s.Email = Request.Form["Email"];
            s.Phone = Request.Form["Phone"];
            s.ParentPhone = Request.Form["ParentPhone"];
            s.Semester = Request.Form["Semester"];
            s.Class = Request.Form["Class"];
            s.Username = Request.Form["Username"];
            s.Password = Request.Form["Password"];
            s.DepartmentID = Convert.ToInt32(Request.Form["DepartmentID"]);
            s.IsActive = (Request.Form["IsActive"] == "1") ? true : false;            

            s.Insert();

            return RedirectToAction("StudentSearch");
        }

        public ActionResult StudentSearch()
        {
            return View(new DataTable());
        }

        [HttpPost]
        public ActionResult StudentSearchResult()
        {

            Student s = new Student();
            DataTable dt = s.Search(Request.Form["Name"]);

            return View("StudentSearch", dt);
        }

        public ActionResult StudentEdit()
        {
            Student s = new Student();
            s.StudentID = Convert.ToInt32(Request.QueryString["ID"]);
            s.SelectByPK();

            Department d = new Department();
            DataTable dt2 = d.SelectAll();

            ViewBag.abc = dt2;

            return View(s);
        }

        [HttpPost]
        public ActionResult SubmitStudentEdit()
        {

            Student s = new Student();
            s.StudentID = Convert.ToInt32(Request.Form["ID"]);
            s.Name = Request.Form["Name"];
            s.Email = Request.Form["Email"];
            s.Phone = Request.Form["Phone"];
            s.ParentPhone = Request.Form["ParentPhone"];
            s.Semester = Request.Form["Semester"];
            s.Class = Request.Form["Class"];
            s.Username = Request.Form["Username"];
            s.Password = Request.Form["Password"];
            s.DepartmentID = Convert.ToInt32(Request.Form["DepartmentID"]);
            s.IsActive = (Request.Form["IsActive"] == "1") ? true : false;

            s.Update();

            return RedirectToAction("StudentSearch");
        }    

        public ActionResult DepartmentNew()
        {
            Staff s = new Staff();
            DataTable dt = s.SelectAll();
            return View(dt);            
        }

        [HttpPost]
        public ActionResult SubmitDepartmentNew()
        {
            Department d = new Department();
            d.DName = Request.Form["DName"];
            d.HeadID = Convert.ToInt32(Request.Form["HeadID"]);

            d.Insert();
            return RedirectToAction("DepartmentList");
        }

        public ActionResult DepartmentList()
        {
            Department d = new Department();
            DataTable dt = d.SelectAll();
            return View(dt);
        }        

        public ActionResult DepartmentEdit()
        {
            Department d = new Department();            
            d.DepartmentID = Convert.ToInt32(Request.QueryString["ID"]);
            d.SelectByPK();

            Staff S = new Staff();
            DataTable dt2 = S.SelectAll();

            ViewBag.abc = dt2;

            return View(d);
        }

        [HttpPost]
        public ActionResult SubmitDepartmentEdit()
        {
            Department d = new Department();
            d.DepartmentID = Convert.ToInt32(Request.Form["ID"]);
            d.SelectByPK();

            d.DName = Request.Form["DName"];
            d.HeadID = Convert.ToInt32(Request.Form["HeadID"]);
            
            d.Update();

            return RedirectToAction("DepartmentList");
        }

        public ActionResult FAQNew()
        {
            Staff s = new Staff();
            DataTable dt = s.SelectAll();
            return View(dt);
        }

        [HttpPost]
        public ActionResult SubmitFAQNew()
        {
            FAQ f = new FAQ();
            f.Question = Request.Form["Question"];
            f.Answer = Request.Form["Answer"];            

            f.Insert();
            return RedirectToAction("FAQList");
        }

        public ActionResult FAQList()
        {
            FAQ f = new FAQ();
            DataTable dt = f.SelectAll();
            return View(dt);
        }

        public ActionResult FAQEdit()
        {
            FAQ f = new FAQ();
            f.FAQID = Convert.ToInt32(Request.QueryString["ID"]);
            f.SelectByPK();

            Staff S = new Staff();
            DataTable dt2 = S.SelectAll();

            ViewBag.abc = dt2;

            return View(f);
        }

        [HttpPost]
        public ActionResult SubmitFAQEdit()
        {
            FAQ f = new FAQ();
            f.FAQID = Convert.ToInt32(Request.Form["ID"]);
            f.SelectByPK();

            f.Question = Request.Form["Question"];
            f.Answer = Request.Form["Answer"];

            f.Update();

            return RedirectToAction("FAQList");
        }
    }    
}