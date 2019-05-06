using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;//添加引用SQL Server;
using System.Data;//添加引用SqlDbType
public partial class Admin_Admin : System.Web.UI.Page
{
    //查询字符串，静态变量，用于在本页面共用
    static string selectStr = "";//select语句的字符串要与其他删除、修改作用的字符串采用不同的变量

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminName"] == null)//如果没有登录，则打开登录页
        {
            Response.Redirect("AdminLogin.aspx");  //去登录页面
        }
        if (!IsPostBack)
        {
            selectStr = "select AdminID, AdminName, AdminPassword, AdminRealName, AdminGradeID from Admin";//显示全部记录
            ShowAdmin(selectStr);
        }
    }
    /// <summary>
    /// 数据绑定,显示全部记录
    /// </summary>
    private void ShowAdmin(string seleStr)
    {
        DataSet ds = SqlHelper.GetDataSet(seleStr);
        gridAdmin.DataSource = ds;
        gridAdmin.DataKeyNames = new string[] { "AdminID" };//GridView控件的主键名
        gridAdmin.AllowPaging = true;//启用分页
        gridAdmin.AutoGenerateColumns = false;//不自己绑定字段
        gridAdmin.PageSize = 5;//每页显示的记录数
        gridAdmin.DataBind();
    }
    /// <summary>
    /// "显示全部"按钮的单击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        selectStr = "select AdminID, AdminName, AdminPassword, AdminRealName, AdminGradeID from Admin";//显示全部记录
        gridAdmin.PageIndex = 0;//从第1页开始显示
        ShowAdmin(selectStr);
    }
    /// <summary>
    /// "查找"按钮的单击事件。组成在GridView控件中显示记录的查询条件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnFind_Click(object sender, EventArgs e)
    {
        string key = this.txtKey.Text.Trim();
        if (key != "")
        {
            selectStr = "Select AdminID, AdminName, AdminPassword, AdminRealName, AdminGradeID from Admin ";//注意字符串尾部有一个空格
            selectStr += "where AdminName like '%" + key + "%' ";//按管理员账号查找
            selectStr += "or AdminRealName like '%" + key + "%' ";//按真实姓名查找
            selectStr += "or AdminGradeID like '%" + key + "%' "; //按管理员级别查找
        }
        else
        {
            selectStr = "select AdminID, AdminName, AdminPassword, AdminRealName, AdminGradeID from Admin";//显示全部记录
        }
        ShowAdmin(selectStr);//显示给定条件的记录
    }
    /// <summary>
    /// "添加管理员"按钮的单击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminAdd.aspx");//定向到添加管理员
    }
    /// <summary>
    /// 分页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gridAdmin_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridAdmin.PageIndex = e.NewPageIndex;
        ShowAdmin(selectStr);//显示给定条件的记录
    }
}