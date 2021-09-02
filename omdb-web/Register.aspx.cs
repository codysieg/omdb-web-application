using Dapper;
using omdb_dal;
using omdb_dal.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace omdb_web
{
    public partial class Register : System.Web.UI.Page
    {
        /**
         * TODO: Before registering a user, validate that a user does not exist with that email address.
         */
        protected void Page_Load(object sender, EventArgs e)
        {
            this.cmdRegister.ServerClick += new System.EventHandler(this.cmdRegister_ServerClick);
        }
        private void cmdRegister_ServerClick(object sender, System.EventArgs e)
        {

            string emailAddress = txtEmail.Value;
            string password = txtPassword.Value;

            if (validateUserInput(emailAddress, password))
            {
                createUser(emailAddress, password);

                FormsAuthenticationTicket tkt = new FormsAuthenticationTicket(1, txtEmail.Value, DateTime.Now, DateTime.Now.AddMinutes(30), false, "your custom data");
                string cookiestr = FormsAuthentication.Encrypt(tkt);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
                cookie.Path = FormsAuthentication.FormsCookiePath;
                Response.Cookies.Add(cookie);

                string strRedirect = "Default.aspx";
                Response.Redirect(strRedirect, true);
            }
        }

        private bool validateUserInput(string emailAddress, string password)
        {

            if(emailAddress != null && password != null)
            {
                return true;
            }

            return false;
        }

        private void createUser(string emailAddress, string password)
        {
            var OmdbDataBaseConnector = new OmdbDatabaseConnector(ConfigurationManager.ConnectionStrings["OmdbDatabase"].ConnectionString);

            OmdbDataBaseConnector.createUser(emailAddress, password);
        }

    }
}