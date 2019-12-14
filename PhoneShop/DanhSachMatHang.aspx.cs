using PhoneShop.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhoneShop
{
    public partial class DanhSachMatHang : System.Web.UI.Page
    {
        COMMON cm = new COMMON();
        DataTable dt= new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            int page = int.Parse("0" + Request.QueryString["page"]);
            if (page == 0) page = 1;
            if (!IsPostBack)
            {
                string MADM = Request.QueryString.Get("MADM");
                
                DataTable dt = new DataTable();
                //string sql="Select * from tbDANHMUC where DanhMuc_ID='"++"'"
                //string parent_id = "";


                if (MADM == null)
                {
                    // sql = "Select * from tbSANPHAM";
                    NapDuLieu1(page, 20, 4);
                }
                else
                {

                    SqlParameter[] pr = { new SqlParameter("@MaDM", MADM) };

                        dt = cm.getTableStoreprocedure("getSanPham", pr);                       

                    DataList1.DataSource = dt;
                    DataList1.DataBind();
                    if (dt.Rows.Count > 0)
                    {
                        NapDuLieu(page, 20, 4, Int16.Parse(MADM));
                    }
                    else
                    {
                        string script = "alert(\"Mục này chưa có sản phẩm!\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                        return;
                    }

                }

                
              
            }

        }

        private void NapDuLieu(int currPage, int recodperpage, int Pagesize, int MADM)
        {
            //string MADM = Request.QueryString.Get("MADM");

            DataSet ds = cm.StoreToDataSet(currPage, recodperpage, Pagesize, MADM);
            DataTable dtbData = ds.Tables[0];
            DataTable dtbPhanTrang = ds.Tables[1];

            if (dtbData.Rows.Count > 0)
            {
                DataList1.DataSource = dtbData;
                DataList1.DataBind();
                if (dtbPhanTrang.Rows.Count > 0)
                {
                    Literal1.Text = dtbPhanTrang.Rows[0]["PhanTrang"] + "";
                }
            }
        }
        private void NapDuLieu1(int currPage, int recodperpage, int Pagesize)
        {
            string MADM = Request.QueryString.Get("MADM");

            DataSet ds = cm.StoreToDataSet(currPage, recodperpage, Pagesize);
            DataTable dtbData = ds.Tables[0];
            DataTable dtbPhanTrang = ds.Tables[1];

            if (dtbData.Rows.Count > 0)
            {
                DataList1.DataSource = dtbData;
                DataList1.DataBind();
                if (dtbPhanTrang.Rows.Count > 0)
                {
                    Literal1.Text = dtbPhanTrang.Rows[0]["PhanTrang"] + "";
                }
            }
        }

    }
}