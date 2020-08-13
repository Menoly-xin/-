///<summary>

///模块编号：<InfSendStu>

///作用：<学生查看消息，此界面呈现学生接收到的消息并且可以看到发送方是谁(教师&管理员)>

///作者：朱立新、肖鑫,田彬洋

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
    /// 
    /// 
    /// ///<summary>

    ///定义结构体，方便对DataGrid进行赋值

    ///</summary>
    public struct Information
    {
        public string Sender { get; set; }
        public string Info { get; set; }
        public DateTime Time { get; set; }
    }
    public partial class InfSendStu : Window
    {
        //设置一个定时器timer
        DispatcherTimer timer = new DispatcherTimer();
        //定义返回值为Information类型的泛型，方便对DataGrid进行赋值
        List<Information> infoList1 = new List<Information>();

        /// <summary>
        /// 初始化学生消息界面
        /// </summary>
        public InfSendStu()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //建立定时器，时间间隔为1s，并启动定时器
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();

            string n = MainWindow.UserCode;
            //UserNameStu为登录用户名
            string UserNameStu = n.ToString();
            //Time为现在的时间
            DateTime Time = DateTime.Now;
            DateTime SetTime = new DateTime();
            TimeSpan dt;
            //定义Information类型的结构体Stu
            Information Stu = new Information();

            #region 连接数据库
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

            //根据UserNameStu（登录用户名）选择出对应的个人信息
            SqlCommand cmd = new SqlCommand("select 发送方,消息内容,时间 from xxb where 接收方 = '" + UserNameStu + "'", myConnection);
            SqlDataReader sdr = cmd.ExecuteReader();
            //读取信息并对Stu结构体赋值
            while (sdr.Read())
            {
                SetTime = DateTime.Parse(sdr[2].ToString());
                if (sdr[0].ToString().Trim().Equals("定时提醒")==true)
                {
                    try
                    {
                        dt = Time - SetTime;
                        if (dt.Minutes >=01)
                        {
                            Stu.Sender = sdr[0].ToString();  //将发送人姓名赋值
                            Stu.Info = sdr[1].ToString();    //将信息内容赋值
                            Stu.Time = DateTime.Parse(sdr[2].ToString().Trim());
                            infoList1.Add(Stu);              //将Stu的内容返回给infoList1                     
                        }
                    }
                    catch
                    { }
                }
                else
                {
                    Stu.Sender = sdr[0].ToString();  //将发送人姓名赋值
                    Stu.Info = sdr[1].ToString();    //将信息内容赋值
                    Stu.Time = DateTime.Parse(sdr[2].ToString().Trim());
                    infoList1.Add(Stu);              //将Stu的内容返回给infoList1
                }

            }
            infoList1.Sort(delegate (Information x, Information y)
            {
                return y.Time.CompareTo(x.Time);
            });
            DG2.AutoGenerateColumns = false;
            DG2.ItemsSource = infoList1;       //对DataGrid的文本框赋值
        }
        //定时刷新
        void timer_Tick(object sender, EventArgs e)
        {
            Button_Click(null, null);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string n = MainWindow.UserCode;
            //UserNameStu为登录用户名
            string UserNameStu = n.ToString();
            //定义Information类型的结构体Stu
            DateTime Time = DateTime.Now;
            DateTime SetTime = new DateTime();
            TimeSpan dt;
            #region 连接数据库
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
            #endregion

            //根据UserNameStu（登录用户名）选择出对应的个人信息
            SqlCommand cmd = new SqlCommand("select 发送方,消息内容,时间 from xxb where 接收方 = '" + UserNameStu + "'", myConnection);
            SqlDataReader sdr = cmd.ExecuteReader();
            //清空infoList1的内容
            infoList1.Clear();        
            //读取信息并对Stu结构体赋值
            while (sdr.Read())
            {
                SetTime = DateTime.Parse(sdr[2].ToString());
                if (sdr[0].ToString().Trim().Equals("定时提醒"))
                {
                    try
                    {
                        dt = Time - SetTime;
                        if (dt.Minutes >= 0)
                        {
                            Stu.Sender = sdr[0].ToString();  //将发送人姓名赋值
                            Stu.Info = sdr[1].ToString();    //将信息内容赋值
                            Stu.Time = DateTime.Parse(sdr[2].ToString().Trim());
                            infoList1.Add(Stu);              //将Stu的内容返回给infoList1                     
                        }
                    }
                    catch
                    { }
                }
                else
                {
                    Stu.Sender = sdr[0].ToString();  //将发送人姓名赋值
                    Stu.Info = sdr[1].ToString();    //将信息内容赋值
                    Stu.Time = DateTime.Parse(sdr[2].ToString().Trim());
                    infoList1.Add(Stu);              //将Stu的内容返回给infoList1
                }
                
            }
            sdr.Close();

            infoList1.Sort(delegate (Information x, Information y)
            {
                return y.Time.CompareTo(x.Time);
            });
            DG2.AutoGenerateColumns = false;
            DG2.ItemsSource = null;             //将DataGrid清空
            DG2.ItemsSource = infoList1;        //对DataGrid的文本框赋值 

        }
    }
}