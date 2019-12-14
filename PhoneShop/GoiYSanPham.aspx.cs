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
    public partial class GoiYSanPham : System.Web.UI.Page
    {
        COMMON cm = new COMMON();
        ServiceReference1.ServiceClient ws = new ServiceReference1.ServiceClient();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            if (Request.Cookies["UserName"] == null)
            {
                string script = "alert(\"Bạn chưa đăng nhập!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            else
            {
                string userName = Request.Cookies["UserName"].Value;
                string Password = Request.Cookies["Password"].Value;
                string sql = "Select * from View_2 where UserName='" + userName + "'and Password='" + Password + "'";
                DataTable dt = new DataTable();
                dt = cm.getTable(sql);
                if (dt.Rows.Count > 0)
                {
                    string array = "";

                    array = dt.Rows[0]["TenSoThich"].ToString() + "," + dt.Rows[0]["TenGioiTinh"].ToString() + "," + dt.Rows[0]["Tuoi"].ToString() + "," + dt.Rows[0]["LoaiThuNhap"].ToString();

                    string danhsachmasp = ws.getConsultingResults(array); /*duyệt kết quả in mã sản phẩm theo array*/
                    DataTable tb1 = ws.getTableTree();/*duyệt xong lấy cây*/

                    if (danhsachmasp == "")
                    {
                        string script = "alert(\"Không có sản phẩm phù hợp với thông tin của bạn!\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                        Server.Transfer("GoiYSanPham.aspx");
                        Label2.Text = "Không có sản phẩm nào phù hợp với thông tin của bạn";
                    }
                    else
                    {
                        string data = "Select * from view_giohang where SanPham_ID in (" + danhsachmasp.Substring(0, danhsachmasp.Length - 1) + ")";
                        string data_user = "Select * from view_khachhang where UserName='" + userName + "' and Password='" + Password + "'";
                        dataGoiY.DataSource = cm.getTable(data);
                        dataGoiY.DataBind();
                        DataList1.DataSource = cm.getTable(data_user);
                        DataList1.DataBind();
                    }
                }
                else
                {
                    string script = "alert(\"Bạn phải nhập vào thông tin bản thân.Kích chuột vào welcome!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    Label2.Text = "Không có sản phẩm nào phù hợp với thông tin của bạn";
                    
                }
            }
            
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
        float dongia, int soluong, String mamau, string tenmau)
        {
            dt = (DataTable)Session["tbGiohang"];
            bool flag = false;
            if (dt == null) KHOITAOGIOHANG();
            foreach (DataRow row1 in dt.Rows)
            {
                if (row1["SanPham_ID"].ToString().Equals(mamh))
                {
                    row1["SoLuong"] = 1;
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

        protected void btn_mua_Click(object sender, EventArgs e)
        {
            string masp = ((LinkButton)sender).CommandArgument;
            Context.Items["masp"] = masp;

            String SQL = "Select * from view_giohang WHERE SanPham_ID='" + masp + "'";
            dt = cm.getTable(SQL);

            THEMGIOHANG(dt.Rows[0]["SanPham_ID"].ToString(),
                dt.Rows[0]["TenSanPham"].ToString(), dt.Rows[0]["HinhAnh"].ToString(),
                float.Parse(dt.Rows[0]["DonGia"].ToString()),
                1, dt.Rows[0]["Mau_ID"].ToString(), dt.Rows[0]["TenMau"].ToString());

            Response.Redirect("GioHang.aspx");
        }
    }
}