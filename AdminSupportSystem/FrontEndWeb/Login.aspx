<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FrontEndWeb.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server">
        <div id="confirmationDiv">
            <asp:Label ID="lblMessage" runat="server" CssClass="lblMessage" ForeColor="Black"></asp:Label><br /><br />
        </div>
    </asp:Panel><br />
    <div id="userFields">
        <asp:Label ID="lblUser" runat="server" Text="User: " CssClass="userLabel"></asp:Label>
            <asp:DropDownList ID="ddlUser" runat="server" Width="200px" CssClass="userText"></asp:DropDownList><br /><br />
        <asp:Label ID="lblPassword" runat="server" Text="Password: " CssClass="userLabel"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" ReadOnly="True" Width="200px" CssClass="userText"></asp:TextBox>
    </div>
    <div id="userButtons">
        <asp:Button ID="btnLogin" runat="server" class="btn" Text="Login" OnClick="btnLogin_Click" />
    </div>
</asp:Content>
