<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ModifyPurchaseOrder.aspx.cs" Inherits="FrontEndWeb.ModifyPurchaseOrder" %>
<%@ Register assembly="BasicFrame.WebControls.BasicDatePicker" namespace="BasicFrame.WebControls" tagprefix="BDP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .infoLeft {
            font-weight: 700;
        }
    </style>
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
    <asp:Panel ID="searchPanel" runat="server">
        <div id="search">
            <div id="searchNumber">
                <asp:Label ID="lblSearchNumber" runat="server" Text="Search by Order Number" style="font-weight: 700"></asp:Label><br /><br />
                    <asp:TextBox ID="txtNumber" runat="server"></asp:TextBox><br /><br />
                <asp:Button ID="btnSearchNumber" runat="server" class="btn btn-default" Text="Search" OnClick="btnSearchNumber_Click" /><br /><br />
            </div>
            <div id="searchOther">
                <asp:Label ID="lblSearchOther" runat="server" Text="Search by Other" style="font-weight: 700"></asp:Label><br /><br />
                <asp:Label ID="lblStartDate" runat="server" Text="Start Date"></asp:Label>
                    <BDP:BasicDatePicker ID="dtpStartDate" runat="server" />
                <asp:Label ID="lblEndDate" runat="server" Text="End Date"></asp:Label>
                    <BDP:BasicDatePicker ID="dtpEndDate" runat="server" /><br /><br />
                <asp:RadioButtonList ID="rblStatus" runat="server" RepeatDirection="Horizontal"  CssClass="searchRadioButton" CellPadding="0" CellSpacing="0" OnSelectedIndexChanged="rblStatus_SelectedIndexChanged" RepeatLayout="Flow" AutoPostBack="True">
                    <asp:ListItem Text="All" Value="A"></asp:ListItem>
                    <asp:ListItem Text="Pending" Value="P"></asp:ListItem>
                    <asp:ListItem Text="Closed" Value="C"></asp:ListItem>
                </asp:RadioButtonList>
                <%--<asp:Panel ID="pnlRadioButtons" runat="server" style="display:inline;" >
                    <asp:RadioButton ID="rdoAll" runat="server" Text="All" CssClass="searchRadioButton" GroupName="Filter" OnCheckedChanged="rdoAll_CheckedChanged" AutoPostBack="true"/>
                    <asp:RadioButton ID="rdoPending" runat="server" Text="Pending" CssClass="searchRadioButton" GroupName="Filter" OnCheckedChanged="rdoAll_CheckedChanged" AutoPostBack="true"/>
                    <asp:RadioButton ID="rdoClosed" runat="server" Text="Closed" CssClass="searchRadioButton" GroupName="Filter" OnCheckedChanged="rdoAll_CheckedChanged" AutoPostBack="true"/>
                </asp:Panel>--%>
                <asp:Label ID="lblEmployeeName" runat="server" Text="Employee Name"></asp:Label>
                    <asp:TextBox ID="txtEmployeeName" runat="server"></asp:TextBox><br /><br />
                <asp:Button ID="btnSearchDates" runat="server" class="btn btn-default" Text="Search" OnClick="btnSearchDates_Click" />
                <asp:Button ID="btnReset" runat="server" class="btn btn-default" Text="Reset" OnClick="btnReset_Click" />
                <asp:TextBox ID="txtFilter" runat="server" Width="20px" Visible="False"></asp:TextBox>
            </div>   
        </div>
    </asp:Panel>
    <asp:Panel ID="orders" runat="server">
        <div id="orderInfo">
            <asp:GridView ID="grdOrders" runat="server" CellPadding="4" ForeColor="Black" GridLines="Vertical" AutoGenerateSelectButton="True" OnRowCreated="grdOrders_RowCreated" OnRowCommand="grdOrders_RowCommand" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" width="700px">
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
        <div id="cancelButton">
            <asp:Button ID="btnCancelSearch" runat="server" class="btn btn-default" OnClick="btnCancelSearch_Click" Text="Cancel Search" />
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
    <asp:Panel ID="items" runat="server">
        <div id="itemsInfo">
            <asp:GridView ID="grdItems" runat="server" CellPadding="4" ForeColor="Black" GridLines="Vertical" AutoGenerateSelectButton="True" OnRowCommand="grdItems_RowCommand" OnRowDeleting="grdItems_RowDeleting" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" width="1000px" OnRowDataBound="grdItems_RowDataBound">
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
                <columns>
                    <asp:CommandField ShowDeleteButton="True" ButtonType="Button" DeleteText="Remove"/>
                </columns>
            </asp:GridView>
        </div>
        <div id ="itemButtons">
            <asp:Button ID="btnCancelItems" runat="server" class="btn btn-default" OnClick="btnCancelItems_Click" Text="Cancel" AutoPostBack="true"/>
            <asp:Button ID="btnAdd" runat="server" class="btn btn-default" Text="Add New Item" OnClick="btnAdd_Click" />
        </div>
    </asp:Panel>
    <asp:Panel ID="itemInformation" runat="server">
        <div id="itemDetails">
            <div id="infoLeft">
                <asp:Label ID="lblName" runat="server" EnableTheming="True" Text="Name: " CssClass="itemLabel"></asp:Label>
                    <asp:TextBox ID="txtName" runat="server" CssClass="itemText" MaxLength="100"></asp:TextBox><br /><br />
                <asp:Label ID="lblDescription" runat="server" Text="Description: " CssClass="itemLabel"></asp:Label>
                    <asp:TextBox ID="txtDescription" runat="server" CssClass="itemText" MaxLength="200"></asp:TextBox><br /><br />
                <asp:Label ID="lblPurchaseLocation" runat="server" Text="Purchase Location: " CssClass="itemLabel"></asp:Label>
                    <asp:TextBox ID="txtPurchaseLocation" runat="server" CssClass="itemText" MaxLength="100"></asp:TextBox><br /><br />
                <asp:Label ID="lblJustification" runat="server" Text="Justification: " CssClass="itemLabel"></asp:Label>
                    <asp:TextBox ID="txtJustification" runat="server" TextMode="MultiLine" CssClass="itemText" MaxLength="300"></asp:TextBox><br /><br /><br /><br />
                <asp:Label ID="lblModReason" runat="server" Text="Mod Reason: " style="font-weight: 700" CssClass="itemLabel"></asp:Label>
                    <asp:TextBox ID="txtModReason" runat="server" CssClass="itemText" MaxLength="200"></asp:TextBox>  
            </div>
            <div id="infoRight">
                <asp:Label ID="lblPrice" runat="server" Text="Price: " style="font-weight: 700" CssClass="itemLabel"></asp:Label>
                    <asp:TextBox ID="txtPrice" runat="server" CssClass="itemText"></asp:TextBox><br /><br />
                <asp:Label ID="lblQuantity" runat="server" Text="Quantity: " style="font-weight: 700" CssClass="itemLabel"></asp:Label>
                    <asp:TextBox ID="txtQuantity" runat="server" CssClass="itemText"></asp:TextBox><br /><br />    
                <div id="modifyButtons">
                    <asp:Button ID="btnModify" runat="server" class="btn btn-default" Text="Modify Item" OnClick="btnModify_Click" />
                    <asp:Button ID="btnAddItem" runat="server" class="btn btn-default" Text="Add Item" OnClick="btnAddItem_Click" /><br /><br />
                    <asp:Button ID="btnCancelEdit" runat="server" class="btn btn-default" Text="Cancel" Height="26px" OnClick="btnCancelEdit_Click" />
                </div>
            </div><br /><br />
        </div>
    </asp:Panel>
</asp:Content>
