<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ProcessPurchaseOrder.aspx.cs" Inherits="FrontEndWeb.ProcessPurchaseOrder" %>
<%@ Register assembly="BasicFrame.WebControls.BasicDatePicker" namespace="BasicFrame.WebControls" tagprefix="BDP" %>
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
        <div id="confirmationProcess">
            <asp:Label ID="lblMessage" runat="server" CssClass="lblMessage" ForeColor="Black"></asp:Label><br /><br />
        </div>
    </asp:Panel>
    <asp:Panel ID="searchPanel" runat="server">
        <div id="search">
            <div id="searchProcess">
                <asp:Label ID="lblSearchOther" runat="server" Text="Search Purchase Orders" style="font-weight: 700"></asp:Label><br /><br />
                <asp:Label ID="lblStartDate" runat="server" Text="Start Date"></asp:Label>
                    <BDP:BasicDatePicker ID="dtpStartDate" runat="server" />
                <asp:Label ID="lblEndDate" runat="server" Text="End Date"></asp:Label>
                    <BDP:BasicDatePicker ID="dtpEndDate" runat="server" /><br /><br />
                <asp:RadioButtonList ID="rblStatus" runat="server" RepeatDirection="Horizontal"  CssClass="searchRadioButton" CellPadding="0" CellSpacing="0" OnSelectedIndexChanged="rblStatus_SelectedIndexChanged" RepeatLayout="Flow" AutoPostBack="True">
                    <asp:ListItem Text="All" Value="A"></asp:ListItem>
                    <asp:ListItem Text="Pending" Value="P"></asp:ListItem>
                    <asp:ListItem Text="Closed" Value="C"></asp:ListItem>
                </asp:RadioButtonList>
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
            <asp:GridView ID="grdOrders" runat="server" CellPadding="4" ForeColor="Black" GridLines="Vertical" AutoGenerateSelectButton="True" OnRowCommand="grdOrders_RowCommand" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" width="700px">
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
            <asp:Label ID="lblPONumber" runat="server" Text="Order Number: " CssClass="employeeLabel" style="font-weight: 700"></asp:Label>
                <asp:TextBox ID="txtPONumber" runat="server" ReadOnly="True"></asp:TextBox>  
            <asp:Label ID="lblCreationDate" runat="server" Text="Creation Date: " CssClass="employeeLabel" style="font-weight: 700"></asp:Label>
                <asp:TextBox ID="txtCreationDate" runat="server" ReadOnly="True"></asp:TextBox>
            <asp:Label ID="lblEmployee" runat="server" Text="Employee: " CssClass="employeeLabelFirst" style="font-weight: 700"></asp:Label>
                <asp:TextBox ID="txtEmployee" runat="server" ReadOnly="True"></asp:TextBox>
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
            <asp:GridView ID="grdItems" runat="server" CellPadding="4" ForeColor="Black" GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" width="1000px" OnRowCommand="grdItems_RowCommand" OnRowCreated="grdItems_RowCreated">
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
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="btnApprove" runat="server" CausesValidation="false" CommandName="Approve"
                            Text="Approve" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="btnDeny" runat="server" CausesValidation="false" CommandName="Deny"
                            Text="Deny" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="btnPending" runat="server" CausesValidation="false" CommandName="Pending"
                            Text="Set to Pending" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </columns>
            </asp:GridView>
        </div>
        <div id="itemButtons">
            <asp:Button ID="btnCancelItems" runat="server" class="btn btn-default" OnClick="btnCancelItems_Click" Text="Cancel" />
            <asp:Button ID="btnClose" runat="server" class="btn btn-default" Text="Close Purchase Order" OnClick="btnClose_Click"/>
        </div>
<%--        <div id="itemButtons">
            <asp:Button ID="btnApprove" runat="server" class="btn btn-default" Text="Approve Item" />
            <asp:Button ID="btnDeny" runat="server" class="btn btn-default" Text="Deny Item" />
            <asp:Button ID="btnPending" runat="server" class="btn btn-default" Text="Set to Pending" />
            <asp:Button ID="btnCancelItems" runat="server" class="btn btn-default" OnClick="btnCancelItems_Click" Text="Cancel" AutoPostBack="true"/>
        </div>--%>
    </asp:Panel>
    <asp:Panel ID="pnlDeny" runat="server">
        <div id="itemButtons">
            <asp:Label ID="lblDeny" runat="server" Text="Reason for Denial: "></asp:Label>
            <asp:TextBox ID="txtDeny" runat="server" MaxLength="200"></asp:TextBox>
            <asp:Button ID="btnDenyFinal" runat="server" class="btn btn-default" Text="Deny Item" OnClick="btnDenyFinal_Click" />
            <asp:Button ID="btnCancelDeny" runat="server" class="btn btn-default" Text="Cancel" OnClick="btnCancelDeny_Click" />
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlClose" runat="server">
        <div id="closeDiv">
            <asp:Label ID="lblClose" runat="server" Text="All items on this purchase order have been processed. Do you wish to close the purchase order now?"></asp:Label><br /><br />
            <div id="itemButtons">
                <asp:Button ID="btnCloseYes" runat="server" Text="Yes" OnClick="btnCloseYes_Click" />
                <asp:Button ID="btnCloseNo" runat="server" Text="No" OnClick="btnCloseNo_Click" />
            </div>
        </div>
    </asp:Panel>
</asp:Content>
