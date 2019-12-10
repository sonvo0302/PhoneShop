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
    public partial class ChiTiet1 : System.Web.UI.Page
    {
        COMMON cs = new COMMON();
        DataTable dt = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Timeout = 1;
                if (Session["tbGiohang"] == null)
                    KHOITAOGIOHANG();
                string MaMH = Request.QueryString.Get("MaSP");
                String SQL = "Select * from tbSANPHAM WHERE SanPham_ID='" + MaMH + "'";
                dt = cs.getTable(SQL);
                this.Repeater1.DataSource = dt;
                this.Repeater1.DataBind();

                int soluong = Convert.ToInt16(dt.Rows[0]["SoLuong"].ToString());
                for (int i = 1; i <= soluong; i++)
                    this.drop_SOLUONG.Items.Add(i.ToString());


                int MaDM = Convert.ToInt16(dt.Rows[0]["DanhMuc_ID"].ToString());
                string sql = "Select top(3) * from tbSANPHAM where DanhMuc_ID=" + MaDM + "";
                this.DataList2.DataSource = cs.getTable(sql);
                this.DataList2.DataBind();
            }
        }
        public void KHOITAOGIOHANG()
        {
            dt = new DataTable();
            dt.Columns.Add("SanPham_ID", typeof(int));
            dt.Columns.Add("TenSanPham", typeof(String));
            dt.Columns.Add("HinhAnh", typeof(String));
            dt.Columns.Add("DonGia", typeof(double));
            dt.Columns.Add("SoLuong", typeof(int));
            dt.Columns.Add("ThanhTien", typeof(double), "SoLuong*DonGia");
            
            Session["tbGiohang"] = dt;

        }
        public void THEMGIOHANG(String mamh, String tenmh, String anhmathang,
      double dongia, int soluong)
        {
            DataTable tbgiohang = (DataTable)Session["tbGiohang"];
            bool flag = false;
            foreach (DataRow row1 in tbgiohang.Rows)
            {
                if (row1["SanPham_ID"].ToString().Equals(mamh))
                {
                    if (Int16.Parse(drop_SOLUONG.Items[this.drop_SOLUONG.Items.Count - 1].ToString())
                           >= Int16.Parse(row1["SoLuong"].ToString()) + soluong)
                        row1["SoLuong"] = Int16.Parse(row1["SoLuong"].ToString()) + soluong;
                    flag = true;
                }
            }
            if (!flag)
            {
                DataRow row = tbgiohang.NewRow();
                row["SanPham_ID"] = mamh;
                row["TENMH"] = tenmh;
                row["HinhAnh"] = anhmathang;
                row["DonGia"] = dongia;
                row["SoLuong"] = soluong;
                row["ThanhTien"] = dongia * soluong;
                tbgiohang.Rows.Add(row);
                Session["tbGiohang"] = tbgiohang;
            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Session.Timeout = 1;
                if (Session["tbGiohang"] == null)
                    KHOITAOGIOHANG();

                string MaMH = Request.QueryString.Get("MaSP");


                String SQL = "Select * from tbMATHANG WHERE MAMH='" + MaMH + "'";
                dt = cs.getTable(SQL);
                this.Repeater1.DataSource = dt;
                this.Repeater1.DataBind();

                int soluong = int.Parse(dt.Rows[0]["SOLUONG"].ToString());
                for (int i = 1; i <= soluong; i++)
                    this.drop_SOLUONG.Items.Add(i.ToString());
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("GioHang1.aspx");
        }
    }
}