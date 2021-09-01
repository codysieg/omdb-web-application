<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="omdb_web.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="authentication-flex-container">
        <div class="authentication-flex-inner">
            <div class="form-group">
                <label for="txtFirstName">First Name</label>
                <input type="text" class="form-control" id="txtFirstName" placeholder="First Name" runat="server">
            </div>
            <div class="form-group">
                <label for="txtLastName">Last Name</label>
                <input type="text" class="form-control" id="txtLastName" placeholder="Last Name" runat="server">
            </div>
            <div class="form-group">
                <label for="txtEmail">Email Address</label>
                <input type="email" class="form-control" id="txtEmail" placeholder="Email Address" runat="server">
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

            <input type="submit" value="Register" class="btn float-right login_btn" id="cmdRegister" runat="server">
        </div>
    </div>

</asp:Content>
