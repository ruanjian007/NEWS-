<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="User.aspx.cs" Inherits="Admin_User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="right-frame-content">
        <div class="center-title">
            请选择查询项：<asp:DropDownList ID="ddlFindOption" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFindOption_SelectedIndexChanged">
                <asp:ListItem Value="1">会员名</asp:ListItem>
                <asp:ListItem Value="2">性别</asp:ListItem>
                <asp:ListItem Value="3">邮件地址</asp:ListItem>
                <asp:ListItem Value="4">状态</asp:ListItem>
            </asp:DropDownList>
            &nbsp;请输入查询值：<asp:TextBox ID="txtKey" runat="server" Width="73px"></asp:TextBox>
            &nbsp;<asp:DropDownList ID="ddlUserGender" runat="server" Width="43px">
                <asp:ListItem>男</asp:ListItem>
                <asp:ListItem>女</asp:ListItem>
            </asp:DropDownList>
             &nbsp;<asp:DropDownList ID="ddlIsPass" runat="server" Width="62px">
                <asp:ListItem Value="1">正常</asp:ListItem>
                <asp:ListItem Value="0">禁用</asp:ListItem>
            </asp:DropDownList>
            &nbsp;
            <asp:Button ID="btnFind" runat="server" Text="查找" OnClick="btnFind_Click" />&nbsp;<asp:Button ID="btnShowAll" runat="server" Text="显示全部" Width="76px" OnClick="btnShowAll_Click" />
        </div>
        <br />
        <div>
        <asp:GridView ID="gridUser" runat="server" AutoGenerateColumns="False" BorderColor="#999999"
            AllowPaging="True" PageSize="5" OnPageIndexChanging="gridUser_PageIndexChanging"
            DataKeyNames="UserID" Width="615px" OnRowCancelingEdit="gridUser_RowCancelingEdit"
            OnRowDeleting="gridUser_RowDeleting" OnRowEditing="gridUser_RowEditing" OnRowUpdating="gridUser_RowUpdating"
            OnRowDataBound="gridUser_RowDataBound" BackColor="White" BorderStyle="None" BorderWidth="1px"
            CellPadding="3" GridLines="Vertical" CssClass="t2" HorizontalAlign="Center">
            <Columns>
                <asp:BoundField DataField="UserName" HeaderText="会员名" ReadOnly="true">
                    <ControlStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="UserPassword" HeaderText="密码">
                    <ControlStyle Width="50px" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="性别">
                    <ItemTemplate>
                        <asp:Label ID="lblGender" runat="server" Text='<%# Bind("UserGender") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:HiddenField ID="hdfGender" runat="server" Value='<%# Eval("UserGender") %>' />
                        <asp:DropDownList ID="ddlGender" runat="server">
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="UserEmail" HeaderText="邮件地址">
                    <ControlStyle Width="80px" />
                </asp:BoundField>
                <asp:BoundField DataField="UserAsk" HeaderText="提问">
                    <ControlStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="UserAnswer" HeaderText="回答">
                    <ControlStyle Width="50px" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="状态">
                    <ItemTemplate>
                        <asp:HiddenField ID="hdfIsPassLbl" runat="server" Value='<%# Eval("IsPass") %>' />
                        <asp:Label ID="lblIsPass" runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:HiddenField ID="hdfIsPass" runat="server" Value='<%# Bind("IsPass") %>' />
                        <asp:DropDownList ID="ddlIsPass" runat="server">
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="修改" ShowEditButton="True">
                    <HeaderStyle Width="40px" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:CommandField>
                <asp:TemplateField HeaderText="删除" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                            Text="删除" OnClientClick="return confirm('真的删除吗？');"></asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle Width="40px" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:HyperLinkField DataNavigateUrlFields="UserID" DataNavigateUrlFormatString="UserLoginRecord.aspx?ID={0}"
                    HeaderText="登录记录" Target="_self" Text="登录记录" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="#DCDCDC" />
        </asp:GridView>
        </div>
    </div>
</asp:Content>
