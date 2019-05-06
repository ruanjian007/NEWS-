using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserRegister : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lbtnCheckUserName.CausesValidation = false;//单击"检查注册名"按钮不激发验证  
        btnReturn.CausesValidation = false;//单击"返回"按钮不激发验证
        txtUserPassword.Attributes.Add("value1", txtUserPassword.Text.Trim());//刷新时保存密码
        txtUserPasswordAgain.Attributes.Add("value2", txtUserPasswordAgain.Text.Trim());//刷新时保存密码
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        //“注册”按钮的单击事件
        //单击登陆按钮后，先判断验证码正确后，再判断其他。Session["CheckCode"来自ValidateCode2.aspx
        if (Session["CheckCode"].ToString().ToLower().Equals(txtValidateCode.Text.ToString().ToLower()))
        {
            if (chkUserAgree.Checked) //复选框同意“网站服务条款”
            {
                if (ExistUserName() <= 0)   //调用自定义方法ExistUserName()判断该用户名是否存在
                {   //<=0不存在

                    string userName = txtUserName.Text.Trim(); //获取用户名
                    string userPassword = txtUserPassword.Text.Trim();//获取密码. 如果不采用MD5，则去掉本行注释，给下行加上注释
                    //string userPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(txtUserPassword.Text.Trim(), "MD5");//去掉注释则实现MD5，给上面一行加上注释
                    string userGender = radlUserGender.SelectedValue; //获取性别
                    string userEmail = txtUserEmail.Text.Trim(); //获取电子邮件 
                    string userAsk = ddlUserAsk.SelectedItem.Text.Trim();//问题
                    string userAnswer = txtUserAnswer.Text.Trim();//问题回答
                    DateTime createdDateTime = DateTime.Now;//现在时间
                    bool isPass = true;//设置用户状态
                    if (AddUser(userName, userPassword, userGender, userEmail, userAsk, userAnswer, createdDateTime, isPass))//调用自定义方法AddUser()添加用户
                    {   //true添加成功
                        SqlHelper.MsgBox("注册成功！单击确定返回登陆页面", "UserLogin.aspx", Page);
                    }
                    else
                    {
                        SqlHelper.MsgBox("注册失败！", Page);
                    }
                }
                else
                {
                    SqlHelper.MsgBox("用户名已经存在！", Page);
                }
            }
            else
            {
                SqlHelper.MsgBox("您必须同意“网站服务条款”才能注册！", Page);
            }
        }
        else
        {
            SqlHelper.MsgBox("验证码错误！", Page);
        }
    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        //“返回”按钮的单击事件，返回登录页面
        string LinkStr = "UserLogin.aspx";
        Response.Redirect(LinkStr, true);
    }
    protected void lbtnCheckUserName_Click(object sender, EventArgs e)
    {
        //“检查注册名”按钮的单击事件
        if (ExistUserName() > 0)
        {
            SqlHelper.MsgBox("注册名已经存在！", Page);
        }
        else
        {
            SqlHelper.MsgBox("可以注册!", Page);
        }
    }

    protected int ExistUserName()
    {
        //自定义方法，判断用户名是否存在,如果不存在为0,否则为>=1
        int i = 0;
        string userName = txtUserName.Text.Trim();
        if (userName != "")
        {
            string sqlStr = "select count(*) from UserInfo where UserName='" + userName + "'";
            i = Convert.ToInt32(SqlHelper.GetExecuteScalar(sqlStr));//返回受影响的行数
        }
        else
        {
            i = 1;//不输入用户名，也作为已存在用户来处理
        }
        return i;
    }

    protected bool AddUser(string userName, string userPassword, string userGender, string userEmail, string userAsk, string userAnswer, DateTime createdDateTime, bool isPass)
    {
        //自定义方法，把用户信息添加到数据库中,成功返回True否则false
        int pass = (isPass) ? 1 : 0;//把bool isPass转换为int
        string sqlStr = "insert into UserInfo (UserName, UserPassword, UserGender, UserEmail, UserAsk, UserAnswer, CreatedDateTime, IsPass) values('" + userName + "','" + userPassword + "','" + userGender + "','" + userEmail + "','" + userAsk + "','" + userAnswer + "','" + createdDateTime + "','" + pass + "')";
        int i = SqlHelper.GetExecuteNonQuery(sqlStr); //返回受影响的行数
        return (i > 0) ? true : false;
    }
}