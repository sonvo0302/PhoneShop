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
    public partial class DatHang : System.Web.UI.Page
    {
        DataTable dt=new DataTable();
        COMMON cs = new COMMON();
        protected void Page_Load(object sender, EventArgs e)
        {
            
                if (!IsPostBack)
                {
                    load_methodPay();
                }

            if (Session["tbGiohang"] == null)
            {
                string script = "alert(\"Bạn chưa có gì trong giỏ hàng!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                Response.Redirect("GioHang.aspx");
            }
            string username = Request.Cookies["UserName"].Value;
            string password = Request.Cookies["Password"].Value;
            string tenkh = "Select HoTen from tbTHONGTINCANHAN,tbLOGIN where UserName='" + username + "' and Password='" + password + "' and tbTHONGTINCANHAN.KH_ID=tbLOGIN.User_ID".ToString();
            DataTable tb = cs.getTable(tenkh);
            dt = (DataTable)Session["tbGiohang"];
                double tong = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    double thanhtien = Convert.ToDouble(dt.Rows[i]["SoLuong"]) * Convert.ToDouble(dt.Rows[i]["DonGia"]);
                    dt.Rows[i]["ThanhTien"] = Math.Round(thanhtien) + "";
                    tong += thanhtien;
                }
                Label2.Text = " "+tong+"";
                grdDatHang.DataSource = dt;
                grdDatHang.DataBind();
                txt_ThoiGianDH.Text = DateTime.Now.Date.ToString();
            
        }
        public void load_methodPay()
        {
            string sql = "select Pay_ID,PayName from tbPayMethod where Visible = 1";
            dropdown_thanhtoan.DataSource = cs.getTable(sql);

            dropdown_thanhtoan.DataTextField = "PayName";
            dropdown_thanhtoan.DataValueField = "Pay_ID";
            dropdown_thanhtoan.DataBind();
        }

        protected void btn_DatHang_Click(object sender, EventArgs e)
        {
            string username = Request.Cookies["UserName"].Value;
            string password = Request.Cookies["Password"].Value;
            string userid = "Select User_ID from tbTHONGTINCANHAN,tbLOGIN where UserName='" + username + "' and Password='" + password + "' and tbTHONGTINCANHAN.KH_ID=tbLOGIN.User_ID";
            DataTable tb = cs.getTable(userid);
            string makh = "";
            foreach(DataRow row in tb.Rows)
            {
                 makh = row["User_ID"].ToString();
            }
            if (Session["tbGiohang"] == null)
            {
                Response.Redirect("GioHang.aspx");
            }   
            dt = (DataTable)Session["tbGiohang"];
            double tong = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                double thanhtien = Convert.ToDouble(dt.Rows[i]["SoLuong"]) * Convert.ToDouble(dt.Rows[i]["DonGia"]);
                dt.Rows[i]["ThanhTien"] = Math.Round(thanhtien) + "";
                tong += thanhtien;
            }
            int ngay = int.Parse(DateTime.Now.Day.ToString());
            int thang = int.Parse(DateTime.Now.Month.ToString());
            int nam = int.Parse(DateTime.Now.Year.ToString());

            string sql1 = "Insert into tbHOADON(User_ID,TenKhachHang,DiaChi,Phone,NgayHD,TongTien,Pay_ID,Status) values('" + makh + "',N'" + txt_TenKhachHang.Text + "',N'" + txt_DiaChi.Text + "','" + txt_DienThoai.Text + "','"+ nam + " / " + thang + " / " + ngay + "',"+tong+",'" + dropdown_thanhtoan.SelectedItem.Value.ToString() + "',0)";
            cs.ExecuteNonQuery(sql1);
            string sql2 = "select HD_ID from tbHOADON";
            int idDH = 0;
            foreach (DataRow r in cs.getTable(sql2).Rows)
            {
                idDH = int.Parse(r[0].ToString());
            }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow r in dt.Rows)
                {
                    int idSP = int.Parse(r["SanPham_ID"].ToString());
                    int SoLuong = int.Parse(r["SoLuong"].ToString());   
                    double Gia = double.Parse(r["DonGia"].ToString());
                    string mau = r["TenMau"].ToString();
                    string hinhanh = r["HinhAnh"].ToString();   
                    string sql3 = "insert into tbCHITIETHOADON(HD_ID,SanPham_ID,HinhAnh,DonGia,Mau,SoLuongDat) values(" + idDH + "," + idSP + ",'"+hinhanh+"'," + Gia + ",N'"+mau+"'," + SoLuong + ")";
                    cs.ExecuteNonQuery(sql3);
                }
            }
            //string return_url = "http://localhost:62407/Default.aspx";
            //String transaction_info = txt_TenKhachHang.Text;
            //String order_code = txt_ThoiGianDH.Text;
            //String receiver = "webmaster@dotnet.vn";//Tài khoản nhận tiền 
            //String price = tong.ToString();
            //Checkout nl = new Checkout();
            //String url;
            //url = nl.buildCheckoutUrl(return_url, receiver, transaction_info, order_code, price);
            //Response.Redirect(url);
            Response.Redirect("DatHangThanhCong.aspx");
        }
    }
}