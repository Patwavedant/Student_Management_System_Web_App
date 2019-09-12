using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class Attendance
    {
        public int AttendanceID;
        public int StudentID;
        public int StaffID;
        public DateTime AtDate;
        public string Semester;
        public string Class;
        public string Session;

        public int Insert()
        {
            string query = "INSERT INTO Attendance VALUES(@StudentID , @StaffID, @AtDate, @Semester, @Class, @Session)";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@StudentID", this.StudentID));
            parameters.Add(new SqlParameter("@StaffID", this.StaffID));
            parameters.Add(new SqlParameter("@AtDate", this.AtDate));
            parameters.Add(new SqlParameter("@Semester", this.Semester));
            parameters.Add(new SqlParameter("@Class", this.Class));
            parameters.Add(new SqlParameter("@Session", this.Session));

            return DBUtility.ModifyData(query, parameters);
        }

        public int Update()
        {
            string query = "UPDATE Attendance SET StudentID = @StudentID, StaffID = @StaffID,  AtDate = @AtDate, Semester =@Semester, Class = @Class, Session = @Session WHERE AttendanceID = @AttendanceID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@StudentID", this.StudentID));
            parameters.Add(new SqlParameter("@StaffID", this.StaffID));
            parameters.Add(new SqlParameter("@AtDate", this.AtDate));
            parameters.Add(new SqlParameter("@Semester", this.Semester));
            parameters.Add(new SqlParameter("@Class", this.Class));
            parameters.Add(new SqlParameter("@Session", this.Session));
            parameters.Add(new SqlParameter("@AttendanceID", this.AttendanceID));

            return DBUtility.ModifyData(query, parameters);
        }

        public int Delete()
        {
            string query = "DELETE Attendance WHERE AttendanceID = @AttendanceID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@AttendanceID", this.AttendanceID));

            return DBUtility.ModifyData(query, parameters);
        }

        public bool SelectByPK()
        {
            string query = "SELECT * FROM Attendance WHERE AttendanceID = @AttendanceID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@AttendanceID", this.AttendanceID));

            DataTable dt = DBUtility.SelectData(query, parameters);

            if (dt.Rows.Count > 0)
            {
                this.StudentID = Convert.ToInt32(dt.Rows[0]["StudentID"]);
                this.StaffID = Convert.ToInt32(dt.Rows[0]["StaffId"]);
                this.AtDate = Convert.ToDateTime(dt.Rows[0]["AtDate"].ToString());
                this.Semester = dt.Rows[0]["Semester"].ToString();
                this.Class = dt.Rows[0]["Class"].ToString();
                this.Session = dt.Rows[0]["Session"].ToString();
                this.AttendanceID = Convert.ToInt32(dt.Rows[0]["AttendanceID"]);


                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable SelectAll()
        {
            string query = "SELECT * FROM Attendance";
            List<SqlParameter> parameters = new List<SqlParameter>();

            return DBUtility.SelectData(query, parameters);
        }

      }
  }
