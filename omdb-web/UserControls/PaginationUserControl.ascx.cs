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
        public string typeOfContent { get; set; }
        public string searchQuery { get; set; }
        public string pageNumber { get; set; }
        public string numberOfPages { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //First
            HyperLink firstLink = new HyperLink();
            firstLink.CssClass = "glyphicon glyphicon-fast-backward";
            firstLink.NavigateUrl = "~/SecurePages/ProductList.aspx?search=" + searchQuery + "&type=" + typeOfContent + "&page=" + 1;
            PaginationPlaceholder.Controls.Add(firstLink);

            //Previous
            HyperLink previousLink = new HyperLink();
            previousLink.CssClass = "glyphicon glyphicon-backward";
            previousLink.NavigateUrl = "~/SecurePages/ProductList.aspx?search=" + searchQuery + "&type=" + typeOfContent + "&page=" + (int.Parse(pageNumber) - 1);
            PaginationPlaceholder.Controls.Add(previousLink);

            //Next
            HyperLink nextLink = new HyperLink();
            nextLink.CssClass = "glyphicon glyphicon-forward";
            nextLink.NavigateUrl = "~/SecurePages/ProductList.aspx?search=" + searchQuery + "&type=" + typeOfContent + "&page=" + (int.Parse(pageNumber) + 1);
            PaginationPlaceholder.Controls.Add(nextLink);

            //Last
            HyperLink lastLink = new HyperLink();
            lastLink.CssClass = "glyphicon glyphicon-fast-forward";
            lastLink.NavigateUrl = "~/SecurePages/ProductList.aspx?search=" + searchQuery + "&type=" + typeOfContent + "&page=" + numberOfPages;
            PaginationPlaceholder.Controls.Add(lastLink);

            if(Int32.Parse(pageNumber) <= 1)
            {
                firstLink.Visible = false;
                previousLink.Visible = false;
            }

            if(Int32.Parse(pageNumber) >= Int32.Parse(numberOfPages))
            {
                nextLink.Visible = false;
                lastLink.Visible = false;
            }

        }
    }
}