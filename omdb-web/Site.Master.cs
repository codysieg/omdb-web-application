using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace omdb_web
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.Compare(Request.Url.LocalPath, "/default.aspx") == 0 || string.Compare(Request.Url.LocalPath, "/Default") == 0 || string.Compare(Request.Url.LocalPath, "/") == 0)
            {
                SearchBoxContainer.Visible = false;
            }
        }

        protected void SearchBox_Submitted(object sender, EventArgs e)
        {
            String APIContentType = Request.QueryString["type"];
            String search = SearchBox.Text;
            Response.Redirect("~/ProductList.aspx?type=" + APIContentType + "&page=1" + "&search=" + search, false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}