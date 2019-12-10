using PhoneShop.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhoneShop.ManagementShop
{
    public partial class QLyTKhoan : System.Web.UI.Page
    {
        COMMON cm = new COMMON();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            string username = Request.Cookies["UserName"].Value;
            string password = Request.Cookies["Password"].Value;
            string sql = "Select User_ID,UserName,Password,Group_ID from tbLOGIN where UserName!='" + username + "'";
            GridView1.DataSource = cm.getTable(sql);
            GridView1.DataBind();
        }

        protected void phanquyen_Click(object sender, EventArgs e)
        {
            Server.Transfer("PhanQuyen.aspx");
        }

        protected void qltaikhoan_Click(object sender, EventArgs e)
        {
            Server.Transfer("QLTaiKhoan.aspx");
        }

        protected void btn_xoa_Click(object sender, EventArgs e)
        {

        }

        protected void btn_sua_Click(object sender, EventArgs e)
        {

        }
    }
}