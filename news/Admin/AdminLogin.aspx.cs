using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;//添加引用SQL Server;
using System.Web.Security;//添加引用MD5
using System.Data;//添加引用SqlDbType

public partial class Admin_AdminLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtAdminName.Focus();//焦点设置到账户文本框
        btnReset.CausesValidation = false;//单击"重置"按钮不激发验证  

    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        //“登录”按钮的单击事件
        //单击“登录”按钮后，先判断验证码正确后，再判断其他
        if (Session["CheckCode"].ToString().ToLower().Equals(txtValidateCode.Text.ToString().ToLower()))
        {
            string adminName = txtAdminName.Text.Trim(); //获取用户名
            string adminPassword = txtAdminPassword.Text.Trim();//获取密码
            if (ExistAdmin(adminName, adminPassword) > 0)//判断管理员名和密码是否正确
            {
                Session["AdminID"] = GetAdminID(adminName, adminPassword);//得到管理员ID，保存管理员ID
                Session["AdminName"] = adminName; //保存管理员名
                int adminGradeID = GetAdminGradeID(adminName, adminPassword);//得到管理员权限ID
                Session["AdminGradeID"] = adminGradeID; //保存管理员权限ID
                Session["AdminGradeName"] = GetAdminGradeName(adminGradeID);//由权限ID得到对应的权限名

                Response.Redirect("HomeAdmin.aspx");//重定向到后台主程序
            }
            else
            {
                SqlHelper.MsgBox("密码或管理员名错误！", Page);//调用自定义类中的方法
            }
        }
        else
        {
            SqlHelper.MsgBox("验证码错误！", Page);//调用自定义类中的方法
        }
    }

    private int ExistAdmin(string adminName, string adminPassword)
    {
        //判断管理员名和密码是否正确
        //设置参数，并把控件中的值赋给相应参数
        string sqlStr = "select count(*) from Admin where AdminName =@AdminName and AdminPassword=@AdminPassword";
        SqlParameter[] paras = new SqlParameter[]
        {
            new SqlParameter("@AdminName", SqlDbType.VarChar, 50),
            new SqlParameter("@AdminPassword", SqlDbType.VarChar, 50)
        };
        paras[0].Value = adminName; //获取管理员名
        //paras[1].Value = adminPassword;//获取密码，如果不采用MD5，则去掉本行注释，给下行加上注释
        paras[1].Value = FormsAuthentication.HashPasswordForStoringInConfigFile(adminPassword, "MD5");//去掉注释则实现MD5，给上面一行加上注释
        int i =Convert.ToInt32(SqlHelper.GetExecuteScalar(sqlStr, paras));//把object类型转换为int
        return i;
    }

    protected int GetAdminID(string adminName, string adminPassword)
    {
        //得到管理员ID
        //在Admin表中查找输入的管理员名和密码的记录
        string sqlStr = "select AdminID from Admin where AdminName =@AdminName and AdminPassword=@AdminPassword";
        SqlParameter[] paras = new SqlParameter[]
        {
            new SqlParameter("@AdminName", SqlDbType.VarChar, 50),
            new SqlParameter("@AdminPassword", SqlDbType.VarChar, 50)
        };
        paras[0].Value = adminName; //获取管理员名
        //paras[1].Value = adminPassword;//获取密码，如果不采用MD5，则去掉本行注释，给下行加上注释
        paras[1].Value = FormsAuthentication.HashPasswordForStoringInConfigFile(adminPassword, "MD5");//去掉注释则实现MD5，给上面一行加上注释

        int adminID = 0;//保存从Admin表中得到的管理员ID

        SqlDataReader reader = SqlHelper.GetDataReader(sqlStr, paras);//调用自定义类中的方法
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                //当管理员名和密码正确时，找到该记录
                adminID = (int)reader["AdminID"];//从表中得到管理员ID
            }
        }
        reader.Close();

        return adminID;//返回管理员ID
    }
    private int GetAdminGradeID(string adminName, string adminPassword)
    {
        //得到权限ID
        int adminGradeID = 0;//权限ID
        string sqlStr = "select AdminGradeID from Admin where AdminName =@AdminName and AdminPassword=@AdminPassword";
        SqlParameter[] paras = new SqlParameter[]
        {
            new SqlParameter("@AdminName", SqlDbType.VarChar, 50),
            new SqlParameter("@AdminPassword", SqlDbType.VarChar, 50)
        };
        paras[0].Value = adminName; //获取管理员名
        //paras[1].Value = adminPassword;//获取密码，如果不采用MD5，则去掉本行注释，给下行加上注释
        paras[1].Value = FormsAuthentication.HashPasswordForStoringInConfigFile(adminPassword, "MD5");//去掉注释则实现MD5，给上面一行加上注释
        SqlDataReader reader = SqlHelper.GetDataReader(sqlStr, paras);//调用自定义类中的方法
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                adminGradeID = (int)reader["AdminGradeID"];
            }
        }
        reader.Close();
        return adminGradeID;//返回权限ID
    }
    private string GetAdminGradeName(int adminGradeID)
    {
        //到权限表中，由权限ID找出对应的权限名
        string adminGradeName = "";//权限名
        string sqlStr = "select AdminGradeID, AdminGradeName from AdminGrade where AdminGradeID=" + adminGradeID;
        SqlDataReader reader = SqlHelper.GetExecuteReader(sqlStr);//调用自定义类中的方法
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                adminGradeName = reader["AdminGradeName"].ToString();//获取权限名
            }
        }
        reader.Close();
        return adminGradeName;//返回权限名
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        //“重置”按钮的单击事件
        txtAdminName.Text = null;//账户框
        txtAdminPassword.Text = null;//密码框
        txtValidateCode.Text = null;//验证码框
        txtAdminName.Focus();//焦点设置到账户文本框
    }
}