using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhoneShop
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                if (CheckFileType(FileUpload1.FileName))
                {
                    FileUpload1.SaveAs(Server.MapPath("~/NewFolder1") + FileUpload1.FileName);
                    lblthongbao.Text = "Upload thành công";
                }
                else
                {
                    lblthongbao.Text = "Loại file không hợp lệ";
                }
            }
        }
    }
}