<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="FriendLink.aspx.cs" Inherits="Admin_FriendLink" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
<asp:GridView ID="gridFriendLink" runat="server" AutoGenerateColumns="False" 
            OnPageIndexChanging="gridFriendLink_PageIndexChanging" 
            onrowdeleting="gridFriendLink_RowDeleting" Width="613px" 
        Caption="&lt;strong&gt;友情链接管理&lt;/strong&gt;" CssClass="t2" 
        HorizontalAlign="Center">
            <Columns>
                <asp:BoundField DataField="FriendLinkName" HeaderText="名称" >
                    <ControlStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="FriendLinkUrl" HeaderText="链接地址" >
                    <ControlStyle Width="150px" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Logo图片">
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("LogoPath","{0}") %>' 
                            Height="30px" Width="100px" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="FriendLinkSort" HeaderText="显示顺序" >
                    <ControlStyle Width="50px" />
                </asp:BoundField>
                <asp:CommandField ShowDeleteButton="True" >
                    <ControlStyle Width="50px" />
                </asp:CommandField>
            </Columns>
        </asp:GridView>
</asp:Content>

