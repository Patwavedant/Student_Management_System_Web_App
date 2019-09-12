using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class TimeTable
    {
        public int TimeTableID;
        public int DepartmentID;
        public string Semester;
        public string Class;
        public string TTFile;
        public Boolean IsActive;

        public int Insert()
        {
            string query = "INSERT INTO TimeTable VALUES(@DepartmentID, @Semester, @Class, @TTFile, @IsActive)";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@DepartmentID", this.DepartmentID));
            parameters.Add(new SqlParameter("@Semester", this.Semester));
            parameters.Add(new SqlParameter("@Class", this.Class));
            parameters.Add(new SqlParameter("@TTFile", this.TTFile));
            parameters.Add(new SqlParameter("@IsActive", this.IsActive));

            return DBUtility.ModifyData(query, parameters);
        }

        public int Update()
        {
            string query = "UPDATE TimeTable SET  DepartmentID =@DepartmentID, Semester = @Semester, Class = @Class, TTFile = @TTFile, IsActive = @IsActive WHERE TimeTableID = @TimeTableID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@DepartmentID", this.DepartmentID));
            parameters.Add(new SqlParameter("@Semester", this.Semester));
            parameters.Add(new SqlParameter("@Class", this.Class));
            parameters.Add(new SqlParameter("@TTFile", this.TTFile));
            parameters.Add(new SqlParameter("@TimeTableID", this.TimeTableID));
            parameters.Add(new SqlParameter("@IsActive", this.IsActive));


            return DBUtility.ModifyData(query, parameters);
        }

        public int Delete()
        {
            string query = "DELETE TimeTable WHERE TimeTableID = @TimeTableID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@TimeTableID", this.TimeTableID));

            return DBUtility.ModifyData(query, parameters);
        }

        public bool SelectByPK()
        {
            string query = "SELECT * FROM TimeTable WHERE TimeTableID = @TimeTableID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@TimeTableID", this.TimeTableID));

            DataTable dt = DBUtility.SelectData(query, parameters);

            if (dt.Rows.Count > 0)
            {
                this.DepartmentID = Convert.ToInt32(dt.Rows[0]["DepartmentID"]);
                this.Semester =dt.Rows[0]["Semester"].ToString();
                this.Class = dt.Rows[0]["Class"].ToString();
                this.TTFile = dt.Rows[0]["TTFile"].ToString();
                this.TimeTableID = Convert.ToInt32(dt.Rows[0]["TimeTableID"]);
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
            string query = "SELECT * FROM TimeTable";
            List<SqlParameter> parameters = new List<SqlParameter>();

            return DBUtility.SelectData(query, parameters);
        }

        public DataTable Search(string Semester)
        {
            string query = @"SELECT * 
                            FROM TimeTable
                            INNER JOIN Department ON Department.DepartmentID = TimeTable.DepartmentID
                            WHERE Semester = @Semester";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Semester", Semester));

            return DBUtility.SelectData(query, parameters);

        }


        public DataTable SelectActive()
        {
            string query = "SELECT * FROM TimeTable WHERE IsActive = 1";
            List<SqlParameter> parameters = new List<SqlParameter>();

            return DBUtility.SelectData(query, parameters);
        }

        public DataTable SelectActiveByDepartmentSemester(int DepartmentID, string Semester)
        {
            string query = @"SELECT tt. *, D.DName 
                                    FROM TimeTable tt
                                        INNER JOIN Department D ON D.DepartmentID = tt.DepartmentID
                           WHERE IsActive = 1 AND DepartmentID = @DepartmentID AND Semester = @Semester";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@DepartmentID", DepartmentID));
            parameters.Add(new SqlParameter("@Semester", Semester));

            return DBUtility.SelectData(query, parameters);
        }

        public DataTable SelectInActive()
        {
            string query = "SELECT * FROM TimeTable WHERE IsActive = 0";
            List<SqlParameter> parameters = new List<SqlParameter>();

            return DBUtility.SelectData(query, parameters);
        }
    }
}
    
    
