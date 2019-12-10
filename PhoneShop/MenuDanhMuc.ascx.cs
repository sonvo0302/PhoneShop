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
    public partial class MenuDanhMuc : System.Web.UI.UserControl
    {
        public String strMenu = "<div id='cssmenu'>";
        DataTable tbDANHMUC = new DataTable();
        COMMON cm = new COMMON();
        protected void Page_Load(object sender, EventArgs e)
        {

            SqlParameter[] pr = { new SqlParameter("@MaDM", DBNull.Value) };

            tbDANHMUC = cm.getTableStoreprocedure("getCategory", pr);

            MenuDequy(0);
            strMenu += "</ul></div>";
        }
        void MenuDequy(int Parent_ID)
        {
            tbDANHMUC.DefaultView.RowFilter = "Parent_ID=" + Parent_ID;
            DataTable tbChilrent = tbDANHMUC.DefaultView.ToTable();
            if (tbChilrent.Rows.Count > 0)
            {
                strMenu += "<ul>";
                foreach (DataRow row in tbChilrent.Rows)
                {
                    string str = "DanhSachMatHang.aspx? MADM =<%#Eval(\"DanhMuc_ID\") %>";
                    strMenu += "<li><a href='" + str + "'>" + row["TenDanhMuc"].ToString() + "</a>";

                    int idChilrent = Convert.ToInt16(row["DanhMuc_ID"].ToString());
                    MenuDequy(idChilrent);

                    strMenu += "</li>";

                }
                strMenu += "</ul>";
            }
        }
    }
}