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
    public partial class ChiTietSanPham1 : System.Web.UI.Page
    {
        COMMON cs = new COMMON();
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Session.Timeout = 1;
                if (Session["tbGiohang"] == null)
                    KHOITAOGIOHANG();
                string MaMH = Request.QueryString.Get("MaSP");
                LoadMau();
                String SQL = "Select * from tbSANPHAM WHERE SanPham_ID='" + MaMH + "'";
                dt = cs.getTable(SQL);
                this.Repeater1.DataSource = dt;
                this.Repeater1.DataBind();

                int soluong = Convert.ToInt16(dt.Rows[0]["SoLuong"].ToString());
                for (int i = 1; i <= soluong; i++)
                    this.drop_SOLUONG.Items.Add(i.ToString());


                int MaDM = Convert.ToInt16(dt.Rows[0]["DanhMuc_ID"].ToString());
                string sql = "Select top(4)* from tbSANPHAM where DanhMuc_ID=" + MaDM + "";
                this.DataList2.DataSource = cs.getTable(sql);
                this.DataList2.DataBind();
                string sql1="Select * from tbSANPHAM,tbDANHMUC where tbSANPHAM.DanhMuc_ID=tbDANHMUC.DanhMuc_ID and SanPham_ID ='"+MaMH+"'";
                this.DataList1.DataSource = cs.getTable(sql1);
                this.DataList1.DataBind();
            }

        }
        public void LoadMau()
        {
            string sql = "Select * from tbMAUSP";
            dropdown_Mau.DataSource = cs.getTable(sql);
            dropdown_Mau.DataTextField = "TenMau";
            dropdown_Mau.DataValueField = "Mau_ID";
            dropdown_Mau.DataBind();

        }
        public void KHOITAOGIOHANG()
        {
            dt = new DataTable();
            dt.Columns.Add("SanPham_ID");
            dt.Columns.Add("TenSanPham");
            dt.Columns.Add("HinhAnh");
            dt.Columns.Add("Mau_ID");
            dt.Columns.Add("TenMau");
            dt.Columns.Add("DonGia");
            dt.Columns.Add("SoLuong");
            dt.Columns.Add("ThanhTien");
            Session["tbGiohang"] = dt;

        }
        public void THEMGIOHANG(String mamh, String tenmh, string hinhanh,
          float dongia, int soluong,String mamau,string tenmau)
        {
            dt = (DataTable)Session["tbGiohang"];
            bool flag = false;
            if (dt == null) KHOITAOGIOHANG();
            foreach (DataRow row1 in dt.Rows)
            {
                if (row1["SanPham_ID"].ToString().Equals(mamh) && row1["Mau_ID"].ToString().Equals(mamau))
                {
                    row1["SoLuong"] = Convert.ToInt32(row1["SoLuong"]) + Convert.ToInt32(soluong);
                    flag = true;
                } 
            }
            if (!flag)
            {
                DataRow row = dt.NewRow();
                row["SanPham_ID"] = mamh;
                row["TenSanPham"] = tenmh;
                row["HinhAnh"] = hinhanh;
                row["Mau_ID"] = mamau;
                row["TenMau"] = tenmau;
                row["DonGia"] = dongia;
                row["SoLuong"] = soluong;               
                row["ThanhTien"] = "";
                dt.Rows.Add(row);

            }
            Session["tbGiohang"] = dt;
        }
        //protected void btn_mua_Click(object sender, EventArgs e)
        //{
        //    string MaMH = Request.QueryString.Get("MaSP");
        //    String SQL = "Select * from tbSANPHAM WHERE SanPham_ID='" + MaMH + "'";
        //    dt = cs.getTable(SQL);

        //    THEMGIOHANG(dt.Rows[0]["SanPham_ID"].ToString(),
        //        dt.Rows[0]["TenSanPham"].ToString(), dt.Rows[0]["HinhAnh"].ToString(),
        //        float.Parse(dt.Rows[0]["DonGia"].ToString()),
        //        int.Parse(this.drop_SOLUONG.SelectedValue), this.dropdown_Mau.SelectedItem.Value.ToString(),dropdown_Mau.SelectedItem.Text.ToString());

        //    Response.Redirect("GioHang.aspx");
        //}

        protected void btn_muahang_Click(object sender, EventArgs e)
        {
            string MaMH = Request.QueryString.Get("MaSP");
            String SQL = "Select * from tbSANPHAM WHERE SanPham_ID='" + MaMH + "'";
            dt = cs.getTable(SQL);

            THEMGIOHANG(dt.Rows[0]["SanPham_ID"].ToString(),
                dt.Rows[0]["TenSanPham"].ToString(), dt.Rows[0]["HinhAnh"].ToString(),
                float.Parse(dt.Rows[0]["DonGia"].ToString()),
                int.Parse(this.drop_SOLUONG.SelectedValue), this.dropdown_Mau.SelectedItem.Value.ToString(), dropdown_Mau.SelectedItem.Text.ToString());

            Response.Redirect("GioHang.aspx");
        }
        
        
    }
}
