<%@ Page Language="C#" MasterPageFile="~/admin/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="UserLoginRecord.aspx.cs" Inherits="admin_UserLoginRecord" Title="显示会员登录记录" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    会员管理&gt;&gt;管理注册会员&gt;&gt;显示会员登录记录<br />
    <br />
    <div align="center">
        <asp:GridView ID="gridUserLogin" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" ForeColor="#333333" GridLines="None" 
            OnPageIndexChanging="gridUserLogin_PageIndexChanging">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
           <Columns>
               <asp:BoundField DataField="UserID" HeaderText="会员ID" />
               <asp:TemplateField HeaderText="会员名">
                   <ItemTemplate>
                       <asp:Label ID="Label1" runat="server" 
                           Text='<%# GetUserName() %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:BoundField DataField="LoginDateTime" HeaderText="登录日期时间" />
               <asp:BoundField DataField="LoginIP" HeaderText="登录IP" />
           </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
       </asp:GridView>
        &nbsp; &nbsp;
    </div>
</asp:Content>

