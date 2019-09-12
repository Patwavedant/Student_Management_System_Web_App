using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class Student
    {
            public int StudentID;
            public string Name;
            public string Email;
            public string Phone;
            public string ParentPhone;
            public string Semester;
            public string Class;
            public string Username;
            public string Password;
            public int DepartmentID;
            public Boolean IsActive;

        public int Insert()
        {
            string query = "INSERT INTO Student VALUES(@Name, @Email, @Phone, @ParentPhone, @Semester, @Class, @Username, @Password, @DepartmentID, @IsActive )";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Name", this.Name));
            parameters.Add(new SqlParameter("@Email", this.Email));
            parameters.Add(new SqlParameter("@Phone", this.Phone));
            parameters.Add(new SqlParameter("@ParentPhone", this.ParentPhone));
            parameters.Add(new SqlParameter("@Semester", this.Semester));
            parameters.Add(new SqlParameter("@Class", this.Class));
            parameters.Add(new SqlParameter("@Username", this.Username));
            parameters.Add(new SqlParameter("@Password", this.Password));            
            parameters.Add(new SqlParameter("@DepartmentID", this.DepartmentID));
            parameters.Add(new SqlParameter("@IsActive", this.IsActive));

            return DBUtility.ModifyData(query, parameters);
        }

        public int Update()
        {
            string query = "UPDATE Student SET Name = @Name, Email = @Email, Phone = @Phone, ParentPhone = @ParentPhone, Semester = @Semester, Class = @Class, Username = @Username, Password = @Password, DepartmentID = @DepartmentID, IsActive = @IsActive WHERE StudentID = @StudentID";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Name", this.Name));
            parameters.Add(new SqlParameter("@Email", this.Email));
            parameters.Add(new SqlParameter("@Phone", this.Phone));
            parameters.Add(new SqlParameter("@ParentPhone", this.ParentPhone));
            parameters.Add(new SqlParameter("@Semester", this.Semester));
            parameters.Add(new SqlParameter("@Class", this.Class));
            parameters.Add(new SqlParameter("@Username", this.Username));
            parameters.Add(new SqlParameter("@Password", this.Password));            
            parameters.Add(new SqlParameter("@DepartmentID", this.DepartmentID));
            parameters.Add(new SqlParameter("@IsActive", this.IsActive));
            parameters.Add(new SqlParameter("@StudentID", this.StudentID));

            return DBUtility.ModifyData(query, parameters);
        }

        public int Delete()
        {
            string query = "DELETE Student WHERE StudentID = @StudentID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@StudentID", this.StudentID));

            return DBUtility.ModifyData(query, parameters);
        }

        public bool SelectByPK()
        {
            string query = "SELECT * FROM Student WHERE StudentID = @StudentID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@StudentID", this.StudentID));

            DataTable dt = DBUtility.SelectData(query, parameters);

            if (dt.Rows.Count > 0)
            {
                this.Name = dt.Rows[0]["Name"].ToString();
                this.Email = dt.Rows[0]["Email"].ToString();
                this.Phone =dt.Rows[0]["Phone"].ToString();
                this.ParentPhone = dt.Rows[0]["ParentPhone"].ToString();
                this.Semester = dt.Rows[0]["Semester"].ToString();
                this.Class = dt.Rows[0]["Class"].ToString();
                this.Username = dt.Rows[0]["Username"].ToString();
                this.Password = dt.Rows[0]["Password"].ToString();               
                this.DepartmentID = Convert.ToInt32(dt.Rows[0]["DepartmentID"]);
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
            string query = "SELECT * FROM Student";
            List<SqlParameter> parameters = new List<SqlParameter>();

            return DBUtility.SelectData(query, parameters);
        }

        public DataTable Search(string Name)
        {
            string query = @"SELECT * 
                            FROM Student
                                LEFT JOIN Department ON Department.DepartmentID = Student.DepartmentID
                            WHERE Name LIKE @Name + '%'" + ""; 
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Name", Name));

            return DBUtility.SelectData(query, parameters);

        }

        public bool Authenticate()
        {
            string query = "SELECT * FROM Student WHERE Username = @Username AND Password = @Password";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Username", this.Username));
            parameters.Add(new SqlParameter("@Password", this.Password));

            DataTable dt = DBUtility.SelectData(query, parameters);

            if (dt.Rows.Count > 0)
            {
                this.Name = dt.Rows[0]["Name"].ToString();
                this.Email = dt.Rows[0]["Email"].ToString();
                this.Phone =dt.Rows[0]["Phone"].ToString();
                this.ParentPhone = dt.Rows[0]["ParentPhone"].ToString();
                this.Semester = dt.Rows[0]["Semester"].ToString();
                this.Class = dt.Rows[0]["Class"].ToString();
                this.Username = dt.Rows[0]["Username"].ToString();
                this.Password = dt.Rows[0]["Password"].ToString();                
                this.DepartmentID = Convert.ToInt32(dt.Rows[0]["DepartmentID"]);
                this.IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"].ToString());

                return true;
            }
            else
            {
                return false;

            }
        }

        public DataTable GetProfile()
        {
            string query = @"SELECT S.*, D.DName
                            FROM Student S
                                INNER JOIN Department D ON D.DepartmentID = S.DepartmentID
                            WHERE Username = @Username AND Password = @Password";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Username", this.Username));
            parameters.Add(new SqlParameter("@Password", this.Password));

            return DBUtility.SelectData(query, parameters);
        }
      }
    }
  
