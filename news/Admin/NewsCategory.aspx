<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="NewsCategory.aspx.cs" Inherits="Admin_NewsCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 500px;
            border-style: solid;
            border-width: 1px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="right-frame-content">
        <asp:GridView ID="gridNewsCategory" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="gridNewsCategory_PageIndexChanging"
            HorizontalAlign="Center" Width="294px" CellPadding="4" ForeColor="#333333" 
            GridLines="None" onrowcancelingedit="gridNewsCategory_RowCancelingEdit" 
            onrowdeleting="gridNewsCategory_RowDeleting" 
            onrowediting="gridNewsCategory_RowEditing" 
            onrowupdating="gridNewsCategory_RowUpdating">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="NewsCategoryName" HeaderText="新闻类别名称" />
                <asp:BoundField DataField="NewsCategorySort" HeaderText="显示顺序" />
                <asp:CommandField HeaderText="编辑删除" ShowDeleteButton="True" ShowEditButton="True"
                    ShowHeader="True" />
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
        <br />
        <br />
        <div style="margin-left: 0px">
            <table width="360px" border="0" cellspacing="2" cellpadding="0" class="t2">
                <tr>
                    <th colspan="2">
                        添加新闻类别
                    </th>
                </tr>
                <tr>
                    <td class="tdright" style="color: #000000">
                        新闻类别名称：
                    </td>
                    <td class="tdleft">
                        <asp:TextBox ID="txtNewsCategoryName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="tdright" style="color: #000000">
                        显示顺序：
                    </td>
                    <td class="tdleft">
                        <asp:TextBox ID="txtNewsCategorySort" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnOK" runat="server" Text="添加" OnClick="btnOK_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
