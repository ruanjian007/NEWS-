using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;//引用SQL Server数据库
using System.Data;//引用DataSet
using System.Web.UI;//引用Page对象
using System.Text;//引用StringBuilder对象
//<!--*《ASP.NET数据库网站设计教程（C#版）第2版》配套教学资源-刘瑞新主编-电子工业出版社2015.1 可以自由使用，但请不要删除本标志，引用请注明出处*-->

/// <summary>
///SqlHelper 的摘要说明
/// </summary>
public class SqlHelper
{
    public SqlHelper()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    private static SqlConnection conn = new SqlConnection();//创建静态Connection对象
    private static SqlCommand cmd = new SqlCommand();//创建静态Command对象
    /// <summary>
    /// 打开连接
    /// </summary>
    private static void OpenConnection()
    {   //如果连接状态为关闭，则打开连接
        if (conn.State == ConnectionState.Closed)
        {   //web.config文件中获取数据库连接字符串
            string connString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            conn.ConnectionString = connString;//把连接字符串赋值给连接对象
            cmd.Connection = conn;//设置命令对象的连接对象
            conn.Open();//打开连接
        }
    }
    /// <summary>
    /// 关闭连接
    /// </summary>
    public static void CloseConnection()
    {   //如果连接状态为打开，则关闭连接
        if (conn.State == ConnectionState.Open)
        { 
            conn.Close();//关闭连接
        }
    }

    /// <summary>
    /// 执行一条sql语句，返回一个整数
    /// </summary>
    /// <param name="sqlStr">sql语句</param>
    ///GetExecuteNonQuery(string sqlStr)调用形式
    ///string sqlStr = "insert UserLogin values('" + txtUserInfo_Name.Text.Trim() + "','" + Request.UserHostAddress.ToString() + "')";
    ///或string sqlStr = "update UserInfo set UserInfo_Password='" + pwdNew + "',UserInfo_Sex='" + sex
    ///                 + "'" + " where UserInfo_Name='" + name + "'";
    ///SqlHelper.GetExecuteNonQuery(sqlStr);
    //或int i = SqlHelper.GetExecuteNonQuery(sqlStr);
    public static int GetExecuteNonQuery(string sqlStr)
    {
        OpenConnection();//打开连接
        cmd.CommandType = CommandType.Text;//定义为使用SQL语句
        cmd.CommandText = sqlStr;//初始化Command对象的SQL字符串
        int result = cmd.ExecuteNonQuery();//执行SQL语句并返回受影响的行数
        CloseConnection();//关闭连接
        return result;//返回整数
    }


    /// <summary>
    /// 执行一条sql语句,设置值为参数集，public static int GetExecuteNonQuery(string sqlStr)的重载方法
    /// </summary>
    /// <param name="sqlStr">sql语句</param>
    ///string sqlStr = "insert into gongGaoInfo(title,content,fabuTime) values(@title,@content,@fabuTime)";
    ///或string sqlStr = "update gongGaoInfo set title=@title,content=@content,fabuTime=@fabuTime where id=@id";
    ///或string sqlStr = "update UserInfo set UserInfo_Password=@UserInfo_Password,UserInfo_Sex=@UserInfo_Sex where UserInfo_Name=@UserInfo_Name";
    ///SqlParameter[] paras = new SqlParameter[]
    ///{
    ///    new SqlParameter("@UserInfo_Password",SqlDbType.VarChar, 50),
    ///    new SqlParameter("@UserInfo_Sex",SqlDbType.VarChar, 50),
    ///    new SqlParameter("@UserInfo_Name",SqlDbType.VarChar, 50)
    ///};
    ///paras[0].Value = pwdNew;
    ///paras[1].Value = sex;
    ///paras[2].Value = name;
    ///int ret = SqlHelper.GetExecuteNonQuery(sqlStr,paras); 
    public static int GetExecuteNonQuery(string sqlStr, params SqlParameter[] values)
    {
        OpenConnection();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = sqlStr;
        cmd.Parameters.AddRange(values);//添加参数集
        int result = cmd.ExecuteNonQuery();
        CloseConnection();
        cmd.Parameters.Clear();
        return result;
    }

