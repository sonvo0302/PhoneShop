using PhoneShop.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhoneShop
{
    public partial class DangKy : System.Web.UI.Page
    {
        COMMON cs = new COMMON();
        DataTable dt;
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                string Tendangnhap = tendangnhap.Value.ToString();
                string Matkhau = MaHoaMD5.Encryptdata(matkhau.Value.ToString());
                string Xacnhan_matkhau = MaHoaMD5.Encryptdata(xacnhan_matkhau.Value.ToString());
                string Hoten = txt_hoten.Value.ToString();
                string sql = "Select * from tbLOGIN";
                dt = cs.getTable(sql);
                string ten = "";
                foreach (DataRow row in dt.Rows)
                {
                    ten += row["UserName"].ToString();
                }
                if (Tendangnhap == ten)
                {
                    string script = "alert(\"Đã có tên đăng nhập này!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    
                }
                else
                {
                    
                    if (Matkhau.Equals(Xacnhan_matkhau) == false)
                    {
                        string script = "alert(\"Nhập sai mật khẩu ở xác nhận mật khẩu!\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                        return;
                    }
                    else
                    {
                        string q = "Insert into tbLOGIN(UserName,Password,Group_ID) values('" + Tendangnhap + "','" + Matkhau + "',1)";
                        cs.ExecuteNonQuery(q);

                        string data = "Select * from tbLOGIN where UserName='" + Tendangnhap + "' and Password='" + Matkhau + "'";
                        DataTable tb = cs.getTable(data);
                        string user_id = "";
                        foreach (DataRow row in tb.Rows)
                        {
                            user_id = row["User_ID"].ToString();
                        }
                        string q1 = "Insert into tbTHONGTINCANHAN(KH_ID,HoTen)values('" + user_id + "',N'" + Hoten + "')";
                        cs.ExecuteNonQuery(q1);
                        string script = "alert(\"Mời bạn đăng nhập!\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);

                        Response.Redirect("DangNhap.aspx");

                    }
                }


            }
            catch(SqlException ex)
            {
               
                throw ex;
                
              
            }
        }
    }
}