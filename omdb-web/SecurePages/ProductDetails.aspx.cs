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

                Movie movie = await HTTPConnector.getSpecificContentFromAPI(IMDBId);

                //Check to see if an error was returned from the API
                //If so, display a message (bind null to the movie object
                // to display the EmptyDataTemplate view.

                //Would like to do this a different way (take to an error page maybe?)
                //This is a bad way to do it cause I have to handle hiding all the buttons.
                if (movie == null || movie.Error != null)
                {
                    IndividualContent.DataSource = null;
                    IndividualContent.DataBind();
                    AddToMyListButtonID.Visible = false;
                    RemoveFromMyListButtonID.Visible = false;
                    SeasonDropDownList.Visible = false;
                }
                else
                {
                    IndividualContent.DataSource = new List<Movie> { movie };
                    IndividualContent.DataBind();

                    //Check to see if this movie you are currently on is added to My List.
                    getMyListStatusForMovie(IMDBId);

                    //Get the seasons and episodes in the seasons and show that information on the Product Details page
                    //Initially fetch how many seasons are in the show. API is poopy.
                    handleSeasonDropdownDataBinding(IMDBId);
                }

            }
        }

        private void getMyListStatusForMovie(String ImdbId)
        {
            var OmdbDataBaseConnector = new OmdbDatabaseConnector(ConfigurationManager.ConnectionStrings["OmdbDatabase"].ConnectionString);

            if (OmdbDataBaseConnector.getFavouriteStatusByImdbId(ImdbId))
            {
                AddToMyListButtonID.Visible = false;
                RemoveFromMyListButtonID.Visible = true;
            }
            else
            {
                AddToMyListButtonID.Visible = true;
                RemoveFromMyListButtonID.Visible = false;
            }
        }

        /**
         * Handlers for Drop down & Click events / data-binding that occur on the page.
         */
        protected void SeasonDropDownList_DataBound(object sender, EventArgs e)
        {
            SeasonDropDownList.Items.Insert(0, new ListItem("Select a Season", ""));
        }

        private async void handleSeasonDropdownDataBinding(string IMDBId)
        {
            int numOfSeasons = await HTTPConnector.getNumberOfSeasonsFromAPI(IMDBId);
            if (numOfSeasons <= 0)
            {
                SeasonDropDownList.Visible = false;
            }

            List<string> series = new List<string>();

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

        protected async void SeasonDropDownList_ShowSeasonData(object sender, EventArgs e)
        {
            String IMDBId = Request.QueryString["IMDBId"];
            int seasonNumber = -1;

            if (SeasonDropDownList.SelectedValue.Length > 0)
            {
                SeasonEpisodesListView.Visible = true;

                //API returns Season: xx, need to parse from 7th character on to end.
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

        protected void AddToMyListButtonID_Click(object sender, EventArgs e)
        {
            string ImdbId = Request.QueryString["IMDBId"];

            var OmdbDataBaseConnector = new OmdbDatabaseConnector(ConfigurationManager.ConnectionStrings["OmdbDatabase"].ConnectionString);
            OmdbDataBaseConnector.addFavouriteToMyList(ImdbId);

            AddToMyListButtonID.Visible = false;
            RemoveFromMyListButtonID.Visible = true;
        }

        protected void RemoveFromMyListButtonID_Click(object sender, EventArgs e)
        {
            string ImdbId = Request.QueryString["IMDBId"];

            var OmdbDataBaseConnector = new OmdbDatabaseConnector(ConfigurationManager.ConnectionStrings["OmdbDatabase"].ConnectionString);
            OmdbDataBaseConnector.removeFavouriteFromMyList(ImdbId);

            AddToMyListButtonID.Visible = true;
            RemoveFromMyListButtonID.Visible = false;
        }
        protected string GetImagePathOrDefault(string imagePath)
        {
            if (imagePath.Equals("N/A"))
            {
                return "~/Content/Images/no-image-found.png";
            }
            else
            {
                return imagePath;
            }
        }
    }
}
