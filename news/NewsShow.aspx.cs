using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;//添加引用SQL Server;
public partial class NewsShow : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        imgNewsPicture.Visible = false;//初始不显示新闻图片
        if (Session["userFromHomeNews"] == null)  //如果没有从HomeNews.aspx登录，则定向到HomeNews.aspx
        {
            Response.Redirect("HomeNews.aspx"); //定向到HomeNews.aspx
        }
        if (!Page.IsPostBack)
        {
            ShowNewNewsList();//显示“最新新闻”名称列表
            ShowSequenceNewsList();//显示“阅读排行”列表 
            ShowNews();//显示选定的新闻内容
            ShowNewsAllUserReview();//显示选定新闻的所有评论
        }
        if (Request.Cookies["username"] == null)  //如果用户没有登录,在UserLogin.asp.cs中保存
        {
            lbtnLogin.Visible = true;//显示“登录”按钮
            lbtnExit.Visible = false;//不显示“退出”按钮
            btnOK.Enabled = false;//“提交评论”按钮无效
        }
        else
        {
            lbtnLogin.Visible = false;//不显示“登录”按钮
            lbtnExit.Visible = true;//显示“退出”按钮
            btnOK.Enabled = true;//“提交评论”按钮有效
            lblUserName.Text = Request.Cookies["username"].Value;  //读取指定Cookie的值，赋给变量,显示已经登录的用户名
        }
    }
    private void ShowNews()
    {   //显示详细新闻内容
        string sqlStr = "select NewsID, NewsTitle, NewsAuthor, CreatedDateTime, NewsPicture, NewsContent, ShowPageCount from News where NewsID ='" + Request.QueryString["id"] + "'";
        SqlDataReader reader = SqlHelper.GetExecuteReader(sqlStr);
        string newsPicture = "";
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                lblNewsTitle.Text = reader["NewsTitle"].ToString();//新闻标题
                lblNewsAuthor.Text = reader["NewsAuthor"].ToString();//新闻来源、作者
                newsPicture = reader["NewsPicture"].ToString();//新闻图片名
                if (newsPicture != "temp.jpg".Trim()) //如果保存在表中的新闻图片名称不是一个标识名称temp.jpg
                {
                    imgNewsPicture.ImageUrl = "~/Admin/UploadedImages/NewsPictures/" + newsPicture;//新闻图片的路径和名称
                    imgNewsPicture.Visible = true;//显示新闻图片
                }
                lblNewsContent.Text = reader["NewsContent"].ToString();//新闻内容
                lblCreatedDateTime.Text = reader["CreatedDateTime"].ToString();//发布时间
                lblShowPageCount.Text = reader["ShowPageCount"].ToString();//浏览次数
            }
        }
        reader.Close();//关闭读取器
        SqlHelper.CloseConnection();//关闭连接

        //浏览的网页数加1，单击数加1
        string sqlStr1 = "update News set ShowPageCount = ShowPageCount + 1 where NewsID =" + Request.QueryString["id"];
        SqlHelper.GetExecuteNonQuery(sqlStr1);
    }
    private void ShowNewNewsList()
    {   //显示“最新新闻”名称列表
        string sqlStr = "select top 20 NewsID, NewsTitle from News where IsPass=1 order by CreatedDateTime desc";
        SqlDataReader reader = SqlHelper.GetExecuteReader(sqlStr);
        repNew.DataSource = reader;
        repNew.DataBind();
        reader.Close();//关闭读取器
        SqlHelper.CloseConnection();//关闭连接
    }
    private void ShowSequenceNewsList()
    {  //显示“阅读排行”列表  
        string sqlStr = "select top 20 NewsID, NewsTitle from News where IsPass=1 order by CreatedDateTime desc";
        SqlDataReader reader = SqlHelper.GetExecuteReader(sqlStr);
        repSequence.DataSource = reader;
        repSequence.DataBind();
        reader.Close();//关闭读取器
        SqlHelper.CloseConnection();//关闭连接
    }
    private void ShowNewsAllUserReview()
    {   //显示新闻的所有用户评论

        //计算该新闻（NewsID）的评论条数
        string sqlStr1 = "select count(*) from UserReview where NewsID =" + Request.QueryString["id"];
        lblReviewCount.Text = SqlHelper.GetExecuteScalar(sqlStr1).ToString();

        //列出该新闻（NewsID）的所有评论，显示次序是：先显示最后的评论
        string sqlStr = "select UserID, UserName, UserReviewContent, NewsID, CreatedDateTime, LoginIP from UserReview where NewsID =" + Request.QueryString["id"] + " order by UserReviewID desc";
        SqlDataReader reader = SqlHelper.GetExecuteReader(sqlStr);
        repReviewList.DataSource = reader;
        repReviewList.DataBind();
        reader.Close();//关闭读取器
        SqlHelper.CloseConnection();//关闭连接
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        //"提交评论"按钮
        int userID = Convert.ToInt32(Request.Cookies["userid"].Value);  //读取指定Cookie的值
        string userName = Request.Cookies["username"].Value;  //读取指定Cookie的值
        string userReviewContent = txtUserReviewContent.Text.Trim();
        int newsID = int.Parse(Request.QueryString["id"]);
        DateTime createdDateTime = DateTime.Now;//系统时间
        string loginIP = Request.UserHostAddress.ToString();//IP

        if (userReviewContent != null) //如果写有评论
        {
            if (AddReview(userID, userName, userReviewContent, newsID, createdDateTime, loginIP) > 0) //添加评论
            {
                Response.Redirect("NewsShow.aspx?id=" + Request.QueryString["id"]);
            }
        }
        else
        {
            Response.Write("<script>alert('请输入评论内容!');history.go(-1);</script>");
        }
    }
    private int AddReview(int userID, string userName, string userReviewContent, int newsID, DateTime createdDateTime, string loginIP)
    {
        //添加评论
        string sqlStr = "insert into UserReview(UserID, UserName, UserReviewContent, NewsID, CreatedDateTime, LoginIP)" + "Values('" + userID + "','" + userName + "','" + userReviewContent + "','" + newsID + "','" + createdDateTime + "','" + loginIP + "')";
        int i = SqlHelper.GetExecuteNonQuery(sqlStr);
        return i;
    }
    protected void lbtnExit_Click(object sender, EventArgs e)
    {
        //"退出"登录按钮
        if (Request.Cookies["username"] != null)
        {
            Response.Cookies["username"].Expires = DateTime.Now.AddDays(-1);//Cookie有效期过期
            Response.Redirect("NewsShow.aspx?id=" + Request.QueryString["id"]);
        }
    }
    protected void lbtnLogin_Click(object sender, EventArgs e)
    {
        //"登录"按钮
        string linkStr = "UserLogin.aspx";//去登录页面
        Response.Redirect(linkStr);
    }
}