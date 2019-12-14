using PhoneShop.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhoneShop.ManagementShop
{
    public partial class SuaTaikhoan : System.Web.UI.Page
    {
        COMMON cm = new COMMON();
        public String strMenu;
        DataTable dt;
        string user_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            user_id = Context.Items["userid"].ToString();
            Load_group();
            docDL();
        }
        void docDL()
        {
            
            string sql = "Select * from tbLOGIN where User_ID='" + user_id + "'";
            dt = cm.getTable(sql);

            foreach (DataRow row in dt.Rows)
            {
                Text1.Value = user_id;
                user_name.Value = row["UserName"].ToString();
                inputPassword.Value = MaHoaMD5.Decryptdata(row["Password"].ToString());
                
            }
        }
        private void Load_group()
        {
            string sql = "Select * from tbGROUP";
            dropdown_group.DataValueField = "Group_ID";
            dropdown_group.DataTextField = "GroupName";
            dropdown_group.DataSource = cm.getTable(sql);
            dropdown_group.DataBind();
        }
        protected void btn_save_Click(object sender, EventArgs e)
        {
            string sql = "Update tbLOGIN set Group_ID='" + dropdown_group.SelectedValue.ToString() + "' where User_ID='" +Text1.Value.ToString()+ "'";
                cm.ExecuteNonQuery(sql);
            Server.Transfer("QuanLyTaiKhoan.aspx");
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("QuanLyTaiKhoan.aspx");
        }
        protected void phanquyen_Click(object sender, EventArgs e)
        {
            Server.Transfer("PhanQuyen.aspx");
        }

        protected void qltaikhoan_Click(object sender, EventArgs e)
        {
            Server.Transfer("QuanLyTaiKhoan.aspx");
        }
    }
}