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
    public partial class QLDanhMuc : System.Web.UI.Page
    {
        COMMON cm = new COMMON();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            docDL();
        }


        void docDL()
        {
            string sql = "Select * from tbDANHMUC";
            DataTable dt = cm.getTable(sql);
            DataList1.DataSource = cm.getTable(sql);
            DataList1.DataBind();
        }

        protected void btn_themDMCha_Click(object sender, EventArgs e)
        {
            string DMCha = danhmuccha.Value.ToString();
            string sql = "Insert into tbDANHMUC(TenDanhMuc,Parent_ID) values(N'" + DMCha + "',0)";
            cm.ExecuteNonQuery(sql);
            docDL();
        }
        //protected void btn_sua_danhmuc_Click(object sender, EventArgs e)
        //{
        //    string madm = ((LinkButton)sender).CommandArgument;
        //    Context.Items["madm"] = madm;
        //    Response.Redirect("SuaDanhMuc.aspx");
        //}

        //protected void btn_xoa_dm_Click(object sender, EventArgs e)
        //{
        //    string madm = ((LinkButton)sender).CommandArgument;
        //    string data_sp = "Delete from tbSANPHAM where DanhMuc_ID='" + madm + "'";
        //    cm.ExecuteNonQuery(data_sp);
        //    string sql = "Delete from tbDANHMUC where DanhMuc_ID='" + madm + "'";
        //    cm.ExecuteNonQuery(sql);
        //    docDL();
        //}
    }
}