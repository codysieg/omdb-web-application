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

namespace omdb_web
{
    public partial class ProductList : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            /**
             * Fetch Query Parameters
             * 
             * type - movie || series
             * search - search query
             * page - page number
             */
            string typeOfContent = Request.QueryString["type"];
            string searchQuery = Request.QueryString["search"];
            string pageNumber = Request.QueryString["page"];
            int numberOfPages;

            if (typeOfContent == null)
            {
                Response.Redirect("~/", false);
                Context.ApplicationInstance.CompleteRequest();
            }

            //On the first page load, searchQuery will be null, so use "first" as a query param for movies and series.
            //Search by title and search
            //Fix this - create new endpoint for searching by title, this cannot have pagination.
            Movies movies = await omdb_dal.HTTPConnector.getAPIByTitleAndType(searchQuery, typeOfContent, pageNumber);
            movies.movies = addFavouriteStatusToMovies(movies.movies);
            APIDataList.DataSource = movies.movies;
            APIDataList.DataBind();
            numberOfPages = (int)(movies.TotalResults / 10.0) + 1;

            PaginationInfoLabel.Text = "Page " + pageNumber + " of " + numberOfPages;

            PaginationUserControl.typeOfContent = typeOfContent;
            PaginationUserControl.searchQuery = searchQuery;
            PaginationUserControl.pageNumber = pageNumber;
            PaginationUserControl.numberOfPages = numberOfPages.ToString();
        }

        private List<Movie> addFavouriteStatusToMovies(List<Movie> movieData)
        {
            if ((HttpContext.Current.User != null) && HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var db = new omdb_dal.OmdbDatabase(ConfigurationManager.ConnectionStrings["OmdbDatabase"].ConnectionString).GetDatabase();
                string userEmail = HttpContext.Current.User.Identity.Name;

                foreach (Movie m in movieData)
                {
                    string imdb = m.ImdbID;
                    var data = db.Query<Movie>("GetFavouriteStatusById", new
                    {
                        @Email_Address = userEmail,
                        @ImdbId = imdb
                    }, commandType: CommandType.StoredProcedure).ToList();

                    if(data.Count > 0)
                    {
                        m.isFavourited = true;
                    }
                    else
                    {
                        m.isFavourited = false;
                    }
                }

                return movieData;
            }
            else
            {
                return movieData;
            }
        }
    }
}