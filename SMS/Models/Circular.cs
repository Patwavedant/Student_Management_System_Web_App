using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class Circular
    {
        public int CircularID;
        public string Title;
        public string CFile;
        public DateTime PublishDate;
        public Boolean IsActive;

        public int Insert()
        {
            string query = "INSERT INTO  Circular VALUES(@Title, @CFile, @PublishDate, @IsActive)";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Title", this.Title));
            parameters.Add(new SqlParameter("@CFile", this.CFile));
            parameters.Add(new SqlParameter("@PublishDate", this.PublishDate));
            parameters.Add(new SqlParameter("@IsActive", this.IsActive));
           

            return DBUtility.ModifyData(query, parameters);
        }

        public int Update()
        {
            string query = "UPDATE Circular SET  Title = @Title, CFile = @CFile, PublishDate = @PublishDate, IsActive = @IsActive WHERE CircularID = @CircularID";
            List<SqlParameter> parameters = new List<SqlParameter>();           
            parameters.Add(new SqlParameter("@Title", this.Title));
            parameters.Add(new SqlParameter("@CFile", this.CFile));
            parameters.Add(new SqlParameter("@CircularID", this.CircularID));
            parameters.Add(new SqlParameter("@PublishDate", this.PublishDate));
            
            parameters.Add(new SqlParameter("@IsActive", this.IsActive));

            return DBUtility.ModifyData(query, parameters);
        }

        public int Delete()
        {
            string query = "DELETE Circular WHERE CircularID = @CircularID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@CircularID", this.CircularID));

            return DBUtility.ModifyData(query, parameters);
        }

        public bool SelectByPK()
        {
            string query = "SELECT * FROM Circular WHERE CircularID = @CircularID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@CircularID", this.CircularID));

            DataTable dt = DBUtility.SelectData(query, parameters);

            if (dt.Rows.Count > 0)
            {
                this.Title = dt.Rows[0]["Title"].ToString();
                this.CFile = dt.Rows[0]["CFile"].ToString();
                this.PublishDate = Convert.ToDateTime(dt.Rows[0]["PublishDate"].ToString());
                this.CircularID = Convert.ToInt32(dt.Rows[0]["CircularID"]);
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
            string query = "SELECT * FROM Circular";
            List<SqlParameter> parameters = new List<SqlParameter>();

            return DBUtility.SelectData(query, parameters);
        }

        public DataTable Search(string Semester)
        {
            string query = @"SELECT * 
                            FROM Circular
                            LEFT JOIN Department ON Department.DepartmentID = Circular.DepartmentID
                            WHERE Semester = @Semester";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Semester", Semester));

            return DBUtility.SelectData(query, parameters);

        }

        public DataTable SelectActive()
        {
            string query = "SELECT * FROM Circular WHERE IsActive = 1";
            List<SqlParameter> parameters = new List<SqlParameter>();

            return DBUtility.SelectData(query, parameters);
        }

        public DataTable SelectInActive()
        {
            string query = "SELECT * FROM Circular WHERE IsActive = 0";
            List<SqlParameter> parameters = new List<SqlParameter>();

            return DBUtility.SelectData(query, parameters);
        }
    }
}
    
    