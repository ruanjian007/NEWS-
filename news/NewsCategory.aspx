<%@ Page Title="" Language="C#" MasterPageFile="~/NewsMasterPage.master" AutoEventWireup="true"
    CodeFile="NewsCategory.aspx.cs" Inherits="NewsCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        /*定义两栏的栏目页NewsCategory.htm----------------------------开始--*/
        /*左边的主要内容*/
        #left-main-content
        {
            float: left;
            width: 628px; /*956-(316+2+5+2+3)=628*/
            background-color: #e6e8eb;
            height: 100%;
            border: 1px solid #72cfd7; /*画浅蓝色实线*/
        }
        /*右侧栏*/
        #right-sidebar
        {
            float: left;
            width: 316px; /*background-color: #e7f2fb; 背景色为淡蓝色,调试用，完成后最好删掉*/
            margin-left: 7px;
        }
        
        /*==用于NewsCategory.aspx,开始====*/
        /*分类新闻列表区*/
        #news_list
        {
            width: 100%;
            background-color: #e7f2fb; /*背景色为淡蓝色,调试用，完成后最好删掉*/
        }
        /*新闻列表区中的标题*/
        .news_list_title
        {
            font-size: 16px;
            font-family: 黑体, Helvetica, sans-serif;
            color: #000000;
            background-color: #EAF6FF;
            border: 1px solid #A2D8FF;
            text-align: center;
            height: 25px;
            padding-top: 8px;
        }
        /*新闻列表区中的列表内容*/.news_list_content
        {
            color: #000000;
            font-family: 宋体, Helvetica, sans-serif;
            background-color: #FBFDFF;
            border: 1px solid #c3e0f5;
            line-height: 20px;
            text-align: left;
            padding: 10px;
        }
        /*新闻列表区中的页码*/.news_list_page
        {
            line-height: 20px;
            text-align: center;
            height: 20px;
            border: 1px solid #c3e0f5;
        }
        /*==用于NewsCategory.aspx,结束====*/
        
        
        /*==用于NewsCategory.aspx,NewsShow.aspx中的最新新闻。开始====*/
        
        /*最新新闻块*/
        .new_news_box
        {
            width: 100%;
            margin-bottom: 10px; /*底边与footer的间距*/
        }
        /*最新新闻标题*/
        .new_news_box .new_news_head
        {
            font-weight: bold;
            color: #83443B;
            background-color: #FFED9C;
            text-align: center;
            height: 15px;
            padding: 3px;
            border: 1px solid #FFD924;
        }
        /*最新新闻内容*/
        .new_news_box .new_news_content
        {
            color: #000000;
            background-color: #FFFCEE;
            line-height: 20px;
            text-align: left;
            padding: 5px;
            border: 1px solid #FFD924;
        }
        /*==用于NewsCategory.aspx,NewsShow.aspx中的最新新闻。结束====*/
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!--页面主体-开始-->
    <div id="left-main-content">
        <!--左侧主内容-开始-->
        <div id="news_list">
            <div class="news_list_title">
                新闻列表
            </div>
            <div class="news_list_content">
            <table cellpadding="0" cellspacing="0" style="width: 96%;" border="0">
                <asp:Repeater ID="repNewsCategoryList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td style="width: 375px;">
                                ·<a href="NewsShow.aspx?id=<%#Eval("NewsID") %>"><%#Eval("NewsTitle") %></a></td>
                            <td>
                                <%#Eval("CreatedDateTime","{0:g}") %>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            </div>
            <div class="news_list_page">
            <asp:LinkButton ID="lbtnFirstPage" runat="server" OnClick="lbtnFirstPage_Click">首页</asp:LinkButton>
            <asp:LinkButton ID="lbtnpritPage" runat="server" OnClick="lbtnpritPage_Click">上一页</asp:LinkButton>
            <asp:LinkButton ID="lbtnNextPage" runat="server" OnClick="lbtnNextPage_Click">下一页</asp:LinkButton>
            <asp:LinkButton ID="lbtnDownPage" runat="server" OnClick="lbtnDownPage_Click">尾页</asp:LinkButton>
            第<asp:Label ID="lblPage" runat="server" Text="Label"></asp:Label>页/共<asp:Label ID="lblCountPage"
                runat="server" Text="Label"></asp:Label>页 共<asp:Label ID="lblTotal" runat="server" />条新闻
            </div>
        </div>
        <!--左侧主内容-结束-->
    </div>
    <div id="right-sidebar">
        <!--右侧边栏-开始-->
        <div class="new_news_box">
            <div class="new_news_head">
                最新消息</div>
            <div class="new_news_content">
                <asp:Repeater ID="repNew" runat="server">
                    <ItemTemplate>
                        <a href="NewsShow.aspx?id=<%#Eval("NewsID") %>">·<%#Eval("NewsTitle").ToString().Trim().Length > 18 ? Eval("NewsTitle").ToString().Trim().Substring(0, 18) : Eval("NewsTitle").ToString().Trim()%></a><br />
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div class="new_news_box">
            <div class="new_news_head">
                阅读排行</div>
            <div class="new_news_content">
                 <asp:Repeater ID="repSequence" runat="server">
                    <ItemTemplate>
                        <a href="NewsShow.aspx?id=<%#Eval("NewsID") %>">·<%#Eval("NewsTitle").ToString().Trim().Length > 18 ? Eval("NewsTitle").ToString().Trim().Substring(0, 18) : Eval("NewsTitle").ToString().Trim()%></a><br />
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <!--右侧边栏-结束-->
    </div>
    <!--页面主体-结束-->
</asp:Content>
