///<summary>

///模块编号：<FunctionStudent>

///作用：<学生功能界面,显示各功能入口,以及基本信息>

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
    //Bulletinboard为公告结构体
    public struct Bulletinboard
    {
        public string Content { get; set; }
        public DateTime Time { get; set; }
    }
    /// <summary>
    /// FunctionStudent.xaml 的交互逻辑
    /// </summary>
    /// 
    public partial class FunctionStudent : Window
    {
        //设置一个定时器timer
        DispatcherTimer timer = new DispatcherTimer();
        //infoList为公告列表
        List<Bulletinboard> infoList = new List<Bulletinboard>();
        public int Counter_1 = 0;
        public int Counter_2 = 0;
        public int TimeCounter_1 = 0;
        public int TimeCounter_2 = 0;
        public FunctionStudent()
        {
            Counter_1 = 0;
            //Stu为单个文件的集合
            Bulletinboard Stu = new Bulletinboard();
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //建立定时器，时间间隔为1s，并启动定时器
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
            //UserNameStu为主界面传过来的用户名
            string n = MainWindow.UserCode;
            string UserNameStu = n.ToString();
            //绑定界面姓名栏的信息源为UserNameStu
            FunctionUserNameStu.Content = UserNameStu;
            #region 数据库连接
            SqlConnection myConnection;
            //string connStr = @"Server =   LAPTOP-25MJ4H0M\SQLEXPRESS; database =教学系统; Trusted_Connection=SSPI";
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
            //从学生表中查询学号为UserNameStu的信息
            SqlCommand cmd = new SqlCommand("select 姓名,班级,邮箱,性别 from xsb where 学号 = '" + UserNameStu + "'", myConnection);
            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            //MessageBox.Show(sdr[1].ToString());
            //绑定性别,班级等各栏的信息源
            if (sdr[0].ToString() == null)
            {
                FunctionNameStu.Content = "未设置";
            }
            else
            {
                FunctionNameStu.Content = sdr[0].ToString();
            }

            if (sdr[1].ToString() == null)
            {
                FunctionClassStu.Content = "未设置";
            }
            else
            {
                FunctionClassStu.Content = sdr[1].ToString();
            }
            if (sdr[3].ToString() == null)
            {
                FunctionSexStu.Content = "未设置";
            }
            else
            {
                FunctionSexStu.Content = sdr[3].ToString();
            }
            FunctionEmaliStu.Content = sdr[2].ToString();
            sdr.Close();
            //查询公告
            SqlCommand cmd2 = new SqlCommand("select 内容,时间 from ggb ", myConnection);
            SqlDataReader sdr2 = cmd2.ExecuteReader();
            //循环读取公告并将其加入公告列表
            while (sdr2.Read())
            {


                Stu.Content = sdr2[0].ToString();
                Stu.Time = DateTime.Parse(sdr2[1].ToString().Trim());
                infoList.Add(Stu);



            };
            sdr2.Close();
            //对公告表按时间排序
            infoList.Sort(delegate (Bulletinboard x, Bulletinboard y)
            {
                return y.Time.CompareTo(x.Time);
            });
            try
            {
                Bulletin.Content = infoList[0].Content;
            }
            catch { }
            //查询新消息总数
            //根据UserNameStu（登录用户名）选择出对应的个人信息
            DateTime Time = DateTime.Now;
            DateTime SetTime = new DateTime();
            TimeSpan dt;
            SqlCommand cmd3 = new SqlCommand("select 发送方,时间,状态 from xxb where 接收方 = '" + UserNameStu + "' ", myConnection);
            SqlDataReader sdr3 = cmd3.ExecuteReader();
            //读取信息并对Stu结构体赋值            
            while (sdr3.Read())
            {
                SetTime = DateTime.Parse(sdr3[1].ToString());
                if (sdr3[0].ToString().Trim().Equals("定时提醒") == true)
                {
                    try
                    {
                        dt = Time - SetTime;
                        if (dt.Minutes >= 0)
                        {
                            TimeCounter_1++;
                        }
                    }
                    catch
                    { }
                }
                else if (sdr3[2].ToString().Trim().Equals("0"))
                {
                    Counter_1++;
                }

            }
            MessageAlert.Content = "未读消息数" + Counter_1.ToString();
            myConnection.Close();
        }

        //定时刷新
        void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                Bulletinboard Stu = new Bulletinboard();
                string n = MainWindow.UserCode;
                string UserNameStu = n.ToString();
                #region 数据库连接
                SqlConnection myConnection;
                //string connStr = @"Server =   LAPTOP-25MJ4H0M\SQLEXPRESS; database =教学系统; Trusted_Connection=SSPI";
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
                //查询公告
                SqlCommand cmd2 = new SqlCommand("select 内容,时间 from ggb ", myConnection);
                SqlDataReader sdr2 = cmd2.ExecuteReader();
                //循环读取公告并将其加入公告列表
                while (sdr2.Read())
                {
                    Stu.Content = sdr2[0].ToString();
                    Stu.Time = DateTime.Parse(sdr2[1].ToString().Trim());
                    infoList.Add(Stu);

                };
                //对公告表按时间排序
                infoList.Sort(delegate (Bulletinboard x, Bulletinboard y)
                {
                    return y.Time.CompareTo(x.Time);
                });
                sdr2.Close();
                Bulletin.Content = infoList[0].Content;

                RefreshStuInf_Click(null, null);
                DateTime Time = DateTime.Now;
                DateTime SetTime = new DateTime();
                TimeSpan dt;
                SqlCommand cmd3 = new SqlCommand("select 发送方,时间,状态 from xxb where 接收方 = '" + UserNameStu + "' ", myConnection);
                SqlDataReader sdr3 = cmd3.ExecuteReader();
                //读取信息并对Stu结构体赋值                    
                while (sdr3.Read())
                {
                    //SetTime为定时提醒设置的时间
                    SetTime = DateTime.Parse(sdr3[1].ToString());
                    //如果是定时提醒,则判断是否到达设定时间
                    if (sdr3[0].ToString().Trim().Equals("定时提醒") == true)
                    {
                        try
                        {
                            dt = Time - SetTime;
                            if (dt.Minutes >= 0)
                            {
                                TimeCounter_2++;
                            }
                        }
                        catch
                        { }
                    }
                    //否则如果是未读消息则Counter_2+1
                    else if (sdr3[2].ToString().Trim().Equals("0"))
                    {
                        Counter_2++;
                    }

                }
                //如果定时提醒的数量变化,则提醒定时消息到达
                if (TimeCounter_1 < TimeCounter_2)
                {
                    MessageBox.Show("您有定时提醒达到,请在消息中查看");
                }
                int Sub = Counter_2 - Counter_1;
                //如果新消息数目变化,则提醒新消息到达
                if (Sub > 0)
                {
                    MessageBox.Show("您有新消息，请注意查看");
                }
                MessageAlert.Content = "未读消息数" + Counter_1.ToString();
                Counter_1 = Counter_2;
                Counter_2 = 0;
                TimeCounter_1 = TimeCounter_2;
                TimeCounter_2 = 0;
                myConnection.Close();
            }
            catch { }
        }
        /// <summary>
        /// 点击弹出信息更改界面
        /// </summary>
        private void InfChangeStu_Click(object sender, RoutedEventArgs e)
        {
            InfChangeStu window = new InfChangeStu();
            window.Show();
        }
        /// <summary>
        /// 注销弹出主界面
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow windowstu = new MainWindow();
            Window window = Window.GetWindow(this);//关闭父窗体
            window.Close();
            windowstu.Show();

        }
        /// <summary>
        /// 进入提交问题界面
        /// </summary>
        private void QuestionStu_Click(object sender, RoutedEventArgs e)
        {
            //如果未完善信息则禁止使用除更改信息以外其它功能
            if (String.IsNullOrEmpty(FunctionNameStu.Content.ToString()) || String.IsNullOrEmpty(FunctionSexStu.Content.ToString()) ||
               String.IsNullOrEmpty(FunctionClassStu.Content.ToString()))
            {
                MessageBox.Show("请先完善信息,否则无法使用");
            }
            else
            {
                //如果信息完善则弹出问题界面
                QuestionWindow window2 = new QuestionWindow();
                window2.Show();
            }
        }
        /// <summary>
        /// 进入消息查看界面
        /// </summary>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //如果未完善信息则禁止使用除更改信息以外其它功能
            if (String.IsNullOrEmpty(FunctionNameStu.Content.ToString()) || String.IsNullOrEmpty(FunctionSexStu.Content.ToString()) ||
               String.IsNullOrEmpty(FunctionClassStu.Content.ToString()))
            {
                MessageBox.Show("请先完善信息,否则无法使用");
            }
            else
            {
                //如果信息完善则弹出问题界面
                InfSendStu window3 = new InfSendStu();
                window3.Show();
            }
        }
        /// <summary>
        /// 刷新个人信息
        /// </summary>
        private void RefreshStuInf_Click(object sender, RoutedEventArgs e)
        {
            //UserNameStu为用户名
            try
            {
                string n = MainWindow.UserCode;
                string UserNameStu = n.ToString();
                FunctionUserNameStu.Content = UserNameStu;
                #region 数据库连接
                SqlConnection myConnection;
                //string connStr = @"Server =   LAPTOP-25MJ4H0M\SQLEXPRESS; database =教学系统; Trusted_Connection=SSPI";
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
                //查询用户名为UserNameStu的信息
                SqlCommand cmd = new SqlCommand("select 姓名,班级,邮箱,性别 from xsb where 学号 = '" + UserNameStu + "'", myConnection);
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                //绑定性别等各栏的信息源
                if (sdr[0].ToString() == null)
                {
                    FunctionNameStu.Content = "未设置";
                }
                else
                {
                    FunctionNameStu.Content = sdr[0].ToString();
                }

                if (sdr[1].ToString() == null)
                {
                    FunctionClassStu.Content = "未设置";
                }
                else
                {
                    FunctionClassStu.Content = sdr[1].ToString();
                }
                if (sdr[3].ToString() == null)
                {
                    FunctionSexStu.Content = "未设置";
                }
                else
                {
                    FunctionSexStu.Content = sdr[3].ToString();
                }
                FunctionEmaliStu.Content = sdr[2].ToString();
                sdr.Close();
                myConnection.Close();
            }
            catch { }
        }
        /// <summary>
        /// 弹出文件窗口 
        /// </summary>
        private void FileStu_Click(object sender, RoutedEventArgs e)
        {
            FileStu window = new FileStu();
            window.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            stugonggao window10 = new stugonggao();
            window10.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            stugonggao window10 = new stugonggao();
            window10.Show();
        }
    }
}