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
    public partial class ChiTietMaster : System.Web.UI.MasterPage
    {
        COMMON cm = new COMMON();
        public String strLogin;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Cookies["UserName"] == null)
            {
                strLogin += "<li><a data-modal='modalTwo' class='button'>Đăng ký</a></li> ";
                strLogin += "<li><a data-modal='modalOne' class='button'>Đăng nhập</a></li>";
            }
            else
            {
                string username = Request.Cookies["UserName"].Value;
                string password = Request.Cookies["Password"].Value;
                string userid = "Select * from View_login where UserName='" + username + "' and Password='" + password + "'";
                DataTable tb = cm.getTable(userid);
                foreach (DataRow row in tb.Rows)
                {
                    strLogin += "<li><a title='Click vào đây để xem thông tin của bạn' href='ThongTinKhachHang.aspx'>Chào mừng" + row["HoTen"].ToString() + "</a></li>";
                }
                strLogin += "<li><a href='DangXuat.aspx'>Đăng xuất</a>";
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["UserName"] != null)
            {
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
            }
            Response.Redirect("DanhSachMatHang.aspx", true);
        }

        protected void btn_dangnhap_Click(object sender, EventArgs e)
        {
          
            string userName = user_name.Value.ToString();
            string Password = MaHoaMD5.Encryptdata(password_c.Value.ToString());
            string sql = "Select * from View_3 where UserName = '" + userName + "' and Password='" + Password + "'";
            DataTable tb = cm.getTable(sql);
            int group_id = 0;
            foreach (DataRow row in tb.Rows)
            {
                group_id = Convert.ToInt16(row["Group_ID"].ToString());
            }
            if (tb.Rows.Count != 0)
            {
                Response.Cookies["UserName"].Value = userName;
                Response.Cookies["Password"].Value = Password;
                Session["user"] = userName.ToString();
              
                if (group_id == 1)
                {
                    
                    Server.Transfer("DanhSachMatHang.aspx");
                }
                else if (group_id == 2)
                {


                    Server.Transfer("~/ManagementShop/HomePageAdmin.aspx");
                }
                else
                {

                    Server.Transfer("~/Staffs/Home.aspx");
                }
            }
            else
            {
                string script = "alert(\"Lỗi đăng nhập!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
        }

        protected void btn_dangky_Click(object sender, EventArgs e)
        {
            try
            {

                string Tendangnhap = username.Value.ToString();
                string Matkhau = password1.Value.ToString();
                string Xacnhan_matkhau = password2.Value.ToString();
                string Hoten = hoten.Value.ToString();
                string sql = "Select * from tbLOGIN where UserName ='" + Tendangnhap + "'";
                DataTable dt = cm.getTable(sql);
                string ten = "";
                foreach (DataRow row in dt.Rows)
                {
                    ten += row["UserName"].ToString();
                }
                if (dt.Rows.Count > 0)
                {
                    string script = "alert(\"Đã có tên đăng nhập này!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    return;
                }
                else
                {
                    if (Matkhau.Equals(Xacnhan_matkhau) == false)
                    {
                        string script = "alert(\"Nhập sai mật khẩu ở xác nhận mật khẩu!\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                        return;
                    }
                    else
                    {
                        string q = "Insert into tbLOGIN(UserName,Password,Group_ID) values('" + Tendangnhap + "','" + MaHoaMD5.Encryptdata(Matkhau) + "',1)";
                        cm.ExecuteNonQuery(q);

                        string data = "Select * from tbLOGIN where UserName='" + Tendangnhap + "' and Password='" + MaHoaMD5.Encryptdata(Matkhau) + "'";
                        DataTable tb = cm.getTable(data);
                        string user_id = tb.Rows[0]["User_ID"].ToString();
                        int ngay = int.Parse(day.Value.ToString());
                        int thang = int.Parse(month.Value.ToString());
                        int nam = int.Parse(year.Value.ToString());
                        string q1 = "Insert into tbTHONGTINCANHAN(KH_ID,HoTen,NgaySinh)values('" + user_id + "',N'" + Hoten + "','" + ngay + "/" + thang + "/" + nam + "')";
                        cm.ExecuteNonQuery(q1);
                        string script = "alert(\"Mời bạn đăng nhập!\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);

                        Response.Redirect("DanhSachMatHang.aspx");

                    }
                }


            }
            catch (SqlException ex)
            {

                throw ex;


            }
        }

        protected void btn_timkiem_Click(object sender, EventArgs e)
        {
            if (txt_search.Text == "")
            {
                Response.Write("<script>alert('Bạn Phải Nhập Từ Khoá Trước Khi Tìm >.<!...')</script>");
            }
            else

            {
                string TenSanPham = txt_search.Text;
                Response.Redirect("KetQuaTim.aspx?TenSanPham=" + TenSanPham);

            }
        }
    }
}