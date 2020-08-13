///<summary>

///模块编号：<MainWindow>

///作用：<主界面,提供登陆、注册、忘记密码选项>

///作者:肖鑫,朱立新

///编写日期<2019-11-20>

///</summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
namespace software_design
{
    /// <summary>
    /// ip 结构体,由于ip变换频繁,故直接定义结构体方便更改
    /// </summary>
    static class IPAddress
    {
        //public static string ip= "10.15.58.142,1433";
        //public static string ip = "222.20.25.202,1433";
        public static string ip = " 10.15.56.78,1433";
    }

    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string UserCode;      
        public MainWindow()
        {
            InitializeComponent();          
            WindowStartupLocation = WindowStartupLocation.CenterScreen;           


        }
        /// <summary>
        /// 点击弹出用户注册界面
        /// </summary>
        private void UserRegister(object sender, RoutedEventArgs e)
        {
            //弹出注册界面
            RegisterPanel window = new RegisterPanel();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.Show();
        }
        /// <summary>
        /// 点击弹出忘记密码界面
        /// </summary>
        private void fogetpas_Click(object sender, RoutedEventArgs e)
        {
            ForgetPaswd window = new ForgetPaswd();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.Show();

        }

        /// <summary>
        /// 点击登陆
        /// </summary>
        private void Login1_Click(object sender, RoutedEventArgs e)
        {
            //UserCode为输入的账户
            UserCode = UserText.Text.Trim();
            //PassCode为输入的密码
            string PassCode = PasText.Password.Trim();
            //如果选中学生登陆选项
            if (sturadio.IsChecked == true)
            {
                //判断用户名和密码是否为空
                if (String.IsNullOrEmpty(UserCode) || String.IsNullOrEmpty(PassCode))
                {
                    MessageBox.Show("用户名或密码不能为空！");
                }
                else
                {
                    #region 数据库连接
                    SqlConnection myConnection;
                    string connStr = "Server =  '" + IPAddress.ip + "'; database =测试数据库; uid =sa; pwd=1738010002";
                    //string connStr = @"Server =   LAPTOP-25MJ4H0M\SQLEXPRESS; database =教学系统; Trusted_Connection=SSPI";
                    //string connStr = "Server =   10.15.60.156,1433; database =教学系统; uid =softwaredesign; pwd=123456";
                    myConnection = new SqlConnection(connStr);
                    try
                    {
                        myConnection.Open();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("连接失败");
                    }
                    #endregion
                    //查询用户名和密码是否存在和匹配
                    SqlCommand cmd = new SqlCommand("select * from xsb where 学号='" + UserCode + "' and 密码='" + PassCode + "'", myConnection);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    sdr.Read();
                    //如果用户名和密码匹配,则弹出对应的功能界面
                    if (sdr.HasRows)
                    {
                        //MessageBox.Show("登录成功", "提示");
                        FunctionStudent windowstu = new FunctionStudent();
                        Window window = Window.GetWindow(this);//关闭父窗体
                        window.Close();
                        WindowStartupLocation = WindowStartupLocation.CenterScreen;
                        windowstu.Show();
                        myConnection.Close();
                    }
                    //如果不匹配则显示错误
                    else
                    {
                        MessageBox.Show("用户名或者密码错误！", "警告");
                        myConnection.Close();
                    }
                }
            }
            //如果选中的是教师登陆选项
            else if (tearadio.IsChecked == true)
            {
                //判断密码和用户名是否为空
                if (String.IsNullOrEmpty(UserCode) || String.IsNullOrEmpty(PassCode))
                {
                    MessageBox.Show("用户名或密码不能为空！");
                }
                #region 数据库连接
                SqlConnection myConnection;
                string connStr = "Server ='" + IPAddress.ip + "'; database =测试数据库; uid =sa; pwd=1738010002";
                myConnection = new SqlConnection(connStr);
                try
                {
                    myConnection.Open();
                }
                catch (Exception)
                {
                    MessageBox.Show("连接失败");
                }
                #endregion
                SqlCommand cmd = new SqlCommand("select * from jsb where 职工号='" + UserCode + "' and 密码='" + PassCode + "'", myConnection);
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                //如果用户名和密码匹配,则弹出对应的功能界面
                if (sdr.HasRows)
                {
                    //MessageBox.Show("登录成功", "提示");
                    FunctionTeacher windowteach = new FunctionTeacher();
                    Window window = Window.GetWindow(this);//关闭父窗体
                    window.Close();                   
                    windowteach.Show();
                    myConnection.Close();
                    
                }
                else
                {
                    MessageBox.Show("用户名或者密码错误！", "警告");
                    myConnection.Close();
                }
            }
            //如果选中管理员登陆选项
            else
            {
                if (String.IsNullOrEmpty(UserCode) || String.IsNullOrEmpty(PassCode))
                {
                    MessageBox.Show("用户名或密码不能为空！");
                }
                SqlConnection myConnection;
                string connStr = "Server ='" + IPAddress.ip + "'; database =测试数据库; uid =sa; pwd=1738010002";
                myConnection = new SqlConnection(connStr);
                try
                {
                    myConnection.Open();
                }
                catch (Exception)
                {
                    MessageBox.Show("连接失败");
                }
                SqlCommand cmd = new SqlCommand("select * from admin where 管理员编号='" + UserCode + "' and 密码='" + PassCode + "'", myConnection);
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                //如果用户名和密码匹配,则弹出对应的功能界面
                if (sdr.HasRows)
                {
                    MessageBox.Show("登录成功", "提示");
                    AdminFunction windowteach = new AdminFunction();
                    Window window = Window.GetWindow(this);//关闭父窗体
                    window.Close();                  
                    windowteach.Show();
                    myConnection.Close();

                }
                else
                {
                    MessageBox.Show("用户名或者密码错误！", "警告");
                    myConnection.Close();
                }
            }
        }
        /// <summary>
        /// 点击取消登陆
        /// </summary>
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);//关闭父窗体
            window.Close();
        }
    }
}
