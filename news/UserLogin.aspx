<%@ Page Title="" Language="C#" MasterPageFile="~/NewsMasterPage.master" AutoEventWireup="true"
    CodeFile="UserLogin.aspx.cs" Inherits="UserLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        #main-content
        {
            line-height: 30px;
            background-color: #EAF6FF;
            border: 1px solid #A2D8FF;
            margin: 0px auto;
        }
        .table_content
        {
            margin: 60px auto; /*重新定义表格层容器的上距*/
        }
        #Text1
        {
            width: 150px;
        }
        #Text2
        {
            width: 150px;
        }
        .style1
        {
            text-align: left;
            width: 7px;
            height: 32px;
        }
        .style2
        {
            width: 43%;
            text-align: right;
            height: 32px;
        }
        .style3
        {
            text-align: left;
            height: 32px;
        }
        .style4
        {
            text-align: left;
            height: 32px;
            width: 56px;
        }
        .style5
        {
            width: 43%;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!--页面主体-开始-->
    <div id="main-content">
        <div class="table_content">
            <!--表格层容器-开始-->
            <table>
                <tr>
                    <th class="style5">
                    </th>
                    <th class="td_right" colspan="3">
                        &nbsp; &nbsp;&nbsp;登 录
                    </th>
                </tr>
                <tr>
                    <td class="style5">
                        用户名：
                    </td>
                    <td class="td_right" colspan="3">
                        <asp:TextBox ID="txtUserName" runat="server" Width="150px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                            ErrorMessage="必须输入!" ControlToValidate="txtUserName" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="只能输入字母和(或)数字！"
                            ControlToValidate="txtUserName" ValidationExpression="^[A-Za-z0-9]+$" 
                            ForeColor="Red"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style5">
                        密码：
                    </td>
                    <td class="td_right" colspan="3">
                        <asp:TextBox ID="txtUserPassword" runat="server" TextMode="Password" Width="150px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="必须输入！"
                            ControlToValidate="txtUserPassword" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtUserPassword"
                            ErrorMessage="只能输入字母和(或)数字！" ValidationExpression="^[A-Za-z0-9]+$" 
                            ForeColor="Red"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        验证码：
                    </td>
                    <td class="style1">
                        <asp:TextBox ID="txtValidateCode" runat="server" Width="49px"></asp:TextBox>
                    </td>
                    <td class="style4">
                        <img id="imgCode" alt="看不清，请单击我!" src="ValidateCode2.aspx" style="cursor: hand; width: 55px;
                            height: 25px" onclick="this.src=this.src+'?'" />
                    </td>
                    <td class="style3">
                        按图中字符填写，不区分大小写，单击图片换一组验证码
                    </td>
                </tr>
                <tr>
                    <td class="style5">
                        登录保留：
                    </td>
                    <td class="td_right" colspan="3">
                        &nbsp;<asp:DropDownList ID="ddlDay" runat="server">
                            <asp:ListItem Selected="True">一天</asp:ListItem>
                            <asp:ListItem>一月</asp:ListItem>
                            <asp:ListItem>一年</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style5">
                    </td>
                    <td class="td_right" colspan="3">
                        <asp:Button ID="btnOK" runat="server" Text="登录" OnClick="btnOK_Click" />&nbsp;
                        <asp:LinkButton ID="lbtnUserRegiste" runat="server" CausesValidation="False" 
                            OnClick="lbtnUserRegiste_Click" Font-Underline="True">注册新会员</asp:LinkButton>&nbsp;
                        <asp:LinkButton ID="lbtnForgotPassword" runat="server" CausesValidation="False" 
                            OnClick="lbtnForgotPassword_Click" Font-Underline="True">忘记密码</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td class="style5">
                    </td>
                    <td class="td_right" colspan="3">
                    </td>
                </tr>
                <tr>
                    <td class="style5">
                    </td>
                    <td id="lblMsg" class="td_right" colspan="3">
                        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
            <!--表格层容器-结束-->
        </div>
    </div>
    <div style="clear: both; display: block">
    </div>
    <!--页面主体-结束-->
</asp:Content>
