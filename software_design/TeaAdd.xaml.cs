///<summary>

///模块编号：<TeaAdd>

///作用：<管理员教师注册界面>

///作者:肖鑫,田彬洋

///编写日期<2019-01-07>

///</summary>
using System;
using System.Windows;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace software_design
{
    /// <summary>
    /// TeaAdd.xaml 的交互逻辑
    /// </summary>
    public partial class TeaAdd : Window
    {
        public TeaAdd()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        /// <summary>
        /// 管理员教师注册界面
        /// </summary>
        private void UploadClick(object sender, RoutedEventArgs e)
        {
            //UserName等为教师的用户名等
            string UserName = UserContent.Text.Trim();
            string Passwd = PasswordContent.Password.Trim();
            string ConfirmPas = ConfirmContent.Password.Trim();
            string Email = EmailContent.Text.Trim();          
            //查询是否为空
            if (String.IsNullOrEmpty(UserName) || String.IsNullOrEmpty(Passwd) ||
               String.IsNullOrEmpty(ConfirmPas))
            {
                MessageBox.Show("用户名或密码不能为空！");
                return;
            }


            //查询是否为空
            Regex regex = new Regex(@"\bM\S*");
            if ((regex.IsMatch(UserName)) == false)
            {
                MessageBox.Show("用户名不符合规范！");
                return;
            }

            if ((UserName.Length) != 10)
            {
                MessageBox.Show("用户名长度不符合规范！");
                return;
            }
            Regex RegEmail = new Regex(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");//w 英文字母或数字的字符串，和 [a-zA-Z0-9] 语法一样 
            Match m = RegEmail.Match(Email);
            if (m.Success)
            {

            }
            else
            {
                MessageBox.Show("邮箱格式不正确");
                return;
            }
            //数据库连接
            SqlConnection myConnection;
            string connStr = "Server ='" + IPAddress.ip + "'; database =测试数据库; uid =sa; pwd=1738010002";
            //string connStr = @"Server =   LAPTOP-25MJ4H0M\SQLEXPRESS; database =教学系统; Trusted_Connection=SSPI";
            myConnection = new SqlConnection(connStr);
            try
            {
                myConnection.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("连接失败");
            }
            //查询用户名是否已经存在
            SqlCommand cmd = new SqlCommand("select * from jsb where 职工号 = '" + UserName + "'", myConnection);
            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            //如果存在则报错
            if (sdr.HasRows)
            {
                MessageBox.Show("该用户已注册，请直接登录", "提示");
                myConnection.Close();
                myConnection.Dispose();
                return;
            }
            //否则进行注册
            else
            {
                if (Passwd.Equals(ConfirmPas))
                {
                    try
                    {
                        sdr.Close();
                        string myInsert = "insert into jsb(职工号,密码,邮箱) values ('" + UserName + "','" + Passwd + "','" + Email + "')";
                        SqlCommand myCom = new SqlCommand(myInsert, myConnection);
                        myCom.ExecuteNonQuery();
                        myConnection.Close();
                        myConnection.Dispose();
                        MessageBox.Show("您已注册成功！");
                    }
                    catch 
                    {
                        MessageBox.Show("输入过长,注册失败");
                        myConnection.Close();
                        myConnection.Dispose();
                        return;
                    }
                }
                else 
                {
                    MessageBox.Show("密码不一致");
                    myConnection.Close();
                    myConnection.Dispose();
                    return;
                }
            }
            Window window = Window.GetWindow(this);//关闭父窗体
            window.Close();
        }
    }
}
