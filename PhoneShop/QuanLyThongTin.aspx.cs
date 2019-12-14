using PhoneShop.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhoneShop
{
    public partial class QuanLyThongTin : System.Web.UI.Page
    {
        DataTable dt;
        COMMON cs = new COMMON();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            load_Sothich();
            load_GioiTinh();
            load_thunhap();
            string q = "Select * from View_login where User_ID='" + makh() + "'";
            dt = cs.getTable(q);



            // Cast instead of using ToString

            DateTime sdate = (DateTime)dt.Rows[0]["NgaySinh"];
            // Then format it as desired. Example:
            string formattedDate = sdate.ToString("dd-MM-yyyy");


            txt_TenKhachHang.Text = dt.Rows[0]["HoTen"].ToString();
            txt_matkhau.Text = MaHoaMD5.Decryptdata(dt.Rows[0]["Password"].ToString());
            txt_ngaySinh.Text = formattedDate;
            txt_DienThoai.Text = dt.Rows[0]["SoDienThoai"].ToString();
            txt_Email.Text = dt.Rows[0]["Email"].ToString();
            txt_DiaChi.Text = dt.Rows[0]["DiaChi"].ToString();
            dropdown_Sothich.SelectedValue = dt.Rows[0]["SoThich_ID"].ToString();
            drp_thunhap.SelectedValue = dt.Rows[0]["ThuNhap_ID"].ToString();
            drop_gioitinh.SelectedValue = dt.Rows[0]["GioiTinh_ID"].ToString();




        }
        public string makh()
        {
            string username = Request.Cookies["UserName"].Value;
            string password = Request.Cookies["Password"].Value;
            string userid = "Select * from tbLOGIN where UserName='" + username + "' and Password='" + password + "'";
            DataTable tb = cs.getTable(userid);
            string makh = tb.Rows[0]["User_ID"].ToString();

            return makh;
        }
        void load_thunhap()
        {
            string q = "Select * from tbTHUNHAP";
            drp_thunhap.DataValueField = "ThuNhap_ID";
            drp_thunhap.DataTextField = "LoaiThuNhap";
            drp_thunhap.DataSource = cs.getTable(q);
            drp_thunhap.DataBind();
        }
        private void load_Sothich()
        {
            string sql = "select * from tbSOTHICH";
            dropdown_Sothich.DataValueField = "SoThich_ID";
            dropdown_Sothich.DataTextField = "TenSoThich";


            dropdown_Sothich.DataSource = cs.getTable(sql);

            dropdown_Sothich.DataBind();
        }
        private void load_GioiTinh()
        {
            string sql = "Select * from tbGIOITINH";
            drop_gioitinh.DataValueField = "GioiTinh_ID";
            drop_gioitinh.DataTextField = "TenGioiTinh";
            drop_gioitinh.DataSource = cs.getTable(sql);
            drop_gioitinh.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            

            string date = Convert.ToDateTime(txt_ngaySinh.Text).ToString("yyyy-MM-dd");
            DateTime sdate = Convert.ToDateTime(date);
            int ngay = int.Parse(sdate.Day.ToString());
            int thang = int.Parse(sdate.Month.ToString());
            int nam = int.Parse(sdate.Year.ToString());

            string sql = "Select*from tbTHONGTINCANHAN where KH_ID='" + makh() + "'";
            dt = cs.getTable(sql);

            string q;
            string data;
            if (dt.Rows.Count > 0)
            {
                q = "Update tbTHONGTINCANHAN set HoTen= N'" + txt_TenKhachHang.Text + "',NgaySinh='" + nam + " / " + thang + " / " + ngay + "',GioiTinh_ID='" + drop_gioitinh.SelectedValue.ToString() + "',SoDienThoai='" + txt_DienThoai.Text + "',Email='" + txt_Email.Text + "',DiaChi= N'" + txt_DiaChi.Text + "', SoThich_ID ='" + dropdown_Sothich.SelectedValue.ToString() + "',ThuNhap_ID='" + drp_thunhap.SelectedValue.ToString() + "' where KH_ID ='" + makh() + "'";
                cs.ExecuteNonQuery(q);
                data = "Update tbLOGIN set Password='" + MaHoaMD5.Encryptdata(txt_matkhau.Text) + "' where User_ID='" + makh() + "'";
                cs.ExecuteNonQuery(data);

            }
            else
            {
                q = "Insert into tbTHONGTINCANHAN(HoTen,NgaySinh,GioiTinh_ID,SoDienThoai,Email,DiaChi,SoThich_ID,ThuNhap_ID)values(N'" + txt_TenKhachHang.Text + "','" + nam + " / " + thang + " / " + ngay + "','" + drop_gioitinh.SelectedValue.ToString() + "','" + txt_DienThoai.Text + "','" + txt_Email.Text + "', N'" + txt_DiaChi.Text + "','" + dropdown_Sothich.SelectedValue.ToString() + "','" + drp_thunhap.SelectedValue.ToString() + "')";
                cs.ExecuteNonQuery(q);
            }



            Response.Redirect("/ThongTinKhachHang.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ThongTinKhachHang.aspx");
        }
    }
}