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
    public partial class GioHang1 : System.Web.UI.Page
    {
        COMMON cs = new COMMON();
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.docDL();
        }

        private void docDL()
        {
            dt = (DataTable)Session["tbGiohang"];
          
            grdGIOHANG.DataSource = dt;

            double tong = 0;

            foreach (DataRow row1 in dt.Rows) {
                double thanhtien = Convert.ToDouble(row1["ThanhTien"]);
                row1["ThanhTien"] = Math.Round(thanhtien) + "";
                tong += thanhtien;
            }

            grdGIOHANG.DataBind();

        }
        protected void btnTRAHANG_Click(object sender, EventArgs e)
        {
         
        }

        protected void btnTHANHTOAN_Click(object sender, EventArgs e)
        {

        }

        protected void btn_sua_Click(object sender, EventArgs e)
        {
            
        }
        protected void grdGIOHANG_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.grdGIOHANG.PageIndex = e.NewPageIndex;
            this.grdGIOHANG.DataSource = (DataTable)Session["tbGiohang"];
            this.grdGIOHANG.DataBind();
        }
    }
}