using PhoneShop.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhoneShop.Staffs
{
    public partial class QuanLyThongTinKhachHang : System.Web.UI.Page
    {
        COMMON cm = new COMMON();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            string sql = "Select * from view_khachhang where Group_ID = 1";
            DataTable dt = new DataTable();
            dt = cm.getTable(sql);
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }

    }
}