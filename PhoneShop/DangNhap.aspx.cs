using PhoneShop.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhoneShop
{
    public partial class DangNhap : System.Web.UI.Page
    {
        COMMON cs = new COMMON();
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

       

        protected void Button1_Click(object sender, EventArgs e)
        {
            string userName = username.Value.ToString();
            string Password = MaHoaMD5.Encryptdata(password.Value.ToString());
            string sql = "Select * from tbLOGIN where UserName = '" + userName + "' and Password='" +Password + "'";
            dt = cs.getTable(sql);
         
            if (dt.Rows.Count != 0)
            {
                Response.Cookies["UserName"].Value = userName;
                Response.Cookies["Password"].Value = Password;
                Session["user"] = userName.ToString();
                Response.Redirect("DanhSachMatHang.aspx");
            }
            else
            {
                string script = "alert(\"Lỗi đăng nhập!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
        }
    }
}