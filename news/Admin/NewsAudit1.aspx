﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="NewsAudit1.aspx.cs" Inherits="Admin_NewsAudit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>审核新闻</title>
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
        <table border="1" class="t1">
            <tr>
                <th class="style2">
                    新闻标题（单击查看）
                </th>
                <th>
                    新闻类别
                </th>
                <th>
                    发布者
                </th>
                <th>
                    发布时间
                </th>
                <th>
                    审核
                </th>
            </tr>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <tr>
                        <td  style="text-align:left">
                            <a href="..\NewsShow.aspx?id=<%#Eval("NewsID") %>" target="_blank">
                                <%#Eval("NewsTitle").ToString().Trim().Length > 24 ? Eval("NewsTitle").ToString().Trim().Substring(0, 24) : Eval("NewsTitle").ToString().Trim()%></a>
                        </td>
                        <td >
                            <%#Eval("NewsCategoryName") %>
                        </td>
                        <td>
                            <%#Eval("NewsAuthor") %>
                        </td>
                        <td>
                            <%#Eval("CreatedDateTime") %>
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%#Eval("IsPass") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <table border="0" cellspacing="0">
            <tr>
                <td class="style1">
                    <asp:LinkButton ID="lbtnFirstPage" runat="server" OnClick="lbtnFirstPage_Click">首页</asp:LinkButton>&nbsp;
                    <asp:LinkButton ID="lbtnpritPage" runat="server" OnClick="lbtnpritPage_Click">上一页</asp:LinkButton>&nbsp;
                    <asp:LinkButton ID="lbtnNextPage" runat="server" OnClick="lbtnNextPage_Click">下一页</asp:LinkButton>&nbsp;
                    <asp:LinkButton ID="lbtnDownPage" runat="server" OnClick="lbtnDownPage_Click">尾页</asp:LinkButton>&nbsp;
                    第
                    <asp:Label ID="labPage" runat="server" Text="Label"></asp:Label>
                    页 (共
                    <asp:Label ID="LabCountPage" runat="server" Text="Label"></asp:Label>
                    页)
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
