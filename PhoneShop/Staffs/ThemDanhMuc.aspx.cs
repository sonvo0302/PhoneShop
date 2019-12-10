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
    public partial class ThemDanhMuc : System.Web.UI.Page
    {
        COMMON cm = new COMMON();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            string sql = "Select * from tbDANHMUC where Parent_ID=0";
            DataTable dt = cm.getTable(sql);
            drp_danhmuccha.DataValueField = "DanhMuc_ID";
            drp_danhmuccha.DataTextField = "TenDanhMuc";
            drp_danhmuccha.DataSource = dt;
            drp_danhmuccha.DataBind();
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("QLDanhMuc.aspx");
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            string danhmuccon = txt_tendanhmuccon.Value.ToString();
            string sql = "Insert into tbDANHMUC(TenDanhMuc,Parent_ID)values(N'" + danhmuccon + "','"+drp_danhmuccha.SelectedValue.ToString()+"')";
            cm.ExecuteNonQuery(sql);
            Response.Redirect("QLDanhMuc.aspx");
        }
    }
}