using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;//添加引用SQL Server;
using System.Data;//添加对DataSet的引用

public partial class NewsAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminName"] == null)//如果没有登录，则定向到后台登录页
        {
            Response.Redirect("~/Admin/AdminLogin.aspx");  //定向到后台登录页
        }
        if (!IsPostBack)
        {
            ShowNewsCategory();//绑定新闻类别到下拉列表框
            btnReset.CausesValidation = false;//“重置”按钮不验证
        }
    }
    private void ShowNewsCategory()
    {
        //绑定新闻类别到下拉列表框
        string seleStr = "select NewsCategoryID, NewsCategoryName from NewsCategory ORDER BY NewsCategorySort";//显示全部记录
        DataSet ds = SqlHelper.GetDataSet(seleStr);
        ddlNewsCategory.DataSource = ds;
        ddlNewsCategory.DataTextField = "NewsCategoryName";//显示字段
        ddlNewsCategory.DataValueField = "NewsCategoryID";//值字段
        ddlNewsCategory.DataBind();
        ddlNewsCategory.SelectedIndex = 0;//默认选中第1个选项
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        UploadPicture();//上传新闻图片
        int newsCategoryID = int.Parse(ddlNewsCategory.SelectedValue);//新闻类别ID
        string newsCategoryName = ddlNewsCategory.SelectedItem.Text;//新闻类别名称
        string newsTitle = txtNewsTitle.Text.Trim();//新闻标题
        string newsAuthor = txtNewsAuthor.Text.Trim();//作者、来源
        string newsPicture = UploadPicture();//图片名
        string newsContent = ToHtml(txtNewsContent.Text);//新闻内容,替换换行符
        int creatorID = (int)(Session["AdminID"]);//添加者
        DateTime createdDateTime = DateTime.Now;//系统时间
        int isPass = (int)(Session["AdminGradeID"]) > 2 ? 0 : 1;//如果管理员的权限ID大于2则是录入员，需要审核；否则不需要审核
        if (AddNews(newsCategoryID, newsCategoryName, newsTitle, newsAuthor, newsPicture, newsContent, creatorID, createdDateTime, isPass))
        {
            lblMsg.Text = "添加新闻成功！";
            ResetNews();//初始化添加新闻框 
        }
        else
        {
            lblMsg.Text = "添加新闻失败！";
        }

    }

    private bool AddNews(int newsCategoryID, string newsCategoryName, string newsTitle, string newsAuthor, string newsPicture, string newsContent, int creatorID, DateTime createdDateTime, int isPass)
    {
        // 添加新闻
        string sqlStr = "insert into News(NewsCategoryID, NewsCategoryName, NewsTitle, NewsAuthor, NewsPicture, NewsContent, CreatorID, CreatedDateTime, IsPass)";
        sqlStr += " values('"
            + newsCategoryID + "','"
            + newsCategoryName + "','"
            + newsTitle + "','"
            + newsAuthor + "','"
            + newsPicture + "','"
            + newsContent + "','"
            + creatorID + "','"
            + createdDateTime + "','"
            + isPass + "')";
        int result = SqlHelper.GetExecuteNonQuery(sqlStr);
        bool flag = false;//添加新闻是否成功标记
        if (result > 0)
        {
            flag = true;
        }
        return flag;
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        //“重置”按钮
        ResetNews();//初始化添加新闻框
    }
    private void ResetNews()
    {
        //初始化添加新闻框
        txtNewsTitle.Text = string.Empty;
        txtNewsAuthor.Text = string.Empty;
        txtNewsContent.Text = string.Empty;
        lblMsg.Text = string.Empty;
    }
    private string UploadPicture()
    {
        //上传新闻图片
        Boolean fileOK = false;  //文件类型符合要求标志，初始为不符合
        String path = Server.MapPath("~/Admin/UploadedImages/NewsPictures/");//服务器中保存新闻图片的路径
        if (fileUploadPicture.HasFile)   //检查FileUpload1控件中是否包含有文件
        {
            //获取客户端使用FileUpload控件上传的文件的扩展名，并改为小写
            String fileExtension = System.IO.Path.GetExtension(fileUploadPicture.FileName).ToLower();
            String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
            for (int i = 0; i < allowedExtensions.Length; i++)   //根据文件扩展名检查文件类型
            {
                //检查要上传的文件是否为允许的图像文件类型
                if (fileExtension == allowedExtensions[i])
                {
                    fileOK = true;
                }
            }
        }
        string pictureName;//图片的名称
        if (fileOK)  //检查文件是否为允许上传的图像文件类型
        {
            //如果文件类型符合要求
            pictureName = fileUploadPicture.FileName;//图片文件名
            fileUploadPicture.PostedFile.SaveAs(path + fileUploadPicture.FileName);//上传文件
        }
        else
        {
            pictureName = "temp.jpg";//如果上传不成功，或者该新闻没有图片，则保存临时图片名
        }
        return pictureName;//返回上传的图片文件名
    }
    /// 将无格式的文本处理成有格式的文本
    /// </summary>
    /// <param name="mystr">要处理的文本</param>
    /// <returns>返回带换行等格式的文本</returns>
    public string ToHtml(string str)
    {
        str = str.Replace(" ", "&nbsp;");
        str = str.Replace("\n", "<br />");//录入时不需要键入\n
        str = str.Replace("\r\n", "<br />");
        str = str.Replace("\t", "&nbsp;&nbsp;");
        return str;
    }
}