using SMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Controllers
{
    public class HODController : Controller
    {
        Staff CURRENTStaff = new Staff();

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["Staff"] == null)
            {
                filterContext.Result = RedirectToAction("Login", "Access");
                return;
            }

            CURRENTStaff = (Staff)Session["Staff"];
            if (CURRENTStaff.StaffType != "HOD")
            {
                filterContext.Result = RedirectToAction("Index", "Staff");
                return;
            }

            base.OnActionExecuting(filterContext);
        }

        public ActionResult ExamScheduleNew()
        {
            Department d = new Department();
            DataTable dt = d.SelectAll();
            return View(dt);
        }
        [HttpPost]
        public ActionResult SubmitExamScheduleNew()
        {
            ExamSchedule e = new ExamSchedule();
            e.DepartmentID = Convert.ToInt32(Request.Form["DepartmentID"]);
            e.Semester = Request.Form["Semester"];

            if (Request.Files["ScheduleFile"] != null && !string.IsNullOrEmpty(Request.Files["ScheduleFile"].FileName))
            {
                e.ScheduleFile = DateTime.Now.Ticks + "_" + Request.Files["ScheduleFile"].FileName;
                Request.Files["ScheduleFile"].SaveAs(Server.MapPath("\\docs\\" + e.ScheduleFile));
            }

            //e.ScheduleFile = Request.Form["ScheduleFile"];

            DateTime dtm1 = new DateTime();
            if (!DateTime.TryParseExact(Request.Form["PublishDate"], "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out dtm1))
            {
                dtm1 = DateTime.Today;
            }
            e.PublishDate = dtm1;
            e.IsActive = (Request.Form["IsActive"] == "1") ? true : false;

            e.Insert();

            return RedirectToAction("ExamScheduleActive");
        }
       
       public ActionResult ExamScheduleActive()
        {
            ExamSchedule es = new Models.ExamSchedule();
            DataTable dt = es.SelectActive();

            return View(dt);
        }

        public ActionResult ExamScheduleInActive()
        {
            ExamSchedule es = new ExamSchedule();
            DataTable dt = es.SelectInActive();

            return View(dt);
        }

        public ActionResult ExamScheduleEdit()
        {
            ExamSchedule e = new ExamSchedule();
            e.ExamScheduleID = Convert.ToInt32(Request.QueryString["ID"]);
            e.SelectByPK();

            Department d = new Department();
            DataTable dt2 = d.SelectAll();

            ViewBag.abc = dt2;

            return View(e);
        }
        [HttpPost]
        public ActionResult SubmitExamScheduleEdit()
        {
            ExamSchedule e = new ExamSchedule();
            e.ExamScheduleID = Convert.ToInt32(Request.Form["ID"]);
            e.Semester = Request.Form["Semester"];
            e.ScheduleFile = Request.Form["ScheduleFile"];

            DateTime dtm1 = new DateTime();
            if (!DateTime.TryParseExact(Request.Form["PublishDate"], "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out dtm1))
            {
                dtm1 = DateTime.Today;
            }
            e.PublishDate = dtm1;
            e.DepartmentID = Convert.ToInt32(Request.Form["DepartmentID"]);
            e.IsActive = (Request.Form["IsActive"] == "1") ? true : false;

            e.Update();

            return RedirectToAction("ExamScheduleActive");
        }

        public ActionResult TimeTableNew()
        {
            Department d = new Department();
            DataTable dt = d.SelectAll();
            return View(dt);
        }
        [HttpPost]
        public ActionResult SubmitTimeTableNew()
        {
            TimeTable tt = new TimeTable();
            tt.DepartmentID = Convert.ToInt32(Request.Form["DepartmentID"]);
            tt.Semester = Request.Form["Semester"];
            tt.Class = Request.Form["Class"];

            if (Request.Files["TTFile"] != null && !string.IsNullOrEmpty(Request.Files["TTFile"].FileName))
            {
                tt.TTFile = DateTime.Now.Ticks + "_" + Request.Files["TTFile"].FileName;
                Request.Files["TTFile"].SaveAs(Server.MapPath("\\docs\\" + tt.TTFile));
            }

           // tt.TTFile = Request.Form["TTFile"];
            tt.IsActive = (Request.Form["IsActive"] == "1") ? true : false;

            tt.Insert();

            return RedirectToAction("TimeTableActive");
        }

        public ActionResult TimeTableActive()
        {
            TimeTable tt = new Models.TimeTable();
            DataTable dt = tt.SelectActive();

            return View(dt);
        }

        public ActionResult TimeTableInActive()
        {
            TimeTable tt = new TimeTable();
            DataTable dt = tt.SelectInActive();

            return View(dt);
        }

        public ActionResult TimeTableEdit()
        {
            TimeTable tt = new TimeTable();
            tt.TimeTableID = Convert.ToInt32(Request.QueryString["ID"]);
            tt.SelectByPK();

            Department d = new Department();
            DataTable dt2 = d.SelectAll();

            ViewBag.abc = dt2;

            return View(tt);

        }

        [HttpPost]
        public ActionResult SubmitTimeTableEdit()
        {
            TimeTable tt = new TimeTable();
            tt.TimeTableID = Convert.ToInt32(Request.Form["ID"]);           
            tt.Semester = Request.Form["Semester"];
            tt.Class = Request.Form["Class"];
            tt.TTFile = Request.Form["TTFile"];
            tt.DepartmentID = Convert.ToInt32(Request.Form["DepartmentID"]);
            tt.IsActive = (Request.Form["IsActive"] == "1") ? true : false;

            tt.Update();

            return RedirectToAction("TimeTableActive");
        }

        public ActionResult CircularNew()
        {
            Department d = new Department();
            DataTable dt = d.SelectAll();
            return View(dt);
        }
        [HttpPost]
        public ActionResult SubmitCircularNew()
        {
            Circular c = new Circular();
            c.Title = Request.Form["Title"];

            if (Request.Files["CFile"] != null && !string.IsNullOrEmpty(Request.Files["CFile"].FileName))
            {
                c.CFile = DateTime.Now.Ticks + "_" + Request.Files["CFile"].FileName;
                Request.Files["CFile"].SaveAs(Server.MapPath("\\docs\\" + c.CFile));
            }

            // c.CFile = Request.Form["CFile"];

            DateTime dtm1 = new DateTime();
            if (!DateTime.TryParseExact(Request.Form["PublishDate"], "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out dtm1))
            {
                dtm1 = DateTime.Today;
            }
            c.PublishDate = dtm1;
            c.IsActive = (Request.Form["IsActive"] == "1") ? true : false;

            c.Insert();

            return RedirectToAction("CircularActive");
        }
       
        public ActionResult CircularActive()
        {
            Circular c = new Models.Circular();
            DataTable dt = c.SelectActive();

            return View(dt);
        }

        public ActionResult CircularInActive()
        {
            Circular c = new Circular();
            DataTable dt = c.SelectInActive();

            return View(dt);

        }

        public ActionResult CircularEdit()
        {
            Circular c = new Circular();
            c.CircularID = Convert.ToInt32(Request.QueryString["ID"]);
            c.SelectByPK();

            Department d = new Department();
            DataTable dt2 = d.SelectAll();

            ViewBag.abc = dt2;

            return View(c);

        }

        [HttpPost]

        public ActionResult SubmitCircularEdit()
        {
            Circular c = new Circular();
            c.CircularID = Convert.ToInt32(Request.Form["ID"]);
            c.Title = Request.Form["Title"];
            c.CFile = Request.Form["CFile"];

            DateTime dtm1 = new DateTime();
            if (!DateTime.TryParseExact(Request.Form["PublishDate"], "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out dtm1))
            {
                dtm1 = DateTime.Today;
            }
            c.PublishDate = dtm1;
            c.IsActive = (Request.Form["IsActive"] == "1") ? true : false;

            c.Update();

            return RedirectToAction("CircularActive");
        }

    }

}