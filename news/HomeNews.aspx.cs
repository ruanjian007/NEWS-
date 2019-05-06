using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;//添加引用SQL Server;

public partial class HomeNews : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Session["userFromHomeNews"] = 1;//判断从HomeNews.aspx执行

            ShowChinaNewsList();//显示“国内新闻”列表，新闻类别为1
            ShowFinanceNewsList();//显示“财经股票”新闻列表，新闻类别为3
            ShowHealthNewsList();//显示“饮食健康”新闻列表，新闻类别为5
            ShowForeignNewsList();//显示“国际新闻”列表，新闻类别为2
            ShowPastimeNewsList();//显示“娱乐明星”新闻列表，新闻类别为4
            ShowNatureNewsList();//显示“自然旅游”新闻列表，新闻类别为6
            ShowNewNewsList();//显示“最新新闻”列表
            ShowSequenceNewsList();//显示“阅读排行”列表  
            ShowFriendLink();//显示友情链接
        }
    }
    private void ShowChinaNewsList()
    {   //显示“国内新闻”列表，国内新闻类别为1，显示8行
        string sqlStr = "select top 8 NewsID, NewsTitle from News where IsPass=1 and NewsCategoryID=1 order by CreatedDateTime desc";//按时间倒序显示最新发布的8条新闻
        SqlDataReader reader = SqlHelper.GetExecuteReader(sqlStr);
        repChina.DataSource = reader;//数据源设置到repChina
        repChina.DataBind();//绑定到repChina
        reader.Close();//关闭读取器
        SqlHelper.CloseConnection();//关闭连接
    }
    private void ShowFinanceNewsList()
    {   //显示“财经股票”新闻列表，新闻类别为3
        string sqlStr = "select top 8 NewsID, NewsTitle from News where IsPass=1 and NewsCategoryID=3 order by CreatedDateTime desc";
        SqlDataReader reader = SqlHelper.GetExecuteReader(sqlStr);
        repFinance.DataSource = reader;
        repFinance.DataBind();
        reader.Close();//关闭读取器
        SqlHelper.CloseConnection();//关闭连接
    }
    private void ShowHealthNewsList()
    {   //显示“饮食健康”新闻列表，新闻类别为5
        string sqlStr = "select top 8 NewsID, NewsTitle from News where IsPass=1 and NewsCategoryID=5 order by CreatedDateTime desc";
        SqlDataReader reader = SqlHelper.GetExecuteReader(sqlStr);
        repHealth.DataSource = reader;
        repHealth.DataBind();
        reader.Close();//关闭读取器
        SqlHelper.CloseConnection();//关闭连接
    }
    private void ShowForeignNewsList()
    {   //显示“国际新闻”列表，新闻类别为2
        string sqlStr = "select top 8 NewsID, NewsTitle from News where IsPass=1 and NewsCategoryID=2 order by CreatedDateTime desc";
        SqlDataReader reader = SqlHelper.GetExecuteReader(sqlStr);
        repForeign.DataSource = reader;
        repForeign.DataBind();
        reader.Close();//关闭读取器
        SqlHelper.CloseConnection();//关闭连接
    }
    private void ShowPastimeNewsList()
    {   //显示“娱乐明星”新闻列表，新闻类别为4
        string sqlStr = "select top 8 NewsID, NewsTitle from News where IsPass=1 and NewsCategoryID=4 order by CreatedDateTime desc";
        SqlDataReader reader = SqlHelper.GetExecuteReader(sqlStr);
        repPastime.DataSource = reader;
        repPastime.DataBind();
        reader.Close();//关闭读取器
        SqlHelper.CloseConnection();//关闭连接
    }
    private void ShowNatureNewsList()
    {   //显示“自然旅游”新闻列表，新闻类别为6
        string sqlStr = "select top 8 NewsID, NewsTitle from News where IsPass=1 and NewsCategoryID=6 order by CreatedDateTime desc";
        SqlDataReader reader = SqlHelper.GetExecuteReader(sqlStr);
        repNature.DataSource = reader;
        repNature.DataBind();
        reader.Close();//关闭读取器
        SqlHelper.CloseConnection();//关闭连接
    }

    private void ShowNewNewsList()
    {  //显示“最新新闻”列表
        string sqlStr = "select top 10 NewsID, NewsTitle from News where IsPass=1 order by CreatedDateTime desc";
        SqlDataReader reader = SqlHelper.GetExecuteReader(sqlStr);
        repNew.DataSource = reader;
        repNew.DataBind();
        reader.Close();//关闭读取器
        SqlHelper.CloseConnection();//关闭连接
    }
    private void ShowSequenceNewsList()
    {  //显示“阅读排行”列表  
        string sqlStr = "select top 9 NewsID, NewsTitle from News where IsPass=1 order by CreatedDateTime desc";
        SqlDataReader reader = SqlHelper.GetExecuteReader(sqlStr);
        repSequence.DataSource = reader;
        repSequence.DataBind();
        reader.Close();//关闭读取器
        SqlHelper.CloseConnection();//关闭连接
    }
    private void ShowFriendLink()
    {
        //显示友情链接
        string sqlStr = "select top 3 FriendLinkName,FriendLinkUrl,LogoPath from FriendLink where IsShow=1 order by FriendLinkSort";//显示4个友情链接图片
        SqlDataReader reader = SqlHelper.GetExecuteReader(sqlStr);
        repFriendLink.DataSource = reader;
        repFriendLink.DataBind();
        reader.Close();//关闭读取器
        SqlHelper.CloseConnection();//关闭连接
    }
}