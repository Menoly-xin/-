///<summary>

///模块编号：<AdminFunction>

///作用：<管理员功能界面,显示管理员各功能入口,以及发布公告的界面>

///作者:肖鑫、田彬洋

///编写日期<2019-12-20>

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
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace software_design
{
    /// <summary>
    /// AdminFunction.xaml 的交互逻辑
    /// </summary>
    public partial class AdminFunction : Window
    {
        /// <summary>
        /// 初始化  
        /// </summary>
        public AdminFunction()//初始化
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        /// <summary>
        /// 点击弹出学生管理窗口
        /// </summary>
        private void StuManageButton_Click(object sender, RoutedEventArgs e)
        {
            AdminStu window = new AdminStu();//点击弹出学生管理窗口          
            window.Show();
        }
        /// <summary>
        /// 点击弹出教师管理窗口
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdminTea window = new AdminTea();//点击弹出教师管理窗口          
            window.Show();
        }
        /// <summary>
        /// 点击弹出答疑统计窗口
        /// </summary>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AdminQueAns window = new AdminQueAns();//点击弹出答疑统计窗口         
            window.Show();
        }
        /// <summary>
        /// 点击弹出群发消息窗口
        /// </summary>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AdminMessage window = new AdminMessage();//点击弹出群发消息窗口          
            window.Show();
        }
        /// <summary>
        /// 实现对公告板内容的读取及上传到数据库
        /// </summary>
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (BulletinBox.Text.Trim().Length == 0)
            {
                MessageBox.Show("输入不能为空");
            }
            else
            {
                #region 数据库连接
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
                #endregion
                //MessageTemp存储公告板的内容
                string MessageTemp = BulletinBox.Text;
                //Time为现在的系统时间
                DateTime Time = DateTime.Now;
                //将公告板的内容写入数据库
                SqlCommand cmd2 = new SqlCommand("insert into ggb(内容,时间) values ('" + MessageTemp + "','" + Time.ToString() + "')", myConnection);
                cmd2.ExecuteNonQuery();
                MessageBox.Show("发送成功");
                myConnection.Close();
                //关闭数据库连接
                myConnection.Dispose();
            }
        }
        /// <summary>
        /// 点击注销并弹出主界面
        /// </summary>
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MainWindow windowtea = new MainWindow();
            Window window = Window.GetWindow(this);//关闭父窗体
            window.Close();        
            windowtea.Show();
        }

        private void FileAdmin_Click(object sender, RoutedEventArgs e)
        {
            FileAdmin window = new FileAdmin();
            window.Show();
        }
    }
}
