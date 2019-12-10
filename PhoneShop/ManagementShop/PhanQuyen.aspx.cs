using PhoneShop.App_Code;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhoneShop.ManagementShop
{

    public partial class PhanQuyen : System.Web.UI.Page
    {
        COMMON cm = new COMMON();
        DataTable tbModule = new DataTable();
        public String strMenu;
        protected void Page_Load(object sender, EventArgs e)
        {
   
            if (IsPostBack) return;


            load_DropGroup();
            string sql = "Select* from tbMODULE";
            tbModule = cm.getTable(sql);
            tbModule.DefaultView.RowFilter = "Parent_ID=0";

            foreach (DataRow row in tbModule.DefaultView.ToTable().Rows)
            {
                TreeNode NodeParent = new TreeNode();
                NodeParent.Text = row["ModuleName"].ToString();
                NodeParent.Target = row["Module_ID"].ToString();
                loadMenu(NodeParent, Convert.ToUInt16(row["Module_ID"].ToString()));
                trview_grant.Nodes.Add(NodeParent);

            }

        }
        //private void load_treeview()
        //{
        //    string sql = "Select * from tbTHONGTINCANHAN t inner join tbLOGIN log on log.User_ID=t.KH_ID where Group_ID='" + drpd_NhomNguoi.SelectedItem.Value.ToString() + "'";
        //    DataTable tb = cm.getTable(sql);
        //    string group_id = "";
        //    foreach (DataRow row in tb.Rows)
        //    {
        //        group_id = group_id + row["Group_ID"].ToString();
        //    }

        //    string sql1 = "Select * from tbMODULE modul inner join tbUSER_GROUP_MODULE usermodule on usermodule.Module_ID=modul.Module_ID" +
        //        " inner join tbUSER_GROUP gr on gr.User_Group_ID=usermodule.User_Group_ID inner join tbGROUP tgr on " +
        //        "tgr.Group_ID=gr.Group_ID inner join tbLOGIN log on log.Group_ID=tgr.Group_ID inner join tbTHONGTINCANHAN tt on tt.KH_ID=log.User_ID where gr.Group_ID='" + group_id + "' ";
        //    DataTable dt = cm.getTable(sql1);


        //    foreach (DataRow row in dt.Rows)
        //    {
        //        TreeNode NodeParent = new TreeNode();
        //        NodeParent.Text = row["ModuleName"].ToString();
        //        NodeParent.Target = row["Module_ID"].ToString();
        //        loadMenu(NodeParent, Convert.ToUInt16(row["Module_ID"].ToString()));
        //        trview_grant.Nodes.Add(NodeParent);
        //    }
        //}
        private void load_DropGroup()
        {
            String sql = "Select * from tbGROUP";
            drpd_NhomNguoi.DataValueField = "Group_ID";
            drpd_NhomNguoi.DataTextField = "GroupName";
            drpd_NhomNguoi.DataSource = cm.getTable(sql);
            drpd_NhomNguoi.DataBind();

        }

        protected void trview_grant_SelectedNodeChanged(object sender, EventArgs e)
        {

        }
        public void loadMenu(TreeNode NodeParent, int Parent_ID)
        {

            //node.Text = "ABC";
            //node.Target = "1";
            //trview_grant.Nodes.Add(node)
            tbModule.DefaultView.RowFilter = "Parent_ID=" + Parent_ID;
            DataTable tbChilrent = tbModule.DefaultView.ToTable();
            if (tbChilrent.Rows.Count > 0)
            {

                foreach (DataRow row in tbChilrent.Rows)
                {
                    TreeNode NodeChildrent = new TreeNode();
                    NodeChildrent.Text = row["ModuleName"].ToString();
                    NodeChildrent.Target = NodeParent.Target + "@" + row["Module_ID"].ToString();
                    NodeParent.ChildNodes.Add(NodeChildrent);
                    loadMenu(NodeChildrent, Convert.ToUInt16(row["Module_ID"].ToString()));

                }

            }

        }
        ArrayList module = new ArrayList();
        public void DuyetCay(TreeNode NodeParent)
        {
            if (NodeParent.Checked == true)
                if (NodeParent.Target.IndexOf("@") > 0)
                    module.Add(NodeParent.Target);
            if (NodeParent.ChildNodes.Count > 0)
                foreach (TreeNode node in NodeParent.ChildNodes)
                    DuyetCay(node);
        }
        public ArrayList add_Module(TreeNode Node)
        {
            ArrayList module = new ArrayList();
            if (Node.Checked)
            {
                module.Add(Node.Target);
            }
            return module;
        }
        private void load_tenNguoiDung()
        {
            string sql = "Select * from tbTHONGTINCANHAN tt inner join tbLOGIN log on log.User_ID=tt.KH_ID where Group_ID='" + drpd_NhomNguoi.SelectedItem.Value.ToString() + "'";
            DataTable tb = cm.getTable(sql);
            lst_Left.Items.Clear();
            foreach (DataRow row in tb.Rows)
            {
                ListItem item = new ListItem(row["HoTen"].ToString(), row["KH_ID"].ToString(), true);
                lst_Left.Items.Add(item);
            }

        }
        protected void drpd_NhomNguoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_tenNguoiDung();
        }
        protected void btn_Next_Click(object sender, EventArgs e)
        {
            if (lst_Left.SelectedIndex == -1)
            {
                string script = "alert(\"Bạn chưa chọn dữ liệu ở list box!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            else
            {
                for (int i = lst_Left.Items.Count - 1; i >= 0; i--)
                {
                    if (lst_Left.Items[i].Selected)
                    {
                        this.lst_Box2.Items.Add(lst_Left.Items[i]);
                        lst_Left.Items.RemoveAt(i);
                    }
                }
            }
        }
        void AddAll(ListBox list1, ListBox list2)
        {
            for (int i = 0; i < list1.Items.Count; i++)
            {
                ListItem a = list1.Items[i];
                list1.Items.Remove(a);
                list2.Items.Add(a);
                i--;
            }
        }
        protected void btn_NextAll_Click(object sender, EventArgs e)
        {

            AddAll(lst_Left, lst_Box2);
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            if (lst_Box2.SelectedIndex == -1)
            {
                string script = "alert(\"Bạn chưa chọn dữ liệu ở list box!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            else
            {
                for (int i = lst_Box2.Items.Count - 1; i >= 0; i--)
                {
                    if (lst_Box2.Items[i].Selected)
                    {
                        this.lst_Left.Items.Add(lst_Box2.Items[i]);
                        lst_Box2.Items.RemoveAt(i);
                    }
                }
            }
        }

        protected void btn_BackAll_Click(object sender, EventArgs e)
        {
            AddAll(lst_Box2, lst_Left);
        }

        protected void lst_Box2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void trview_grant_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
        {

        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            foreach (TreeNode nodeparent in trview_grant.Nodes)
                DuyetCay(nodeparent);

            foreach (ListItem item in lst_Box2.Items)
            {

                int User_ID = Int16.Parse(item.Value);
                int Group_ID = Int16.Parse(drpd_NhomNguoi.SelectedValue);
                SqlParameter[] prUSER_GROUP = { new SqlParameter("@User_ID", User_ID), new SqlParameter("@Group_ID", Group_ID) };
                object User_Group_ID = cm.ExecuteScalarProcedure("[AddUserGroup]", prUSER_GROUP);
                foreach (String itemModul in module)
                {
                    String[] value = itemModul.Split('@');
                    int Parent_ID = Int16.Parse(value[0]);
                    int Module_ID = Int16.Parse(value[1]);
                    SqlParameter[] prUSER_GROUP_MODULE = { new SqlParameter("@User_Group_ID", User_Group_ID), new SqlParameter("@Module_ID", Module_ID), new SqlParameter("@Parent_ID", Parent_ID) };
                    cm.ExecuteProcedure("AddUSER_GROUP_MODULE", prUSER_GROUP_MODULE);

                }

            }
            string script = "alert(\"Lưu thành công!\");";
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);

            //SqlParameter[] pr = { new SqlParameter("@User_ID", DBNull.Value), new SqlParameter("@Group_ID", DBNull.Value) };
            //for (int i = 0; i < lst_Box2.Items.Count; i++)
            //{
            //    lst_Box2.DataSource = cm.getTableStoreprocedure("AddUserGroup", pr);

            //}
            //for (int i = 0; i < module.Count; i++)
            //{

            //    string sql = "Select"
            //}
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