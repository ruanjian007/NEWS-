using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;//添加引用SqlDbType
using System.Data;//添加

public partial class UserEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["username"] == null) //如果没有登录
        {
            Response.Redirect("UserLogin.aspx");
        }

        if (!IsPostBack)
        {
            string userName = "";
            string userPassword = "";
            string userGender = "";
            string userEmail = "";
            string userAsk = "";
            string userAnswer = "";
            GetUserInfo(ref userName, ref userPassword, ref userGender, ref userEmail, ref userAsk, ref userAnswer);//得到该用户信息
            //把该用户的资料显示在控件中
            lblUserName.Text = userName;
            txtPasswordNew.Text = userPassword;
            radlUserGender.Text = userGender;
            txtUserEmail.Text = userEmail;
            //txtUserAsk.Text = userAsk;
            txtUserAnswer.Text = userAnswer;

            btnReturn.CausesValidation = false;//“重置”按钮不验证
        }
    }

    private void GetUserInfo(ref string userName, ref string userPassword, ref string userGender, ref string userEmail, ref string userAsk, ref string userAnswer)
    {
        //得到该用户的信息，通过ref引用来传递参数
        string sqlStr = "select UserName, UserPassword, UserGender, UserEmail, UserAsk, UserAnswer from UserInfo where UserName = '" + Request.Cookies["username"].Value.ToString() + "'";
        SqlDataReader reader = SqlHelper.GetExecuteReader(sqlStr);
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                userName = reader["UserName"].ToString(); ;
                userPassword = reader["UserPassword"].ToString();
                userGender = reader["UserGender"].ToString();
                userEmail = reader["UserEmail"].ToString();
                userAsk = reader["UserAsk"].ToString();
                userAnswer = reader["UserAnswer"].ToString();
            }
        }
        reader.Close();
        SqlHelper.CloseConnection();//关闭连接
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        string userName = Request.Cookies["username"].Value.ToString(); //获取登录用户名
        string userPassword = txtUserPassword.Text.Trim();//从文本框得到现在的密码
        //string userPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(txtUserPassword.Text.Trim(), "MD5");//MD5
        string userPasswordNew = txtPasswordNew.Text.Trim();//从文本框得到新密码
        //string userPasswordNew = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPasswordNew.Text.Trim(), "MD5");
        string userGender = radlUserGender.SelectedValue; //从单选列表中得到新性别
        string userEmail = txtUserEmail.Text.Trim(); //从文本框中得到新电子邮件 
        string userAsk = ddlUserAsk.SelectedItem.Text.Trim();//从下拉列表框中得到新提问
        string userAnswer = txtUserAnswer.Text.Trim();//从文本框中得到新回答
        bool isPass = true;//设置用户状态，默认为有效

        if (IsPassword(userName, userPassword))
        {
            //如果该用户的当前密码正确，则可以修改
            if (EditUserInfo(userName, userPasswordNew, userGender, userEmail, userAsk, userAnswer, isPass) > 0)
            {   //如果修改成功，则重新登录
                Response.Redirect("UserLogin.aspx");
            }
            else
            {
                SqlHelper.MsgBox("密码修改不成功！，请重新操作。", Page);
            }
        }
        else
        {
            lblMessage.Text = "现在的密码不正确！";
        }
    }
    protected void lbtnForgotPassword_Click(object sender, EventArgs e)
    {
        //“忘记密码”按钮的单击事件,找回密码
        string LinkStr = "UserRetakePassword.aspx";
        Response.Redirect(LinkStr);
    }
    private bool IsPassword(string userName, string userPassword)
    {
        //按该用户输入的现在密码查找
        string sqlStr = "select count(*) from UserInfo where UserName='" + userName + "' and UserPassword='" + userPassword + "'";
        int i = Convert.ToInt32(SqlHelper.GetExecuteScalar(sqlStr));
        return i > 0 ? true : false;
    }
    private int EditUserInfo(string userName, string userPasswordNew, string userGender, string userEmail, string userAsk, string userAnswer, bool isPass)
    {
        string sqlStr = "update UserInfo set UserPassword = @UserPassword, UserGender = @UserGender, UserEmail = @UserEmail, UserAsk = @UserAsk, UserAnswer = @UserAnswer, IsPass = @IsPass where UserName = @UserName";
        SqlParameter[] paras = new SqlParameter[]
        {
            new SqlParameter("@UserName",SqlDbType.VarChar, 50),
            new SqlParameter("@UserPassword",SqlDbType.VarChar, 50),
            new SqlParameter("@UserGender",SqlDbType.VarChar, 50),
            new SqlParameter("@UserEmail",SqlDbType.VarChar, 50),
            new SqlParameter("@UserAsk",SqlDbType.VarChar, 50),
            new SqlParameter("@UserAnswer",SqlDbType.VarChar, 50),
            new SqlParameter("@IsPass",SqlDbType.Bit)
        };
        paras[0].Value = userName;
        paras[1].Value = userPasswordNew;
        paras[2].Value = userGender;
        paras[3].Value = userEmail;
        paras[4].Value = userAsk;
        paras[5].Value = userAnswer;
        paras[6].Value = isPass;
        int i = SqlHelper.GetExecuteNonQuery(sqlStr, paras);
        return i;
    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserLogin.aspx");
    }
}