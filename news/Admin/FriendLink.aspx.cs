using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;//添加引用
using System.Data.SqlClient;//添加引用
using System.IO;//添加引用FileInfo 
public partial class Admin_FriendLink : System.Web.UI.Page
{
    static string selectStr = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            selectStr = "select FriendLinkID, FriendLinkName, FriendLinkUrl, LogoPath, FriendLinkSort, IsShow from FriendLink ORDER BY FriendLinkSort";//显示全部记录
            ShowFriendLink(selectStr);
        }
    }
    private void ShowFriendLink(string seleStr)
    {
        DataSet ds = SqlHelper.GetDataSet(seleStr);
        gridFriendLink.DataSource = ds;
        gridFriendLink.DataKeyNames = new string[] { "FriendLinkID" };//GridView控件的主键名
        gridFriendLink.AllowPaging = true;//启用分页
        gridFriendLink.AutoGenerateColumns = false;//不自己绑定字段
        gridFriendLink.PageSize = 5;//每页显示的记录数
        gridFriendLink.DataBind();//DataBind()必须写在最后
    }
    protected void gridFriendLink_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridFriendLink.PageIndex = e.NewPageIndex;
        ShowFriendLink(selectStr);//显示给定条件的记录
    }
    protected void gridFriendLink_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string sqlStr = "select LogoPath from FriendLink where FriendLinkID = " + (int)gridFriendLink.DataKeys[e.RowIndex].Value;
        DeleteLogo(sqlStr);//删除服务器上的图片

        string sqlStr1 = "Delete from FriendLink where FriendLinkID = " + (int)gridFriendLink.DataKeys[e.RowIndex].Value;
        DeleteFriendLink(sqlStr1);//删除链接表中的记录

        ShowFriendLink(selectStr);//重新显示删除后的记录
    }
    private void DeleteLogo(string sqlStr)
    {
        //删除服务器上的图片
        //在表记录中根据FriendLinkID，找到要删除的图片的路径和名称
        SqlDataReader reader = SqlHelper.GetExecuteReader(sqlStr);
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                string logoPath = reader["LogoPath"].ToString();
                FileInfo file = new FileInfo(Server.MapPath("~") + logoPath.Substring(1));//logoPath.Substring(1)截掉表中路径的"~"符号
                file.Delete();//执行删除
            }
        }
        reader.Close();//关闭阅读器
        SqlHelper.CloseConnection();//关闭连接    
    }
    private void DeleteFriendLink(string sqlStr)
    {
        //删除链接表中的记录
        SqlHelper.GetExecuteNonQuery(sqlStr);
    }
}
