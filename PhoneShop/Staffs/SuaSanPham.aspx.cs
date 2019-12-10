using PhoneShop.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhoneShop.Staffs
{
    public partial class SuaSanPham : System.Web.UI.Page
    {
        COMMON cm = new COMMON();
        public string masp;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            load_mau();
            load_danhmuc();
            masp = Context.Items["masp"].ToString();
            string sql = "Select * from tbSANPHAM where SanPham_ID='" + masp + "'";
            DataTable dt = cm.getTable(sql);

            txt_spid.Value = masp;
            foreach (DataRow row in dt.Rows)
            {
                txt_tensp.Value = row["TenSanPham"].ToString();
                txt_dongia.Value = row["DonGia"].ToString();
                txt_soluong.Value = row["SoLuong"].ToString();
                txt_mota.Value = row["MoTa"].ToString();
                drp_mau.SelectedItem.Value = row["Mau_ID"].ToString();
                drp_DanhMuc.SelectedItem.Value = row["DanhMuc_ID"].ToString();
                Image1.ImageUrl = "/images/AnhDT/" + row["HinhAnh"].ToString();
            }

        }
        void load_mau()
        {
            string sql = "Select * from tbMAUSP";
            drp_mau.DataValueField = "Mau_ID";
            drp_mau.DataTextField = "TenMau";
            drp_mau.DataSource = cm.getTable(sql);
            drp_mau.DataBind();
        }
        void load_danhmuc()
        {
            string sql = "Select * from tbDANHMUC";
            drp_DanhMuc.DataValueField = "DanhMuc_ID";
            drp_DanhMuc.DataTextField = "TenDanhMuc";
            drp_DanhMuc.DataSource = cm.getTable(sql);
            drp_DanhMuc.DataBind();
        }

     

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("QLSanPham.aspx");       
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {


            string tensp = txt_tensp.Value.ToString();
            float dongia =float.Parse( txt_dongia.Value.ToString());
            int soluong = Int16.Parse(txt_soluong.Value.ToString());
            string mota = txt_mota.Value.ToString();
            string mau_id = drp_mau.SelectedItem.Value.ToString();
            string danhmuc_id = drp_DanhMuc.SelectedItem.Value.ToString();
            string sql = "Update tbSANPHAM set TenSanPham=N'"+tensp+"',DonGia="+dongia+",SoLuong="+soluong+",MoTa='"+mota+"',Mau_ID='"+mau_id+"',DanhMuc_ID='"+danhmuc_id+"' where SanPham_ID='"+txt_spid.Value+"'";
            cm.ExecuteNonQuery(sql);
            Server.Transfer("QLSanPham.aspx");
        }
    }
}