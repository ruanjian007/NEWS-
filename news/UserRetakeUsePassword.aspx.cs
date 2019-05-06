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
using System.Data.SqlClient;//程序员添加的

public partial class UserRetakeUsePassword : System.Web.UI.Page
{
    private static string answer = "";//如果不设置为static，则在Page_Load中要取消if (!IsPostBack)

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] == null)
        {
            Response.Redirect("UserLogin.aspx");
        }
        txtAnswer.Focus();
        if (!IsPostBack)
        {
            lblName.Text = Session["name"].ToString().Trim();
            string sqlStr = "select UserAsk, UserAnswer from UserInfo";
            sqlStr += " where UserName = '" + Session["name"].ToString().Trim() + "'";
            SqlDataReader reader = SqlHelper.GetExecuteReader(sqlStr);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    lblAsk.Text = reader["UserAsk"].ToString().Trim();//reader.GetString(0);
                    answer = reader["UserAnswer"].ToString().Trim();//reader.GetString(1);
                    break;////跳出循环,只读取第一条记录，防止可能有多条记录
                }
            }
            reader.Close();//关闭阅读器
            SqlHelper.CloseConnection();//关闭连接
        }
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        //单击登陆按钮后，先判断验证码正确后，再判断用户名和密码
        if (Session["CheckCode"].ToString().ToLower().Equals(txtValidateCode.Text.ToString().ToLower()))
        {
            if ((txtAnswer.Text).ToString().Trim() == answer)
            {   //更新密码
                string sqlStr = "update UserInfo set UserPassword = '" + txtPassword.Text + "'";
                sqlStr += " where UserName = '" + Session["name"].ToString().Trim() + "'";//只修改第一条记录，如果有多条记录的话
                SqlHelper.GetExecuteNonQuery(sqlStr);

                Response.Redirect("UserLogin.aspx");//去登录页
            }
            else
            {
                lblMsg.Text = "“问题答案”不正确!请重新输入。";
                return;
            }
        }
        else
        {
            txtValidateCode.Text = "";
            lblMsg.Text = "验证码错误！";
        }
    }
}
