<%@ Page Title="" Language="C#" MasterPageFile="~/NewsMasterPage.master" AutoEventWireup="true"
    CodeFile="UserEdit.aspx.cs" Inherits="UserEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .table_content
        {
            margin: 10px auto; /*重新定义表格层容器的上距*/
        }
        .style2
        {
            width: 366px;
        }
        .style3
        {
            width: 366px;
            text-align: right;
        }
        .style4
        {
            width: 579px;
        }
        .style5
        {
            text-align: left;
            width: 579px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!--表格层容器-开始-->
    <table border="0">
        <tr>
            <th class="style2">
            </th>
            <th colspan="3" style="text-align: left" class="style4">
                &nbsp;&nbsp; 会员修改资料
            </th>
        </tr>
        <tr>
            <td class="style3">
                会员注册名：
            </td>
            <td class="style4">
                <asp:Label ID="lblUserName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style3">
                现在的密码：
            </td>
            <td class="style5">
                <asp:TextBox ID="txtUserPassword" runat="server" TextMode="Password" Width="150px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="必须输入！"
                    ControlToValidate="txtUserPassword" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtUserPassword"
                    ErrorMessage="只能输入字母和(或)数字！" ValidationExpression="^[A-Za-z0-9]+$" 
                    Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
                新密码：
            </td>
            <td class="style4">
                <asp:TextBox ID="txtPasswordNew" runat="server" Width="150px" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPasswordNew"
                    ErrorMessage="必须输入！" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPasswordNew"
                    ErrorMessage="只能输入字母和(或)数字！" ValidationExpression="^[A-Za-z0-9]+$" 
                    Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
                再次输入新密码：
            </td>
            <td class="style4">
                <asp:TextBox ID="txtPasswordNew1" runat="server" Width="150px" TextMode="Password"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="两次输入的密码不同！"
                    ControlToCompare="txtPasswordNew" ControlToValidate="txtPasswordNew1" 
                    Display="Dynamic" ForeColor="Red"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
                性别：
            </td>
            <td class="style4">
                <asp:RadioButtonList ID="radlUserGender" runat="server" RepeatDirection="Horizontal"
                    Width="110px">
                    <asp:ListItem Selected="True">男</asp:ListItem>
                    <asp:ListItem>女</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="style3">
                电子邮件地址：
            </td>
            <td class="style4">
                <asp:TextBox ID="txtUserEmail" runat="server" Width="150px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtUserEmail"
                    Display="Dynamic" ErrorMessage="邮件地址格式不正确！" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                    ForeColor="Red"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
                提示的问题：
            </td>
            <td class="style4">
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
            <td class="style3">
                提示问题的回答：
            </td>
            <td class="style4">
                <asp:TextBox ID="txtUserAnswer" runat="server" Width="150px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
            </td>
            <td colspan="3" class="style4">
                &nbsp;<asp:Button ID="btnOk" runat="server" Text="保存修改" OnClick="btnOk_Click" />
                &nbsp;
                <asp:Button ID="btnReturn" runat="server" Text="不保存返回" OnClick="btnReturn_Click" />
            &nbsp;
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
    <!--表格层容器-结束-->
    
    <!--页面主题-结束-->
</asp:Content>