    /// <summary>
    /// 执行一条sql语句，返回一个值
    /// </summary>
    /// <param name="sqlStr">sql语句</param>
    /// GetExecuteScalar(string sqlStr)调用形式
    ///string sqlStr = "select count(*) from Admin where Admin_Name = '" + name + "' and Admin_Password='" + pwd + "'";
    ///int i = SqlHelper.GetExecuteScalar(sqlStr);  
    public static object GetExecuteScalar(string sqlStr)
    {
        OpenConnection();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = sqlStr;
        object result = cmd.ExecuteScalar();//执行SQL语句
        CloseConnection();
        return result;//返回获得的单个值
    }


    /// <summary>
    /// 执行一条sql语句，重载方法
    /// </summary>
    /// <param name="sqlStr">sql语句</param>
    ///GetExecuteScalar(string sqlStr, params SqlParameter[] values)调用形式
    ///string sqlStr = "select count(*) from UserInfo where UserInfo_Name= @name and UserInfo_Password=@pwd";
    ///SqlParameter[] paras = new SqlParameter[]
    ///{
    ///    new SqlParameter("@name ", SqlDbType.VarChar, 50),
    ///    new SqlParameter("@pwd ", SqlDbType.VarChar, 50)
    ///};
    ///paras[0].Value = txtUserInfo_Name.Text.Trim(); //获取用户名
    ///paras[1].Value = txtUserInfo_Password.Text.Trim();//获取密码
    ///int i = SqlHelper.GetExecuteScalar(sqlStr, paras);
    public static object GetExecuteScalar(string sqlStr, params SqlParameter[] values)
    {
        OpenConnection();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = sqlStr;
        cmd.Parameters.Clear();
        cmd.Parameters.AddRange(values);
        object result = cmd.ExecuteScalar();
        CloseConnection();
        cmd.Parameters.Clear();
        return result;
    }


    /// <summary>
    /// 返回DataReader 
    /// </summary>
    /// <param name="sqlStr">sql语句</param>
    ///GetDataReader(string sqlStr)调用形式
    ///string sqlStr = "select UserInfo_Password,UserInfo_Sex from UserInfo where UserInfo_Name = '" + Session["name"].ToString() + "'";
    ///SqlDataReader reader = SqlHelper.GetDataReader(sqlStr);
    ///if (reader.HasRows)
    ///{
    ///    while (reader.Read())
    ///    {
    ///        lblUserInfo_Name.Text = Session["name"].ToString();
    ///        txtNewPassword.Text = (int)reader["UserInfo_Password"].ToString();
    ///        break;////跳出循环,只读取第一条记录，防止可能有多条记录
    ///    }
    ///}
    ///reader.Close();//关闭读取器
    ///SqlHelper.CloseConnection();//关闭连接 
    public static SqlDataReader GetExecuteReader(string sqlStr)
    {
        OpenConnection();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = sqlStr;
        SqlDataReader reader = cmd.ExecuteReader();
        //这里不能关闭连接CloseConnection()，要在调用中关闭
        return reader;
    }


    /// <summary>
    /// 返回DataReader，重载方法
    /// </summary>
    /// <param name="sqlStr">sql语句</param>
    ///GetDataReader(string sqlStr, params SqlParameter[] values)调用形式
    ///string sqlStr = "select Admin_Password,Admin_GradeNo from Admin where Admin_Name =@Admin_Name and Admin_Password=@Admin_Password";
    ///SqlParameter[] paras = new SqlParameter[]
    ///{
    ///    new SqlParameter("@Admin_Name", SqlDbType.VarChar, 50),
    ///    new SqlParameter("@Admin_Password", SqlDbType.VarChar, 50)
    ///};
    ///paras[0].Value = name; //获取用户名
    ///paras[1].Value = pwd;//获取密码
    ///SqlDataReader reader = SqlHelper.GetDataReader(sqlStr, paras);
    ///if (reader.HasRows)
    ///{
    ///    while (reader.Read())
    ///    {
    ///        admin_Password=reader["Admin_Password"].ToString();
    ///        gradeNo = (int)reader["Admin_GradeNo"];
    ///    }
    ///}
    ///reader.Close();//关闭读取器
    ///SqlHelper.CloseConnection();//关闭连接
    public static SqlDataReader GetDataReader(string sqlStr, params SqlParameter[] values)
    {
        OpenConnection();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = sqlStr;
        cmd.Parameters.AddRange(values);
        SqlDataReader reader = cmd.ExecuteReader();
        //这里不能关闭连接CloseConnection()，要在调用中关闭
        cmd.Parameters.Clear();
        return reader;
    }


