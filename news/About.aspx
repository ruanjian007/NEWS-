<%@ Page Language="C#" MasterPageFile="~/NewsMasterPage.master" AutoEventWireup="true"
    CodeFile="About.aspx.cs" Inherits="About" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        #main-content
        {
            line-height: 25px;
            background-color: #EAF6FF;
            padding: 10px;
            border: 1px solid #A2D8FF;
            margin: 0px auto;
        }
        p
        {
            text-indent: 2em; /*段首空2个字符*/
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!--页面主体-开始-->
    <div id="main-content">
        <p>
            本网站正在建设中......</p>
    </div>
    <!--页面主体-结束-->
</asp:Content>
