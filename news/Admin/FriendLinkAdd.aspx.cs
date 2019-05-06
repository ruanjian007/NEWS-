using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class Admin_FriendLinkAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        btnReset.CausesValidation = false;//单击"重新填写"按钮不激发验证  
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        string friendLinkName = txtFriendLinkName.Text.Trim();//链接名称
        string friendLinkUrl = txtFriendLinkUrl.Text.Trim();//链接URL
        string logoPath = @"~\admin\UploadedImages\FriendLinkLogo\" + FileUploadLogo.FileName;//在服务器上保存Logo图片文件的路径
        int friendLinkSort = Convert.ToInt32(txtFriendLinkSort.Text);//显示顺序
        bool isShow = (radlIsShow.SelectedValue == "显示") ? true : false;//是否显示
        int createdID = (int)Session["AdminID"];//创建者的ID
        DateTime createdDateTime = DateTime.Now;//创建时间

        //如果只保存图片文件名，而不保存服务器路径，则改为如下
        //string logoPath = FileUploadLogo.FileName;
        //在绑定到数据控件时，绑定表达式要写为：ImageUrl='<%# Eval("LogoPath","~\\admin\\UploadedImages\\FriendLinkLogo\\{0}").ToString().Trim() %>'


        //上传Logo图片
        if (UploadLogo())
        {
            //如果上传图片成功，则添加新友情链接记录
            if (AddFriendLink(friendLinkName, friendLinkUrl, logoPath, friendLinkSort, isShow, createdID, createdDateTime))
            {
                string message = "添加友情链接成功!";
                lblMsg.Text = message;//显示"添加友情链接成功!"
                txtFriendLinkName.Text = string.Empty;//名称
                txtFriendLinkUrl.Text = "http://";//链接URL
                txtFriendLinkSort.Text = string.Empty;//显示次序
                radlIsShow.SelectedIndex = 0;//状态
                txtFriendLinkName.Focus();
            }
        }
        else
        {
            string message = "友情链接添加不成功，请重新操作!";
            lblMsg.Text = message;
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        ResetFriendLink();//重置输入项
    }

    protected bool UploadLogo()
    {
        //上传Logo图片
        bool fileOK = false;//文件类型是否符合的变量
        if (FileUploadLogo.HasFile)   //检查FileUpload1控件中是否包含有文件
        {
            //获取客户端使用FileUpload控件上传的文件的扩展名
            String fileExtension = System.IO.Path.GetExtension(FileUploadLogo.FileName).ToLower();
            String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };//设置限定的文件类型
            for (int i = 0; i < allowedExtensions.Length; i++)   //根据文件扩展名检查选择的文件类型
            {
                if (fileExtension == allowedExtensions[i]) //检查要上传的文件是否为允许的图像文件类型
                {
                    fileOK = true;//文件类型符合要求
                }
                else
                {
                    string message = "不能上传此种文件类型!";
                    lblMsg.Text = message;
                }
            }
        }
        if (FileUploadLogo.PostedFile.ContentLength > 20000) //如果要上传的文件大于20KB，则不允许上传
        {
            fileOK = false;//文件大小不符合要求
            string message = "要上传的图片文件大小不能超过20KB!";
            lblMsg.Text = message;
        }
        if (fileOK) //如果文件类型、大小符合要求
        {
            try
            {
                //string fileDate = DateTime.Now.ToShortDateString();//当前的日期. 把上传到服务器的文件名前加上当前的日期, 以减少重名
                //FileUploadLogo.PostedFile.SaveAs(path + fileDate + FileUploadLogo.FileName); //把上传的文件改名保存到服务器
                string path = Server.MapPath("~\\admin\\UploadedImages\\FriendLinkLogo\\");//上传到网站服务器中的文件夹
                FileUploadLogo.PostedFile.SaveAs(path + FileUploadLogo.FileName); //把上传的文件保存到服务器指定文件夹下
            }
            catch (Exception ex)
            {
                fileOK = false;
                string message = "文件不能上传!" + ex.Message;
                lblMsg.Text = message;
            }
        }
        return fileOK;
    }
    protected bool AddFriendLink(string friendLinkName, string friendLinkUrl, string logoPath, int friendLinkSort, bool isShow, int createdID, DateTime createdDateTime)
    {
        int show = 0;//把bool型的isShow转换为int才能保存到表中
        if (isShow)
        {
            show = 1;
        }

        //把友情链接存到FriendLink表中
        string sqlStr = "insert into FriendLink(FriendLinkName, FriendLinkUrl, LogoPath, FriendLinkSort, IsShow, CreatedID, CreatedDateTime)";
        sqlStr += " values('"
               + friendLinkName + "','"
               + friendLinkUrl + "','"
               + logoPath + "',"
               + friendLinkSort + ","
               + show + ","
               + createdID + ",'"
               + createdDateTime + "')";//日期型要加单引号
        int result = SqlHelper.GetExecuteNonQuery(sqlStr);
        bool flag = false;//是否成功标记
        if (result > 0)
        {
            flag = true;
        }
        return flag;
    }

    private void ResetFriendLink()
    {
        txtFriendLinkName.Text = string.Empty;//名称
        txtFriendLinkUrl.Text = "http://";//链接URL
        txtFriendLinkSort.Text = string.Empty;//显示次序
        radlIsShow.SelectedIndex = 0;//状态
        txtFriendLinkName.Focus();
        lblMsg.Text = string.Empty;
    }
}