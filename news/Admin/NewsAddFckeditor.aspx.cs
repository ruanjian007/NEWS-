using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;//添加
public partial class Admin_NewsAddFckeditor : System.Web.UI.Page
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
        int newsCategoryID = int.Parse(ddlNewsCategory.SelectedValue);//新闻类别ID
        string newsCategoryName = ddlNewsCategory.SelectedItem.Text;//新闻类别名称
        string newsTitle = txtNewsTitle.Text.Trim();//新闻标题
        string newsAuthor = txtNewsAuthor.Text.Trim();//作者、来源
        string newsPicture = "temp.jpg";//临时用图片名
        string newsContent = fckNewsContent.Value;//新闻内容
        int creatorID = (int)(Session["AdminID"]);//添加者
        DateTime createdDateTime = DateTime.Now;//系统时间
        int isPass = (int)(Session["AdminGradeID"]) > 2 ? 0 : 1;//如果管理员的权限ID大于2则是录入员，需要审核；否则不需要审核
        if (AddNews(newsCategoryID, newsCategoryName, newsTitle, newsAuthor, newsPicture, newsContent, creatorID, createdDateTime, isPass))
        {
            lblMsg.Text = "添加新闻成功！";
        }
        else
        {
            lblMsg.Text = "添加新闻失败！";
        }
        ResetNews();//初始化添加新闻框
    }

    private bool AddNews(int newsCategoryID, string newsCategoryName, string newsTitle, string newsAuthor, string newsPicture, string newsContent, int creatorID, DateTime createdDateTime, int isPass)
    {// 添加新闻
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
        ResetNews();//初始化添加新闻框
    }
    private void ResetNews()
    {
        //初始化添加新闻框
        txtNewsTitle.Text = string.Empty;
        txtNewsAuthor.Text = string.Empty;
        fckNewsContent.Value = string.Empty;
        lblMsg.Text = string.Empty;
    }
}

