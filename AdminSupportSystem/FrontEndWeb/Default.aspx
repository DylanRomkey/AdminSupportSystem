<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FrontEndWeb.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav class="navbar navbar-default">
        <div class="container-fluid">
            <ul class="nav navbar-nav">
                <li><a href="Default.aspx">Home</a></li>
                <li><a href="CreatePurchaseOrder.aspx">Create Purchase Order</a></li>
                <li><a href="ModifyPurchaseOrder.aspx">Modify Purchase Order</a></li>
                <li><a href="ProcessPurchaseOrder.aspx">Process Purchase Order</a></li>
                <li><a href="ModifyPersonalInfo.aspx">Modify Personal Info</a></li>
                <li><a href="CalculatePension.aspx">Calculate Pension</a></li>
                <li><asp:LinkButton ID="LinkButton1" CssClass="navLink" runat="server" OnClick="btnLogout_Click">Logout</asp:LinkButton></li>
            </ul>
        </div>
    </nav>
    <div class="mainContent">
        <h3>Welcome to the GearWorks Admin Support System intranet application</h3><br />
        <p class="text-center">
            <b>Please select from a list of commands from the navigation bar above to perform regular administrative duties</b><br /><br />If you have any questions regarding the system please contact
            our employee support team online at support@gearworks.com or by phone at 506-645-2156
        </p>
        <hr />
        <p class="text-center">
            Copyright Ⓒ 2017 GearWorks Inc.
        </p>
    </div>
</asp:Content>
