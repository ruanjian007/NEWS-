using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;

public partial class ValidateCode : System.Web.UI.Page
{
    //本页面生成验证码图片
    protected void Page_Load(object sender, EventArgs e)
    {   //调用自定义方法绘制验证码
        CreateCheckCodeImage(GenerateCheckCode());
    }
    private string GenerateCheckCode()
    {  //产生四位的随机字符串
        int number;
        char code;
        string checkCode = String.Empty;//创建字符串变量并初始化为空。保存验证码
        System.Random random = new Random();
        //使用For循环生成4个字符，验证码的位数
        for (int i = 0; i < 4; i++) 
        {
            number = random.Next();//生成一个随机数
            //把数字转换成为字符型
            if (number % 2 == 0)
                code = (char)('0' + (char)(number % 10));
            else
                code = (char)('A' + (char)(number % 26));

            checkCode += code.ToString();
        }
        //把生成的随机字符保存到Session。用于客户端校验码比较
        Session["CheckCode"] = checkCode;
        return checkCode;//返回字符串
    }

    private void CreateCheckCodeImage(string checkCode)
    {   //将验证码字符串转换为图片
        //判断字符串不等于空和null
        if (checkCode == null || checkCode.Trim() == String.Empty)
            return;

        //创建一个位图对象
        System.Drawing.Bitmap image = new System.Drawing.Bitmap((int)Math.Ceiling((checkCode.Length * 14.5)), 23);//验证图片的宽，高23
        //创建Graphics对象
        Graphics g = Graphics.FromImage(image);

        try
        {
            //生成随机生成器 
            Random random = new Random();

            //清空图片背景色 
            g.Clear(Color.White);

            //画图片的背景噪音线 
            for (int i = 0; i < 5; i++)
            {
                int x1 = random.Next(image.Width);
                int x2 = random.Next(image.Width);
                int y1 = random.Next(image.Height);
                int y2 = random.Next(image.Height);
                g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
            }

            Font font = new System.Drawing.Font("Arial", 12, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic));
            System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2f, true);
            g.DrawString(checkCode, font, brush, 1, 1);

            //画图片的前景噪音点 
            for (int i = 0; i < 100; i++)
            {
                int x = random.Next(image.Width);
                int y = random.Next(image.Height);
                image.SetPixel(x, y, Color.FromArgb(random.Next()));
            }

            //画图片的边框线 
            g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
            //将图片输出到页面上
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            Response.ClearContent();
            Response.ContentType = "image/Gif";
            Response.BinaryWrite(ms.ToArray());
        }
        finally
        {
            g.Dispose();
            image.Dispose();
        }
    }
    //在需要验证的页面中加入<img id="imgCode" alt="看不清，请点击我！" src="CheckCode.aspx" 
    //       style="cursor: hand; width: 76px; height: 21px" onclick="this.src=this.src+'?'" />
    //或者放置语句 <asp:Image ID="img1" runat="server" ImageUrl="~/ValidateCode.aspx" /> 
    //在验证时可用Session["CheckCode"].ToString().ToLower()获取该值进行验证。
    //例如，if (Session["CheckCode"].ToString().ToLower().Equals(txtValidateCode.Text.ToString().ToLower()))


}
