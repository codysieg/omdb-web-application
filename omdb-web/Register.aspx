<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="omdb_web.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="d-flex justify-content-center h-100">
        <div class="card">
            <div class="card-header">
                <h3>Register</h3>
            </div>
            <div class="card-body">
                <div class="input-group form-group">
                    <div class="input-group-prepend">
                        <span class="input-group-text"><i class="fas fa-user"></i></span>
                    </div>
                    <input id="txtEmail" type="email" class="form-control" runat="server">
                    <asp:RequiredFieldValidator ControlToValidate="txtEmail"
                        Display="Static" ErrorMessage="*" runat="server"
                        ID="vUserName" />
                </div>
                <div class="input-group form-group">
                    <div class="input-group-prepend">
                        <span class="input-group-text"><i class="fas fa-key"></i></span>
                    </div>
                    <input id="txtPassword" type="password" runat="server">
                    <asp:RequiredFieldValidator ControlToValidate="txtPassword"
                        Display="Static" ErrorMessage="*" runat="server"
                        ID="vUserPass" />
                </div>
                <div class="form-group">
                    <input type="submit" value="Register" class="btn float-right login_btn" id="cmdRegister" runat="server">
                </div>
            </div>
        </div>
    </div>

</asp:Content>
