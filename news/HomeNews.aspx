<%@ Page Title="" Language="C#" MasterPageFile="~/NewsMasterPage.master" AutoEventWireup="true"
    CodeFile="HomeNews.aspx.cs" Inherits="HomeNews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        /*定义三栏的主页HomeNews.htm----------------------------开始--*/
        /*左侧栏---------------------------------------------------*/
        #left-content
        {
            width: 33%;
            float: left;
            margin-right: 8px; /*与右侧边栏的间距*/
        }
        /*中间主要内容栏------------------------------------------*/
        #middle-content
        {
            width: 33%;
            float: left;
            margin-right: 3px; /*与右侧边栏的间距*/
        }
        /*右侧栏-------------------------------------------------*/
        #right-content
        {
            width: 31%;
            float: right;
        }
        /*定义三栏的主页HomeNews.htm----------------------------结束--*/
        /*定义新闻块-----------------------------------开始--*/
        /*新闻块*/
        .news_box
        {
            width: 100%;
            margin-bottom: 10px; /*边栏间距*/
        }
        /*新闻栏目标题*/
        .news_box .news_box_head
        {
            font-weight: bold;
            color: #105cb6;
            background-color: #EAF6FF;
            text-align: left;
            height: 15px;
            padding: 3px;
            border: 1px solid #A2D8FF;
        }
        /*新闻内容区*/
        .news_box .news_box_content
        {
            color: blue;
            background-color: #FBFDFF;
            line-height: 20px;
            text-align: left;
            padding: 5px;
            border: 1px solid #c3e0f5;
        }
        /*定义新闻块-----------------------------------结束--*/
        
        /*右侧边栏区，登录、最新新闻、友情链接---------开始--*/
        /*右侧边栏块*/
        .sidebar_box
        {
            width: 100%;
            margin-bottom: 10px; /*边栏间距*/
        }
        /*侧栏目标题,放在.sidebar_box中*/
        .sidebar_box .sidebar_box_head
        {
            font-size: 14px;
            font-weight: bold;
            color: #83443B;
            background-color: #FFED9C;
            border: 1px solid #FFD924;
            text-align: center;
            height: 15px;
            padding: 3px;
        }
        /*侧内容区,放在.sidebar_box中*/
        .sidebar_box .sidebar_box_content
        {
            font-size: 14px;
            color: #000000;
            background-color: #FFFCEE;
            text-align: left;
            line-height: 20px;
            min-height: 116px;
            padding: 3px;
            border: 1px solid #FFD924;
        }
        /*友情链接图片的尺寸*/
        .friend-pic
        {
            width: 290px;
            height: 44px;
        }
        /*广告条*/
        #picture
        {
            clear: both; /*此句不能省*/
        }
        /*底部图片的尺寸*/
        .bottom-pic
        {
            width: 960px;
            height: 90px;
        }
        /*右侧边栏区，登录、最新新闻、友情链接---------结束--*/
        /*定义三栏的主页NewsHome.htm----------------------------结束--*/
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!--页面主体-开始-->
    <div id="left-content">
        <!--左侧边栏-开始-->
        <div class="news_box">
            <div class="news_box_head">
                国内新闻&nbsp;<a href="NewsCategory.aspx?id=1"><img alt="more" src="Images/more2.jpg" /></a>
            </div>
            <div class="news_box_content">
                <asp:Repeater ID="repChina" runat="server">
                    <ItemTemplate>
                        <a href="NewsShow.aspx?id=<%#Eval("NewsID") %>">·<%#Eval("NewsTitle").ToString().Trim().Length > 18 ? Eval("NewsTitle").ToString().Trim().Substring(0, 18) : Eval("NewsTitle").ToString().Trim()%></a><br />
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div class="news_box">
            <div class="news_box_head">
                财经股票&nbsp;<a href="NewsCategory.aspx?id=3"><img alt="more" src="Images/more2.jpg" /></a>
            </div>
            <div class="news_box_content">
                <asp:Repeater ID="repFinance" runat="server">
                    <ItemTemplate>
                        <a href="NewsShow.aspx?id=<%#Eval("NewsID") %>">·<%#Eval("NewsTitle").ToString().Trim().Length > 18 ? Eval("NewsTitle").ToString().Trim().Substring(0, 18) : Eval("NewsTitle").ToString().Trim()%></a><br />
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div class="news_box">
            <div class="news_box_head">
                饮食健康&nbsp;<a href="NewsCategory.aspx?id=5"><img alt="more" src="Images/more2.jpg" /></a>
            </div>
            <div class="news_box_content">
                <asp:Repeater ID="repHealth" runat="server">
                    <ItemTemplate>
                        <a href="NewsShow.aspx?id=<%#Eval("NewsID") %>">·<%#Eval("NewsTitle").ToString().Trim().Length > 18 ? Eval("NewsTitle").ToString().Trim().Substring(0, 18) : Eval("NewsTitle").ToString().Trim()%></a><br />
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
    <div id="middle-content">
        <!--中部-开始-->
        <div class="news_box">
            <div class="news_box_head">
                国际新闻&nbsp;<a href="NewsCategory.aspx?id=2"><img alt="more" src="Images/more2.jpg" /></a>
            </div>
            <div class="news_box_content">
                <asp:Repeater ID="repForeign" runat="server">
                    <ItemTemplate>
                        <a href="NewsShow.aspx?id=<%#Eval("NewsID") %>">·<%#Eval("NewsTitle").ToString().Trim().Length > 18 ? Eval("NewsTitle").ToString().Trim().Substring(0, 18) : Eval("NewsTitle").ToString().Trim()%></a><br />
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div class="news_box">
            <div class="news_box_head">
                娱乐明星&nbsp;<a href="NewsCategory.aspx?id=4"><img alt="more" src="Images/more2.jpg" /></a>
            </div>
            <div class="news_box_content">
                <asp:Repeater ID="repPastime" runat="server">
                    <ItemTemplate>
                        <a href="NewsShow.aspx?id=<%#Eval("NewsID") %>">·<%#Eval("NewsTitle").ToString().Trim().Length > 18 ? Eval("NewsTitle").ToString().Trim().Substring(0, 18) : Eval("NewsTitle").ToString().Trim()%></a><br />
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div class="news_box">
            <div class="news_box_head">
                自然旅游&nbsp;<a href="NewsCategory.aspx?id=6"><img alt="more" src="Images/more2.jpg" /></a>
            </div>
            <div class="news_box_content">
                <asp:Repeater ID="repNature" runat="server">
                    <ItemTemplate>
                        <a href="NewsShow.aspx?id=<%#Eval("NewsID") %>">·<%#Eval("NewsTitle").ToString().Trim().Length > 18 ? Eval("NewsTitle").ToString().Trim().Substring(0, 18) : Eval("NewsTitle").ToString().Trim()%></a><br />
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <!--中部-结束-->
    </div>
    <div id="right-content">
        <!--右侧边栏-开始-->
        <div class="sidebar_box">
            <div class="sidebar_box_head">
                最新消息</div>
            <div class="sidebar_box_content">
                <asp:Repeater ID="repNew" runat="server">
                    <ItemTemplate>
                        <a href="NewsShow.aspx?id=<%#Eval("NewsID") %>">·<%#Eval("NewsTitle").ToString().Trim().Length > 18 ? Eval("NewsTitle").ToString().Trim().Substring(0, 18) : Eval("NewsTitle").ToString().Trim()%></a><br />
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div class="sidebar_box">
            <div class="sidebar_box_head">
                阅读排行</div>
            <div class="sidebar_box_content">
                <asp:Repeater ID="repSequence" runat="server">
                    <ItemTemplate>
                        <a href="NewsShow.aspx?id=<%#Eval("NewsID") %>">·<%#Eval("NewsTitle").ToString().Trim().Length > 18 ? Eval("NewsTitle").ToString().Trim().Substring(0, 18) : Eval("NewsTitle").ToString().Trim()%></a><br />
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div class="sidebar_box">
            <div class="sidebar_box_head">
                友情链接</div>
            <div class="sidebar_box_content">
                <asp:Repeater ID="repFriendLink" runat="server">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl='<%# Eval("LogoPath") %>'
                            NavigateUrl='<%# Eval("FriendLinkUrl") %>' Target="_blank" Text='<%# Eval("FriendLinkName","{0}") %>'
                            ToolTip='<%# Eval("FriendLinkName") %>'></asp:HyperLink><br />
                    </ItemTemplate>
                </asp:Repeater>
        </div>
        <!--右侧边栏-结束-->
    </div>
    <!--页面主体-结束-->
    </div>
</asp:Content>
