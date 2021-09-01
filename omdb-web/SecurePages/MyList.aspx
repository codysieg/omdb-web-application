<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyList.aspx.cs" Inherits="omdb_web.SecurePages.MyList" Async="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="grid-movie-display">
        <asp:ListView ID="APIDataList" runat="server" ItemType="omdb_dal.Models.Movie">
            <ItemTemplate>
                <a href="ProductDetails.aspx?IMDBId=<%#Item.ImdbID %>">
                    <asp:Image ID="Poster" runat="server" ImageUrl="<%# Item.Poster %>" CssClass="movie-details-poster-image" />
                </a>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
