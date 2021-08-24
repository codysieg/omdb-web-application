using omdb_dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace omdb_web
{
    public partial class ProductList : System.Web.UI.Page
    {
        public static string APIContentType;
        public static string APIContentTitle;
        public static string APIPageNumber;
        public static int numberOfPages;
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /**
                 * Fetch Query Parameters
                 * 
                 * type - movie || series
                 * search - search query
                 * page - page number
                 */
                APIContentType = Request.QueryString["type"];
                APIContentTitle = Request.QueryString["search"];
                APIPageNumber = Request.QueryString["page"];

                if (APIContentType == null)
                {
                    Response.Redirect("~/", false);
                    Context.ApplicationInstance.CompleteRequest();
                }

                /**
                 * Default API call when no search parameters are passed in. - search query param will be empty.
                 */
                if (APIContentTitle == null || APIContentTitle.Equals(""))
                {
                    //Initial API call for both movies / series selection. "First". API requires a title search or an IMDB ID search.
                    Movies movies = await omdb_dal.HTTPConnector.getAPIByTitleAndType("first", APIContentType, APIPageNumber);
                    numberOfPages = (int)(movies.TotalResults / 10.0) + 1;
                    APIDataList.DataSource = movies.movies;
                    APIDataList.DataBind();

                    paginationControl.APIPageNumber = APIPageNumber;
                    paginationControl.APIContentType = APIContentType;
                    paginationControl.numberOfPages = numberOfPages.ToString();
                }
                else
                {
                    //Search by title and search
                    //Fix this - create new endpoint for searching by title, this cannot have pagination.
                    Movies movies = await omdb_dal.HTTPConnector.getAPIByTitleAndType(APIContentTitle, APIContentType, APIPageNumber);
                    APIDataList.DataSource = movies.movies;
                    APIDataList.DataBind();
                    numberOfPages = (int)(movies.TotalResults / 10.0) + 1;

                    paginationControl.APIPageNumber = APIPageNumber;
                    paginationControl.APIContentType = APIContentType;
                    paginationControl.numberOfPages = numberOfPages.ToString();

                }

                Page.DataBind();
            }
        }

        protected void PaginationTextBox_TextChanged(object sender, EventArgs e)
        {
            String page = PaginationTextBox.Text;

            if (page != null && page != "")
            {
                if (APIContentTitle == null || APIContentTitle == "")
                {
                    Response.Redirect("~/ProductList.aspx?type=" + APIContentType + "&page=" + page, false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                else
                {
                    Response.Redirect("~/ProductList.aspx?type=" + APIContentType + "&page=" + page + "&search=" + APIContentTitle, false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
        }
    }
}