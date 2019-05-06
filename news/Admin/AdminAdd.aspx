<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="AdminAdd.aspx.cs" Inherits="Admin_AdminAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 40%;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="right-frame-content">
        <!--主体内容-->
        <table width="100%" border="0" cellspacing="2" cellpadding="0" class="t2">
            <!--*后台表格的第一种样式t2*-->
            <tr>
                <th colspan="2">
                    添加管理员资料
                </th>
            </tr>
            <tr>
                <td class="style1">
                    账号：
                </td>
                <td class="tdleft">
                    <asp:TextBox ID="txtAdminName" runat="server" Width="138px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAdminName"
                        Display="Dynamic" ErrorMessage="必须输入账号" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtAdminName"
                        Display="Dynamic" ErrorMessage="只能输入字母和(或)数字" 
                        ValidationExpression="^[A-Za-z0-9]+$" ForeColor="Red"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    密码：
                </td>
                <td class="tdleft">
                     <asp:TextBox ID="txtAdminPassword" runat="server" Width="138px" 
                        TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAdminPassword"
                        ErrorMessage="必须输入密码" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    再次输入密码：
                </td>
                <td class="tdleft">
                    <asp:TextBox ID="txtAdminPasswordAgain" runat="server" Width="138px" 
                        TextMode="Password"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtAdminPassword"
                        ControlToValidate="txtAdminPasswordAgain" Display="Dynamic" 
                        ErrorMessage="两次输入的密码不同!" ForeColor="Red"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    真实姓名：
                </td>
                <td class="tdleft">
                    <asp:TextBox ID="txtAdminRealName" runat="server" Width="138px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    管理级别：
                </td>
                <td class="tdleft">
                    <asp:DropDownList ID="ddlAdminGrade" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th colspan="2" class="center">
                     <asp:Button ID="btnOk" runat="server" Text="确定添加" Width="74px" 
                        OnClick="btnOk_Click" CssClass="button" />&nbsp;<asp:Button
                        ID="btnReset" runat="server" Text="重新填写" Width="73px" 
                        CausesValidation="False" OnClick="btnReset_Click" CssClass="button" />
                </th>
            </tr>
        </table>
    </div>
</asp:Content>
