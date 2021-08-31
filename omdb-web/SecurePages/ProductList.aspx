<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="omdb_web.ProductList" Async="true" %>
<%@ Register Src="~/UserControls/PaginationUserControl.ascx" TagName="PaginationControl" TagPrefix="PaginationControl" %>

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
    <div class="movie-pagination">
        <asp:PlaceHolder ID="PaginationPlaceholder" runat="server"></asp:PlaceHolder>
    </div>
    <PaginationControl:PaginationControl ID="paginationControl" runat="server"></PaginationControl:PaginationControl>
    <div class="movie-pagination">
        Page <asp:TextBox ID="PaginationTextBox" AutoPostBack="true" Text="<%# APIPageNumber %>" OnTextChanged="PaginationTextBox_TextChanged" CausesValidation="true" runat="server"></asp:TextBox>
        of <%# numberOfPages %>
        <asp:RangeValidator Type="Integer" ControlToValidate="PaginationTextBox" MinimumValue="1" MaximumValue="<%# numberOfPages %>" runat="server" />
    </div>
</asp:Content>
