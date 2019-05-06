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

public partial class UserRetakeUseEmail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] == null)
        {
            Response.Redirect("UserLogin.aspx");
        }

        txtEmail.Focus();
        btnOk.Visible = true;
        lblOk.Visible = false;
        btnFinish.Visible = false;
        if (!IsPostBack)
        {
            lblName.Text = Session["name"].ToString().Trim();
        }
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        string email = txtEmail.Text.Trim();
        if (EmailEqual(email) > 0)//比较输入的Email与表中的Email是否相同，如果相同则执行，否则返回重新输入Email
        {
            lblMsg.Text = "";
            lblOk.Visible = true;
            lblOk.Text = "完成后，系统生成的密码将发到您的邮箱。" + "<br />";
            lblOk.Text += "请查看邮件，用新密码登录，并及时更改密码。";
            btnFinish.Visible = true;
            btnOk.Visible = false;
            btnFinish.Focus();

            string password = GeneratePassword();//随机生成一个密码
            //把随机生成的密码写到表中
            string sqlStr = "update UserInfo set UserPassword = '" + password + "'";
            sqlStr += " where UserName = '" + Session["name"].ToString().Trim() + "'";//只修改第一条记录，如果有多条记录的话
            SqlHelper.GetExecuteNonQuery(sqlStr);

            //SendUserMail(email, password);//然后把密码发送到表中的邮箱，这样用户就可以先用新密码登录
        }
        else
        {
            lblMsg.Text = "您输入的Email与注册时输入的Email不相同! 请重新输入。";
            txtEmail.Text = "";
            return;
        }
    }

    protected int EmailEqual(string email)
    {
        //判断输入的Email与表中的Email是否相同，如果不相同为0,否则为>0
        string sqlStr = "select count(*) from UserInfo where UserName = '" + Session["name"].ToString().Trim() + "'";
        sqlStr += " and UserEmail = '" + email + "'";
        int i = Convert.ToInt32(SqlHelper.GetExecuteScalar(sqlStr));//返回受影响的行数
        return i;
    }
    /// <summary>
    /// 产生六位的随机字符串，作为密码
    /// </summary>
    /// <returns>返回密码字符串</returns>
    private string GeneratePassword()
    {  //产生六位的随机字符串
        int number;
        char code;
        string password = String.Empty;//创建字符串变量并初始化为空
        System.Random random = new Random();
        //使用For循环生成6个字符,验证码的位数
        for (int i = 0; i < 6; i++)
        {
            number = random.Next();//生成一个随机数
            //把数字转换成为字符型
            if (number % 2 == 0)
                code = (char)('0' + (char)(number % 10));
            else
                code = (char)('a' + (char)(number % 26));

            password += code.ToString();
        }
        return password;//返回字符串
    }
    /// <summary>
    /// 发送邮件
    /// </summary>
    /// <param name="recevie">接受者的邮件地址</param>
    /// <param name="password">发送的密码</param>
    /// <returns>返回真</returns>
    private bool SendUserMail(string recevie, string password)
    {
        System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
        client.Host = "SMTP.163.COM";// 把“SMTP.163.COM”改为你使用的SMTP服务器
        client.UseDefaultCredentials = false;
        client.EnableSsl = false;//如果邮箱需要使用SSL安全证书,client.EnableSsl = true
        client.Credentials = new System.Net.NetworkCredential("kflrx@163.com", "ssaa123");//把“kflrx@163.com”改为你发送邮件的邮箱, 把“ssaa123”改为此发送邮箱的密码
        client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
        System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage("kflrx@163.com", recevie);//把“kflrx@163.com”改为发送邮件的邮箱
        message.Subject = "新密码的邮件";//邮件的标题
        message.Body = "您的密码为：" + password;//邮件的密码
        message.BodyEncoding = System.Text.Encoding.UTF8;//邮件的编码形式
        message.IsBodyHtml = true;//邮件内容的形式
        client.Send(message);//发送邮件
        return true;//返回真
    }
    /// <summary>
    /// “完成”按钮的单击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnFinish_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserLogin.aspx");//去登录页
    }
}
