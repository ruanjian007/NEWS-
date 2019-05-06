using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;//添加
using System.Data;//添加引用SqlDbType

public partial class UserLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtUserName.Focus();

        if (!IsPostBack)
        {
            lbtnUserRegiste.CausesValidation = false;//"注册新会员"按钮不激发验证
            lbtnForgotPassword.CausesValidation = false;//"忘记密码"按钮不激发验证
        }
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        //单击登陆按钮后，先判断验证码正确后，再判断用户名和密码
        if (Session["CheckCode"].ToString().ToLower().Equals(txtValidateCode.Text.ToString().ToLower()))
        {
            string userName = txtUserName.Text.Trim();//输入的用户名
            string userPassword = txtUserPassword.Text.Trim();//输入的密码
            if (ExistUser(userName, userPassword) > 0)//判断用户名和密码是否正确
            {
                if (IsPassUser(userName))//判断账号是否被封
                {
                    //如果用户账号正常,添加登陆日志
                    int userID = GetUserID(userName, userPassword);//用户ID
                    DateTime loginDateTime = DateTime.Now;//现在时间
                    string loginIP = Request.UserHostAddress.ToString();//IP
                    AddLoginUser(userID, loginDateTime, loginIP);//添加登录日志

                    //Session["username"] = userName; //保存用户登录状态,保存用户名
                    //Session["userid"] = userID; //保存用户登录状态,保存用户ID

                    Response.Cookies["username"].Value = userName;//保存用户登录状态,保存用户名
                    Response.Cookies["userid"].Value = userID.ToString(); //保存用户登录状态,保存用户ID
                    if (ddlDay.SelectedItem.Text == "一年")
                    {
                        Response.Cookies["username"].Expires = DateTime.Now.AddDays(365);//Cookie有效期为1年
                        Response.Cookies["userid"].Expires = DateTime.Now.AddDays(365);
                    }
                    else if (ddlDay.SelectedItem.Text == "一月")
                    {
                        Response.Cookies["username"].Expires = DateTime.Now.AddDays(31);//Cookie有效期为1月
                        Response.Cookies["userid"].Expires = DateTime.Now.AddDays(31);
                    }
                    else
                    {
                        Response.Cookies["username"].Expires = DateTime.Now.AddDays(1);//Cookie有效期为1天
                        Response.Cookies["userid"].Expires = DateTime.Now.AddDays(1);
                    }

                    Response.Redirect("UserLoginOk.aspx");//定向到HomeNews.aspx页
                }
                else
                {
                    lblMessage.Text = "账号 " + userName + " 被封,暂时不能登录! 请联系管理员！";
                }
            }
            else
            {
                lblMessage.Text = "密码或用户名错误！";
            }
        }
        else
        {
            lblMessage.Text = "验证码错误！";
        }
    }
    protected int ExistUser(string userName, string userPassword)
    {
        //判断用户名和密码是否正确

        //设置参数，并把控件中的值赋给相应参数
        string sqlStr = "select count(*) from UserInfo where UserName = @UserName and UserPassword = @UserPassword";
        SqlParameter[] paras = new SqlParameter[]
        {
            new SqlParameter("@UserName", SqlDbType.VarChar, 50),
            new SqlParameter("@UserPassword", SqlDbType.VarChar, 50)
        };
        paras[0].Value = userName; //获取用户名
        paras[1].Value = userPassword;//如果不采用MD5，则去掉本行注释，给下行加上注释
        //paras[1].Value = FormsAuthentication.HashPasswordForStoringInConfigFile(userPassword, "MD5");//去掉注释则实现MD5，给上面一行加上注释
        int i = Convert.ToInt32(SqlHelper.GetExecuteScalar(sqlStr, paras));
        return i;
    }
    protected bool IsPassUser(string userName)
    {
        //判断账号是否被封
        bool isPass = false;
        string sqlStr = "select IsPass from UserInfo where UserName = '" + userName + "'";
        SqlDataReader reader = SqlHelper.GetExecuteReader(sqlStr);
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                isPass = (bool)reader["IsPass"];
                break;////跳出循环,只读取第一条记录，防止可能有多条记录
            }
        }
        reader.Close();
        return isPass;
    }
    protected int GetUserID(string userName, string userPassword)
    {
        //得到用户ID
        //在UserInfo表中查找输入的用户名和密码的记录
        string sqlStr = "select UserID from UserInfo where UserName = @UserName and UserPassword = @UserPassword";
        SqlParameter[] paras = new SqlParameter[]
        {
            new SqlParameter("@UserName", SqlDbType.VarChar, 50),
            new SqlParameter("@UserPassword", SqlDbType.VarChar, 50)
        };
        paras[0].Value = userName; //登录框中输入的登录用户名
        paras[1].Value = userPassword;//如果不采用MD5，则去掉本行注释，给下行加上注释
        //paras[1].Value  = FormsAuthentication.HashPasswordForStoringInConfigFile(userPassword, "MD5");//去掉注释则实现MD5，给上面一行加上注释

        int userID = 0;//保存从UserInfo表中得到的用户ID

        SqlDataReader reader = SqlHelper.GetDataReader(sqlStr, paras);
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                //当用户名和密码正确时，找到该记录
                userID = (int)reader["UserID"];//从表中得到用户ID
            }
        }
        reader.Close();

        return userID;//返回用户的ID
    }

    protected void AddLoginUser(int userID, DateTime loginDateTime, string loginIP)
    {
        //添加登陆日志
        string sqlStr = "insert UserLogin values('" + userID + "','" + loginDateTime + "','" + loginIP + "')";
        SqlHelper.GetExecuteNonQuery(sqlStr);
    }

    protected void lbtnUserRegiste_Click(object sender, EventArgs e)
    {
        //“注册新会员”按钮的单击事件,去注册页面
        string LinkStr = "UserRegister.aspx";
        Response.Redirect(LinkStr);
    }
    protected void lbtnForgotPassword_Click(object sender, EventArgs e)
    {
        //“忘记密码”按钮的单击事件,找回密码
        string LinkStr = "UserRetakePassword.aspx";
        Response.Redirect(LinkStr);
    }
}