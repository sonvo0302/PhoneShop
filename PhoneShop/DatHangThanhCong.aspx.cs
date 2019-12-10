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
    public partial class DatHangThanhCong : System.Web.UI.Page
    {
        COMMON cs = new COMMON();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            if (Request.Cookies["UserName"] == null)
            {
                string script = "alert(\"Bạn chưa có đơn hàng nào, trở lại mua hàng!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                return;
            }
            string username = Request.Cookies["UserName"].Value;
            string password = Request.Cookies["Password"].Value;
            string userid = "Select * from tbLOGIN where UserName='" + username + "' and Password='" + password + "'";
            DataTable tb = cs.getTable(userid);
            string makh = "";
            foreach (DataRow row in tb.Rows)
            {
                makh = row["User_ID"].ToString();
            }

            string sql = "Select *from view_hoadon where User_ID='" + makh + "'";
            dt = cs.getTable(sql);
            
            double tong = 0; int soluong = 0;
            
            foreach (DataRow row in dt.Rows)
            {
                tong= Convert.ToDouble(row["TongTien"].ToString());
                soluong = soluong + Convert.ToInt16(row["SoLuongDat"]); 
            }
            grdDonHang.DataSource = dt;
            grdDonHang.DataBind();
            //Label2.Text = " " + tong + " ";
            //Label5.Text = " " + tong + " ";
        }

        protected void grdDonHang_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            string username = Request.Cookies["UserName"].Value;
            string password = Request.Cookies["Password"].Value;
            string userid = "Select * from tbLOGIN where UserName='" + username + "' and Password='" + password + "'";
            DataTable tb = cs.getTable(userid);
            grdDonHang.DataSource = dt;
            grdDonHang.DataBind();

                int makh = Int16.Parse(dt.Rows[0]["User_ID"].ToString());


            string sql = "Select * from view_hoadon where User_ID=" + makh + "";
            dt = cs.getTable(sql);
            
            grdDonHang.PageIndex = e.NewPageIndex;
        }


        protected void grdDonHang_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string username = Request.Cookies["UserName"].Value;
            string password = Request.Cookies["Password"].Value;
            string userid = "Select * from tbLOGIN where UserName='" + username + "' and Password='" + password + "'";
            DataTable tb = cs.getTable(userid);

            int makh = Int16.Parse(dt.Rows[0]["User_ID"].ToString());

            string sql = "Select* from view_hoadon where User_ID='" + makh + "'";
            dt = cs.getTable(sql);
            double tong = 0; int soluong = 0;
            foreach (DataRow row in dt.Rows)
            {
                tong = Convert.ToDouble(row["TongTien"].ToString());
                soluong = soluong + Convert.ToInt16(row["SoLuongDat"]);
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lbltotal = (Label)e.Row.FindControl("lblTotal");
                lbltotal.Text = soluong.ToString();
                Label lbl_thanhtien = (Label)e.Row.FindControl("lblTotalMoney");
                lbl_thanhtien.Text = tong.ToString();
            }
           
        }
    }
}
