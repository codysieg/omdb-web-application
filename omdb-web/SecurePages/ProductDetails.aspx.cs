using omdb_dal.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using omdb_dal;
using Dapper;
using System.Data;
using System.Configuration;

namespace omdb_web
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String IMDBId = Request.QueryString["IMDBId"];

                if (IMDBId == null)
                {
                    Response.Redirect("~/", false);
                    Context.ApplicationInstance.CompleteRequest();
                }

                List<Movie> movie = new List<Movie> { await HTTPConnector.getSpecificContentFromAPI(IMDBId) };
                IndividualContent.DataSource = movie;
                IndividualContent.DataBind();

                //Get the seasons and episodes in the seasons and show that information on the Product Details page

                //Initially fetch how many seasons are in the show. API is poopy.
                int numOfSeasons = await HTTPConnector.getNumberOfSeasonsFromAPI(IMDBId);

                if (numOfSeasons <= 0)
                {
                    SeasonDropDownList.Visible = false;
                }

                List<String> series = new List<String>();

                for (int i = 1; i <= numOfSeasons; i++)
                {

                    List<Episode> episodes = new List<Episode>();

                    if (await HTTPConnector.getSeasonByIDFromAPI(IMDBId, i) != null)
                    {
                        //Add option to dropdown
                        series.Add("Season: " + i);
                    }

                }

                SeasonDropDownList.DataSource = series;
                SeasonDropDownList.DataBind();
            }


        }

        protected async void SeasonDropDownList_ShowSeasonData(object sender, EventArgs e)
        {
            String IMDBId = Request.QueryString["IMDBId"];
            //Season: xx

            int seasonNumber = -1;
            if (SeasonDropDownList.SelectedValue.Length > 0)
            {
                SeasonEpisodesListView.Visible = true;

                seasonNumber = Int32.Parse(SeasonDropDownList.SelectedValue.Substring(7));

                List<Episode> episodes = new List<Episode>();

                episodes = (await HTTPConnector.getSeasonByIDFromAPI(IMDBId, seasonNumber)).Episodes;

                SeasonEpisodesListView.DataSource = episodes;
                SeasonEpisodesListView.DataBind();
            }

            else
            {
                SeasonEpisodesListView.Visible = false;
            }

        }

        protected void SeasonDropDownList_DataBound(object sender, EventArgs e)
        {
            SeasonDropDownList.Items.Insert(0, new ListItem("Select a Season", ""));
        }

        protected void AddToMyListButtonID_Click(object sender, EventArgs e)
        {
            string IMDBId = Request.QueryString["IMDBId"];
            if ((HttpContext.Current.User != null) && HttpContext.Current.User.Identity.IsAuthenticated)
            {
                string userEmail = HttpContext.Current.User.Identity.Name;

                //Add IMDB to UserList table
                var db = new omdb_dal.OmdbDatabase(ConfigurationManager.ConnectionStrings["OmdbDatabase"].ConnectionString).GetDatabase();
                db.Execute("AddToMyList", new
                {
                    @Email_Address = userEmail,
                    @ImdbId = IMDBId
                }, commandType: CommandType.StoredProcedure);

            }
            else
            {

            }

        }

        protected void RemoveFromMyListButtonID_Click(object sender, EventArgs e)
        {
            string IMDBId = Request.QueryString["IMDBId"];
            if ((HttpContext.Current.User != null) && HttpContext.Current.User.Identity.IsAuthenticated)
            {
                string userEmail = HttpContext.Current.User.Identity.Name;

                //Remove IMDB from UserList table
                var db = new omdb_dal.OmdbDatabase(ConfigurationManager.ConnectionStrings["OmdbDatabase"].ConnectionString).GetDatabase();
                db.Execute("RemoveFromMyList", new
                {
                    @Email_Address = userEmail,
                    @ImdbId = IMDBId
                }, commandType: CommandType.StoredProcedure);

            }
            else
            {

            }

        }

    }
}
