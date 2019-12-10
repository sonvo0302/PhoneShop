using PhoneShop.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhoneShop.Staffs
{
    public partial class StaffManagement : System.Web.UI.MasterPage
    {
        COMMON cm = new COMMON();
        public String strLogin;
        DataTable tbModule;
        public String strMenu = "<div id='cssmenu'>";


        protected void Page_Load(object sender, EventArgs e)
        {
       


            if (Request.Cookies["UserName"] == null)
            {
                strLogin += "<li class='nav - item dropdown'><a  data-modal='modalOne' class='nav-link button'>Đăng nhập</a></li>";
                string sql = "Select * from tbMODULE";
                tbModule = cm.getTable(sql);
                MenuDequy(0);
                strMenu += "</ul></div>";
            }
            else
            {
                login();
                string username = Request.Cookies["UserName"].Value;
                string password = Request.Cookies["Password"].Value;
                SqlParameter[] pr = { new SqlParameter("@UserName", username), new SqlParameter("@Password", password) };

                tbModule = cm.getTableStoreprocedure("getMo", pr);
                MenuDequy(0);
                strMenu += "</ul></div>";
            }
            
            

        }
        void MenuDequy(int Parent_ID)
        {
            tbModule.DefaultView.RowFilter = "Parent_ID=" + Parent_ID;
            DataTable tbChilrent = tbModule.DefaultView.ToTable();
            if (tbChilrent.Rows.Count > 0)
            {
                strMenu += "<ul>";
                foreach (DataRow row in tbChilrent.Rows)
                {
                    string link = "../Staffs/" + row["Link"].ToString();
                    strMenu += "<li><a href='"+link+"'>" + row["ModuleName"].ToString() + "</a>";

                    int idChilrent = Convert.ToInt16(row["Module_ID"].ToString());
                    MenuDequy(idChilrent);

                    strMenu += "</li>";

                }
                strMenu += "</ul>";
            }
        }
        private void login()
        {
            string username = Request.Cookies["UserName"].Value;
            string password = Request.Cookies["Password"].Value;
            string userid = "Select * from tbLOGIN where UserName='" + username + "' and Password='" + password + "'";
            DataTable tb = cm.getTable(userid);
            string makh = ""; int group_id = 0;
            foreach (DataRow row in tb.Rows)
            {
                makh = row["User_ID"].ToString();
                group_id = Convert.ToInt16(row["Group_ID"].ToString());
            }

            string tenkh = "Select * from tbTHONGTINCANHAN where KH_ID='" + makh + "'";
            DataTable dt = cm.getTable(tenkh);
            //< li id = "dd" class="wrapper-dropdown-2 cart">
            //   <ul class="dropdown">
            //<li>you have no items in your Shopping cart</li>
            //             </ul>
            //             </li>
            if (group_id != 3)
            {
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
                strLogin += "<li class='nav - item dropdown'><a  data-modal='modalOne' class= 'nav-link button'>Đăng nhập</a></li>";
                return;
            }
            else
            {
                foreach (DataRow row in dt.Rows)
                {
                    strLogin += "<li class='nav - item dropdown'><a class='nav - link dropdown - toggle' id='navbarDropdown' role='button' data-toggle='dropdown' aria-haspopup='true' aria-expanded='false'>" + row["HoTen"].ToString() + "</a>";
                    strLogin += "<div class='dropdown-menu dropdown-menu-right' aria-labelledby='navbarDropdown'>";
                    strLogin += "<a class='dropdown-item' href='../DanhSachMatHang.aspx'>Trang chủ sản phẩm</a>";
                    strLogin += "<a class='dropdown-item' href='../DangXuat.aspx'>Đăng xuất</a>";
                    strLogin += "</div></li>";
                }
            }
        }

        protected void btn_dangky_Click(object sender, EventArgs e)
        {

        }

        protected void btn_dangnhap_Click(object sender, EventArgs e)
        {
            string userName = user_name.Value.ToString();
            string Password = MaHoaMD5.Encryptdata(password_c.Value.ToString());
            string sql = "Select * from tbLOGIN where UserName = '" + userName + "' and Password='" + Password + "'";
            DataTable tb = cm.getTable(sql);

            if (tb.Rows.Count != 0)
            {
                Response.Cookies["UserName"].Value = userName;
                Response.Cookies["Password"].Value = Password;
                Session["user"] = userName.ToString();
                Response.Redirect("Home.aspx");
            }
            else
            {
                string script = "alert(\"Lỗi đăng nhập!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
        }
    }
}