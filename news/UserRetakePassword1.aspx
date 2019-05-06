<%@ Page Language="C#" MasterPageFile="~/NewsMasterPage.master" AutoEventWireup="true"
    CodeFile="UserRetakePassword1.aspx.cs" Inherits="UserRetakePassword1" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .pwd_step
        {
            margin: 20px auto;
            padding: 0px 0px 0px 0px;
            width: 750px;
            height: 80px;
            background: url(images/m_step2.jpg) no-repeat 0px 0px;
            font-size: 14px;
            text-align: center;
        }
        .pwd_content
        {
            margin: 20px auto;
            padding: 0px 0px 0px 0px;
            width: 750px;
            height: 250px;
            font-size: 14px;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="text-align: center; margin: 50px auto;">
        <div class="pwd_step">
        </div>
        <div class="pwd_content" style="font-size: 14px">
            <table class="table">
                <tr>
                    <td colspan="2" style="text-align: right">
                        注册会员名：
                    </td>
                    <td colspan="2" style="text-align: left">
                        <asp:Label ID="lblName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 201px; text-align: right">
                        <img alt="" src="images/m_step2_1.PNG" />
                    </td>
                    <td style="width: 159px; text-align: left">
                        <asp:LinkButton ID="lbtnUsePassword" runat="server" OnClick="lbtnUsePassword_Click">通过密码提示问题</asp:LinkButton>
                    </td>
                    <td style="text-align: right">
                        <img alt="" src="images/m_step2_2.PNG" />
                    </td>
                    <td style="text-align: left">
                        <asp:LinkButton ID="lbtnUseEmail" runat="server" OnClick="lbtnUseEmail_Click">通过保密邮箱</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