    /// <summary>
    /// 返回DataSet
    /// </summary>
    /// <param name="sqlStr">sql语句</param>
    /// <returns></returns>
    public static DataSet GetDataSet(string sqlStr)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        OpenConnection();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = sqlStr;
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds);
        CloseConnection();
        return ds;//返回DataSet对象
    }
    //string sqlStr = "select * from Admin ORDER BY Admin_ID ASC";
    //DataSet ds = SqlHelper.GetDataSet(sqlStr);

    /// <summary>
    /// 返回DataSet，重载方法
    /// </summary>
    /// <param name="sqlStr">sql语句</param>
    public static DataSet GetDataSet(string sqlStr, params SqlParameter[] values)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        OpenConnection();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = sqlStr;
        cmd.Parameters.AddRange(values);
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds);
        CloseConnection();
        cmd.Parameters.Clear();
        return ds;//返回DataSet对象
    }

    /// <summary>
    /// 返回DataSet，重载方法,传递表名
    /// </summary>
    /// <param name="strSql"></param>
    /// <param name="tableName"></param>
    /// <returns></returns>
    public static DataSet GetDataSet(string sqlStr, string tableName)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        OpenConnection();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = sqlStr;
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds, tableName);
        CloseConnection();
        return ds;//返回DataSet对象
    }

    /// <summary>
    /// 返回DataTable ，读写数据表--DataTable
    /// </summary>
    /// <param name="sqlStr">sql语句</param>
    ///GetDataTable(String sqlStr)调用形式
    ///string sqlStr = "select UserInfo_Name,UserInfo_Password from UserInfo where UserInfo_Name = '" + Session["name"].ToString() + "'";
    ///DataTable dt = new DataTable();
    ///dt = SqlHelper.GetDataTable(sqlStr);
    ///lblUserInfo_Name.Text = dt.Rows[0].ItemArray[0].ToString();
    ///txtNewPassword.Text = (int)dt.Rows[0].ItemArray[1].ToString();
    public static DataTable GetDataTable(String sqlStr)
    {
        OpenConnection();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = sqlStr;
        DataTable dt = new DataTable();//创建一个数据表dt
        SqlDataAdapter da = new SqlDataAdapter(cmd);//定义并初始化数据适配器
        da.Fill(dt);//将数据适配器中的数据填充到数据集dt中
        CloseConnection();
        return dt;
    }

    /// <summary>
    /// 返回DataTable，重载方法
    /// </summary>
    /// <param name="sqlStr">sql语句</param>
    public static DataTable GetDataTable(string sqlStr, params SqlParameter[] values)
    {
        OpenConnection();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = sqlStr;
        cmd.Parameters.AddRange(values);
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        CloseConnection();
        cmd.Parameters.Clear();
        return ds.Tables[0];
    }


    /// <summary>
    /// 返回一个数据视图
    /// </summary>
    /// <param name="sqlStr">sql语句</param>
    /// <returns></returns>
    public static DataView GetDataView(string sqlStr)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        DataView dv = new DataView();
        DataSet ds = new DataSet();
        OpenConnection();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = sqlStr;
        da.SelectCommand = cmd;
        da.Fill(ds);
        dv = ds.Tables[0].DefaultView;
        CloseConnection();
        return dv;
    }

    /// <summary>
    /// 警告窗口,服务器端弹出alert对话框
    /// </summary>
    /// <param name="message">提示信息,例子："不能为空!"</param>
    /// <param name="page">Page类</param>
    public static void GetAlert(string message, Page page) //显示对话框
    {
        //Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "alert('" + message + "');", true);
        //Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script language='javascript'">alert('" + message + "');</script>",false);
        page.ClientScript.RegisterStartupScript(page.GetType(), "",
       "<script language='javascript' type='text/javascript'>alert('" + message + "')</script>", false);
    }

    /// <summary>
    /// 警告窗口,服务器端弹出alert对话框
    /// </summary>
    /// <param name="message">提示信息,例子："不能为空!"</param>
    /// <param name="page">Page类</param>
    public static void Alert(string message, Page page) //显示对话框
    {
        page.Response.Write("<script  language='javascript' type='text/javascript'>function window.onload() {alert('" + message + "');}</script>");
    }
    //调用方法：SqlHelper.Alert("您已经被禁止登录,请关闭本页后稍后再登录！", Page);

    /// <summary>
    /// 警告窗口,服务器端弹出alert对话框,弹出对话框而不丢失背景
    /// </summary>
    /// <param name="message">提示信息,例子："不能为空!"</param>
    /// <param name="page">Page类</param>
    public static void MsgBox(string message, Page page) //显示对话框
    {
        String csname = "PopupScript";//定义客户端脚本的名
        Type cstype = page.GetType();//定义客户端脚本的类型
        ClientScriptManager cs = page.ClientScript;//创建一个ClientScriptManager类
        if (!cs.IsStartupScriptRegistered(cstype, csname))//如果脚本没有注册
        {
            String cstext = "alert('" + page.Server.HtmlEncode(message) + "');";
            cs.RegisterStartupScript(cstype, csname, cstext, true);
        }
    }

    //// <summary>
    /// 弹出提示并转向url
    /// </summary>
    /// <param name="message"></param>
    /// <param name="url"></param>
    /// Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "alert('注册成功！单击确定返回登陆页面');window.location='UserLogin.aspx'",true);
    public static void MsgBox(string message, string url, Page page)
    {
        ClientScriptManager cs = page.ClientScript;//创建一个ClientScriptManager类
        String csname = "PopupScript";//定义客户端脚本的名
        Type cstype = page.GetType();//定义客户端脚本的类型
        if (!cs.IsStartupScriptRegistered(cstype, csname))//如果脚本没有注册
        {
            String cstext = "alert('" + page.Server.HtmlEncode(message) + "');window.location='" + url + "';";
            cs.RegisterStartupScript(cstype, csname, cstext, true);
        }
    }
    /// <summary>
    /// 弹出提示并转向url,javascript
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    public void AlertBox(string message, string url)
    {
        System.Web.HttpContext.Current.Response.Write("<script>alert('" + message + "');location.href('" + url + "')</script>");
    }
    //调用方法SqlHelper.AlertBox("用户名或者密码错误","index.aspx");

    //// <summary>
    /// 关闭窗口
    /// </summary>
    public static void CClose(Page page)
    {
        //Get a ClientScriptManager reference from the Page class
        ClientScriptManager cs = page.ClientScript;
        //Define the name and Type of the client script on the page
        String csname = "close";
        Type cstype = page.GetType();
        // builder the script text
        StringBuilder cstext = new StringBuilder();
        cstext.Append("<script language='javascript'>");
        cstext.Append("{window.opener='anyone';window.close();}");
        cstext.Append("</script>");
        //Check to see if the startup script is already registered
        if (!cs.IsClientScriptBlockRegistered(cstype, csname))
        {
            cs.RegisterStartupScript(cstype, csname, cstext.ToString());
        }
    }


    /// <summary>
    /// 登陆检验 or 管理页面检验
    /// </summary>
    //public static void CheckCookies(int check_grade)
    //{
    //    if (System.Web.HttpContext.Current.Request.Cookies["UserInfo"] == null)
    //    {
    //        System.Web.HttpContext.Current.Response.Redirect("admin_login.aspx");

    //    }
    //    else
    //    {
    //        HttpCookie Mycookie = System.Web.HttpContext.Current.Request.Cookies["UserInfo"];

    //        grade = ChangeToInt(Mycookie.Values["grade"].ToString());

    //        if (grade < check_grade)
    //        {
    //            System.Web.HttpContext.Current.Response.Write("<script>alert('你的权限不够');location.href('admin_main.htm')</script>");
    //        }
    //    }
    //    System.Web.HttpContext.Current.Response.Write("<div align='center'><a style='font-size:15px;color:#FFFFFF;font-weight:bold;'>新闻后台管理区</a></div>");
    //}

    //private int GetID(string name, string fieldName, string sqlStr)
    //{
    //    //根据表中name，找到对应行的ID
    //    int id = 0;//保存从表中得到的ID
    //    SqlDataReader reader = SqlHelper.GetDataReader(sqlStr);
    //    if (reader.HasRows)
    //    {
    //        while (reader.Read())
    //        {
    //            id = (int)reader[fieldName];//找到该记录,得到用户ID
    //        }
    //    }
    //    reader.Close();

    //    return id;//返回ID
    //}
}