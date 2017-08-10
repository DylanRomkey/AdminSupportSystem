<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ViewProcessedOrder.aspx.cs" Inherits="FrontEndWeb.ViewProcessedOrder" %>
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
    <asp:Panel ID="confirmation" runat="server">
        <div id="confirmationDiv">
            <asp:Label ID="lblMessage" runat="server" CssClass="lblMessage" ForeColor="Black"></asp:Label><br /><br />
        </div>
    </asp:Panel>
    <asp:Panel ID="login" runat="server">
        <div id="userFields">
            <asp:Label ID="lblUser" runat="server" Text="User: " CssClass="userLabel"></asp:Label>
                <asp:DropDownList ID="ddlUser" runat="server" Width="200px" CssClass="userText"></asp:DropDownList><br /><br />
            <asp:Label ID="lblPassword" runat="server" Text="Password: " CssClass="userLabel"></asp:Label>
                <asp:TextBox ID="txtPassword" runat="server" ReadOnly="True" Width="200px" CssClass="userText"></asp:TextBox>
        </div>
        <div id="userButtons">
            <asp:Button ID="btnLogin" runat="server" class="btn" Text="Login" OnClick="btnLogin_Click" />
        </div>
    </asp:Panel>
    <asp:Panel ID="orderDetails" runat="server">
        <div id="orderDetailsInfo">
            <asp:Label ID="lblOrderInfo" runat="server" Text="Purchase Order Information" style="font-weight: 700"></asp:Label><br /><br />    
            <asp:Label ID="lblEmployee" runat="server" Text="Employee: " CssClass="employeeLabelFirst" style="font-weight: 700"></asp:Label>
                <asp:TextBox ID="txtEmployee" runat="server" ReadOnly="True"></asp:TextBox>
            <asp:Label ID="lblDepartment" runat="server" Text="Department: " CssClass="employeeLabel" style="font-weight: 700"></asp:Label>
                <asp:TextBox ID="txtDepartment" runat="server" ReadOnly="True"></asp:TextBox>
            <asp:Label ID="lblSupervisor" runat="server" Text="Supervisor: " CssClass="employeeLabel" style="font-weight: 700"></asp:Label>
                <asp:TextBox ID="txtSupervisor" runat="server" ReadOnly="True"></asp:TextBox><br /><br /> 
            <asp:Label ID="lblPONumber" runat="server" Text="Order Number: " CssClass="employeeLabel" style="font-weight: 700"></asp:Label>
                <asp:TextBox ID="txtPONumber" runat="server" ReadOnly="True"></asp:TextBox>
            <asp:Label ID="lblCreationDate" runat="server" Text="Creation Date: " CssClass="employeeLabel" style="font-weight: 700"></asp:Label>
                <asp:TextBox ID="txtCreationDate" runat="server" ReadOnly="True"></asp:TextBox>
            <asp:Label ID="lblStatus" runat="server" Text="Order Status: " CssClass="employeeLabel" style="font-weight: 700"></asp:Label>
                <asp:TextBox ID="txtStatus" runat="server" ReadOnly="True"></asp:TextBox><br /><br /> 
            <asp:Label ID="lblSubtotal" runat="server" Text="Subtotal: " CssClass="employeeLabel" style="font-weight: 700"></asp:Label>
                <asp:TextBox ID="txtSubtotal" runat="server" ReadOnly="True"></asp:TextBox>
            <asp:Label ID="lblTaxes" runat="server" Text="Taxes: " CssClass="employeeLabel" style="font-weight: 700"></asp:Label>
                <asp:TextBox ID="txtTaxes" runat="server" ReadOnly="True"></asp:TextBox>
            <asp:Label ID="lblTotal" runat="server" Text="Total: " CssClass="employeeLabel" style="font-weight: 700"></asp:Label>
                <asp:TextBox ID="txtTotal" runat="server" ReadOnly="True"></asp:TextBox><br />
        </div>
    </asp:Panel>
    <asp:Panel ID="processedDetails" runat="server">
        <div id="itemsInfo">
            <asp:GridView ID="grdItems" runat="server" CellPadding="4" ForeColor="Black" GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" width="1000px" OnRowCreated="grdItems_RowCreated">
                <AlternatingRowStyle BackColor="White" />
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" HorizontalAlign="Center"/>
                <SelectedRowStyle BackColor="#26B99A" Font-Bold="True" ForeColor="Black" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView>
        </div>
    </asp:Panel><br /><br />
</asp:Content>
