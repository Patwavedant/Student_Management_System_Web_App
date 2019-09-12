using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class Staff
    {
        public int StaffID;
        public string SName;
        public string Email;
        public string Phone;
        public string Username;
        public string Password;
        public int DepartmentID;
        public Boolean IsActive;
        public string StaffType;


        public int Insert()
        {
            string query = "INSERT Into Staff VALUES(@SName, @Email, @Phone, @Username, @Password, @DepartmentID, @IsActive, @StaffType)";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@SName", this.SName));
            parameters.Add(new SqlParameter("@Email", this.Email));
            parameters.Add(new SqlParameter("@Phone", this.Phone));
            parameters.Add(new SqlParameter("@Username", this.Username));
            parameters.Add(new SqlParameter("@Password", this.Password));
            parameters.Add(new SqlParameter("@DepartmentID", this.DepartmentID));
            parameters.Add(new SqlParameter("@IsActive", this.IsActive));
            parameters.Add(new SqlParameter("@StaffType", this.StaffType));

            return DBUtility.ModifyData(query, parameters);
        }

        public int Update()
        {
            string query = "UPDATE Staff SET SName = @SName, Email = @Email, Phone = @Phone, Username = @Username, Password = @Password, DepartmentID = @DepartmentID, IsActive = @IsActive, StaffType = @StaffType WHERE StaffID = @StaffID";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@SName", this.SName));
            parameters.Add(new SqlParameter("@Email", this.Email));
            parameters.Add(new SqlParameter("@Phone", this.Phone));
            parameters.Add(new SqlParameter("@Username", this.Username));
            parameters.Add(new SqlParameter("@Password", this.Password));
            parameters.Add(new SqlParameter("@DepartmentID", this.DepartmentID));
            parameters.Add(new SqlParameter("@IsActive", this.IsActive));
            parameters.Add(new SqlParameter("@StaffType", this.StaffType));
            parameters.Add(new SqlParameter("@StaffID", this.StaffID));


            return DBUtility.ModifyData(query, parameters);
        }

        public int Delete()
        {
            string query = "DELETE Staff WHERE StaffID = @StaffID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@StaffID", this.StaffID));

            return DBUtility.ModifyData(query, parameters);
        }

        public bool SelectByPK()
        {
            string query = "SELECT * FROM Staff WHERE StaffID = @StaffID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@StaffID", this.StaffID));

            DataTable dt = DBUtility.SelectData(query, parameters);

            if (dt.Rows.Count > 0)
            {
                this.SName = dt.Rows[0]["SName"].ToString();
                this.Email = dt.Rows[0]["Email"].ToString();
                this.Phone = dt.Rows[0]["Phone"].ToString();
                this.Username = dt.Rows[0]["Username"].ToString();
                this.Password = dt.Rows[0]["Password"].ToString();
                this.DepartmentID = Convert.ToInt32(dt.Rows[0]["DepartmentID"]);
                this.IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"].ToString());
                this.StaffType = dt.Rows[0]["StaffType"].ToString();


                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable SelectAll()
        {
            string query = "SELECT * FROM Staff";
            List<SqlParameter> parameters = new List<SqlParameter>();

            return DBUtility.SelectData(query, parameters);
        }

        public DataTable Search(string SName)
        {
            string query = @"SELECT * 
                            FROM Staff
                            LEFT JOIN Department ON Department.DepartmentID = Staff.DepartmentID
                            WHERE SName LIKE @SName + '%'" + "";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@SName", SName));

            return DBUtility.SelectData(query, parameters);

        }

        public DataTable SelectByDepartmentID(int DepartmentID)
        {
            String query = @"Select * 
                         from Staff
                         where @DepartmentID = DepartmentID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@DepartmentID", DepartmentID));

            return DBUtility.SelectData(query, parameters);
        }

        public bool Authenticate()
        {
            string query = "SELECT * FROM Staff WHERE Username = @Username AND Password = @Password";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Username", this.Username));
            parameters.Add(new SqlParameter("@Password", this.Password));

            DataTable dt = DBUtility.SelectData(query, parameters);

            if (dt.Rows.Count > 0)
            {
                this.SName = dt.Rows[0]["SName"].ToString();
                this.Email = dt.Rows[0]["Email"].ToString();
                this.Phone = dt.Rows[0]["Phone"].ToString();
                this.Username = dt.Rows[0]["Username"].ToString();
                this.Password = dt.Rows[0]["Password"].ToString();
                this.DepartmentID = Convert.ToInt32(dt.Rows[0]["DepartmentID"]);
                this.IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"].ToString());
                this.StaffType = dt.Rows[0]["StaffType"].ToString();

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}