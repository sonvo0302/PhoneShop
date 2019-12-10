using PhoneShop.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhoneShop.ManagementShop
{
    public partial class AdminArea : System.Web.UI.MasterPage
    {
        COMMON cm = new COMMON();
        public String strLogin;
        protected void Page_Load(object sender, EventArgs e)
        {
         
                    string userName = Request.Cookies["UserName"].Value;
                    string Password = Request.Cookies["Password"].Value;
                    string sql = "Select * from View_3 where UserName = '" + userName + "' and Password='" + Password + "'";
                    DataTable tb = cm.getTable(sql);
                    foreach (DataRow row in tb.Rows)
                    {
                            dangnhap.InnerText = row["HoTen"].ToString();
                    }
                 
                
   
        }

  
        protected void btn_trangchusp_Click(object sender, EventArgs e)
        {
            Server.Transfer("../DangXuat.aspx");
        }



        //protected void btn_dangnhap_Click(object sender, EventArgs e)
        //{
        //    string userName = user_name.Value.ToString();
        //    string Password = MaHoaMD5.Encryptdata(password_c.Value.ToString());
        //    string sql = "Select * from View_3 where UserName = '" + userName + "' and Password='" + Password + "'";
        //    DataTable tb = cm.getTable(sql);
        //    int group_id = 0;
        //    foreach (DataRow row in tb.Rows)
        //    {
        //        group_id = Convert.ToInt16(row["Group_ID"].ToString());

        //    }
        //    if (tb.Rows.Count != 0)
        //    {
        //        Response.Cookies["UserName"].Value = userName;
        //        Response.Cookies["Password"].Value = Password;
        //        Session["user"] = userName.ToString();

        //        if (group_id != 2)
        //        {
        //            string script = "alert(\"Không thuộc nhóm admin!\");";
        //            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
        //            if (Request.Cookies["UserName"] != null)
        //            {
        //                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
        //                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
        //            }

        //            Response.Redirect("HomePageAdmin.aspx", true);
        //        }
        //        else
        //        {
        //            foreach (DataRow row in tb.Rows)
        //            {
        //                strLogin += "<li class='nav-item'><a class='nav-link'>" + row["HoTen"].ToString() + "</a></li>";
        //            }
        //            strLogin += "<li class='nav-item'><a class='nav-link' href='../DangXuat.aspx'>Đăng xuất</a></li>";
        //        }

        //    }
        //    else
        //    {
        //        string script = "alert(\"Sai đăng nhập!\");";
        //        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
        //    }
        //}
    }
}