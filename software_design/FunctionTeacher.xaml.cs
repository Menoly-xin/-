///<summary>

///模块编号：<FunctionTeacher>

///作用：<教师功能界面,显示教师各功能入口,以及公告的界面>

///作者:肖鑫,朱立新

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
    /// FunctionTeacher.xaml 的交互逻辑
    /// </summary>
    public partial class FunctionTeacher : Window
    {
        //设置一个定时器timer
        DispatcherTimer timer = new DispatcherTimer();
        //infoList为公告列表
        List<Bulletinboard> infoList = new List<Bulletinboard>();
        public int Counter_1 = 0;
        public int Counter_2 = 0;
        public FunctionTeacher()
        {
            Counter_1 = 0;
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //建立定时器，时间间隔为1s，并启动定时器
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
            //Stu为单个公告的信息集
            Bulletinboard Stu = new Bulletinboard();
            //UserNameTea为职工号
            string n = MainWindow.UserCode;
            string UserNameTea = n.ToString();
            //绑定姓名栏的数据源为UserNameTea
            FunctionUserNameTea.Content = UserNameTea;

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

            string myUpdate = "update xxb set 状态 =  '" + 1 + "' where 接收方 = '" + UserNameTea + "'";
            SqlCommand myCom = new SqlCommand(myUpdate, myConnection);
            myCom.ExecuteNonQuery();
            //从数据库中读取职工号为UserNameTea的各信息
            SqlCommand cmd = new SqlCommand("select 姓名,管理班级,邮箱,性别 from jsb where 职工号 = '" + UserNameTea + "'", myConnection);
            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            //绑定性别等栏的数据源
            if (sdr[0].ToString() == null)
            {
                FunctionNameTea.Content = "未设置";
                //MessageBox.Show("hhhh");
            }
            else
            {
                FunctionNameTea.Content = sdr[0].ToString();
            }

            if (sdr[1].ToString() == null)
            {
                FunctionClassTea.Content = "未设置";
            }
            else
            {
                FunctionClassTea.Content = sdr[1].ToString();
            }
            if (sdr[3].ToString() == null)
            {
                FunctionSexTea.Content = "未设置";
            }
            else
            {
                FunctionSexTea.Content = sdr[3].ToString();
            }
            FunctionEmailTea.Content = sdr[2].ToString();
            sdr.Close();
            SqlCommand cmd2 = new SqlCommand("select 内容,时间 from ggb ", myConnection);
            SqlDataReader sdr2 = cmd2.ExecuteReader();
            while (sdr2.Read())
            {


                Stu.Content = sdr2[0].ToString();
                Stu.Time = DateTime.Parse(sdr2[1].ToString().Trim());
                infoList.Add(Stu);



            };
            //对公告表按时间进行排序
            infoList.Sort(delegate (Bulletinboard x, Bulletinboard y)
            {
                return y.Time.CompareTo(x.Time);
            });
            sdr2.Close();
            //公告栏显示时间最晚的一条公告
            try
            {
                Bulletin.Content = infoList[0].Content;
            }
            catch { }
            //查询新消息总数
            //根据UserNameStu（登录用户名）选择出对应的个人信息
            SqlCommand cmd3 = new SqlCommand("select 发送方 from xxb where 接收方 = '" + UserNameTea + "' and 状态 = '" + 0 + "'", myConnection);
            SqlDataReader sdr3 = cmd3.ExecuteReader();
            //读取信息并对Stu结构体赋值            
            while (sdr3.Read())
            {
                try
                {
                    Counter_1++;
                }
                catch
                { }
            }
            MessageAlert.Content = "未读消息数目" + Counter_1.ToString();
            //关闭连接
            myConnection.Close();
        }

        //定时刷新
        void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                Bulletinboard Stu = new Bulletinboard();
                //UserNameTea为职工号
                string n = MainWindow.UserCode;
                string UserNameTea = n.ToString();
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
                RefreshTeaInf_Click(null, null);
                SqlCommand cmd3 = new SqlCommand("select 发送方 from xxb where 接收方 = '" + UserNameTea + "' and 状态 = '" + 0 + "'", myConnection);
                SqlDataReader sdr3 = cmd3.ExecuteReader();
                //读取新消息数目            
                while (sdr3.Read())
                {
                    try
                    {
                        Counter_2++;
                    }
                    catch
                    { }
                }
                //如果新消息数目变化则弹窗提醒
                int Sub = Counter_2 - Counter_1;
                if (Sub > 0)
                {
                    MessageBox.Show("您有新消息，请注意查看");
                }
                MessageAlert.Content = "未读消息数" + Counter_1.ToString();
                Counter_1 = Counter_2;
                Counter_2 = 0;

                myConnection.Close();
            }
            catch { }
        }



        private void InfChangeTea_Click(object sender, RoutedEventArgs e)
        {
            InfChangeTea window = new InfChangeTea();
            window.Show();
        }
        /// <summary>
        /// 个人信息刷新 
        /// </summary>
        private void RefreshTeaInf_Click(object sender, RoutedEventArgs e)
        {
            //UserNameTea为该用户的职工号
            string n = MainWindow.UserCode;
            string UserNameTea = n.ToString();
            FunctionUserNameTea.Content = UserNameTea;
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
            //查询用户名为UserNameTea的各信息
            SqlCommand cmd = new SqlCommand("select 姓名,管理班级,邮箱,性别 from jsb where 职工号 = '" + UserNameTea + "'", myConnection);
            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            //绑定姓名等各信息的数据源
            if (sdr[0].ToString() == null)
            {
                FunctionNameTea.Content = "未设置";
            }
            else
            {
                FunctionNameTea.Content = sdr[0].ToString();
            }

            if (sdr[1].ToString() == null)
            {
                FunctionClassTea.Content = "未设置";
            }
            else
            {
                FunctionClassTea.Content = sdr[1].ToString();
            }
            if (sdr[3].ToString() == null)
            {
                FunctionSexTea.Content = "未设置";
            }
            else
            {
                FunctionSexTea.Content = sdr[3].ToString();
            }
            FunctionEmailTea.Content = sdr[2].ToString();
            sdr.Close();
            //关闭连接
            myConnection.Close();
        }
        /// <summary>
        /// 注销并弹出主界面 
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow windowtea = new MainWindow();
            Window window = Window.GetWindow(this);//关闭父窗体
            window.Close();
            windowtea.Show();
        }
        /// <summary>
        /// 弹出管理班级功能界面 
        /// </summary>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //如果信息不全则禁止使用管理班级功能
            if (String.IsNullOrEmpty(FunctionNameTea.Content.ToString()) || String.IsNullOrEmpty(FunctionSexTea.Content.ToString()) ||
               String.IsNullOrEmpty(FunctionClassTea.Content.ToString()))
            {
                MessageBox.Show("请先完善信息,否则无法使用");
            }
            else
            {
                ManageClass windowtea = new ManageClass();
                windowtea.Show();
            }
        }
        /// <summary>
        /// 弹出消息界面
        /// </summary>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MesRecTea window = new MesRecTea();
            window.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            stugonggao window10 = new stugonggao();
            window10.Show();
        }
    }
}
