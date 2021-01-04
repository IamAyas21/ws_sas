using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WS_SAS.Logic
{
    public class Common
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            return conn;
        }
        public static DataTable ExcuteQuery(string Query)
        {
            SqlConnection conn = GetConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader read;

            cmd.CommandText = Query;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                read = cmd.ExecuteReader();
                dt.Load(read);
            }
            catch
            { }
            finally
            {
                try
                {
                    conn.Close();
                }
                catch { }
            }
            return dt;
        }
        public static void ExcuteNonQuery(string Query)
        {
            SqlConnection conn = GetConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader read;

            cmd.CommandText = Query;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                read = cmd.ExecuteReader();
                dt.Load(read);
            }
            catch
            { }
            finally
            {
                try
                {
                    conn.Close();
                }
                catch { }
            }
        }
    }
}