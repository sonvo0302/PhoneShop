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
    public partial class DanhSach1 : System.Web.UI.Page
    {
        COMMON cm = new COMMON();
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            String MADM = Request.QueryString.Get("DanhMuc_ID");
            String sql = null;

            if (MADM == null)
            {
                sql = "Select top(3) * from tbSANPHAM";
            }
            else
            {
                sql = "Select * from tbSANPHAM where DanhMuc_ID='" + MADM + "'";
            }
            DataList1.DataSource = cm.getTable(sql);
            DataList1.DataBind();
        }

      
    }
}