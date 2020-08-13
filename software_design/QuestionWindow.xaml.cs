///<summary>

///模块编号：<QuestionWindouw>

///作用：<问题与提问界面>

///作者:肖鑫,朱立新,田彬洋

///编写日期<2019-01-07>

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
using System.Windows.Threading;

namespace software_design
{
    /// <summary>
    /// QuestionWindow.xaml 的交互逻辑
    /// </summary>

    /// ///<summary>

    ///定义结构体，方便对StuQuestion进行赋值

    ///</summary>
    public struct StuQuestion
    {
        public string Status { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public DateTime Time { get; set; }


    }
    public partial class QuestionWindow : Window
    {
        //设置一个定时器timer
        DispatcherTimer timer = new DispatcherTimer();
        List<StuQuestion> infoList = new List<StuQuestion>();
        public QuestionWindow()
        {

            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //建立定时器，时间间隔为1s，并启动定时器
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();

            //UserName为提问学生的账户名
            string n = MainWindow.UserCode;
            string UserNameStu = n.ToString();
            StuQuestion Stu = new StuQuestion();
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
            //从表中查询问题相关信息并显示
            SqlCommand cmd = new SqlCommand("select 问题,答案,状态,时间 from wtb where 学号 = '" + UserNameStu + "'", myConnection);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Stu.Status = sdr[2].ToString();
                Stu.Question = sdr[0].ToString();
                Stu.Answer = sdr[1].ToString();
                Stu.Time = DateTime.Parse(sdr[3].ToString().Trim());
                infoList.Add(Stu);
            }
            //比较时间大小，将问题排序
            infoList.Sort(delegate (StuQuestion x, StuQuestion y)
            {
                return y.Time.CompareTo(x.Time);
            });

            DG1.AutoGenerateColumns = false;
            DG1.ItemsSource = infoList;


        }
        /// <summary>
        /// 点击提交问题
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string n = MainWindow.UserCode;
            string UserNameStu = n.ToString();
            String Quest = QuestionBox.Text;
            string QueStatue = "未解决";
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
            string myQuery = "select 班级,姓名 from xsb where 学号 = '" + UserNameStu + "'";
            SqlCommand cmd2 = new SqlCommand(myQuery, myConnection);
            SqlDataReader sdr2 = cmd2.ExecuteReader();
            sdr2.Read();
            string MyClass = sdr2[0].ToString();
            string MyNam = sdr2[1].ToString();            
            sdr2.Close();
            DateTime now = DateTime.Now;
            string myInsert = "insert into wtb(学号,问题,状态,班级,姓名,时间) values ('" + UserNameStu + "','" + Quest + "','" + QueStatue + "','" + MyClass + "','" + MyNam + "','" + now.ToString() + "')";
            SqlCommand cmd = new SqlCommand(myInsert, myConnection);
            cmd.ExecuteNonQuery();
            myConnection.Close();
            myConnection.Dispose();
            MessageBox.Show("问题提交成功");
        }

        /// <summary>
        /// 定时刷新
        /// </summary>
        void timer_Tick(object sender, EventArgs e)
        {
            Button_Click_1(null, null);
        }

        /// <summary>
        /// 手动刷新
        /// </summary>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DG1.ItemsSource = null;
            string n = MainWindow.UserCode;
            string UserNameStu = n.ToString();
            StuQuestion Stu = new StuQuestion();
            SqlConnection myConnection;
            string connStr = "Server = '" + IPAddress.ip + "'; database =测试数据库; uid =sa; pwd=1738010002";
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
            SqlCommand cmd = new SqlCommand("select 问题,答案,状态,时间 from wtb where 学号 = '" + UserNameStu + "'", myConnection);
            SqlDataReader sdr = cmd.ExecuteReader();
            infoList.Clear();
            while (sdr.Read())
            {
                Stu.Status = sdr[2].ToString();
                Stu.Question = sdr[0].ToString();
                Stu.Answer = sdr[1].ToString();
                Stu.Time = DateTime.Parse(sdr[3].ToString().Trim());
                infoList.Add(Stu);
            }
            infoList.Sort(delegate (StuQuestion x, StuQuestion y)
            {
                return y.Time.CompareTo(x.Time);
            });
            DG1.AutoGenerateColumns = false;
            DG1.ItemsSource = null;
            DG1.ItemsSource = infoList;

        }
    }

}
