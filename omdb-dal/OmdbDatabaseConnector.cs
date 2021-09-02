using Dapper;
using omdb_dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace omdb_dal
{
    public class OmdbDatabaseConnector : OmdbDatabase
    {
        public string ConnString { get; set; }

        public OmdbDatabaseConnector(string connectionString) : base(connectionString) { this.ConnString = connectionString; }

        public void createUser(string emailAddress, string password)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Email_Address", emailAddress);
            parameters.Add("@Password", password);
            DapperNonQuery("CreateUser", parameters);

        }
        public bool authenticateUser(string emailAddress, string password)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Email_Address", emailAddress);
            parameters.Add("@Password", password);
            User user = DapperItemQuery<User>("LoginUser", parameters);

            if(user == null)
            {
                return false;
            }

            return true;
        }
        
        public async Task<List<Movie>> getFavouritesByUser()
        {
            if ((HttpContext.Current.User != null) && HttpContext.Current.User.Identity.IsAuthenticated)
            {
                string userEmail = HttpContext.Current.User.Identity.Name;

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Email_Address", userEmail);
                List<Movie> data = DapperListQuery<Movie>("GetFavouritesByUser", parameters).AsList<Movie>();

                List<Movie> movies = new List<Movie>();
                foreach (Movie m in data)
                {
                    Movie movie = await HTTPConnector.getAPIByImdbId(m.ImdbID);
                    movies.Add(movie);
                }

                return movies;
            }
            else
            {
                return null;
            }
        }

        public bool getFavouriteStatusByImdbId(string ImdbId)
        {
            if ((HttpContext.Current.User != null) && HttpContext.Current.User.Identity.IsAuthenticated)
            {
                string userEmail = HttpContext.Current.User.Identity.Name;

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Email_Address", userEmail);
                parameters.Add("@ImdbId", ImdbId);

                List<Movie> data = DapperListQuery<Movie>("GetFavouriteStatusById", parameters).AsList<Movie>();

                return data.Count > 0;
            }

            else
            {
                return false;
            }
        }

        public void addFavouriteToMyList(string ImdbId)
        {
            if ((HttpContext.Current.User != null) && HttpContext.Current.User.Identity.IsAuthenticated)
            {
                string userEmail = HttpContext.Current.User.Identity.Name;

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Email_Address", userEmail);
                parameters.Add("@ImdbId", ImdbId);

                DapperNonQuery("AddToMyList", parameters);
            }
        }

        public void removeFavouriteFromMyList(string ImdbId)
        {
            if ((HttpContext.Current.User != null) && HttpContext.Current.User.Identity.IsAuthenticated)
            {
                string userEmail = HttpContext.Current.User.Identity.Name;

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Email_Address", userEmail);
                parameters.Add("@ImdbId", ImdbId);

                DapperNonQuery("RemoveFromMyList", parameters);
            }
        }
    }
}