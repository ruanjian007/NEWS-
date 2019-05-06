<%@ Page Language="C#" MasterPageFile="~/NewsMasterPage.master" AutoEventWireup="true"
    CodeFile="UserRetakePassword.aspx.cs" Inherits="UserRetakePassword" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        
        .pwd_step
        {
            margin: 20px auto;
            padding: 0px 0px 0px 0px;
            width: 750px;
            height: 80px;
            background: url(images/m_step1.jpg) no-repeat 0px 0px;
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
            width: 453px;
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
                    <td class="td_left">
                        注册名：
                    </td>
                    <td class="style1">
                        <asp:TextBox ID="txtName" runat="server" Width="135px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                            ErrorMessage="必须输入注册名！" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtName"
                            Display="Dynamic" ErrorMessage="只能输入字母和(或)数字！" ValidationExpression="^[A-Za-z0-9]+$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="td_left">
                    </td>
                    <td class="style1">
                    </td>
                </tr>
                <tr>
                    <td class="td_left">
                    </td>
                    <td class="style1">
                        <asp:Button ID="btnNext" runat="server" Text="下一步" OnClick="btnNext_Click" Width="64px" />
                    </td>
                </tr>
                <tr>
                    <td class="td_left">
                    </td>
                    <td class="style1">
                        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
