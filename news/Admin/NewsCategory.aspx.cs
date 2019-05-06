using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;//添加引用
public partial class Admin_NewsCategory : System.Web.UI.Page
{
    static string selectString = "";
    //查询字符串，静态，用于在本页面共用。select语句的字符串要与其他删除、修改作用的字符串采用不同的变量

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminName"] == null)//如果没有登录，则打开登录页
        {
            Response.Redirect("AdminLogin.aspx");  //去登录页面
        }
        if (!IsPostBack)
        {
            selectString = "select * from NewsCategory ORDER BY NewsCategorySort";//显示全部记录
            ShowNewsCategory(selectString);
        }
    }
    private void ShowNewsCategory(string seleStr)
    {
        DataSet ds = SqlHelper.GetDataSet(seleStr);

        gridNewsCategory.DataKeyNames = new string[] { "NewsCategoryID" };//GridView控件的主键名
        gridNewsCategory.AllowPaging = true;//启用分页
        gridNewsCategory.AutoGenerateColumns = false;//不自己绑定字段
        gridNewsCategory.PageSize = 5;//每页显示的记录数
        gridNewsCategory.DataSource = ds;
        gridNewsCategory.DataBind();
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        string sqlString = "insert into NewsCategory(NewsCategoryName, NewsCategorySort)";
        sqlString += "values ('" + txtNewsCategoryName.Text.Trim() + "','" + txtNewsCategorySort.Text + "')";
        int i = SqlHelper.GetExecuteNonQuery(sqlString);
        if (i > 0)
        {
            lblMsg.Text = "新闻类别添加成功!";
            txtNewsCategoryName.Text = "";
            txtNewsCategorySort.Text = "";
            selectString = "select * from NewsCategory ORDER BY NewsCategorySort";//显示全部记录
            ShowNewsCategory(selectString);
        }
    }
    protected void gridNewsCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridNewsCategory.PageIndex = e.NewPageIndex;
        ShowNewsCategory(selectString);//显示给定条件的记录
    }
    protected void gridNewsCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string sqlString = "delete from NewsCategory  where NewsCategoryID='" + Convert.ToInt32(gridNewsCategory.DataKeys[e.RowIndex].Value) + "'";//=' "  Value) + " ' "
        int i = SqlHelper.GetExecuteNonQuery(sqlString);
        ShowNewsCategory(selectString);//显示给定条件的记录
    }
    protected void gridNewsCategory_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int newsCategoryID = Convert.ToInt32(gridNewsCategory.DataKeys[e.RowIndex].Value);
        string newsCategoryName = ((TextBox)gridNewsCategory.Rows[e.RowIndex].Cells[0].Controls[0]).Text;//第1列
        int newsCategorySort = Convert.ToInt32((((TextBox)gridNewsCategory.Rows[e.RowIndex].Cells[1].Controls[0]).Text));//第2列

        string sqlString = "update NewsCategory set NewsCategoryName='" + newsCategoryName;
        sqlString += "',NewsCategorySort='" + newsCategorySort + "' where NewsCategoryID=" + newsCategoryID;
        int i = SqlHelper.GetExecuteNonQuery(sqlString);

        gridNewsCategory.EditIndex = -1;//执行更新
        ShowNewsCategory(selectString);//显示给定条件的记录;

    }
    protected void gridNewsCategory_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gridNewsCategory.EditIndex = e.NewEditIndex; //编辑按钮的事件
        ShowNewsCategory(selectString);//显示给定条件的记录
    }
    protected void gridNewsCategory_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gridNewsCategory.EditIndex = -1; //取消编辑
        ShowNewsCategory(selectString);//显示给定条件的记录
    }
}
