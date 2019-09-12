using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class DBUtility
    {
        public static int ModifyData(string query, List<SqlParameter> parameters) //INSERT UPDATE DELETE
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='|DataDirectory|SMS.mdf';Integrated Security=True";

            SqlCommand command = new SqlCommand();
            command.Connection = conn;

            command.CommandText = query;

            command.Parameters.AddRange(parameters.ToArray());

            conn.Open();
            int count = command.ExecuteNonQuery();
            conn.Close();

            return count;
        }

        public static System.Data.DataTable SelectData(string query, List<SqlParameter> parameters) //SELECT
        {

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='|DataDirectory|SMS.mdf';Integrated Security=True";

            SqlCommand command = new SqlCommand();
            command.Connection = conn;

            command.CommandText = query;

            command.Parameters.AddRange(parameters.ToArray());

            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;

            conn.Open();
            adapter.Fill(dt);
            conn.Close();

            return dt;
        }
    }
}