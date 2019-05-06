using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class UserRetakePassword1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] == null)//如果没有输入会员名
        {
            Response.Redirect("UserLogin.aspx");
        }
        else
        {
            lblName.Text = Session["name"].ToString();
        }
    }
    protected void lbtnUsePassword_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserRetakeUsePassword.aspx");
    }
    protected void lbtnUseEmail_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserRetakeUseEmail.aspx");
    }
}
