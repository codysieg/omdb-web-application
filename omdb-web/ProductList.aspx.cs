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
                APIContentType = Request.QueryString["type"];
                APIContentTitle = Request.QueryString["search"];
                APIPageNumber = Request.QueryString["page"];

                if (APIContentType == null)
                {
                    Response.Redirect("~/", false);
                    Context.ApplicationInstance.CompleteRequest();
                }

                if (APIContentTitle == null || APIContentTitle.Equals(""))
                {
                    Movies movies = null;
                    switch (APIContentType)
                    {
                        case "movie":
                            movies = await omdb_dal.HTTPConnector.getAPIByTitleAndType("movie", APIContentType, APIPageNumber);
                            numberOfPages = (int)(movies.TotalResults / 10.0) + 1;
                            APIDataList.DataSource = movies.movies;
                            APIDataList.DataBind();
                            break;
                        case "series":
                            movies = await omdb_dal.HTTPConnector.getAPIByTitleAndType("how", APIContentType, APIPageNumber);
                            APIDataList.DataSource = movies.movies;
                            numberOfPages = (int)(movies.TotalResults / 10.0) + 1;
                            APIDataList.DataBind();
                            break;
                        default:
                            break;
                    }

                    //First
                    HyperLink firstLink = new HyperLink();
                    firstLink.CssClass = "glyphicon glyphicon-fast-backward";
                    firstLink.NavigateUrl = "ProductList.aspx?type=" + APIContentType + "&page=" + 1;
                    PaginationPlaceholder.Controls.Add(firstLink);

                    //Previous
                    HyperLink previousLink = new HyperLink();
                    previousLink.CssClass = "glyphicon glyphicon-backward";
                    previousLink.NavigateUrl = "ProductList.aspx?type=" + APIContentType + "&page=" + (int.Parse(APIPageNumber) - 1);
                    PaginationPlaceholder.Controls.Add(previousLink);

                    //Next
                    HyperLink nextLink = new HyperLink();
                    nextLink.CssClass = "glyphicon glyphicon-forward";
                    nextLink.NavigateUrl = "ProductList.aspx?type=" + APIContentType + "&page=" + (int.Parse(APIPageNumber) + 1);
                    PaginationPlaceholder.Controls.Add(nextLink);

                    //Last
                    HyperLink lastLink = new HyperLink();
                    lastLink.CssClass = "glyphicon glyphicon-fast-forward";
                    lastLink.NavigateUrl = "ProductList.aspx?type=" + APIContentType + "&page=" + numberOfPages;
                    PaginationPlaceholder.Controls.Add(lastLink);

                    if (APIPageNumber.Equals("1"))
                    {
                        firstLink.Visible = false;
                        previousLink.Visible = false;
                    }

                    else if (APIPageNumber.Equals(numberOfPages.ToString()))
                    {
                        nextLink.Visible = false;
                        lastLink.Visible = false;
                    }
                }
                else
                {
                    //Search by title and search
                    //Fix this - create new endpoint for searching by title, this cannot have pagination.
                    Movies movies = await omdb_dal.HTTPConnector.getAPIByTitleAndType(APIContentTitle, APIContentType, APIPageNumber);
                    APIDataList.DataSource = movies.movies;
                    APIDataList.DataBind();
                    numberOfPages = (int)(movies.TotalResults / 10.0) + 1;

                    //First
                    HyperLink firstLink = new HyperLink();
                    firstLink.CssClass = "glyphicon glyphicon-fast-backward";
                    firstLink.NavigateUrl = "ProductList.aspx?type=" + APIContentType + "&page=" + 1 + "&search=" + APIContentTitle;
                    PaginationPlaceholder.Controls.Add(firstLink);

                    //Previous
                    HyperLink previousLink = new HyperLink();
                    previousLink.CssClass = "glyphicon glyphicon-backward";
                    previousLink.NavigateUrl = "ProductList.aspx?type=" + APIContentType + "&page=" + (int.Parse(APIPageNumber) - 1) + "&search=" + APIContentTitle;
                    PaginationPlaceholder.Controls.Add(previousLink);

                    //Next
                    HyperLink nextLink = new HyperLink();
                    nextLink.CssClass = "glyphicon glyphicon-forward";
                    nextLink.NavigateUrl = "ProductList.aspx?type=" + APIContentType + "&page=" + (int.Parse(APIPageNumber) + 1) + "&search=" + APIContentTitle;
                    PaginationPlaceholder.Controls.Add(nextLink);

                    //Last
                    HyperLink lastLink = new HyperLink();
                    lastLink.CssClass = "glyphicon glyphicon-fast-forward";
                    lastLink.NavigateUrl = "ProductList.aspx?type=" + APIContentType + "&page=" + numberOfPages + "&search=" + APIContentTitle;
                    PaginationPlaceholder.Controls.Add(lastLink);

                    if (APIPageNumber.Equals("1"))
                    {
                        firstLink.Visible = false;
                        previousLink.Visible = false;
                    }

                    else if (APIPageNumber.Equals(numberOfPages.ToString()))
                    {
                        nextLink.Visible = false;
                        lastLink.Visible = false;
                    }
                }

                Page.DataBind();
            }

            else
            {
                if (APIContentTitle == null || APIContentTitle.Equals(""))
                {
                    //First
                    HyperLink firstLink = new HyperLink();
                    firstLink.CssClass = "glyphicon glyphicon-fast-backward";
                    firstLink.NavigateUrl = "ProductList.aspx?type=" + APIContentType + "&page=" + 1;
                    PaginationPlaceholder.Controls.Add(firstLink);

                    //Previous
                    HyperLink previousLink = new HyperLink();
                    previousLink.CssClass = "glyphicon glyphicon-backward";
                    previousLink.NavigateUrl = "ProductList.aspx?type=" + APIContentType + "&page=" + (int.Parse(APIPageNumber) - 1);
                    PaginationPlaceholder.Controls.Add(previousLink);

                    //Next
                    HyperLink nextLink = new HyperLink();
                    nextLink.CssClass = "glyphicon glyphicon-forward";
                    nextLink.NavigateUrl = "ProductList.aspx?type=" + APIContentType + "&page=" + (int.Parse(APIPageNumber) + 1);
                    PaginationPlaceholder.Controls.Add(nextLink);

                    //Last
                    HyperLink lastLink = new HyperLink();
                    lastLink.CssClass = "glyphicon glyphicon-fast-forward";
                    lastLink.NavigateUrl = "ProductList.aspx?type=" + APIContentType + "&page=" + numberOfPages;
                    PaginationPlaceholder.Controls.Add(lastLink);

                    if (APIPageNumber.Equals("1"))
                    {
                        firstLink.Visible = false;
                        previousLink.Visible = false;
                    }

                    else if (APIPageNumber.Equals(numberOfPages.ToString()))
                    {
                        nextLink.Visible = false;
                        lastLink.Visible = false;
                    }
                }
                else
                {
                    //First
                    HyperLink firstLink = new HyperLink();
                    firstLink.CssClass = "glyphicon glyphicon-fast-backward";
                    firstLink.NavigateUrl = "ProductList.aspx?type=" + APIContentType + "&page=" + 1 + "&search=" + APIContentTitle;
                    PaginationPlaceholder.Controls.Add(firstLink);

                    //Previous
                    HyperLink previousLink = new HyperLink();
                    previousLink.CssClass = "glyphicon glyphicon-backward";
                    previousLink.NavigateUrl = "ProductList.aspx?type=" + APIContentType + "&page=" + (int.Parse(APIPageNumber) - 1) + "&search=" + APIContentTitle;
                    PaginationPlaceholder.Controls.Add(previousLink);

                    //Next
                    HyperLink nextLink = new HyperLink();
                    nextLink.CssClass = "glyphicon glyphicon-forward";
                    nextLink.NavigateUrl = "ProductList.aspx?type=" + APIContentType + "&page=" + (int.Parse(APIPageNumber) + 1) + "&search=" + APIContentTitle;
                    PaginationPlaceholder.Controls.Add(nextLink);

                    //Last
                    HyperLink lastLink = new HyperLink();
                    lastLink.CssClass = "glyphicon glyphicon-fast-forward";
                    lastLink.NavigateUrl = "ProductList.aspx?type=" + APIContentType + "&page=" + numberOfPages + "&search=" + APIContentTitle;
                    PaginationPlaceholder.Controls.Add(lastLink);

                    if (APIPageNumber.Equals("1"))
                    {
                        firstLink.Visible = false;
                        previousLink.Visible = false;
                    }

                    else if (APIPageNumber.Equals(numberOfPages.ToString()))
                    {
                        nextLink.Visible = false;
                        lastLink.Visible = false;
                    }
                }
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