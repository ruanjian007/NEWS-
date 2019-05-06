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

public partial class UserRetakePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtName.Focus();
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        Session["name"] = txtName.Text.Trim().Trim(); //保存用户名
        if (ExistUserName(txtName.Text.Trim().Trim()) > 0)
        {
            Response.Redirect("UserRetakePassword1.aspx");//存在该用户
        }
        else
        {
            lblMsg.Text = "您输入的用户 " + txtName.Text.Trim().Trim() + " 不存在!";
            txtName.Text = "";
        }

    }
    protected int ExistUserName(string userName)
    {
        //判断用户名是否存在,如果不存在为0,否则为>=1
        string sqlStr = "select count(*) from UserInfo where UserName='" + userName + "'";
        int i = Convert.ToInt32(SqlHelper.GetExecuteScalar(sqlStr));//返回受影响的行数
        return i;
    }
}
