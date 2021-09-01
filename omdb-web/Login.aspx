<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="omdb_web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="authentication-flex-container">
        <div class="authentication-flex-inner">
            <div class="form-group">
                <label for="txtEmail">Email Address</label>
                <input type="email" class="form-control" id="txtEmail" aria-describedby="emailHelp" placeholder="Email Address" runat="server">
                <asp:RequiredFieldValidator ControlToValidate="txtEmail"
                    Display="Static" ErrorMessage="* A valid email address is required." runat="server"
                    ID="vEmail" />
            </div>
            <div class="form-group">
                <label for="txtPassword">Password</label>
                <input type="password" class="form-control" id="txtPassword" placeholder="Password" runat="server">
                <asp:RequiredFieldValidator ControlToValidate="txtPassword"
                    Display="Static" ErrorMessage="* Please enter your password." runat="server"
                    ID="vPassword" />
            </div>

            <div class="form-group form-check">
                <input type="checkbox" id="chkPersistCookie" class="form-check-input" runat="server">
                <label class="form-check-label" for="RememberMe">Remember Me</label>
            </div>

            <input type="submit" value="Log In" class="btn float-right login_btn" id="cmdLogin" runat="server">

            <div class="card-footer">
                <div class="d-flex justify-content-center links">
                    <a href="~/Register" runat="server">Don't have an account?</a>
                </div>
                <div class="d-flex justify-content-center">
                    <a href="#">Forgot your password?</a>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
