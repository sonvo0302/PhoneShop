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
    public partial class ThongTinKhachHang : System.Web.UI.Page
    {
        COMMON cs = new COMMON();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["UserName"] == null) return;
                //string username = Request.Cookies["UserName"].Value;
                //string password = Request.Cookies["Password"].Value;
                //string userid = "Select User_ID from tbLOGIN where UserName='" + username + "' and Password='" + password + "'";
                //DataTable tb = cs.getTable(userid); 
                string q = "Select * from view_khachhang where User_ID='" + makh() + "'";

      
                DataTable dt = cs.getTable(q);
   
      
                // Cast instead of using ToString

                DateTime sdate = (DateTime)dt.Rows[0]["NgaySinh"];
                // Then format it as desired. Example:
                string formattedDate = sdate.ToString("dd-MM-yyyy");


                txt_hoten.Text = dt.Rows[0]["HoTen"].ToString();
                matkhau.Text = MaHoaMD5.Decryptdata(dt.Rows[0]["Password"].ToString());
                ngaysinh.Text = formattedDate;
                txt_dienthoai.Text = dt.Rows[0]["SoDienThoai"].ToString();
                email.Text = dt.Rows[0]["Email"].ToString();
                Diachi.Text = dt.Rows[0]["DiaChi"].ToString();
                sothich.Text = dt.Rows[0]["TenSoThich"].ToString();
                thunhap.Text = dt.Rows[0]["LoaiThuNhap"].ToString();
                gioitinh.Text = dt.Rows[0]["TenGioiTinh"].ToString();
            }

            //    DateTime sdate = (DateTime)row["NgaySinh"];

            //    // Then format it as desired. Example:
            //    string formattedDate = sdate.ToString("dd-MM-yyyy");
            //    ngaysinh.Text = formattedDate;
            //    txt_hoten.Text = row["HoTen"].ToString();
            //    matkhau.Text = MaHoaMD5.Decryptdata(row["Password"].ToString());

            //    gioitinh.Text = row["TenGioiTinh"].ToString();
            //    txt_dienthoai.Text = row["SoDienThoai"].ToString();
            //    email.Text = row["Email"].ToString();
            //    Diachi.Text = row["DiaChi"].ToString();
            //    sothich.Text = row["TenSoThich"].ToString();
            //    thunhap.Text = row["LoaiThuNhap"].ToString();
            //    nguhanh.Text = row["TenNguHanh"].ToString();
            //}
            // Cast instead of using ToString





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

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("QuanLyThongTin.aspx", true);
        }
    }
}