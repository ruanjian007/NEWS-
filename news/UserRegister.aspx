<%@ Page Title="" Language="C#" MasterPageFile="~/NewsMasterPage.master" AutoEventWireup="true"
    CodeFile="UserRegister.aspx.cs" Inherits="UserRegister" %>

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
            margin: 10px auto; /*重新定义表格层容器的上距*/
        }
        #Text1
        {
            width: 151px;
        }
        #Password1
        {
            width: 151px;
        }
        #Password2
        {
            width: 151px;
        }
        #Select1
        {
            width: 150px;
        }
        .style1
        {
            text-align: left;
            width: 459px;
        }
        .style2
        {
            text-align: left;
            width: 48px;
        }
        .style3
        {
            text-align: left;
            width: 61px;
        }
        .style4
        {
            width: 39%;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!--页面主体-开始-->
    <div id="main-content">
        <div class="table_content">
            <!--表格层容器-开始-->
            <table border="0">
                <tr>
                    <th class="style4">
                    </th>
                    <th class="style1" colspan="3">
                        &nbsp;&nbsp;&nbsp;会员注册
                    </th>
                </tr>
                <tr>
                    <td class="style4">
                        注册名：
                    </td>
                    <td class="style1" colspan="3">
                        <asp:TextBox ID="txtUserName" runat="server" Width="150px"></asp:TextBox>
                        <span style="color: red">*</span>
                        <asp:LinkButton ID="lbtnCheckUserName" runat="server" OnClick="lbtnCheckUserName_Click"
                            CausesValidation="False" ForeColor="Black" Font-Underline="True">检查注册名</asp:LinkButton>&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName"
                            Display="Dynamic" ErrorMessage="必须输入!" ForeColor="Red">
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtUserName"
                            ValidationExpression="^[A-Za-z0-9]+$" Display="Dynamic" ErrorMessage="只能输入字母和(或)数字！     "
                            ForeColor="Red"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        密码：
                    </td>
                    <td class="style1" colspan="3">
                        <asp:TextBox ID="txtUserPassword" runat="server" Width="150px" TextMode="Password"></asp:TextBox>
                        <span style="color: red">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="必须输入！"
                            Display="Dynamic" ControlToValidate="txtUserPassword" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        再输入一遍密码：
                    </td>
                    <td class="style1" colspan="3">
                        <asp:TextBox ID="txtUserPasswordAgain" runat="server" Width="150px" TextMode="Password"></asp:TextBox>
                        <span style="color: red">*</span>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="两次输入的密码不同!"
                            ControlToCompare="txtUserPassword" ControlToValidate="txtUserPasswordAgain" Display="Dynamic"
                            ForeColor="Red"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        性别：
                    </td>
                    <td class="style1" colspan="3">
                        <asp:RadioButtonList ID="radlUserGender" runat="server" RepeatDirection="Horizontal"
                            Width="110px">
                            <asp:ListItem Selected="True">男</asp:ListItem>
                            <asp:ListItem>女</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        电子邮件地址：
                    </td>
                    <td class="style1" colspan="3">
                        <asp:TextBox ID="txtUserEmail" runat="server" Width="150px"></asp:TextBox>&nbsp;<asp:RegularExpressionValidator
                            ID="RegularExpressionValidator3" runat="server" ErrorMessage="邮件地址格式不正确！" ControlToValidate="txtUserEmail"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"
                            ForeColor="Red"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        提示的问题：
                    </td>
                    <td class="style1" colspan="3">
                        <asp:DropDownList ID="ddlUserAsk" runat="server">
                            <asp:ListItem>你最喜欢吃的食品？</asp:ListItem>
                            <asp:ListItem>你最喜爱的运动？</asp:ListItem>
                            <asp:ListItem>你最好朋友的名字？</asp:ListItem>
                            <asp:ListItem>你最喜欢的明星？</asp:ListItem>
                            <asp:ListItem>你的宠物名字？</asp:ListItem>
                            <asp:ListItem>你最爱看的小说？</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        提示问题的回答：
                    </td>
                    <td class="style1" colspan="3">
                        <asp:TextBox ID="txtUserAnswer" runat="server" Width="150px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        验证码：
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="txtValidateCode" runat="server" Width="50px"></asp:TextBox>
                    </td>
                    <td class="style3">
                        <img id="imgCode" alt="看不清，请单击我!" src="ValidateCode.aspx" style="cursor: hand; width: 55px;
                            height: 25px" onclick="this.src=this.src+'?'" />
                    </td>
                    <td class="style1">
                        按图中字符填写，不区分大小写，单击图片换一组验证码
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                    </td>
                    <td class="style1" colspan="3">
                        <asp:CheckBox ID="chkUserAgree" runat="server" Text="同意" />&nbsp; <a href="UseTreaty.aspx"
                            target="_blank" style="text-decoration: underline">网站服务条款</a>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                    </td>
                    <td class="style1" colspan="3">
                        &nbsp; &nbsp;<asp:Button ID="btnOK" runat="server" Text="注册" OnClick="btnOK_Click" />
                        &nbsp;<asp:Button ID="btnReturn" runat="server" Text="返回" OnClick="btnReturn_Click" />
                    </td>
                </tr>
            </table>
            <!--表格层容器-结束-->
        </div>
        <!--页面主题-结束-->
    </div>
</asp:Content>
