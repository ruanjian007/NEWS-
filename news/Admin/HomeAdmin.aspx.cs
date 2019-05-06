using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class Admin_HomeAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminName"] == null)  //如果没有登录，则打开后台登录页
        {
            Response.Redirect("AdminLogin.aspx"); //去后台登录页面
        }
    }
}