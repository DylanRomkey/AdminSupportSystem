<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ModifyPersonalInfo.aspx.cs" Inherits="FrontEndWeb.ModifyPersonalInfo" %>
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
    <div id="EmployeeInfo">
        <table>
            <tr>
            <th colspan="2"><asp:Label runat="server" Text="Employee Name "></asp:Label></th>
                <th colspan="2"><asp:Label runat="server" Text="Date of Birth "></asp:Label></th>
            </tr>
            <tr>
            <td colspan="2"><asp:Label ID="lblEmployee" runat="server" Text="Dylan J Romkey"></asp:Label></td>
                <td colspan="2"><asp:Label ID="lblDob" runat="server" Text="2/3/2002"></asp:Label></td>
            </tr>
            <tr>
            <th colspan="2"><asp:Label runat="server" Text="Address "></asp:Label></th>
                <th><asp:Label runat="server" Text="Work Phone "></asp:Label></th>
            <th><asp:Label runat="server" Text="Cell Phone "></asp:Label></th>
            </tr>
            <tr>
            <td colspan="2"><asp:Label ID="lblAddress" runat="server" Text="1234 fake ST, FakeTown F4K3N5"></asp:Label></td>
                <td><asp:Label ID="lblWorkPhone" runat="server" Text="123-123-1234"></asp:Label></td>
            <td><asp:Label ID="lblCellPhone" runat="server" Text="123-123-1233"></asp:Label></td>
            </tr>
        </table>        
    </div>
    <hr style="width:80%" />
    <asp:ScriptManager id="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" updatemode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger controlid="txtWorkPhone" eventname="TextChanged" />
            <asp:AsyncPostBackTrigger controlid="txtCellPhone" eventname="TextChanged" />
            <asp:AsyncPostBackTrigger controlid="txtPC" eventname="TextChanged" />
        </Triggers>
        <ContentTemplate>
            <div id="confirmationCreateDiv">
                <asp:Label ID="lblMessage" runat="server" CssClass="lblMessage" Text="Please enter The updated information:" ForeColor="Black"></asp:Label>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" updatemode="Conditional">
        <ContentTemplate>
            <br />
            <div id="bodyInfo">
                <div id="fields">
                    <asp:Label runat="server" Text="Work Phone Number: " CssClass="itemLabel"></asp:Label>
                        <asp:TextBox ID="txtWorkPhone" runat="server" placeholder="Digits only"  onKeyDown="validateWorkPhone()" CssClass="itemText" MaxLength="10" OnTextChanged="txtChange" AutoPostBack="True"></asp:TextBox><br /><br />
                    <asp:Label runat="server" Text="Cell Phone Number: " CssClass="itemLabel"></asp:Label>
                        <asp:TextBox ID="txtCellPhone" runat="server" placeholder="Digits only"  onKeyDown="validateCellPhone()" CssClass="itemText" MaxLength="10" OnTextChanged="txtChange" AutoPostBack="True"></asp:TextBox><br /><br />
                    <asp:Label runat="server" Text="Street Address: " CssClass="itemLabel"></asp:Label>
                        <asp:TextBox ID="txtStreet" runat="server"  CssClass="itemText" MaxLength="100"  ></asp:TextBox><br /><br />
                    <asp:Label runat="server" Text="City: " CssClass="itemLabel"></asp:Label>
                        <asp:TextBox ID="txtCity" runat="server"  CssClass="itemText" MaxLength="50"></asp:TextBox><br /><br />
                    <asp:Label runat="server" Text="Postal Code: " CssClass="itemLabel"></asp:Label>
                        <asp:TextBox ID="txtPC" runat="server"  placeholder="ex K1A0B1" onKeyDown="validatePostalCode()" CssClass="itemText" MaxLength="6" OnTextChanged="txtChange" AutoPostBack="True"></asp:TextBox><br /><br />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div id="buttons">
        <asp:Button ID="btnSave" runat="server" class="btn btn-default" Text="Save" AutoPostBack="true" OnClick="btnSave_Click"/>
        <asp:Button ID="btnClear" runat="server" class="btn btn-default" Text="Clear" OnClick="btnClear_Click"  />
    </div>
    <br />
</asp:Content>
