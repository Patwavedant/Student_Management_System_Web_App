using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class FAQ
    {
        public int FAQID;
        public string Question;
        public string Answer;

        public int Insert()
        {
            string query = "INSERT INTO  FAQ VALUES(@Question,@Answer)";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Question", this.Question));
            parameters.Add(new SqlParameter("@Answer", this.Answer));

            return DBUtility.ModifyData(query, parameters);

        }

        public int Update()
        {
            string query = "UPDATE FAQ SET Question = @Question, Answer = @Answer WHERE FAQID = @FAQID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Question", this.Question));
            parameters.Add(new SqlParameter("@Answer", this.Answer));
            parameters.Add(new SqlParameter("@FAQID", this.FAQID));

            return DBUtility.ModifyData(query, parameters);

        }
        public int Delete()
        {
            string query = "DELETE FAQ WHERE FAQID = @FAQID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@FAQID", this.FAQID));

            return DBUtility.ModifyData(query, parameters);
        }
        public bool SelectByPK()
        {
            string query = "SELECT * FROM FAQ WHERE FAQID = @FAQID";
            List<SqlParameter> paramaters = new List<SqlParameter>();
            paramaters.Add(new SqlParameter("@FAQID", this.FAQID));

            DataTable dt = DBUtility.SelectData(query, paramaters);

            if (dt.Rows.Count > 0)
            {
                this.Question = dt.Rows[0]["Question"].ToString();
                this.Answer = dt.Rows[0]["Answer"].ToString();
                this.FAQID = Convert.ToInt32(dt.Rows[0]["FAQID"]);

                return true;
            }
            else
            {
                return false;
            }
        }
        
        public DataTable SelectAll()
        {
            string query = "SELECT * FROM FAQ";
            List<SqlParameter> parameters = new List<SqlParameter>();
            return DBUtility.SelectData(query, parameters);
        }
    }
}
    
