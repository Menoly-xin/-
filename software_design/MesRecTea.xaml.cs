///<summary>

///模块编号：<MesRecTea>

///作用：<教师的消息接收界面>

///作者:肖鑫,田彬洋

///编写日期<2019-01-07>

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
using System.Windows.Threading;

namespace software_design
{
    /// <summary>
    /// InfSendStu.xaml 的交互逻辑
    /// </summary>

    public partial class MesRecTea : Window
    {
        //设置一个定时器timer
        DispatcherTimer timer = new DispatcherTimer();
        List<Information> infoList1 = new List<Information>();
        public MesRecTea()
        {
            //UserNameStu为教师的账户
            InitializeComponent();

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //建立定时器，时间间隔为1s，并启动定时器
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();

            string n = MainWindow.UserCode;
            string UserNameStu = n.ToString();
            Information Stu = new Information();
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

            string myUpdate = "update xxb set 状态 =  '" + 1 + "' where 接收方 = '" + UserNameStu + "'";
            SqlCommand myCom = new SqlCommand(myUpdate, myConnection);
            myCom.ExecuteNonQuery();

            //从数据库中查询发送给该教师的消息
            SqlCommand cmd = new SqlCommand("select 发送方,消息内容,时间 from xxb where 接收方 = '" + UserNameStu + "'", myConnection);
            SqlDataReader sdr = cmd.ExecuteReader();
            //循环读取消息
            while (sdr.Read())
            {
                try
                {
                    Stu.Sender = sdr[0].ToString();
                    Stu.Info = sdr[1].ToString();
                    //MessageBox.Show(sdr[2].ToString().Trim());
                    Stu.Time = DateTime.Parse(sdr[2].ToString().Trim());
                    infoList1.Add(Stu);
                }
                catch
                { }
            }
            //将消息按时间排序
            infoList1.Sort(delegate (Information x, Information y)
            {
                return y.Time.CompareTo(x.Time);
            });
            //显示消息
            DG2.AutoGenerateColumns = false;
            DG2.ItemsSource = infoList1;
        }
        //定时刷新
        void timer_Tick(object sender, EventArgs e)
        {
            Button_Click(null, null);
        }


        /// <summary>
        /// 点击刷新消息列表,具体实现同初始化
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string n = MainWindow.UserCode;
            string UserNameStu = n.ToString();
            Information Stu = new Information();
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
            SqlCommand cmd = new SqlCommand("select 发送方,消息内容,时间 from xxb where 接收方 = '" + UserNameStu + "'", myConnection);
            SqlDataReader sdr = cmd.ExecuteReader();
            infoList1.Clear();
            while (sdr.Read())
            {
                Stu.Sender = sdr[0].ToString();
                Stu.Info = sdr[1].ToString();
                Stu.Time = DateTime.Parse(sdr[2].ToString());
                infoList1.Add(Stu);
            }
            infoList1.Sort(delegate (Information x, Information y)
            {
                return y.Time.CompareTo(x.Time);
            });
            DG2.AutoGenerateColumns = false;
            DG2.ItemsSource = null;
            DG2.ItemsSource = infoList1;

        }
    }
}
