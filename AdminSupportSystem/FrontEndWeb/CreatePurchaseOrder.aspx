<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CreatePurchaseOrder.aspx.cs" Inherits="FrontEndWeb.CreatePurchaseOrder" %>
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
        <div id="confirmationCreateDiv">
            <asp:Label ID="lblMessage" runat="server" CssClass="lblMessage" ForeColor="Black"></asp:Label><br /><br />
        </div>
    </asp:Panel>
    <div id="EmployeeInfo">
        <asp:Label ID="lblEmployee" runat="server" Text="Employee Name: " CssClass="employeeLabelFirst" style="font-weight: 700"></asp:Label>
            <asp:TextBox ID="txtEmployee" runat="server" ReadOnly="True"></asp:TextBox>
        <asp:Label ID="lblDepartment" runat="server" Text="Department: " CssClass="employeeLabel" style="font-weight: 700"></asp:Label>
            <asp:TextBox ID="txtDepartment" runat="server" ReadOnly="True"></asp:TextBox>
        <asp:Label ID="lblSupervisor" runat="server" Text="Supervisor: " CssClass="employeeLabel" style="font-weight: 700"></asp:Label>
            <asp:TextBox ID="txtSupervisor" runat="server" ReadOnly="True"></asp:TextBox>
        <asp:Label ID="lblDate" runat="server" Text="Date: " CssClass="employeeLabel" style="font-weight: 700"></asp:Label>
            <asp:TextBox ID="txtDate" runat="server" ReadOnly="True"></asp:TextBox>
    </div>
    <p id="headline">Please enter in all item information to add it to a new Purchase Order</p>
    <div id="bodyInfo">
    <div id="fields">
        <asp:Label ID="lblName" runat="server" Text="Name: " CssClass="itemLabel"></asp:Label>
            <asp:TextBox ID="txtName" runat="server" Width="250px" CssClass="itemText" MaxLength="100"></asp:TextBox><br /><br />
        <asp:Label ID="lblDescription" runat="server" Text="Description: " CssClass="itemLabel"></asp:Label>
            <asp:TextBox ID="txtDescription" runat="server" Width="250px" CssClass="itemText" MaxLength="200"></asp:TextBox><br /><br />
        <asp:Label ID="lblPurchaseLocation" runat="server" Text="Purchase Location: " CssClass="itemLabel"></asp:Label>
            <asp:TextBox ID="txtPurchaseLocation" runat="server" Width="250px" CssClass="itemText" MaxLength="100"></asp:TextBox><br /><br />
        <asp:Label ID="lblJustification" runat="server" Text="Justification: " CssClass="itemLabel"></asp:Label>
            <asp:TextBox ID="txtJustification" runat="server" TextMode="MultiLine" Width="250px" CssClass="itemText" MaxLength="300"></asp:TextBox><br /><br /><br /><br />
        <asp:Label ID="lblPrice" runat="server" Text="Price: " CssClass="itemLabel"></asp:Label>
            <asp:TextBox ID="txtPrice" runat="server" CssClass="itemText"></asp:TextBox><br /><br />
        <asp:Label ID="lblQuantity" runat="server" Text="Quantity: " CssClass="itemLabel"></asp:Label>
            <asp:TextBox ID="txtQuantity" runat="server" CssClass="itemText"></asp:TextBox><br />
    </div>
        </div>
    <div id="buttons">
        <asp:Button ID="btnAdd" runat="server" class="btn btn-default" Text="Add Item" OnClick="btnAdd_Click" AutoPostBack="true"/>
        <asp:Button ID="btnComplete" runat="server" class="btn btn-default" Text="Complete Order" OnClick="btnComplete_Click" />
        <asp:Button ID="btnClearItem" runat="server" class="btn btn-default" Text="Clear" OnClick="btnClearItem_Click" />
        <asp:Button ID="btnClear" runat="server" class="btn btn-default" Text="Clear Item List" OnClick="btnClear_Click" />
    </div>
    <asp:Panel ID="totals" runat="server">
        <div id="totalsInfo">
            <asp:Label ID="lblSubtotal" runat="server" Text="Subtotal: "></asp:Label>
                <asp:TextBox ID="txtSubtotal" runat="server" ReadOnly="True"></asp:TextBox>
            <asp:Label ID="lblTaxes" runat="server" Text="Taxes: "></asp:Label>
                <asp:TextBox ID="txtTaxes" runat="server" ReadOnly="True"></asp:TextBox>
            <asp:Label ID="lblTotal" runat="server" Text="Total: "></asp:Label>
                <asp:TextBox ID="txtTotal" runat="server" ReadOnly="True"></asp:TextBox>
        </div>
    </asp:Panel>
    <asp:Panel ID="gridVIew" runat="server">
        <div id="gridViewInfo">
            <asp:GridView ID="grdItems" runat="server" CellPadding="4" ForeColor="Black" GridLines="Vertical" OnRowCreated="grdItems_RowCreated" OnRowDeleting="grdItems_RowDeleting" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None"  width="700px">
                <AlternatingRowStyle BackColor="White" />
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE"  HorizontalAlign="Center"/>
                <SelectedRowStyle BackColor="#26B99A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
                <columns>
                    <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />
                </columns>
            </asp:GridView>
        </div>
    </asp:Panel>
</asp:Content>
