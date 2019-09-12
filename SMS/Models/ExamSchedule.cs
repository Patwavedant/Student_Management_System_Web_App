using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class ExamSchedule
    {
        public int ExamScheduleID;
        public int DepartmentID;
        public string Semester;
        public string ScheduleFile;
        public DateTime PublishDate;
        public Boolean IsActive;

        public int Insert()
        {
            string query = "INSERT INTO ExamSchedule VALUES(@DepartmentID, @Semester, @ScheduleFile, @PublishDate, @IsActive)";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@DepartmentID", this.DepartmentID));
            parameters.Add(new SqlParameter("@Semester", this.Semester));
            parameters.Add(new SqlParameter("@ScheduleFile", this.ScheduleFile));
            parameters.Add(new SqlParameter("@PublishDate", this.PublishDate));
            parameters.Add(new SqlParameter("@IsActive", this.IsActive));

            return DBUtility.ModifyData(query, parameters);
        }

        public int Update()
        {
            string query = "UPDATE ExamSchedule SET  DepartmentID =@DepartmentID, Semester = @Semester, ScheduleFile = @ScheduleFile, PublishDate = @PublishDate, IsActive =  @IsActive WHERE ExamScheduleID = @ExamScheduleID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@DepartmentID", this.DepartmentID));
            parameters.Add(new SqlParameter("@Semester", this.Semester));
            parameters.Add(new SqlParameter("@ScheduleFile", this.ScheduleFile));
            parameters.Add(new SqlParameter("@PublishDate", this.PublishDate));
            parameters.Add(new SqlParameter("@ExamScheduleID", this.ExamScheduleID));
            parameters.Add(new SqlParameter("@IsActive", this.IsActive));

            return DBUtility.ModifyData(query, parameters);
        }

        public int Delete()
        {
            string query = "DELETE ExamSchedule WHERE ExamScheduleID = @ExamScheduleID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ExamScheduleID", this.ExamScheduleID));

            return DBUtility.ModifyData(query, parameters);
        }

        public bool SelectByPK()
        {
            string query = "SELECT * FROM ExamSchedule WHERE ExamScheduleID = @ExamScheduleID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ExamScheduleID", this.ExamScheduleID));

            DataTable dt = DBUtility.SelectData(query, parameters);

            if (dt.Rows.Count > 0)
            {
                this.DepartmentID = Convert.ToInt32(dt.Rows[0]["DepartmentID"]);
                this.Semester = dt.Rows[0]["Semester"].ToString();
                this.ScheduleFile = dt.Rows[0]["ScheduleFile"].ToString();
                this.PublishDate = Convert.ToDateTime(dt.Rows[0]["PublishDate"].ToString());
                this.IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"].ToString());

                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable SelectAll()
        {
            string query = "SELECT * FROM ExamSchedule";
            List<SqlParameter> parameters = new List<SqlParameter>();

            return DBUtility.SelectData(query, parameters);
        }

        public DataTable Search(string Semester)
        {
            string query = @"SELECT * 
                            FROM ExamSchedule
                            INNER JOIN Department ON Department.DepartmentID = ExamSchedule.DepartmentID
                            WHERE Semester = @Semester";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Semester", Semester));

            return DBUtility.SelectData(query, parameters);

        }

        public DataTable SelectActive()
        {
            string query = "SELECT * FROM ExamSchedule WHERE IsActive = 1";
            List<SqlParameter> parameters = new List<SqlParameter>();

            return DBUtility.SelectData(query, parameters);
        }

        public DataTable SelectActiveByDepartmentSemester(int DepartmentID, string Semester)
        {
            string query = @"SELECT es.*, D.DName 
                                    FROM ExamSchedule es
                                        INNER JOIN Department D ON D.DepartmentID = es.DepartmentID
                           WHERE IsActive = 1 AND D.DepartmentID = @DepartmentID AND Semester = @Semester";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@DepartmentID", DepartmentID));
            parameters.Add(new SqlParameter("@Semester", Semester));

            return DBUtility.SelectData(query, parameters);
        }

        public DataTable SelectInActive()
        {
            string query = "SELECT * FROM ExamSchedule WHERE IsActive = 0";
            List<SqlParameter> parameters = new List<SqlParameter>();

            return DBUtility.SelectData(query, parameters);
        }

    }
}
