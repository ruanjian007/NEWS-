using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;//添加引用SQL Server;
using System.Data;//添加对DataSet的引用
public partial class NewsCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userFromHomeNews"] == null)  //如果没有从HomeNews.aspx登录，则定向到HomeNews.aspx
        {
            Response.Redirect("HomeNews.aspx"); //定向到HomeNews.aspx
        }
        if (!IsPostBack)
        {
            ShowNewNewsList();//显示“最新新闻”名称列表
            ShowSequenceNewsList();//显示“阅读排行”列表 
            lblPage.Text = "1";//从第1页开始显示
            PagingRepeater();//分页
        }
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
    protected void lbtnFirstPage_Click(object sender, EventArgs e)
    {   //第1页
        this.lblPage.Text = "1";
        this.PagingRepeater();
    }
    protected void lbtnpritPage_Click(object sender, EventArgs e)
    {   //上一页
        this.lblPage.Text = Convert.ToString(Convert.ToInt32(lblPage.Text) - 1);
        this.PagingRepeater();
    }
    protected void lbtnNextPage_Click(object sender, EventArgs e)
    {   //下一页
        this.lblPage.Text = this.lblCountPage.Text;
        this.PagingRepeater();
    }
    protected void lbtnDownPage_Click(object sender, EventArgs e)
    {   //最后一页
        this.lblPage.Text = Convert.ToString(Convert.ToInt32(lblPage.Text) + 1);
        this.PagingRepeater();
    }
    public void PagingRepeater()
    {
        string sqlStr = "select NewsID, NewsTitle,CreatedDateTime from News where IsPass = 1 and NewsCategoryID = '" + Request.QueryString["id"] + "' order by CreatedDateTime desc";
        DataSet ds = SqlHelper.GetDataSet(sqlStr);
        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = ds.Tables[0].DefaultView;

        pds.AllowPaging = true;
        pds.PageSize = 10;//每页10条
        lblTotal.Text = pds.Count.ToString();
        pds.CurrentPageIndex = Convert.ToInt32(this.lblPage.Text) - 1;
        repNewsCategoryList.DataSource = pds;
        lblCountPage.Text = pds.PageCount.ToString();
        lblPage.Text = (pds.CurrentPageIndex + 1).ToString();
        lbtnpritPage.Enabled = true;
        lbtnFirstPage.Enabled = true;
        lbtnNextPage.Enabled = true;
        lbtnDownPage.Enabled = true;
        if (pds.CurrentPageIndex < 1)
        {
            lbtnpritPage.Enabled = false;
            lbtnFirstPage.Enabled = false;
        }
        if (pds.CurrentPageIndex == pds.PageCount - 1)
        {
            lbtnNextPage.Enabled = false;
            lbtnDownPage.Enabled = false;
        }
        repNewsCategoryList.DataBind();
    }
}