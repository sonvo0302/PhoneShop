using PhoneShop.App_Code;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhoneShop.Staffs
{
    public partial class ThemSanPhamMoi : System.Web.UI.Page
    {
        COMMON cm = new COMMON();
        public String hinhanh;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            load_mau();
            load_nhomdanhmuc();
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("QLSanPham.aspx");
        }

        void load_mau()
        {
            string sql = "Select * from tbMAUSP";
            drp_mau.DataValueField = "Mau_ID";
            drp_mau.DataTextField = "TenMau";
            drp_mau.DataSource = cm.getTable(sql);
            drp_mau.DataBind();
        }

        void load_nhomdanhmuc()
        {
            string sql = "Select * from tbDANHMUC";
            dropdown_group.DataValueField = "DanhMuc_ID";
            dropdown_group.DataTextField = "TenDanhMuc";
            dropdown_group.DataSource = cm.getTable(sql);
            dropdown_group.DataBind();
        }
        protected void btn_save_Click(object sender, EventArgs e)
        {
            if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
            {
                if (CheckFileType(FileUpload1.FileName))
                {
                    try
                    {
                        string sFolderPath = Server.MapPath(@"/images/AnhDT");
                        HttpPostedFile myFile = FileUpload1.PostedFile;
                        string sFileName = myFile.FileName;
                        myFile.SaveAs(
                            string.Format(@"{0}\{1}", sFolderPath, sFileName));

                        string fn = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);

                        hinhanh = sFileName;

                        lblthongbao.Text = "Upload ảnh thành công!";
                        string tensp = txt_tensanpham.Value.ToString();
                        float dongia = float.Parse(txt_dongia.Value.ToString());
                        int soluong = Int16.Parse(txt_soluong.Value.ToString());
                        string mota = txt_mota.Value.ToString();
                        string mau = drp_mau.SelectedItem.Value.ToString();
                        string danhmuc = dropdown_group.SelectedItem.Value.ToString();
                        string sql = "Insert INTO tbSANPHAM(TenSanPham,DonGia,HinhAnh,SoLuong,MoTa,Mau_ID,DanhMuc_ID)values(N'" + tensp + "'," + dongia + ",'" + hinhanh + "'," + soluong + ",N'" + mota + "','" + mau + "','" + danhmuc + "')";
                        cm.ExecuteNonQuery(sql);

                        Response.Redirect("QLSanPham.aspx");
   
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Error: " + ex.Message);
                        //Note: Exception.Message returns a detailed message that describes the current exception. 
                        //For security reasons, we do not recommend that you return Exception.Message to end users in 
                        //production environments. It would be better to put a generic error message. 
                    }
                }
                else
                {
                    lblthongbao.Text = "Không đúng file.jpg!";
                }
                
            }
            else
            {
                lblthongbao.Text = ("Làm ơn chọn file!");
            }


          

        }
        private bool CheckFileType(string FileName)
        {
            string ext = Path.GetExtension(FileName);
            if (ext.Equals(".jpg"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
     
    }

}