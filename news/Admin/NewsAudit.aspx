<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="NewsAudit.aspx.cs" Inherits="Admin_NewsAudit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="right-frame-content">
        <div class="center-title">
            关键字：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            &nbsp;<asp:Button ID="Button6" runat="server" Text="搜索" Width="54px" />
            &nbsp;
            <asp:Button ID="Button7" runat="server" Text="按发布日期" Width="86px" />
            &nbsp;<asp:Button ID="Button8" runat="server" Text="按发布者" />
            &nbsp;<asp:Button ID="Button9" runat="server" Text="按新闻类别" Width="90px" />
            &nbsp;<asp:Button ID="Button10" runat="server" Text="显示全部" Width="98px" />
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="754px"
            AllowPaging="True" AllowSorting="True" OnSorting="GridView1_Sorting" OnPageIndexChanging="GridView1_PageIndexChanging"
            OnRowUpdating="GridView1_RowUpdating" CellPadding="4" ForeColor="#333333" GridLines="None"
            PageSize="11" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting"
            OnRowEditing="GridView1_RowEditing">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="新闻（单击显示具体内容）">
                    <ItemTemplate>
                        <a href="..\NewsShow.aspx?id=<%#Eval("NewsID") %>" target="_blank">
                            <%#Eval("NewsTitle").ToString().Trim().Length > 24 ? Eval("NewsTitle").ToString().Trim().Substring(0, 24) : Eval("NewsTitle").ToString().Trim()%></a>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>
                <asp:BoundField DataField="NewsCategoryName" HeaderText="新闻类别" SortExpression="NewsCategoryName"
                    ReadOnly="True" ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="NewsAuthor" HeaderText="新闻来源作者" SortExpression="NewsAuthor"
                    ReadOnly="True" ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="CreatedDateTime" HeaderText="发布日期时间" SortExpression="CreatedDateTime"
                    ReadOnly="True" ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:CheckBoxField DataField="IsPass" HeaderText="审核" SortExpression="IsPass" 
                    ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:CheckBoxField>
                <asp:CommandField ShowEditButton="True" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    </div>
</asp:Content>
