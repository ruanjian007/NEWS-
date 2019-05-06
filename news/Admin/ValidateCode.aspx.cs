﻿using System;
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

public partial class CheckImg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string checkCode = CreateCode(4);

        //用于验证
        Session["CheckCode"] = checkCode;
        CreateImages(checkCode);
    }
    /*产生验证码*/
    public string CreateCode(int codeLength)
    {
        //去掉不容易识别的字符
        string so = "2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,j,k,m,n,p,q,r,s,t,u,v,w,x,y,z,A,B,C,D,E,F,G,H,I,J,K,L,M,N,P,Q,R,S,T,U,V,W,X,Y,Z";
        string[] strArr = so.Split(',');
        string code = "";
        Random rand = new Random();
        for (int i = 0; i < codeLength; i++)
        {
            code += strArr[rand.Next(0, strArr.Length)];
        }
        return code;
    }

    /*产生验证图片*/
    public void CreateImages(string code)
    {

        Bitmap image = new Bitmap(78, 28);
        Graphics g = Graphics.FromImage(image);
        WebColorConverter ww = new WebColorConverter();
        g.Clear((Color)ww.ConvertFromString("#eeeeee"));

        Random random = new Random();
        //画图片的背景噪音线
        for (int i = 0; i < 12; i++)
        {
            int x1 = random.Next(image.Width);
            int x2 = random.Next(image.Width);
            int y1 = random.Next(image.Height);
            int y2 = random.Next(image.Height);

            g.DrawLine(new Pen(Color.LightGray), x1, y1, x2, y2);
        }
        Font font = new Font("Arial", 15, FontStyle.Bold | FontStyle.Italic);
        System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(
         new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.Gray, 1.2f, true);
        g.DrawString(code, font, brush, 0, 0);

        //画图片的前景噪音点
        for (int i = 0; i < 10; i++)
        {
            int x = random.Next(image.Width);
            int y = random.Next(image.Height);
            image.SetPixel(x, y, Color.White);
        }

        //画图片的边框线
        g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);

        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
        Response.ClearContent();
        Response.ContentType = "image/Gif";
        Response.BinaryWrite(ms.ToArray());
        g.Dispose();
        image.Dispose();
    }
}
