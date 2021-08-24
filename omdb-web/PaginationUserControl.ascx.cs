using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace omdb_web
{
    public partial class PaginationUserControl : System.Web.UI.UserControl
    {
        public string APIContentType;
        public string APIPageNumber;
        public string numberOfPages;
        protected void Page_Load(object sender, EventArgs e)
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
        }
    }
}