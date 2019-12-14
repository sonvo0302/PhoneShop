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
    public partial class QuanLyTaiKhoan : System.Web.UI.Page
    {
        COMMON cm = new COMMON();
        protected void Page_Load(object sender, EventArgs e)
        {  
            if (IsPostBack) return;
            docDL();
            loadgroup();
            docDLNhom();
        }

       private void docDL()
        {
            string username = Request.Cookies["UserName"].Value;
            string password = Request.Cookies["Password"].Value;
            string sql = "Select * from tbLOGIN where Group_ID!=2";
            DataList1.DataSource = cm.getTable(sql);
            DataList1.DataBind();
        }
        private void docDLNhom()
        {
            string sql = "Select * from tbGROUP where Group_ID!=2";
            DataList2.DataSource = cm.getTable(sql);
            DataList2.DataBind();
        }
        void loadgroup()
        {
            string sql = "SELECT * from tbGROUP";
            DataList2.DataSource = cm.getTable(sql);
            DataList2.DataBind();
        }
        protected void btn_xoa_Click(object sender, EventArgs e)
        {
           
            string user_id = ((LinkButton)sender).CommandArgument;
            if (Int16.Parse(user_id) != 2)
            {
                string sql = "Delete from tbTHONGTINCANHAN where KH_ID='" + user_id + "'";
                cm.ExecuteNonQuery(sql);
                string data = "Delete from tbLOGIN where User_ID='" + user_id + "'";
                cm.ExecuteNonQuery(data);
            }
            else
            {
                string sql2 = "Delete from tbTHONGTINCANHAN where KH_ID='" + user_id + "'";

                cm.ExecuteNonQuery(sql2);

                string data = "Select * from tbUSER_GROUP where User_ID='" + user_id + "'";

                DataTable tb = cm.getTable(data);
                int user_group_id = Int16.Parse(tb.Rows[0]["User_Group_ID"].ToString());

                string sql_gr_md = "Delete from tbUSER_GROUP_MODULE where User_Group_ID=" + user_group_id + "";
                cm.ExecuteNonQuery(sql_gr_md);

                string sql1 = "Delete from tbUSER_GROUP where User_ID='" + user_id + "'";
                cm.ExecuteNonQuery(sql1);

                string sql = "delete from tbLOGIN where User_ID='" + user_id + "'";
                cm.ExecuteNonQuery(sql);
            }
            docDL();
        }

      

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string user_id = ((LinkButton)sender).CommandArgument;
            Context.Items["userid"] = user_id;
            Server.Transfer("SuaTaikhoan.aspx");
    
        }


        protected void phanquyen_Click(object sender, EventArgs e)
        {
            Server.Transfer("PhanQuyen.aspx");
        }

        protected void qltaikhoan_Click(object sender, EventArgs e)
        {
            Server.Transfer("QuanLyTaiKhoan.aspx");
        }

 

  

        protected void btn_themGroup_Click(object sender, EventArgs e)
        {
            string GroupName = groupname.Value.ToString();
            string sql = "Insert into tbGROUP(GroupName) values('" + GroupName + "')";
            cm.ExecuteNonQuery(sql);
            docDLNhom();

        }

        //protected void btn_xoa_group_Click(object sender, EventArgs e)
        //{
        //    string group_id = ((LinkButton)sender).CommandArgument;

        //    if (Int16.Parse(group_id) != 3)
        //    {
        //        string data_user = "Select * from tbLOGIN where Group_ID='" + group_id + "'";
        //        DataTable table = cm.getTable(data_user);
        //        int user_id = Int16.Parse(table.Rows[0]["User_ID"].ToString());
        //        string thongtin = "Delete from tbTHONGTINCANHAN where KH_ID=" + user_id + "";
        //        cm.ExecuteNonQuery(thongtin);
        //        string user_login = "Delete from tbLOGIN where Group_ID='" + group_id + "'";
        //        cm.ExecuteNonQuery(user_login);
        //    }
        //    else
        //    {
        //        string data_usergroup = "Select * from tbUSER_GROUP where Group_ID = 3";
        //        DataTable tb3 = cm.getTable(data_usergroup);
        //        int user_group_id = Int16.Parse(tb3.Rows[0]["User_Group_ID"].ToString());

        //        string sql_gr_md = "Delete from tbUSER_GROUP_MODULE where User_Group_ID=" + user_group_id + "";
        //        cm.ExecuteNonQuery(sql_gr_md);



        //        string sql1 = "Delete from tbUSER_GROUP where Group_ID='" + group_id + "'";
        //        cm.ExecuteNonQuery(sql1);

        //        string user_data = "Select * from tbLOGIN where Group_ID=3";
        //        DataTable tb1 = cm.getTable(user_data);
        //        int user_id_2 = Int16.Parse(tb1.Rows[0]["User_ID"].ToString());
        //        string thongtin_canhan = "Delete from tbTHONGTINCANHAN where User_ID=" + user_id_2 + "";
        //        cm.ExecuteNonQuery(thongtin_canhan);

        //        string xoa_user = "Delete from tbLOGIN where Group_ID='" + group_id + "'";
        //        cm.ExecuteNonQuery(xoa_user);
        //        string sql = "Delete from tbGROUP where Group_ID='" + group_id + "'";
        //        cm.ExecuteNonQuery(sql);
        //    }
        //    docDLNhom();

        //}

        //protected void btn_sua_group_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("SuaNhomNguoiDung.aspx");
        //}
    }
}