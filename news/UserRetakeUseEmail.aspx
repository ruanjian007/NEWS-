<%@ Page Language="C#" MasterPageFile="~/NewsMasterPage.master" AutoEventWireup="true"
    CodeFile="UserRetakeUseEmail.aspx.cs" Inherits="UserRetakeUseEmail" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .pwd_step
        {
            margin: 20px auto;
            padding: 0px 0px 0px 0px;
            width: 750px;
            height: 80px;
            background: url(images/m_step4.jpg) no-repeat 0px 0px;
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
        .style1
        {
            text-align: left;
            width: 456px;
        }
        .style2
        {
            width: 44%;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="text-align: center; margin: 50px auto;">
        <div class="pwd_step">
        </div>
        <div class="pwd_content">
            <table class="table">
                <tr>
                    <td class="style2">
                        注册名：
                    </td>
                    <td class="style1">
                        <asp:Label ID="lblName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        邮箱：
                    </td>
                    <td class="style1">
                        <asp:TextBox ID="txtEmail" runat="server" Width="150px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail"
                            Display="Dynamic" ErrorMessage="必须输入！"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                            ErrorMessage="邮箱格式不正确！" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                    </td>
                    <td class="style1">
                        <asp:Button ID="btnOk" runat="server" Text="确定" OnClick="btnOk_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                    </td>
                    <td class="style1">
                        <asp:Label ID="lblOk" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                    </td>
                    <td class="style1">
                        <asp:Button ID="btnFinish" runat="server" OnClick="btnFinish_Click" Text="完成" />
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                    </td>
                    <td class="style1">
                        <span style="color: red">
                            <asp:Label ID="lblMsg" runat="server"></asp:Label></span>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
