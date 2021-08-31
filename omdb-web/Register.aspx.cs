using Dapper;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            this.cmdRegister.ServerClick += new System.EventHandler(this.cmdRegister_ServerClick);
        }
        private void cmdRegister_ServerClick(object sender, System.EventArgs e)
        {

            if (validateUserInputAndCreateUser())
            {
                FormsAuthenticationTicket tkt;
                string cookiestr;
                HttpCookie ck;
                tkt = new FormsAuthenticationTicket(1, txtEmail.Value, DateTime.Now,
                DateTime.Now.AddMinutes(30), false, "your custom data");
                cookiestr = FormsAuthentication.Encrypt(tkt);
                ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
                ck.Path = FormsAuthentication.FormsCookiePath;
                Response.Cookies.Add(ck);

                string strRedirect = "Default.aspx";
                Response.Redirect(strRedirect, true);

            }
        }

        private bool validateUserInputAndCreateUser()
        {
            string email_address = txtEmail.Value;
            string password = txtPassword.Value;

            if(email_address != null && password != null)
            {
                var db = new omdb_dal.OmdbDatabase(ConfigurationManager.ConnectionStrings["OmdbDatabase"].ConnectionString).GetDatabase();
                User user = new User();
                user.Email_Address = email_address;
                user.Password = password;
                db.Execute("CreateUser", new
                {
                    user.Email_Address,
                    user.Password
                }, commandType: CommandType.StoredProcedure);

                return true;
            }

            return false;
        }

    }
}