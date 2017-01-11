<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rider.aspx.cs" Inherits="Carpool.rider" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
      <asp:GridView ID="gridView" DataKeyNames="id" runat="server"
        AutoGenerateColumns="false" ShowFooter="true" HeaderStyle-Font-Bold="true"
        onrowcancelingedit="gridView_RowCancelingEdit"
        onrowdeleting="gridView_RowDeleting"
        onrowediting="gridView_RowEditing"
        onrowupdating="gridView_RowUpdating"
        onrowcommand="gridView_RowCommand"
        OnRowDataBound="gridView_RowDataBound">
<Columns>

 <asp:TemplateField HeaderText="Source">
      <ItemTemplate>
     
         <asp:Label ID="lblSource" runat="server" Text='<%#Eval("Source") %>'/>
     </ItemTemplate>
     <EditItemTemplate>
         <asp:TextBox ID="txtSource" width="70px"  runat="server" Text='<%#Eval("Source") %>'/>
     </EditItemTemplate>
     <FooterTemplate>
         <asp:TextBox ID="txtInsterSource"  width="120px" runat="server"/>
         <asp:RequiredFieldValidator ID="vname" runat="server" ControlToValidate="txtInsterSource" Text="?" ValidationGroup="validaiton"/>
     </FooterTemplate>
 </asp:TemplateField>
 <asp:TemplateField HeaderText="EmployeePhone">
     <ItemTemplate>
         <asp:Label ID="lblDestination" runat="server" Text='<%#Eval("Destination") %>'/>
     </ItemTemplate>
     <EditItemTemplate>
         <asp:TextBox ID="txtDestination" width="70px"  runat="server" Text='<%#Eval("Destination") %>'/>
     </EditItemTemplate>
    <FooterTemplate>
        <asp:TextBox ID="txtInsterDestinatione" width="110px"  runat="server"/>
        <asp:RequiredFieldValidator ID="vDestination" runat="server" ControlToValidate="txtInsterDestinatione" Text="?" ValidationGroup="validaiton"/>
    </FooterTemplate>
 </asp:TemplateField>

 <asp:TemplateField HeaderText="Date">
       <ItemTemplate>
         <asp:Label ID="lblDate" runat="server" Text='<%#Eval("Date") %>'/>
     </ItemTemplate>
     <EditItemTemplate>
         <asp:TextBox ID="txtDate" width="50px"   runat="server" Text='<%#Eval("Date") %>'/>
     </EditItemTemplate>
    <FooterTemplate>
        <asp:TextBox ID="txtInsterDate" width="60px"  runat="server"/>
        <asp:RequiredFieldValidator ID="vDate" runat="server" ControlToValidate="txtInsterDate" Text="?" ValidationGroup="validaiton"/>
    </FooterTemplate>
 </asp:TemplateField>
  <asp:TemplateField HeaderText="Time">
       <ItemTemplate>
         <asp:Label ID="lblTime" runat="server" Text='<%#Eval("Time") %>'/>
     </ItemTemplate>
     <EditItemTemplate>
         <asp:TextBox ID="txtTime" width="50px"   runat="server" Text='<%#Eval("Time") %>'/>
     </EditItemTemplate>
    <FooterTemplate>
        <asp:TextBox ID="txtInsterTime" width="60px"  runat="server"/>
        <asp:RequiredFieldValidator ID="vTime" runat="server" ControlToValidate="txtInsterTime" Text="?" ValidationGroup="validaiton"/>
    </FooterTemplate>
 </asp:TemplateField>

  <asp:TemplateField HeaderText="EmaployeeId">
       <ItemTemplate>
         <asp:Label ID="lblEmaployeeId" runat="server" Text='<%#Eval("EmpId") %>'/>
     </ItemTemplate>
     <EditItemTemplate>
         <asp:TextBox ID="txtEmaployeeId" width="50px"   runat="server" Text='<%#Eval("EmpId") %>'/>
     </EditItemTemplate>
    <FooterTemplate>
        <asp:TextBox ID="txtInsterEmaployeeId" width="60px"  runat="server"/>
        <asp:RequiredFieldValidator ID="vEmpId" runat="server" ControlToValidate="txtInsterEmaployeeId" Text="?" ValidationGroup="validaiton"/>
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
<br />&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lblmsg" runat="server"></asp:Label>
    </form>
</body>
</html>
