<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="Admin.aspx.cs" Inherits="Admin_Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="right-frame-content">
        <div class="center-title">
            输入管理员名,真实姓名,或管理员级别：
            <asp:TextBox ID="txtKey" runat="server" Width="77px"></asp:TextBox>&nbsp;
            <asp:Button ID="btnFind" runat="server" OnClick="btnFind_Click" Text="查找" Width="43px" />&nbsp;
            <asp:Button ID="btnShowAll" runat="server" OnClick="btnShowAll_Click" Text="显示全部"
                Width="74px" />
            <asp:Button ID="btnAdd" runat="server" Text="添加管理员" Width="89px" OnClick="btnAdd_Click" /><br />
        </div>
        <div style="text-align: center">
            <asp:GridView ID="gridAdmin" runat="server" AutoGenerateColumns="False" Width="565px"
                OnPageIndexChanging="gridAdmin_PageIndexChanging" 
                HorizontalAlign="Center" CellPadding="4" ForeColor="#333333" 
                GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="AdminID" HeaderText="序号" />
                    <asp:BoundField DataField="AdminName" HeaderText="管理员账号" />
                    <asp:TemplateField HeaderText="管理员密码">
                        <ItemTemplate>
                            ******
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="AdminRealName" HeaderText="真实姓名" />
                    <asp:BoundField DataField="AdminGradeID" HeaderText="管理员级别" />
                    <asp:HyperLinkField DataNavigateUrlFields="AdminID" DataNavigateUrlFormatString="AdminModify.aspx?id={0}"
                        HeaderText="修改" Text="修改" />
                    <asp:HyperLinkField DataNavigateUrlFields="AdminID" DataNavigateUrlFormatString="AdminDelete.aspx?id={0}"
                        HeaderText="删除" Text="删除" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>
