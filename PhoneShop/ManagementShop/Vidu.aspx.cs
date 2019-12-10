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
    public partial class Vidu : System.Web.UI.Page
    {
        COMMON cm = new COMMON();
        DataTable tbModule = new DataTable();
        public String strMenu;
        protected void Page_Load(object sender, EventArgs e)
        {
            strMenu += "<a href ='UserGrant.aspx' class='list-group-item list-group-item-action list-group-item-success'>Phân quyền</a>";
            strMenu += "<a href ='QuanLyTaiKhoan.aspx' class='list-group-item list-group-item-action'>Quản lý tài khoản</a>";
            ServiceReference1.ServiceClient ws = new ServiceReference1.ServiceClient();
            ws.CreateTree();
            DataList1.DataSource = ws.getTableTree();
            DataList1.DataBind();
        }
    }
}