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

namespace omdb_web
{
    public partial class Login : System.Web.UI.Page
    {

        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    this.cmdSignOut.ServerClick += new System.EventHandler(this.cmdSignOut_ServerClick);
        //}


        //private void cmdSignOut_ServerClick(object sender, System.EventArgs e)
        //{
        //    FormsAuthentication.SignOut();
        //    Response.Redirect("Login.aspx", true);
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            this.cmdLogin.ServerClick += new System.EventHandler(this.cmdLogin_ServerClick);
        }

        private void cmdLogin_ServerClick(object sender, System.EventArgs e)
        {
            if (ValidateUser(txtEmail.Value, txtPassword.Value))
            {
                FormsAuthenticationTicket tkt;
                string cookiestr;
                HttpCookie ck;
                tkt = new FormsAuthenticationTicket(1, txtEmail.Value, DateTime.Now,
                DateTime.Now.AddMinutes(30), chkPersistCookie.Checked, "your custom data");
                cookiestr = FormsAuthentication.Encrypt(tkt);
                ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
                if (chkPersistCookie.Checked)
                    ck.Expires = tkt.Expiration;
                ck.Path = FormsAuthentication.FormsCookiePath;
                Response.Cookies.Add(ck);

                string strRedirect;
                strRedirect = Request["ReturnUrl"];
                if (strRedirect == null)
                    strRedirect = "Default.aspx";
                Response.Redirect(strRedirect, true);
            }
            else
                Response.Redirect("Login.aspx", true);
        }

        private bool ValidateUser(string email_address, string password)
        {
            var db = new omdb_dal.OmdbDatabase(ConfigurationManager.ConnectionStrings["OmdbDatabase"].ConnectionString).GetDatabase();

            User user = new User();
            user.Email_Address = email_address;
            user.Password = password;

            var data = db.Query("LoginUser", new
            {
                user.Email_Address,
                user.Password
            }, commandType: CommandType.StoredProcedure);

            if (data.Count() >= 1) return true;

            else return false;
        }
    }
}