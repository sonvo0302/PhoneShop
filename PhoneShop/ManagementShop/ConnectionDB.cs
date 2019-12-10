using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PhoneShop.ManagermentShop
{
    public class ConnectionDB
    {
        public static string connStr = "sqlcn";
        static SqlConnection conn;
        static SqlCommand cmd;
        static DataTable dt = new DataTable();
       
        public static DataTable ExecuteCommand(string Text, CommandType CmdType)
        {

            try
            {
                string ketnoi = @"Data Source=DESKTOP-HDB5KQS\MSSQL14;Initial Catalog=QLBANHANG;Integrated Security=True";
                conn = new SqlConnection(ketnoi);
                SqlDataReader dr;

                //Opening Connection  
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                cmd = new SqlCommand(Text, conn);
                cmd.CommandType = CmdType; //Assign the SqlString Type to Command Object  

                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                //Loading all data in a datatable from datareader  
                dt.Load(dr);
                //Closing the connection  
                conn.Close();
                return dt;
            }
            catch
            {
                throw;
            }

        }
    }
}  
