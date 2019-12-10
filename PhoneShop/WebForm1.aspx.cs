using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhoneShop
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceReference1.ServiceClient ws = new ServiceReference1.ServiceClient();
           GridView1.DataSource= ws.getTableTree();
            GridView1.DataBind();
        }
    }
}