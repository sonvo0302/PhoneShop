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
    public partial class GioHang : System.Web.UI.Page
    {
        COMMON cs = new COMMON();
        DataTable dt;
        public String strThanhtoan = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            docDL();
           
        }
        private void docDL()
        {
            dt = (DataTable)Session["tbGiohang"];
            grdGIOHANG.DataSource = dt;
            grdGIOHANG.DataBind();
            if (Request.Cookies["UserName"] == null)
            {
                
                if (grdGIOHANG.Rows.Count == 0)
                {
                    this.Label1.Text = "";
                    this.Label2.Text = "Giỏ hàng trống";
                    this.Label3.Text = "";
                    strThanhtoan += " <span class='float-right'><a data-modal='modalOne' class='btn btn-primary btn-danger'>Thanh toán</a></span>";
                }
                else
                {
                    grdGIOHANG.DataSource = dt;

                    double tong = 0;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        double thanhtien = Convert.ToDouble(dt.Rows[i]["SoLuong"]) * Convert.ToDouble(dt.Rows[i]["DonGia"]);
                        dt.Rows[i]["ThanhTien"] = Math.Round(thanhtien) + "";
                        tong += thanhtien;
                    }

                    grdGIOHANG.DataBind();
                    this.Label2.Text = " " + tong + " ";
                    strThanhtoan += "<a data-modal='modalOne' class='btn btn-primary btn-danger'>Thanh toán</a>";
                }      
            }
            else
            {
                if (grdGIOHANG.Rows.Count == 0)
                {
                    this.Label1.Text = "";
                    this.Label2.Text = "Mời bạn thêm sản phẩm vào giỏ hàng";
                    this.Label3.Text = "";
                    strThanhtoan += "<a href='/GioHang.aspx' class='btn btn-primary btn-danger' >Thanh toán</a>";
                }
                else
                {
                    grdGIOHANG.DataSource = dt;

                    double tong = 0;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        double thanhtien = Convert.ToDouble(dt.Rows[i]["SoLuong"]) * Convert.ToDouble(dt.Rows[i]["DonGia"]);
                        dt.Rows[i]["ThanhTien"] = Math.Round(thanhtien) + "";
                        tong += thanhtien;
                    }

                    grdGIOHANG.DataBind();
                    this.Label2.Text = " " + tong + " ";

                    strThanhtoan += "<a href='../DatHang.aspx' class='btn btn-primary btn-danger'>Thanh toán</a>";
                }
            }
        }


        //protected void btnTHANHTOAN_Click(object sender, EventArgs e)
        //{
        //    if (Request.Cookies["UserName"] == null)
        //    {
        //        string script = "alert(\"Bạn chưa đăng nhập!\");";
        //        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
               
        //    }
        //    Response.Redirect("~/DatHang.aspx");
        //    //dt = (DataTable)Session["tbGiohang"];
        //    //if (Request.Cookies["UserName"] == null) Server.Transfer("Login.aspx");
        //    //string username = Request.Cookies["UserName"].Value;
        //    //string password = Response.Cookies["Password"].Value;

        //    //String mahang = "";
        //    //int soluong = 0;
        //    //double dongia = 0;
        //    //double tongtien = 0;

        //    //string sql1, sql;
        //    //for (int i = 0; i < dt.Rows.Count; i++)
        //    //{
        //    //    mahang = dt.Rows[i]["SanPham_ID"].ToString();
        //    //    soluong = Convert.ToInt32(dt.Rows[i]["SoLuong"]);
        //    //    dongia = Convert.ToDouble(dt.Rows[i]["DonGia"]);
        //    //    tongtien = Convert.ToDouble(dt.Rows[i]["ThanhTien"]);
        //    //}

        //    //string q = "Select HD_ID from tbHOADON where UserName = '" + username + "'";
        //    //DataTable tb = cs.getTable(q);

        //    //sql1 = "Insert into tbHOADON(UserName,TongTien) values('" + username + "'," + tongtien + ") SELECT SCOPE_IDENTITY();";
        //    ////cs.ExecuteNonQuery(sql1);
        //    //string q1 = cs.reader(sql1);
        //    //sql = "Insert into tbCHITIETHOADON(HD_ID,SanPham_ID,SoLuong,DonGia) values('" + q1 + "','" + mahang + "'," + soluong + "," + dongia + ")";
        //    //cs.ExecuteNonQuery(sql);

        //    //this.docDL();

        //}
        protected void btnTRAHANG_Click(object sender, EventArgs e)
        {
             dt = (DataTable)Session["tbGiohang"];
            for (int i = this.grdGIOHANG.Rows.Count - 1; i >= 0; i--)
            {
                CheckBox ckb = null;
                GridViewRow grow = this.grdGIOHANG.Rows[i];
                if (grow.FindControl("ckbTRAHANG") is CheckBox)
                    ckb = (CheckBox)grow.FindControl("ckbTRAHANG");
                if (ckb.Checked == true)
                {
                    dt.Rows.RemoveAt(i);

                }
            }
            Session["tbGiohang"] = dt;
            this.grdGIOHANG.DataSource = dt;
            this.grdGIOHANG.DataBind();
            this.docDL();
            //if (Session["tbGiohang"] != null)
            //{
            //    // Opening / Retreiving DataTable.
            //    dt = (DataTable)Session["tbGiohang"];

            //    foreach (GridViewRow row in grdGIOHANG.Rows)
            //    {
            //        CheckBox cbk_xoa = row.Cells[0].FindControl("ckbTRAHANG") as CheckBox;

            //        if (cbk_xoa != null && cbk_xoa.Checked)
            //        {
            //            int sanphamid = Convert.ToInt32(grdGIOHANG.DataKeys[row.RowIndex].Value);
            //            DataRow[] drs = dt.Select("SanPham_ID = '" + sanphamid + "'");
            //            if (drs.Length > 0)
            //            {
            //                dt.Rows.Remove(drs[0]);
            //            }
            //            //Saving session
            //            Session["tbGiohang"] = dt;
            //            // Updating grdGioHang
            //            grdGIOHANG.DataSource = dt;
            //            grdGIOHANG.DataBind();
            //        }
            //    }
            //    this.docDL();
            //}
        }

        protected void btn_Sua_Click(object sender, EventArgs e)
        {
            dt = (DataTable)Session["tbGiohang"];
            foreach (GridViewRow r in grdGIOHANG.Rows)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (int.Parse(grdGIOHANG.DataKeys[r.DataItemIndex].Value.ToString()) == int.Parse(dr["SanPham_ID"].ToString()))
                    {
                        TextBox t = (TextBox)r.Cells[4].FindControl("TextBox1");
                        if (Convert.ToInt32(t.Text) <= 0)
                            dt.Rows.Remove(dr);
                        else
                            dr["SoLuong"] = t.Text;
                        break;
                    }
                }
            }
            Session["tbGiohang"] = dt;
            Response.Redirect("Giohang.aspx");

        }
    
        public void RefreshPages()
        {
            if (Session["tbGiohang"] != null)
            {
                dt = (DataTable)Session["tbGiohang"];
                grdGIOHANG.DataSource = dt;
                grdGIOHANG.DataBind();
            }
        }
        
        protected void btnTIEPTUCMUAHANG_Click(object sender, EventArgs e)
        {
            Server.Transfer("DanhSachMatHang.aspx");
        }

        protected void btn_dangnhap_Click(object sender, EventArgs e)
        {
            string userName = user_name.Value.ToString();
            string Password = MaHoaMD5.Encryptdata(password_c.Value.ToString());
            string sql = "Select * from tbLOGIN where UserName = '" + userName + "' and Password='" + Password + "'";
            DataTable tb = cs.getTable(sql);

            if (tb.Rows.Count != 0)
            {
                Response.Cookies["UserName"].Value = userName;
                Response.Cookies["Password"].Value = Password;
                Session["user"] = userName.ToString();
                Response.Redirect("GioHang.aspx");
            }
            else
            {
                string script = "alert(\"Lỗi đăng nhập!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
        }
    }
}
