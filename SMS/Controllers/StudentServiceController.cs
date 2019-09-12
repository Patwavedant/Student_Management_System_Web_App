using SMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace SMS.Controllers
{
    public class StudentServiceController : Controller
    {
        public static string DataTabletoJSON(DataTable dt)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            Dictionary<string, object> row = null;
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn dc in dt.Columns)
                {
                    if (dc.DataType == typeof(DateTime))
                    {
                        row.Add(dc.ColumnName, dr[dc] != DBNull.Value ? Convert.ToDateTime(dr[dc]).ToString("yyyy-MM-dd#HH:mm") : "");
                    }
                    else
                    {
                        row.Add(dc.ColumnName, dr[dc] != DBNull.Value ? dr[dc] : "");
                    }
                }
                rows.Add(row);
            }
            return jss.Serialize(rows);
        }


        public ActionResult Login()
        {
            Student s = new Student();
            s.Username = Request.Params["un"];
            s.Password = Request.Params["pw"];
            if (s.Authenticate())
            {
                return Content("SUCCESS");
            }
            else
            {
                return Content("FAIL");
            }
        }
        public ActionResult MyProfile()
        {
            Student s = new Student();
            s.Username = Request.Params["un"];
            s.Password = Request.Params["pw"];
            if (s.Authenticate())
            {
                DataTable dt = s.GetProfile();
                string data = DataTabletoJSON(dt);
                return Content(data);
            }
            else
            {
                return Content("FAIL");
            }
        }
        public ActionResult ChangePassword()
        {
            Student s = new Student();
            s.Username = Request.Params["Username"];
            s.Password = Request.Params["Password"];

            if (s.Authenticate())
            {
                s.Password = Request.Params["newpw"];
                s.Update();
                return Content("SUCCESS");
            }
            else
            {
                   return Content("FAIL");
            }
        }

        public ActionResult GetExamSchedule()
        {
            Student s = new Student();
            s.Username = Request.Params["un"];
            s.Password = Request.Params["pw"];
            if (s.Authenticate())
            {
                ExamSchedule es = new ExamSchedule();
                DataTable dt = es.SelectActiveByDepartmentSemester(s.DepartmentID, s.Semester);
                string data = DataTabletoJSON(dt);

                return Content(data);
            }
            else
            {
                return Content("FAIL");
            }
        }
        public ActionResult GetTimeTable()
        {
            Student s = new Student();
            s.Username = Request.Params["un"];
            s.Password = Request.Params["pw"];
            if (s.Authenticate())
            {
                TimeTable tt = new TimeTable();
                DataTable dt = tt.SelectActiveByDepartmentSemester(s.DepartmentID, s.Semester);
                string data = DataTabletoJSON(dt);

                return Content(data);
            }
            else
            {
                return Content("FAIL");
            }
        }
    }
}
    
