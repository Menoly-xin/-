///<summary>

///模块编号：<QuesAns>

///作用：<教师问题回答界面>

///作者:肖鑫,朱立新,田彬洋

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
using System.Data;
using System.Windows.Threading;



namespace software_design
{
    //TeaAnsQues为单个问题的状态结构体
    public struct TeaAnsQues
    {
        public string TeaStatus { get; set; }
        public string TeaQuestion { get; set; }
        public string TeaAnswer { get; set; }
        public string TeaName { get; set; }
        public string TeaUser { get; set; }
        public Boolean TeaSelectQues { get; set; }
        public DateTime Time { get; set; }

        public string ClassName { get; set; }
    }
    /// <summary>
    /// QuesAns.xaml 的交互逻辑
    /// </summary>
    public partial class QuesAns : Window
    {
        //设置一个定时器timer
        DispatcherTimer timer = new DispatcherTimer();
        //Question,QuestionUser为问题,问题的提出者
        public static string Question;
        public static string QuestionUser;
        public static string Before = null;
        List<TeaAnsQues> infoList = new List<TeaAnsQues>();
        public QuesAns()
        {
            InitializeComponent();
            Before = null;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //建立定时器，时间间隔为1s，并启动定时器
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();

            //UserNameTea为教师的账户名
            string n = MainWindow.UserCode;
            string UserNameTea = n.ToString();
            TeaAnsQues Stu = new TeaAnsQues();
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
            //查询该教师管理的班级
            SqlCommand cmd2 = new SqlCommand("select 管理班级 from jsb where 职工号 = '" + UserNameTea + "'", myConnection);
            SqlDataReader sdr2 = cmd2.ExecuteReader();
            sdr2.Read();
            //TeaClass为管理的班级
            string TeaClass = sdr2[0].ToString();
            sdr2.Close();
            //查询该班级所有的问题
            SqlCommand cmd = new SqlCommand("select 问题,答案,状态,姓名,学号,时间 from wtb where 班级 = '" + TeaClass + "'", myConnection);
            SqlDataReader sdr = cmd.ExecuteReader();
            //循环读取问题
            while (sdr.Read())
            {
                Stu.TeaStatus = sdr[2].ToString();
                Stu.TeaQuestion = sdr[0].ToString();
                Stu.TeaAnswer = sdr[1].ToString();
                Stu.TeaName = sdr[3].ToString();
                Stu.TeaUser = sdr[4].ToString();
                Stu.Time = DateTime.Parse(sdr[5].ToString().Trim());

                infoList.Add(Stu);
            }
            //将问题列表按时间排序
            infoList.Sort(delegate (TeaAnsQues x, TeaAnsQues y)
            {
                return y.Time.CompareTo(x.Time);
            });
            //绑定数据源
            DG4.AutoGenerateColumns = false;
            DG4.ItemsSource = infoList;

        }
        /// <summary>
        /// 点击提交答案
        /// </summary>
        private void AnsQuestion_Click(object sender, RoutedEventArgs e)
        {
            //循环读取问题列表看是否被选中
            for (int i = 0; i < this.DG4.Items.Count; i++)
            {
                var cntr = DG4.ItemContainerGenerator.ContainerFromIndex(i);
                DataGridRow ObjROw = (DataGridRow)cntr;
                if (ObjROw != null)
                {
                    FrameworkElement objElement = DG4.Columns[4].GetCellContent(ObjROw);
                    if (objElement != null)
                    {
                        //if (objElement.GetType().ToString().EndsWith("cRUID"))
                        //{
                        System.Windows.Controls.CheckBox objChk = (System.Windows.Controls.CheckBox)objElement;
                        //如果该问题被选中则回答该问题
                        if (objChk.IsChecked == true)
                        {
                            Question = infoList[i].TeaQuestion;
                            QuestionUser = infoList[i].TeaUser;
                            //弹出问题回答界面
                            SolveQuestion window = new SolveQuestion();
                            WindowStartupLocation = WindowStartupLocation.Manual;
                            window.Left = 300;
                            window.Top = 200;
                            window.Show();
                            return;

                        }
                        //}
                    }
                }
            }
        }
        //定时刷新
        void timer_Tick(object sender, EventArgs e)
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
            //循环读取是否被选中
            for (int i = 0; i < this.DG4.Items.Count; i++)
            {
                var cntr = DG4.ItemContainerGenerator.ContainerFromIndex(i);
                DataGridRow ObjROw = (DataGridRow)cntr;
                if (ObjROw != null)
                {
                    FrameworkElement objElement = DG4.Columns[4].GetCellContent(ObjROw);
                    if (objElement != null)
                    {
                        System.Windows.Controls.CheckBox objChk = (System.Windows.Controls.CheckBox)objElement;
                        if (objChk.IsChecked == true)
                        {

                            if (Before != infoList[i].TeaQuestion)
                            {
                                Before = infoList[i].TeaQuestion;
                                break;
                            }
                        }
                    }
                }
            }
            string n = MainWindow.UserCode;
            string UserNameTea = n.ToString();
            infoList.Clear();
            TeaAnsQues Stu = new TeaAnsQues();
            SqlCommand cmd2 = new SqlCommand("select 管理班级 from jsb where 职工号 = '" + UserNameTea + "'", myConnection);
            SqlDataReader sdr2 = cmd2.ExecuteReader();
            sdr2.Read();
            string TeaClass = sdr2[0].ToString();
            sdr2.Close();
            SqlCommand cmd = new SqlCommand("select 问题,答案,状态,姓名,学号,时间 from wtb where 班级 = '" + TeaClass + "'", myConnection);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Stu.TeaStatus = sdr[2].ToString();
                Stu.TeaQuestion = sdr[0].ToString();
                Stu.TeaAnswer = sdr[1].ToString();
                Stu.TeaName = sdr[3].ToString();
                Stu.TeaUser = sdr[4].ToString();
                if (Before == null)
                {
                    Stu.TeaSelectQues = false;
                }
                else if (Stu.TeaQuestion == Before)
                {
                    Stu.TeaSelectQues = true;
                }
                else
                {
                    Stu.TeaSelectQues = false;
                }
                Stu.Time = DateTime.Parse(sdr[5].ToString().Trim());
                infoList.Add(Stu);
            }
            infoList.Sort(delegate (TeaAnsQues x, TeaAnsQues y)
            {
                return y.Time.CompareTo(x.Time);
            });
            DG4.AutoGenerateColumns = false;
            DG4.ItemsSource = null;
            DG4.ItemsSource = infoList;

        }  
        /// <summary>
        /// 刷新问题状态,具体做法同初始化
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Before = null;
            string n = MainWindow.UserCode;
            string UserNameTea = n.ToString();
            infoList.Clear();
            TeaAnsQues Stu = new TeaAnsQues();
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
            SqlCommand cmd2 = new SqlCommand("select 管理班级 from jsb where 职工号 = '" + UserNameTea + "'", myConnection);
            SqlDataReader sdr2 = cmd2.ExecuteReader();
            sdr2.Read();
            string TeaClass = sdr2[0].ToString();
            sdr2.Close();
            SqlCommand cmd = new SqlCommand("select 问题,答案,状态,姓名,学号,时间 from wtb where 班级 = '" + TeaClass + "'", myConnection);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Stu.TeaStatus = sdr[2].ToString();
                Stu.TeaQuestion = sdr[0].ToString();
                Stu.TeaAnswer = sdr[1].ToString();
                Stu.TeaName = sdr[3].ToString();
                Stu.TeaUser = sdr[4].ToString();
                Stu.Time = DateTime.Parse(sdr[5].ToString().Trim());

                infoList.Add(Stu);
            }
            infoList.Sort(delegate (TeaAnsQues x, TeaAnsQues y)
            {
                return y.Time.CompareTo(x.Time);
            });
            DG4.AutoGenerateColumns = false;
            DG4.ItemsSource = null;
            DG4.ItemsSource = infoList;
        }
    }
}
