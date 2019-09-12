using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class Department
    {
        public int DepartmentID;
        public string DName;
        public int HeadID;
        
        

        public int Insert()
        {
            string query = "INSERT INTO  Department VALUES(@DName,@HeadID)";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@DName", this.DName));
            parameters.Add(new SqlParameter("@HeadID", this.HeadID));

            return DBUtility.ModifyData(query, parameters);
        }
        public int Update()
        {
            string query = "UPDATE Department SET DName = @DName, HeadID = @HeadID WHERE DepartmentID = @DepartmentID";

            List<SqlParameter> parameters = new List<SqlParameter>();            
            parameters.Add(new SqlParameter("@DName", this.DName));
            parameters.Add(new SqlParameter("@HeadID", this.HeadID));
            parameters.Add(new SqlParameter("@DepartmentID", this.DepartmentID));




            return DBUtility.ModifyData(query, parameters);

        }
        public int Delete()
        {
            string query = "DELETE Department WHERE DepartmentID = @DepartmentID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@DepartmentID", this.DepartmentID));

            return DBUtility.ModifyData(query, parameters);
        }
        public bool SelectByPK()
        {
            string query = "SELECT * FROM Department WHERE DepartmentID = @DepartmentID";
            List<SqlParameter> paramaters = new List<SqlParameter>();
            paramaters.Add(new SqlParameter("@DepartmentID", this.DepartmentID));
            DataTable dt = DBUtility.SelectData(query, paramaters);

            if(dt.Rows.Count > 0)
            {
                 this.DName = dt.Rows[0]["DName"].ToString();
                 this.HeadID =  Convert.ToInt32(dt.Rows[0]["HeadID"]);                

                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable SelectAll()
        {
            string query = @"SELECT * 
                            FROM Department
                            LEFT JOIN Staff ON Staff.StaffID = Department.HeadID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            return DBUtility.SelectData(query, parameters);
        }

        public DataTable Search(string DName)
        {
            string query = @"SELECT * 
                            FROM Department
                            LEFT JOIN Staff ON Staff.StaffID = Department.StaffID
                            WHERE DName LIKE @DName  + '%'" + "";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@DName", DName));

            return DBUtility.SelectData(query, parameters);

        }

    }
}


