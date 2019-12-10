using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhoneShop.ManagementShop
{
    public partial class HomePageAdmin : System.Web.UI.Page
    {
        public String strLogin;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void phanquyen_Click(object sender, EventArgs e)
        {
            Server.Transfer("PhanQuyen.aspx");
        }

        protected void qltaikhoan_Click(object sender, EventArgs e)
        {
            Server.Transfer("QuanLyTaiKhoan.aspx");
        }
    }
}