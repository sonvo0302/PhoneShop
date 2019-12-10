using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PhoneShop.App_Code
{
    public class COMMON
    {
        string ketnoi = @"Data Source=DESKTOP-HDB5KQS\MSSQL14;Initial Catalog=QLBANHANG;Integrated Security=True";
        SqlConnection conn;
        public COMMON()
        {
            conn = new SqlConnection(ketnoi);
        }

        public void open()
        {

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }
        public void close()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        public DataTable getTable(string sql)
        {

            open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            da.Fill(dt);

            close();
            return dt;
        }
        public DataTable getTableStoreprocedure(String Nameprocedure, SqlParameter[] pr)
        {
            this.open();
            DataTable tb = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = Nameprocedure;
                cmd.Connection = this.conn;
                if (pr != null)
                    cmd.Parameters.AddRange(pr);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                adp.Fill(tb);
            }
            catch (SqlException ex)
            {
                throw ex;

            }
            finally
            {
                this.close();
            }
            return tb;

        }
        public static DataSet ThucThiStore_DataSet(string StoredProcedure, params SqlParameter[] Parameters)
        {
            //Khai báo cuỗi kết nối
            string ConnectionString =
            @"Data Source=DESKTOP-HDB5KQS\MSSQL14;Initial Catalog=QLBANHANG;Integrated Security=True";
            SqlConnection Conn = new SqlConnection(ConnectionString);
            SqlCommand Command = new SqlCommand(StoredProcedure, Conn);
            if (Parameters != null)
            {
                Command.Parameters.Clear();
                Command.Parameters.AddRange(Parameters);
            }
            DataSet ds = new DataSet(); SqlDataAdapter da =
            new SqlDataAdapter(StoredProcedure, Conn);
            Command.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = Command;
            try
            {
                //Mở kết nối
                Conn.Open();
                da.Fill(ds);
            }
            finally
            {
                // Đóng kết nối
                if (Conn.State == ConnectionState.Open)
                    Conn.Close();
                Conn.Dispose();
            }
            return ds;
        }

        public DataSet StoreToDataSet(int currPage, int recodperpage, int Pagesize)
        {
            DataSet dts = new DataSet();
            SqlParameter[] arrParam = {
                    new SqlParameter("@currPage", SqlDbType.Int),
                    new SqlParameter("@recodperpage", SqlDbType.Int),
                    new SqlParameter("@Pagesize", SqlDbType.Int)
            };
            arrParam[0].Value = currPage;
            arrParam[1].Value = recodperpage;
            arrParam[2].Value = Pagesize;
            return ThucThiStore_DataSet("tbSANPHAM_PhanTrang", arrParam);
        }
        public DataSet StoreToDataSet(int currPage, int recodperpage, int Pagesize, int MaDM)
        {
            DataSet dts = new DataSet();
            SqlParameter[] arrParam = {
                    new SqlParameter("@currPage", SqlDbType.Int),
                    new SqlParameter("@recodperpage", SqlDbType.Int),
                    new SqlParameter("@Pagesize", SqlDbType.Int),
                    new SqlParameter("@MaDM",SqlDbType.Int)
            };
            arrParam[0].Value = currPage;
            arrParam[1].Value = recodperpage;
            arrParam[2].Value = Pagesize;
            arrParam[3].Value = MaDM;
            return ThucThiStore_DataSet("tbSanPhamTheoDM_PhanTrang", arrParam);
        }
        public void ExecuteNonQuery(string sql)
        {
            open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            close();
        }
        public void ExecuteProcedure(string StoredProcedure, params SqlParameter[] Parameters)
        {
            this.open();
            object value = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = StoredProcedure;
                cmd.Connection = this.conn;
                if (Parameters != null)
                    cmd.Parameters.AddRange(Parameters);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;

            }
            finally
            {
                this.close();
            }

        }
        public object ExecuteScalarProcedure(string StoredProcedure, params SqlParameter[] Parameters)
        {

            this.open();
            object value = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = StoredProcedure;
                cmd.Connection = this.conn;
                if (Parameters != null)
                    cmd.Parameters.AddRange(Parameters);
                value = cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                throw ex;

            }
            finally
            {
                this.close();
            }
            return value;


        }
        public int ExecuteScalar(string sql)
        {
            open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            int kq = int.Parse(cmd.ExecuteScalar().ToString());
            close();
            return kq;
        }
        public string reader(string sql)
        {
            open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            sql = reader[0].ToString();
            close();
            return sql;
        }
    }
}