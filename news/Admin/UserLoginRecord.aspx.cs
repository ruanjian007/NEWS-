using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;//添加引用
public partial class admin_UserLoginRecord : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminName"] == null)//如果没有登录，则打开登录页
        {
            Response.Redirect("AdminLogin.aspx");  //去登录页面
        }
        if (!IsPostBack)
        {
            ShowLoginAll();
        }
    }

    //显示用户登录记录
    public void ShowLoginAll()
    {
        string sqlStr = "select * from UserLogin where UserID ='" + Request.QueryString["ID"] + "' ORDER BY UserLoginID DESC";
        DataSet ds = SqlHelper.GetDataSet(sqlStr);
        gridUserLogin.AllowPaging = true;
        gridUserLogin.AllowSorting = true;
        gridUserLogin.AutoGenerateColumns = false;
        gridUserLogin.PageSize = 5;
        gridUserLogin.DataSource = ds;
        gridUserLogin.DataBind();
    }

    //分页
    protected void gridUserLogin_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        string sqlStr = "select * from UserLogin where UserID ='" + Request.QueryString["ID"] + "' ORDER BY UserLoginID DESC";
        DataSet ds = SqlHelper.GetDataSet(sqlStr);
        gridUserLogin.PageIndex = e.NewPageIndex;
        gridUserLogin.DataSource = ds;
        gridUserLogin.DataBind();
    }

    protected string GetUserName()
    {
        //得到UserInfo_Name表中记录的用户名
        string name = "";
        string sqlStr = "select UserName from UserInfo where UserID = '" + Request.QueryString["ID"] + "'";
        SqlDataReader reader = SqlHelper.GetExecuteReader(sqlStr);
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                name = reader["UserName"].ToString();
            }
        }
        reader.Close();
        return name;//返回用户名
    }

}
