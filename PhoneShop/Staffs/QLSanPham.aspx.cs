using PhoneShop.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhoneShop.Staffs
{
    public partial class QLSanPham : System.Web.UI.Page
    {
        COMMON cm = new COMMON();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            docDL_Spham();
            docMau();

        }

        void docDL_Spham()
        {
            string data_sp = "Select * from view_sanpham";
            DataList1.DataSource = cm.getTable(data_sp);
            DataList1.DataBind();
        }
        void docMau()
        {
            string data_mau = "Select * from tbMAUSP";
            DataList3.DataSource = cm.getTable(data_mau);

            DataList3.DataBind();
        }
        protected void btn_sua_sanpham_Click(object sender, EventArgs e)
        {
            string masp = ((LinkButton)sender).CommandArgument;
            Context.Items["masp"] = masp;
            Server.Transfer("SuaSanPham.aspx");
        }

        protected void btn_xoa_sp_Click(object sender, EventArgs e)
        {
            string masp = ((LinkButton)sender).CommandArgument;
            string sql = "Delete from tbSANPHAM where SanPham_ID='" + masp + "'";
            cm.ExecuteNonQuery(sql);
            docDL_Spham();
        }
    }
}