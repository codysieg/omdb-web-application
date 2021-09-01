﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="omdb_web.ProductList" Async="true" %>

<%@ Register Src="~/UserControls/PaginationUserControl.ascx" TagName="PaginationControl" TagPrefix="PaginationControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="grid-movie-display">
        <asp:ListView ID="APIDataList" runat="server" ItemType="omdb_dal.Models.Movie">
            <ItemTemplate>
                <div class="image-container">
                    <a href="ProductDetails.aspx?IMDBId=<%#Item.ImdbID %>">
                        <asp:Image ID="Poster" runat="server" ImageUrl="<%# Item.Poster %>" CssClass="movie-details-poster-image" />
                        <div class="image-overlay-favourites">
                            <div class="add-to-list">
                                <div id="FavouriteSymbolID" class="favourite-status" runat="server"><%# Item.isFavourited ? "Remove from My List" : "Add to My List" %></div>
                            </div>
                        </div>
                    </a>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
    <div class="movie-pagination">
        <asp:PlaceHolder ID="PaginationPlaceholder" runat="server"></asp:PlaceHolder>
    </div>
    <PaginationControl:PaginationControl ID="PaginationUserControl" runat="server"></PaginationControl:PaginationControl>
    <div class="movie-pagination input-group rounded">
        <asp:Label ID="PaginationInfoLabel" runat="server"></asp:Label>
    </div>

</asp:Content>
