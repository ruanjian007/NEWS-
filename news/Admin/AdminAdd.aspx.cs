using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;//添加引用SQL Server;
using System.Web.Security;//添加引用MD5
using System.Data;//添加对DataSet的引用


public partial class Admin_AdminAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminName"] == null)//如果没有登录，则打开登录页
        {
            Response.Redirect("AdminLogin.aspx");  //定向到登录页面
        }

        if (!IsPostBack)
        {
            ShowAdminGrade();//绑定权限级别下拉列表框
        }
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        //“确定添加”按钮的单击事件
        if (Page.IsValid)
        {
            //首先检查新账号是否存在.
            string sqlStr1 = "select count(*) from Admin where AdminName='" + txtAdminName.Text + "'";
            int i = Convert.ToInt32(SqlHelper.GetExecuteScalar(sqlStr1));
            if (i > 0)
            {
                SqlHelper.MsgBox("该账号已经存在!请改名。", Page);
                return;
            }
            else
            {   //如果新账号名不存在，则执行修改
                int adminGradeID = ddlAdminGrade.SelectedIndex + 1;//下拉列表框的第1项的序号是0，所以+1
                string adminPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(txtAdminPassword.Text.Trim(), "MD5");

                string sqlStr = "insert into Admin(AdminName, AdminPassword, AdminRealName, AdminGradeID)";
                sqlStr += "values ('" + txtAdminName.Text + "','" + adminPassword + "','";
                sqlStr += txtAdminRealName.Text + "','" + adminGradeID + "')";
                SqlHelper.GetExecuteNonQuery(sqlStr);

                Response.Redirect("Admin.aspx");//定向到编辑管理员页
            }
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        //“重新填写”按钮的单击事件
        txtAdminName.Text = null;
        txtAdminPassword.Text = null;
        txtAdminRealName.Text = null;
    }
    private void ShowAdminGrade()
    {
        //从权限级别表中读出到下拉列表框中
        string sqlStr = "select AdminGradeName from AdminGrade";
        DataSet ds = SqlHelper.GetDataSet(sqlStr);
        ddlAdminGrade.DataSource = ds.Tables[0].DefaultView;
        ddlAdminGrade.DataTextField = "AdminGradeName";
        ddlAdminGrade.DataValueField = "AdminGradeName";
        ddlAdminGrade.DataBind();
    }
}