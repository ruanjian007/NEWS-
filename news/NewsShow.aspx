<%@ Page Title="" Language="C#" MasterPageFile="~/NewsMasterPage.master" AutoEventWireup="true"
    CodeFile="NewsShow.aspx.cs" Inherits="NewsShow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        /*定义两栏的内容页NewsShow.htm----------------------------开始--*/
        /*左侧栏*/
        #left-sidebar
        {
            float: left;
            width: 316px;
            height: 100%; /*为什么不会随着右侧块而加长？？？？？？？？？？？？？？？？？？？？？？？？*/
            background-color: #e6e8eb; /*背景色为淡蓝色,调试用，完成后最好删掉*/
            margin-bottom: 10px;
        }
        /*主要内容*/
        #right-main-content
        {
            float: right;
            margin-left: 5px; /*与左侧栏的间距*/
            width: 632px; /*960-(316+2+5+2+3)=632*/
            height: 100%; /*background: #EEE;调试用，完成后最好删掉*/
            margin-bottom: 10px;
        }
        
        /*==用于NewsCategory.aspx,NewsShow.aspx中的最新新闻。开始====*/
        /*最新新闻块*/
        .new_news_box
        {
            width: 100%;
            height: 100%; /*为什么不会随着右侧块而加长？？？？？？？？？？？？？？？？？？？？？？？？*/
            margin-bottom: 10px;
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
            min-height: 100%;
            background-color: #FFFCEE;
            line-height: 20px;
            text-align: left;
            padding: 5px;
            border: 1px solid #FFD924;
        }
        /*==用于NewsCategory.aspx,NewsShow.aspx中的最新新闻。结束====*/
        
        /*新闻内容区*/#news
        {
            width: 100%;
        }
        /*新闻区中的标题*/.news_title
        {
            font-size: 16px;
            font-family: 黑体, Helvetica, sans-serif;
            color: #000000;
            background-color: #EAF6FF;
            text-align: center;
            height: 25px;
            padding-top: 8px;
            border: 1px solid #A2D8FF;
        }
        /*新闻区中的作者*/.news_author
        {
            color: #000000;
            font-family: 宋体, Helvetica, sans-serif;
            background-color: #FBFDFF;
            line-height: 20px;
            text-align: center;
            height: 20px;
            padding-top: 3px;
            border: 1px solid #c3e0f5;
        }
        
        /*新闻区中的图片，只显示一张图片*/.news_picture
        {
            color: #000000;
            background-color: #FBFDFF;
            text-align: center;
            padding: 10px 0px 0px 0px; 
            border-style: solid;
            border-width: 1px 1px 0px 1px;/*下边线不显示*/
            border-color: #c3e0f5;
        }
        /*新闻区中的内容*/.news_content
        {
            color: #000000;
            font-family: 宋体, Helvetica, sans-serif;
            background-color: #FBFDFF;
            line-height: 20px;
            text-align: left;
            padding: 5px 10px 10px 10px;
            border-style: solid;
            border-width: 0px 1px 1px 1px; /* 上边线不显示*/
            border-color: #c3e0f5;          
        }
        
        /*右侧评论区,写在#main中*/#review
        {
            width: 100%;
            margin-top: 5px;
        }
        /*评论区中的标题*/.review_title
        {
            font-size: 14px;
            font-family: 黑体, Helvetica, sans-serif;
            color: #000000;
            background-color: #EAF6FF;
            text-align: left;
            height: 22px;
            padding-top: 6px;
            padding-left: 3px;
            border: 1px solid #A2D8FF;
        }
        /*评论区中的内容*/.review_reviewer
        {
            color: #000000;
            font-family: 宋体, Helvetica, sans-serif;
            background-color: #EAF6FF;
            line-height: 20px;
            text-align: left;
            padding-top: 0px;
            border: 1px solid #c3e0f5;
        }
        /*评论区中的内容*/.review_content
        {
            color: #000000;
            font-family: 宋体, Helvetica, sans-serif;
            background-color: #FBFDFF;
            line-height: 20px;
            text-align: left;
            padding-top: 0px;
            border: 1px solid #c3e0f5;
        }
        /*评论区中的输入内容*/.review_content_new
        {
            color: #000000;
            font-family: 宋体, Helvetica, sans-serif;
            background-color: #FBFDFF;
            line-height: 20px;
            text-align: right;
            padding: 10px;
            border: 1px solid #c3e0f5;
        }
        .review1
        {
            width: 617px;
            color: #000000;
            font-family: 宋体, Helvetica, sans-serif;
            background-color: #EAF6FF;
            line-height: 20px;
            text-align: left;
            padding-top: 8px;
            border: 1px solid #c3e0f5;
        }
        .review2
        {
            width: 617px;
            color: #000000;
            font-family: 宋体, Helvetica, sans-serif;
            background-color: #FBFDFF;
            line-height: 20px;
            text-align: left;
            padding-top: 8px;
            border: 1px solid #c3e0f5;
        }
        .style1
        {
            text-decoration: underline;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!--页面主体-开始-->
    <div id="left-sidebar">
        <!--左侧边栏-开始-->
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
    </div>
    <div id="right-main-content">
        <!--右侧主内容-开始-->
        <div id="news">
            <div class="news_title">
                <asp:Label ID="lblNewsTitle" runat="server"></asp:Label>
            </div>
            <div class="news_author">
                来源:<asp:Label ID="lblNewsAuthor" runat="server"></asp:Label>&nbsp; &nbsp; 
                发表时间:<asp:Label ID="lblCreatedDateTime" runat="server"></asp:Label>&nbsp;&nbsp; 
                浏览次数:<asp:Label ID="lblShowPageCount" runat="server"></asp:Label>
            </div>
            <div class="news_picture">
                <asp:Image ID="imgNewsPicture" runat="server" /> <!--新闻图片-->
            </div>
            <div class="news_content">
                <asp:Label ID="lblNewsContent" runat="server"></asp:Label> <!--新闻内容-->
            </div>
        </div>
        <div id="review">
            <div class="review_title">
                网友热评（已经有<asp:Label ID="lblReviewCount" runat="server"></asp:Label>人参与）
            </div>
            <div class="review_content">
                <table cellpadding="10" cellspacing="0" style="width: 99%">
                    <asp:Repeater ID="repReviewList" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="review_reviewer">
                                    网友:<%#Eval("UserName")%>&nbsp; &nbsp;发表时间:<%#Eval("CreatedDateTime")%></td>
                            </tr>
                            <tr>
                                <td class="review_content">
                                    <%#Eval("UserReviewContent")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
            <div class="review_title">
                我要评论(<asp:Label ID="lblUserName" runat="server"></asp:Label>
                <asp:LinkButton ID="lbtnExit" runat="server" ForeColor="Blue" OnClick="lbtnExit_Click">退出</asp:LinkButton>
                <asp:LinkButton ID="lbtnLogin" runat="server" ForeColor="Blue" OnClick="lbtnLogin_Click">登录</asp:LinkButton>）
            </div>
            <div class="review_content_new">
                <asp:TextBox ID="txtUserReviewContent" runat="server" Height="80px" TextMode="MultiLine"
                    Width="610px" Style="margin-left: 0px"></asp:TextBox>
                <asp:Button ID="btnOK" runat="server" Text="提交评论" OnClick="btnOK_Click" />
            </div>
        </div>
        <!--右侧主内容-结束-->
    </div>
    <!--页面主体-结束-->
</asp:Content>
