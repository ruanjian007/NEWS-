using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class Admin_MasterPageAdmin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminName"] == null) //如果没有登录，则打开登录页
        {
            Response.Redirect("AdminLogin.aspx");//重定向到登录页面
        }
        if (!IsPostBack)
        {
            lblAdminName.Text = Session["adminname"].ToString();//获取管理员名
            lblAdminGradeName.Text = Session["admingradename"].ToString().Trim();//获取权限
            lbtnExit.CausesValidation = false;//不验证“退出后台管理”按钮
        }
    }
    protected void lbtnExit_Click(object sender, EventArgs e)
    {
        //清空登陆信息，退出登陆
        Session["adminid"] = null;//管理员ID
        Session["adminname"] = null;//管理员名
        Session["admingradeid"] = null;//权限ID
        Session["admingradename"] = null;//权限名
        Response.Redirect("AdminLogin.aspx"); //重定向到登录页面
    }
}
