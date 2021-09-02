using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace omdb_web
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.Compare(Request.Url.LocalPath, "/") == 0 || string.Compare(Request.Url.LocalPath, "/Default.aspx") == 0 || string.Compare(Request.Url.LocalPath, "/default.aspx") == 0 || string.Compare(Request.Url.LocalPath, "/Default") == 0)
            {
                SearchBoxContainer.Visible = false;
            }
            if (string.Compare(Request.Url.LocalPath, "/Login.aspx") == 0 || string.Compare(Request.Url.LocalPath, "/Login") == 0)
            {
                SearchBoxContainer.Visible = false;
            }
            if (string.Compare(Request.Url.LocalPath, "/Register.aspx") == 0 || string.Compare(Request.Url.LocalPath, "/Register") == 0)
            {
                SearchBoxContainer.Visible = false;
            }

            if (string.Compare(Request.Url.LocalPath, "/SecurePages/MyList.aspx") == 0 || string.Compare(Request.Url.LocalPath, "/SecurePages/MyList") == 0)
            {
                SearchBoxContainer.Visible = false;
            }

            /**
             * If authenticated, hide Login button.
             */
            if ((HttpContext.Current.User != null) && HttpContext.Current.User.Identity.IsAuthenticated) {
                LoginDiv.Visible = false;
                LogoutDiv.Visible = true;
                MyListID.Visible = true;
                CurrentEmailLabel.Text = "Welcome, " + HttpContext.Current.User.Identity.Name;
            }
            else
            {
                MyListID.Visible = false;
                LogoutDiv.Visible = false;
            }

            this.cmdSignOut.ServerClick += new System.EventHandler(this.cmdSignOut_ServerClick);
        }

        protected void SearchBox_Submitted(object sender, EventArgs e)
        {
            String typeOfContent = Request.QueryString["type"];
            String search = SearchBox.Text;
            Response.Redirect("~/SecurePages/ProductList.aspx?search=" + search + "&type=" + typeOfContent + "&page=1", false);
            Context.ApplicationInstance.CompleteRequest();
        }

        private void cmdSignOut_ServerClick(object sender, System.EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Default.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}