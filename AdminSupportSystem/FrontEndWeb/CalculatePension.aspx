<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CalculatePension.aspx.cs" Inherits="FrontEndWeb.CalculatePension" %>
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
    
        <div id="confirmationCreateDiv">
            <asp:Label ID="lblMessage" runat="server" CssClass="lblMessage" ForeColor="Black"></asp:Label><br /><br />
        </div>
    <asp:Panel ID="confirmation" runat="server">
    
    <div id="EmployeeInfo">
        <asp:CheckBox ID="chk55" runat="server" Enabled="False" Text="- Are 55 or older" /><br />
        <asp:CheckBox ID="chk5" runat="server" Enabled="False" Text="- 5 years with company" /><br />
        <br />
        <table>
          <tr>
              <th><asp:Label runat="server" Text="Employee Id "></asp:Label></th>
            <th><asp:Label runat="server" Text="Employee Name "></asp:Label></th>
              <th><asp:Label runat="server" Text="Date of Birth "></asp:Label></th>
          </tr>
          <tr>
              <td><asp:Label ID="lblId" runat="server" Text="10000001"></asp:Label></td>
            <td><asp:Label ID="lblEmployee" runat="server" Text="Dylan J Romkey"></asp:Label></td>
              <td><asp:Label ID="lblDob" runat="server" Text="2/3/2002"></asp:Label></td>
          </tr>
          <tr>
              <th><asp:Label runat="server" Text="Seniority Date "></asp:Label></th>
              <th><asp:Label runat="server" Text="Full Pention Date "></asp:Label></th>
            <th><asp:Label runat="server" Text="Full Pention "></asp:Label></th>
          </tr>
          <tr>
              <td><asp:Label ID="lblSenDate" runat="server" Text="2/3/2002"></asp:Label></td>
              <td><asp:Label ID="lblPenDate" runat="server" Text="2/3/2002"></asp:Label></td>
            <td><asp:Label ID="lblPension" runat="server" Text="22.22"></asp:Label></td>
          </tr>
        </table>
         </div>
        <div class="retireTable"> 
        <table>
            <tr>
                <th colspan="2" style="padding-right:30px;"><asp:Label runat="server" Text="Early Pension Penalty "></asp:Label></th>
                <th colspan="2"><asp:Label runat="server" Text="Highest Earnings "></asp:Label></th>
            </tr>
            <tr>
                <th><asp:Label runat="server" Text="At 55"></asp:Label></th>
                <td><asp:Label ID="lbl55" runat="server" Text=""></asp:Label></td>
                <th><asp:Label ID="lblYear1" runat="server" Text="1995: "></asp:Label></th>
                <td><asp:Label ID="lblYear1G" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <th><asp:Label runat="server" Text="At 56"></asp:Label></th>
                <td><asp:Label ID="lbl56" runat="server" Text=""></asp:Label></td>
                <th><asp:Label ID="lblYear2" runat="server" Text="1995: "></asp:Label></th>
                <td><asp:Label ID="lblYear2G" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <th><asp:Label runat="server" Text="At 57"></asp:Label></th>
                <td><asp:Label ID="lbl57" runat="server" Text=""></asp:Label></td>
                <th><asp:Label ID="lblYear3" runat="server" Text="1995: "></asp:Label></th>
                <td><asp:Label ID="lblYear3G" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <th><asp:Label runat="server" Text="At 58"></asp:Label></th>
                <td><asp:Label ID="lbl58" runat="server" Text=""></asp:Label></td>
                <th><asp:Label ID="lblYear4" runat="server" Text="1995: "></asp:Label></th>
                <td><asp:Label ID="lblYear4G" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <th><asp:Label runat="server" Text="At 59"></asp:Label></th>
                <td><asp:Label ID="lbl59" runat="server" Text=""></asp:Label></td>
                <th><asp:Label ID="lblYear5" runat="server" Text="1995: "></asp:Label></th>
                <td><asp:Label ID="lblYear5G" runat="server" Text=""></asp:Label></td>
            </tr>
        </table>
    </div>
        </asp:Panel>
    <br /><br /><br />  
</asp:Content>
