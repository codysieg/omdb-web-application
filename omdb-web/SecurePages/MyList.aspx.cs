using Dapper;
using omdb_dal;
using omdb_dal.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace omdb_web.SecurePages
{
    public partial class MyList : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            var OmdbDataBaseConnector = new OmdbDatabaseConnector(ConfigurationManager.ConnectionStrings["OmdbDatabase"].ConnectionString);

            APIDataList.DataSource = await OmdbDataBaseConnector.getFavouritesByUser();
            APIDataList.DataBind();
        }
    }
}