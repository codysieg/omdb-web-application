<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="omdb_web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="default-page-container">
        <a href="ProductList.aspx?type=movie&page=1" class="default-page-movies">
            <span class="default-page-tags">Movies</span>
            <svg xmlns="http://www.w3.org/2000/svg" width="250" height="250" viewBox="0 0 24 24" fill="#f5c518" role="presentation">
                <path fill="none" d="M0 0h24v24H0V0z"></path><path d="M18 4v1h-2V4c0-.55-.45-1-1-1H9c-.55 0-1 .45-1 1v1H6V4c0-.55-.45-1-1-1s-1 .45-1 1v16c0 .55.45 1 1 1s1-.45 1-1v-1h2v1c0 .55.45 1 1 1h6c.55 0 1-.45 1-1v-1h2v1c0 .55.45 1 1 1s1-.45 1-1V4c0-.55-.45-1-1-1s-1 .45-1 1zM8 17H6v-2h2v2zm0-4H6v-2h2v2zm0-4H6V7h2v2zm10 8h-2v-2h2v2zm0-4h-2v-2h2v2zm0-4h-2V7h2v2z"></path></svg>
        </a>
        <a href="ProductList.aspx?type=series&page=1" class="default-page-series">
            <span class="default-page-tags">TV Shows</span>
            <svg xmlns="http://www.w3.org/2000/svg" width="250" height="250" viewBox="0 0 24 24" fill="#f5c518" role="presentation">
                <path fill="none" d="M0 0h24v24H0V0z"></path><path d="M21 3H3c-1.1 0-2 .9-2 2v12c0 1.1.9 2 2 2h5v1c0 .55.45 1 1 1h6c.55 0 1-.45 1-1v-1h5c1.1 0 1.99-.9 1.99-2L23 5a2 2 0 0 0-2-2zm-1 14H4c-.55 0-1-.45-1-1V6c0-.55.45-1 1-1h16c.55 0 1 .45 1 1v10c0 .55-.45 1-1 1z"></path></svg>
        </a>
    </div>
</asp:Content>