<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="omdb_web.ProductDetails" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:FormView ID="IndividualContent" runat="server" ItemType="omdb_dal.Models.Movie">
        <ItemTemplate>
            <div class="movie-container">
                <div class="movie-poster-container">
                    <asp:Image runat="server" class="movie-details-poster-image" ImageUrl="<%# Item.Poster %>" />
                    <div runat="server"><span class="movie-details-tag">Rating: </span><%#Item.FilmRating %></div>
                    <div runat="server"><span class="movie-details-tag">Genre: </span><%#Item.Genre %></div>
                </div>
                <div class="movie-details-container">
                    <div class="movie-details-title" runat="server"><%#Item.Title %></div>
                    <div class="movie-details-plot" runat="server"><%#Item.Plot %></div>
                    <div class="movie-details-runtimelength" runat="server"><span class="movie-details-tag">Movie Length: </span><%#Item.RunTimeLength %></div>
                    <div class="movie-details-actors" runat="server"><span class="movie-details-tag">Actors: </span><%#Item.Actors %></div>
                    <div class="movie-details-imdbrating" runat="server"><span class="movie-details-tag">IMDB Rating: </span><%#Item.ImdbRating %></div>
                    <div class="movie-details-director" runat="server"><span class="movie-details-tag">Director: </span><%#Item.Director %></div>
                    <div class="movie-details-writer" runat="server"><span class="movie-details-tag">Writer: </span><%#Item.Writer %></div>
                    <div class="movie-details-production" runat="server"><span class="movie-details-tag">Production: </span><%#Item.Production %></div>
                    <div class="movie-details-revenue" runat="server"><span class="movie-details-tag">Box Office Revenue: </span><%#Item.BoxOfficeRevenue %></div>
                    <div class="movie-details-yearreleased" runat="server"><span class="movie-details-tag">Year Released: </span><%#Item.Year %></div>
                    <div class="movie-details-awards" runat="server"><span class="movie-details-tag">Awards: </span><%#Item.Awards %></div>
                    <div class="movie-details-country" runat="server"><span class="movie-details-tag">Country: </span><%#Item.Country %></div>
                </div>
            </div>
        </ItemTemplate>
    </asp:FormView>

    <%-- Add to My List --%>
    <div>
        <asp:Button ID="AddToMyListButtonID" OnClick="AddToMyListButtonID_Click" Text="Add to My List" runat="server" />
    </div>

    <div>
        <asp:Button ID="RemoveFromMyListButtonID" OnClick="RemoveFromMyListButtonID_Click" Text="Remove from my List" runat="server" />
    </div>

    <div class="season-dropdown-list-container">
        <asp:DropDownList ID="SeasonDropDownList" ItemType=".Models.Series" AutoPostBack="true" OnSelectedIndexChanged="SeasonDropDownList_ShowSeasonData" OnDataBound="SeasonDropDownList_DataBound" runat="server" />
    </div>

    <asp:ListView ID="SeasonEpisodesListView" ItemType="omdb_dal.Models.Episode" runat="server">
        <ItemTemplate>
            <div class="season-episodes-container">
                <a href="SecurePages/ProductDetails.aspx?IMDBId=<%#Item.ImdbID %>">
                    <div class="season-episodes-title" runat="server"><%#Item.Title%></div>
                    <div class="season-episodes-number" runat="server"><%#Item.EpisodeNumber%></div>
                </a>
            </div>
        </ItemTemplate>
    </asp:ListView>

</asp:Content>
