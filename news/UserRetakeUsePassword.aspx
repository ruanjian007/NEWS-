<%@ Page Language="C#" MasterPageFile="~/NewsMasterPage.master" AutoEventWireup="true"
    CodeFile="UserRetakeUsePassword.aspx.cs" Inherits="UserRetakeUsePassword" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .pwd_step
        {
            margin: 20px auto;
            padding: 0px 0px 0px 0px;
            width: 750px;
            height: 80px;
            background: url(images/m_step3.jpg) no-repeat 0px 0px;
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
            width: 43%;
            text-align: right;
            height: 18px;
        }
        .style2
        {
            width: 43%;
            text-align: right;
            height: 29px;
        }
        .style3
        {
            width: 43%;
            text-align: right;
        }
        .table
        {
            width: 729px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="text-align: center; margin: 10px auto;">
        <div class="pwd_step">
        </div>
        <div class="pwd_content">
            <table class="table">
                <tr>
                    <td class="style3">
                        注册名：
                    </td>
                    <td class="td_right">
                        <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        问题：
                    </td>
                    <td class="td_right" style="height: 18px">
                        <asp:Label ID="lblAsk" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        问题答案：
                    </td>
                    <td class="td_right">
                        <asp:TextBox ID="txtAnswer" runat="server" Width="163px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAnswer"
                            Display="Dynamic" ErrorMessage="必须输入！"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        新密码：
                    </td>
                    <td class="td_right">
                        <asp:TextBox ID="txtPassword" runat="server" Width="163px" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
                            Display="Dynamic" ErrorMessage="必须输入！"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        再次输入新密码：
                    </td>
                    <td class="td_right" style="height: 29px">
                        <asp:TextBox ID="txtPasswordAgain" runat="server" Width="163px" TextMode="Password"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword"
                            ControlToValidate="txtPasswordAgain" Display="Dynamic" ErrorMessage="两次输入的密码不同!"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        验证码：
                    </td>
                    <td class="td_right">
                        <asp:TextBox ID="txtValidateCode" runat="server" Width="41px"></asp:TextBox>
                        <img id="imgCode" alt="看不清，请单击我！" src="ValidateCode.aspx" onclick="this.src=this.src+'?'" />
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                    </td>
                    <td class="td_right">
                        不区分大小写,单击验证码图片换一张
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                    </td>
                    <td class="td_right">
                        <asp:Button ID="btnOk" runat="server" Text="完成" OnClick="btnOk_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                    </td>
                    <td class="td_right">
                        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
