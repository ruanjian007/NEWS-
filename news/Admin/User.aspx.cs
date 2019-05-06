using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;//添加
public partial class Admin_User : System.Web.UI.Page
{
    //本页面主要是说明GridView的删除、编辑的用法。在实际项目中，一般是不能删除、更改用户的资料
    //查询字符串，静态，用于在本页面共用。select语句的字符串要与其他删除、修改作用的字符串采用不同的变量
    static string selectStr = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminName"] == null)//如果没有登录，则打开登录页
        {
            Response.Redirect("AdminLogin.aspx");  //去登录页面
        }
        if (!IsPostBack)
        {
            txtKey.Visible = true;
            ddlUserGender.Visible = false;
            ddlIsPass.Visible = false;

            selectStr = "select * from UserInfo ORDER BY UserID DESC";//显示全部记录，倒序排列，后注册的先显示
            ShowGridView(selectStr);
        }
    }

    private void ShowGridView(string seleStr)
    {
        DataSet ds = SqlHelper.GetDataSet(seleStr);
        gridUser.DataSource = ds;
        gridUser.DataKeyNames = new string[] { "UserID" };//GridView控件的主键名
        gridUser.AllowPaging = true;//启用分页
        gridUser.AutoGenerateColumns = false;//不自己绑定字段
        gridUser.PageSize = 5;//每页显示的记录数
        gridUser.DataBind();
    }
    /// <summary>
    /// "显示全部"记录按钮的单击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        txtKey.Text = "";

        selectStr = "select * from UserInfo ORDER BY UserID DESC";//显示全部记录
        gridUser.PageIndex = 0;//从第1页开始显示
        ShowGridView(selectStr);
    }
    /// <summary>
    /// "查找"按钮的单击事件。组成在GridView控件中显示记录的查询条件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnFind_Click(object sender, EventArgs e)
    {
        string ColumnValue = ddlFindOption.SelectedValue;//查询项下拉列表的选定值,1:会员名（默认值）,2:性别,3:Email,4:状态
        string ColumnName = "";//列名
        string key = "";//查询值
        switch (ColumnValue)
        {
            case "1":
                ColumnName = "UserName";//1:会员名
                key = txtKey.Text.Trim();
                if (txtKey.Text.Trim() != "")
                {
                    selectStr = "select * from UserInfo where " + ColumnName + " like '%" + key + "%'";
                }
                else
                {
                    selectStr = "select * from UserInfo ORDER BY UserID DESC";//显示全部记录
                }
                break;
            case "2":
                ColumnName = "UserGender";//2:性别
                key = ddlUserGender.SelectedItem.Text;//取Text
                selectStr = "select * from UserInfo where " + ColumnName + " like '%" + key + "%'";
                break;
            case "3":
                ColumnName = "UserEmail";//3:Email
                key = txtKey.Text.Trim();
                selectStr = "select * from UserInfo where " + ColumnName + " like '%" + key + "%'";
                break;
            case "4":
                ColumnName = "IsPass";//4:状态
                key = ddlIsPass.SelectedValue;//“正常”的值为1,“禁用”的值为0
                selectStr = "select * from UserInfo where " + ColumnName + "=" + key;
                break;
        }
        ShowGridView(selectStr);//显示给定条件的记录
    }
    /// <summary>
    /// 分页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gridUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridUser.PageIndex = e.NewPageIndex;
        ShowGridView(selectStr);//显示给定条件的记录
    }
    /// <summary>
    /// 在单击 GridView 控件内某一行的 "删除"按钮（其 CommandName 属性设置为"Delete"的按钮）时发生，但在 GridView 控件从数据源删除记录之前。此事件通常用于取消删除操作。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gridUser_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //为了删除该用户，要先删除该用户在登陆日志表UserLogin中的所有登录记录
        string sqlStr1 = "delete from UserLogin where UserLoginID=" + Convert.ToInt32(gridUser.DataKeys[e.RowIndex].Value);
        SqlHelper.GetExecuteNonQuery(sqlStr1);

        //删除用户表UserInfo中的记录
        string sqlStr2 = "delete from UserInfo where UserID=" + Convert.ToInt32(gridUser.DataKeys[e.RowIndex].Value);
        SqlHelper.GetExecuteNonQuery(sqlStr2);

        //删除记录后，重新在GridView中显示记录
        ShowGridView(selectStr);//显示给定条件的记录
    }

    /// <summary>
    /// 在单击 GridView 控件内某一行的"编辑"按钮（其 CommandName 属性设置为"Edit"的按钮）时发生，但在 GridView 控件进入编辑模式之前。此事件通常用于取消编辑操作。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gridUser_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gridUser.EditIndex = e.NewEditIndex;
        ShowGridView(selectStr);//显示给定条件的记录
    }
    /// <summary>
    /// 在单击 GridView 控件内某一行的"更新"按钮（其 CommandName 属性设置为"Update"的按钮）时发生，但在 GridView 控件更新记录之前。此事件通常用于取消更新操作。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gridUser_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int id = Convert.ToInt32(gridUser.DataKeys[e.RowIndex].Value);
        string pwd = ((TextBox)(gridUser.Rows[e.RowIndex].Cells[1].Controls[0])).Text.ToString().Trim();
        string gender = ((DropDownList)gridUser.Rows[e.RowIndex].FindControl("ddlGender")).SelectedValue;
        string email = ((TextBox)(gridUser.Rows[e.RowIndex].Cells[3].Controls[0])).Text.ToString().Trim();
        string ask = ((TextBox)(gridUser.Rows[e.RowIndex].Cells[4].Controls[0])).Text.ToString().Trim();
        string answer = ((TextBox)(gridUser.Rows[e.RowIndex].Cells[5].Controls[0])).Text.ToString().Trim();
        string pass = ((DropDownList)gridUser.Rows[e.RowIndex].FindControl("ddlIsPass")).SelectedValue;

        string sqlStr = "update UserInfo set UserPassword='" + pwd;
        sqlStr += "',UserGender='" + gender + "',UserEmail='" + email + "',UserAsk='" + ask;
        sqlStr += "',UserAnswer='" + answer + "',IsPass='" + pass + "' where UserID=" + id;
        SqlHelper.GetExecuteNonQuery(sqlStr);
        gridUser.EditIndex = -1;
        ShowGridView(selectStr);//显示给定条件的记录
    }
    /// <summary>
    /// 在单击 GridView 控件内某一行的"取消"按钮（其 CommandName 属性设置为“Cancel”的按钮）时发生，但在 GridView 控件退出编辑模式之前。此事件通常用于停止取消操作。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gridUser_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gridUser.EditIndex = -1;
        ShowGridView(selectStr);//显示给定条件的记录
    }
    /// <summary>
    /// 在 GridView 控件中的某个行被绑定到一个数据记录时发生。此事件通常用于在某个行被绑定到数据时修改该行的内容。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gridUser_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //用户状态，显示时。行绑定Label
        if (((Label)e.Row.FindControl("lblIsPass")) != null)
        {
            Label LBLIsPass = (Label)e.Row.FindControl("lblIsPass");
            if (((HiddenField)e.Row.FindControl("hdfIsPassLbl")).Value.ToString() == "True")
            {
                LBLIsPass.Text = "正常";
            }
            else
            {
                LBLIsPass.Text = "禁用";
                LBLIsPass.ForeColor = System.Drawing.Color.Red;
            }
        }
        //性别，修改时。行绑定DropDownList
        if (((DropDownList)e.Row.FindControl("ddlGender")) != null)
        {
            DropDownList DDLGender = (DropDownList)e.Row.FindControl("ddlGender");
            //DDLGender初始被选择的项
            DDLGender.Items.Clear();
            DDLGender.Items.Add(new ListItem("男", "男"));
            DDLGender.Items.Add(new ListItem("女", "女"));
            DDLGender.SelectedValue = ((HiddenField)e.Row.FindControl("hdfGender")).Value;
        }
        //用户状态，修改时。行绑定DropDownList
        if (((DropDownList)e.Row.FindControl("ddlIsPass")) != null)
        {
            DropDownList DDLIsPass = (DropDownList)e.Row.FindControl("ddlIsPass");
            DDLIsPass.Items.Clear();
            DDLIsPass.Items.Add(new ListItem("正常", "True"));//注意"True"的大小写
            DDLIsPass.Items.Add(new ListItem("禁用", "False"));//注意"False"的大小写
            DDLIsPass.SelectedValue = ((HiddenField)e.Row.FindControl("hdfIsPass")).Value;
        }
    }
    protected void ddlFindOption_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ColumnValue = ddlFindOption.SelectedValue;
        switch (ColumnValue)
        {
            case "1":
                txtKey.Visible = true;
                ddlUserGender.Visible = false;
                ddlIsPass.Visible = false;
                break;
            case "2":
                txtKey.Visible = false;
                ddlUserGender.Visible = true;
                ddlIsPass.Visible = false;
                break;
            case "3":
                txtKey.Visible = true;
                ddlUserGender.Visible = false;
                ddlIsPass.Visible = false;
                break;
            case "4":
                txtKey.Visible = false;
                ddlUserGender.Visible = false;
                ddlIsPass.Visible = true;
                break;
        }
    }
}