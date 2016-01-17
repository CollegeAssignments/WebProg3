<%@ Page Title="" Language="C#" MasterPageFile="~/mainTemplate.Master" AutoEventWireup="true" CodeBehind="signIn.aspx.cs" Inherits="WebProg_3___Car_Rental_Website.signIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="input-group col-xs-12 col-md-6 col-md-offset-3 space-inputs">
            <label>User Name</label>
            <asp:TextBox ID="tbxUserName" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvUserName" CssClass="alert alert-danger label col-xs-12" ControlToValidate="tbxUserName" Display="Dynamic" ErrorMessage="*UserName is Required." runat="server" />
        </div>
        <div class="input-group col-xs-12 col-md-6 col-md-offset-3 space-inputs">
            <label>Password</label>
            <asp:TextBox ID="tbxPassword" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPassword" CssClass="alert alert-danger label col-xs-12" ControlToValidate="tbxPassword" Display="Dynamic" ErrorMessage="*Password is Required" runat="server" />
        </div>
        <div class="input-group col-xs-12 col-md-4 col-md-offset-4 space-inputs">
            <asp:Button ID="btnSignIn" CssClass="btn btn-default col-xs-12" Text="Login" OnClick="btnSignIn_Click" runat="server" />
        </div>
        <!--Container for server error message-->
        <div class="col-xs-12 text-center">
            <asp:Label CssClass="alert alert-danger label col-xs-12 spacer" ID="lblDbErrorNotice" runat="server" ></asp:Label>
        </div>
    </div>
</asp:Content>
