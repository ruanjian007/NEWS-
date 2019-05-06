using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;//添加引用SQL Server;
using System.Data;//添加对DataSet的引用

public partial class NewsMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {
            NewsCategoryMenu();//显示新闻导航栏
        }    
    }
    private void NewsCategoryMenu()
    {
        //显示新闻导航栏
        string sqlStr = "select NewsCategoryID, NewsCategoryName from NewsCategory order by NewsCategorySort asc";
        SqlDataReader reader = SqlHelper.GetExecuteReader(sqlStr);
        repNewsCategory.DataSource = reader;
        repNewsCategory.DataBind();
        reader.Close();//关闭读取器
        SqlHelper.CloseConnection();//关闭连接
    }
}
