<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="Carpool.Employee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
  <form id="form1" runat="server">
<div>
<asp:GridView ID="gridView" DataKeyNames="Empid" runat="server"
        AutoGenerateColumns="false" ShowFooter="true" HeaderStyle-Font-Bold="true"
        onrowcancelingedit="gridView_RowCancelingEdit"
        onrowdeleting="gridView_RowDeleting"
        onrowediting="gridView_RowEditing"
        onrowupdating="gridView_RowUpdating"
        onrowcommand="gridView_RowCommand"
        OnRowDataBound="gridView_RowDataBound">
<Columns>
<%--<asp:TemplateField HeaderText="Empid">
    <ItemTemplate>
        <asp:Label ID="txtEmpid" runat="server" Text='<%#Eval("Empid") %>'/>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:Label ID="lblEmpid" runat="server" width="40px" Text='<%#Eval("Empid") %>'/>
    </EditItemTemplate>
    
</asp:TemplateField>--%>
 <asp:TemplateField HeaderText="EmployeeName">
      <ItemTemplate>
     
         <asp:Label ID="lblEmployeeName" runat="server" Text='<%#Eval("EmployeeName") %>'/>
     </ItemTemplate>
     <EditItemTemplate>
         <asp:TextBox ID="txtEmployeeName" width="70px"  runat="server" Text='<%#Eval("EmployeeName") %>'/>
     </EditItemTemplate>
     <FooterTemplate>
         <asp:TextBox ID="txtInsterEmpName"  width="120px" runat="server"/>
         <asp:RequiredFieldValidator ID="vname" runat="server" ControlToValidate="txtInsterEmpName" Text="?" ValidationGroup="validaiton"/>
     </FooterTemplate>
 </asp:TemplateField>
 <asp:TemplateField HeaderText="EmployeePhone">
     <ItemTemplate>
         <asp:Label ID="lblEmployeePhone" runat="server" Text='<%#Eval("EmployeePhone") %>'/>
     </ItemTemplate>
     <EditItemTemplate>
         <asp:TextBox ID="txtEmployeePhone" width="70px"  runat="server" Text='<%#Eval("EmployeePhone") %>'/>
     </EditItemTemplate>
    <FooterTemplate>
        <asp:TextBox ID="txtInsterEmpphone" width="110px"  runat="server"/>
        <asp:RequiredFieldValidator ID="vPhone" runat="server" ControlToValidate="txtInsterEmpphone" Text="?" ValidationGroup="validaiton"/>
    </FooterTemplate>
 </asp:TemplateField>
  <asp:TemplateField HeaderText="EmployeeEmail">
       <ItemTemplate>
         <asp:Label ID="lblEmployeeEmail" runat="server" Text='<%#Eval("EmployeeEmail") %>'/>
     </ItemTemplate>
     <EditItemTemplate>
         <asp:TextBox ID="txtEmployeeEmail" width="50px"   runat="server" Text='<%#Eval("EmployeeEmail") %>'/>
     </EditItemTemplate>
    <FooterTemplate>
        <asp:TextBox ID="txtInsterEmpEmail" width="60px"  runat="server"/>
        <asp:RequiredFieldValidator ID="vEmail" runat="server" ControlToValidate="txtInsterEmpEmail" Text="?" ValidationGroup="validaiton"/>
    </FooterTemplate>
 </asp:TemplateField>

 <asp:TemplateField>
    <EditItemTemplate>
        <asp:Button ID="ButtonUpdate" runat="server" CommandName="Update"  Text="Update"  />
        <asp:Button ID="ButtonCancel" runat="server" CommandName="Cancel"  Text="Cancel" />
    </EditItemTemplate>
    <ItemTemplate>
        <asp:Button ID="ButtonEdit" runat="server" CommandName="Edit"  Text="Edit"  />
        <asp:Button ID="ButtonDelete" runat="server" CommandName="Delete"  Text="Delete"  />
    </ItemTemplate>
    <FooterTemplate>
        <asp:Button ID="ButtonAdd" runat="server" CommandName="AddNew"  Text="Add New Row" ValidationGroup="validaiton" />
    </FooterTemplate>
 </asp:TemplateField>
 </Columns>
</asp:GridView>
    </div>
<div >
<br />&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lblmsg" runat="server"></asp:Label>
</div>
    </form>
</body>
</html>
