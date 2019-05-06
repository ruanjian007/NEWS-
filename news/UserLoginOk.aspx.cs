using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserLoginOk : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["username"] == null) //如果会员没有登录
        {
            Response.Redirect("UserLogin.aspx");//登录
        }
        else
        {
            lblMessage.Text = Request.Cookies["username"].Value;//如果已经登录，则显示会员名
        }
    }
    protected void lbtnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserEdit.aspx");//会员修改资料
    }
    protected void lbtnExit_Click(object sender, EventArgs e)
    {
        Response.Cookies["username"].Expires = DateTime.Now.AddDays(-1);//Cookie有效期过期
        Response.Redirect("UserLogin.aspx");
    }
}