using Dapper;
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

            var db = new omdb_dal.OmdbDatabase(ConfigurationManager.ConnectionStrings["OmdbDatabase"].ConnectionString).GetDatabase();

            if ((HttpContext.Current.User != null) && HttpContext.Current.User.Identity.IsAuthenticated)
            {
                string userEmail = HttpContext.Current.User.Identity.Name;
                var data = db.Query<Movie>("GetFavouritesByUser", new
                {
                    @Email_Address = userEmail
                }, commandType: CommandType.StoredProcedure).ToList();

                Movies movies = new Movies();
                movies.movies = new List<Movie>();
                foreach(Movie m in data)
                {
                    Movie movie = await omdb_dal.HTTPConnector.getAPIByImdbId(m.ImdbID);
                    movies.movies.Add(movie);
                }

                APIDataList.DataSource = movies.movies;
                APIDataList.DataBind();

            }
        }
    }
}