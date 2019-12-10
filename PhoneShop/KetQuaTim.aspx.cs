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
    public partial class KetQuaTim : System.Web.UI.Page
    {
        COMMON cm = new COMMON();
        protected void Page_Load(object sender, EventArgs e)
        {
            int page = int.Parse("0" + Request.QueryString["page"]);
            if (page == 0) page = 1;
            if (IsPostBack) return;

            string sten = Request.QueryString["TenSanPham"].ToString();


            string sql = "select * from tbSANPHAM where TenSanPham like N'%" + sten + "%'";

            DataList1.DataSource = cm.getTable(sql);

            DataList1.DataBind();

        }

    }

}
