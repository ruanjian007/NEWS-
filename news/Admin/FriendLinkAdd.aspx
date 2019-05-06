<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.master" AutoEventWireup="true"
    CodeFile="FriendLinkAdd.aspx.cs" Inherits="Admin_FriendLinkAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 30%;
            text-align: right;
            height: 30px;
        }
        .style2
        {
            text-align: left;
            height: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="right-frame-content">
        <br />
        <br />
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="t2">
            <!--*后台表格的第一种样式t2*-->
            <tr>
                <td class="tdright">
                </td>
                <td class="tdleft">
                    <strong>&nbsp;&nbsp; 添加友情链接</strong>
                </td>
            </tr>
            <tr>
                <td class="tdright">
                    名称：
                </td>
                <td class="tdleft">
                    <asp:TextBox ID="txtFriendLinkName" runat="server" Width="230px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFriendLinkName"
                        Display="Dynamic" ErrorMessage="必须输入!" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="tdright">
                    链接URL：
                </td>
                <td class="tdleft">
                    <asp:TextBox ID="txtFriendLinkUrl" runat="server" Width="230px">http://</asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFriendLinkUrl"
                        ErrorMessage="必须输入!" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="tdright">
                    上传Logo：
                </td>
                <td class="tdleft">
                    <asp:FileUpload ID="FileUploadLogo" runat="server" Width="230px" />
                </td>
            </tr>
            <tr>
                <td class="tdright">
                    显示次序：
                </td>
                <td class="tdleft">
                    <asp:TextBox ID="txtFriendLinkSort" runat="server" Width="50px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFriendLinkSort"
                        ErrorMessage="必须输入!" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtFriendLinkSort"
                        ErrorMessage="只能输入1～100之间的数!" MaximumValue="100" MinimumValue="1" Type="Integer"
                        ForeColor="Red"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td class="tdright">
                    是否显示：
                </td>
                <td class="tdleft">
                    <asp:RadioButtonList ID="radlIsShow" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="显示">显示</asp:ListItem>
                        <asp:ListItem Value="暂停显示">暂停显示</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <th class="style1">
                </th>
                <th class="style2">
                    <asp:Button ID="btnOk" runat="server" Text="添加" Width="74px" OnClick="btnOk_Click" />&nbsp;<asp:Button
                        ID="btnReset" runat="server" Text="重新填写" Width="73px" CausesValidation="False"
                        OnClick="btnReset_Click" />
                </th>
            </tr>
            <tr>
                <td class="tdright">
                    &nbsp;
                </td>
                <td class="tdleft">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="tdright">
                    &nbsp;
                </td>
                <td class="tdleft">
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
