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
    public partial class QLyHoaDon : System.Web.UI.Page
    {
        COMMON cm = new COMMON();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sql = "Select * from tbHOADON";
                DataTable dt = new DataTable();
                dt = cm.getTable(sql);
                DataList1.DataSource = dt;
                DataList1.DataBind();

                double tong = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    double thanhtien = double.Parse(dt.Rows[i]["TongTien"].ToString());
                    tong += thanhtien;
                }
                this.lbl_ThanhTien.Text = "Tổng thành tiền: " + tong + " VNĐ";
            }

        }   
    }
}