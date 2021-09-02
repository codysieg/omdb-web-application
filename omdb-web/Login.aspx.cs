using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Security;
using System.Configuration;
using omdb_dal.Models;
using Dapper;
using System.Data;
using omdb_dal;

namespace omdb_web
{
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            this.cmdLogin.ServerClick += new System.EventHandler(this.cmdLogin_ServerClick);
        }

        private void cmdLogin_ServerClick(object sender, System.EventArgs e)
        {
            if (authenticateUser(txtEmail.Value, txtPassword.Value))
            {
                //Create Cookie to store in Client Browser for session.
                FormsAuthenticationTicket tkt = new FormsAuthenticationTicket(1, txtEmail.Value, DateTime.Now, DateTime.Now.AddMinutes(30), chkPersistCookie.Checked, "your custom data");
                string cookiestr = FormsAuthentication.Encrypt(tkt);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
                if (chkPersistCookie.Checked)
                    cookie.Expires = tkt.Expiration;
                cookie.Path = FormsAuthentication.FormsCookiePath;
                Response.Cookies.Add(cookie);

                string strRedirect = Request["ReturnUrl"];
                if (strRedirect == null)
                    strRedirect = "~/Default.aspx";

                Response.Redirect(strRedirect, true);
            }
            else
                Response.Redirect("Login.aspx", true);
        }

        private bool authenticateUser(string emailAddress, string password)
        {
            var OmdbDataBaseConnector = new OmdbDatabaseConnector(ConfigurationManager.ConnectionStrings["OmdbDatabase"].ConnectionString);

            return OmdbDataBaseConnector.authenticateUser(emailAddress, password);
        }
    }
}