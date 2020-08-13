///<summary>

///模块编号：<stugonggao>

///作用：<扩展展示公告表>

///作者：田彬洋

///编写日期<2019-12-20>
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
    /// stugonggao.xaml 的交互逻辑
    /// </summary>
    /// 
    /// 
    /// ///<summary>

    ///定义结构体，方便对DataGrid进行赋值

    ///</summary>

    public struct gonggao
    {
        public string Info { get; set; }
        public DateTime Time { get; set; }
    }

    public partial class stugonggao : Window
    {
        //设置一个定时器timer
        DispatcherTimer timer = new DispatcherTimer();
        //定义返回值为gonggao类型的泛型，方便对DataGrid进行赋值
        List<gonggao> infoList1 = new List<gonggao>();
        public stugonggao()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //建立定时器，时间间隔为1s，并启动定时器
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();

            //UserNameStu为登录用户名

            //定义Information类型的结构体Stu
            gonggao gg = new gonggao();

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

            //根据UserNameStu（登录用户名）选择出对应的个人信息
            SqlCommand cmd = new SqlCommand("select 内容,时间 from ggb ", myConnection);
            SqlDataReader sdr = cmd.ExecuteReader();
            //读取信息并对Stu结构体赋值
            while (sdr.Read())
            {
                try
                {
                    gg.Info = sdr[0].ToString();    //将信息内容赋值
                    gg.Time = DateTime.Parse(sdr[1].ToString().Trim());
                    infoList1.Add(gg);              //将Stu的内容返回给infoList1
                }
                catch
                { }
            }
            infoList1.Sort(delegate (gonggao x, gonggao y)
            {
                return y.Time.CompareTo(x.Time);
            });
            DGg.AutoGenerateColumns = false;
            DGg.ItemsSource = infoList1;       //对DataGrid的文本框赋值
        }

        private void DGg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        //定时刷新
        void timer_Tick(object sender, EventArgs e)
        {
            Button_Click(null, null);
        }

        //手动刷新

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            #region 连接数据库
            gonggao Stu = new gonggao();
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
            SqlCommand cmd = new SqlCommand("select 内容,时间 from ggb ", myConnection);
            SqlDataReader sdr = cmd.ExecuteReader();
            //清空infoList1的内容
            infoList1.Clear();
            //读取信息并对Stu结构体赋值
            while (sdr.Read())
            {
                Stu.Info = sdr[0].ToString();    //将信息内容赋值
                Stu.Time = DateTime.Parse(sdr[1].ToString());
                infoList1.Add(Stu);              //将Stu的内容返回给infoList1
            }
            infoList1.Sort(delegate (gonggao x, gonggao y)
            {
                return y.Time.CompareTo(x.Time);
            });
            DGg.AutoGenerateColumns = false;
            DGg.ItemsSource = null;             //将DataGrid清空
            DGg.ItemsSource = infoList1;        //对DataGrid的文本框赋值 

        }

        private void DGg_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
