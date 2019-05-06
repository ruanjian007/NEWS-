<%@ Page Title="" Language="C#" MasterPageFile="~/NewsMasterPage.master" AutoEventWireup="true"
    CodeFile="UserLoginOk.aspx.cs" Inherits="UserLoginOk" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .lable
        {
            padding: 100px 0px 100px 0px;
            width: 100%;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!--页面主体-开始-->
    <div class="lable">
        会员名：<asp:Label ID="lblMessage" runat="server"></asp:Label>&nbsp; &nbsp;<asp:LinkButton
            ID="lbtnEdit" runat="server" OnClick="lbtnEdit_Click" 
            Font-Underline="True">修改会员资料</asp:LinkButton>&nbsp;
        &nbsp;<asp:LinkButton ID="lbtnExit" runat="server" OnClick="lbtnExit_Click" 
            Font-Underline="True">退出登录</asp:LinkButton>
        <br />
    </div>
    <!--页面主体-结束-->
</asp:Content>
