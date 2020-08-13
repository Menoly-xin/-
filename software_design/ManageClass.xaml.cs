///<summary>

///模块编号：<ManageClass>

///作用：<班级管理界面,提供发送消息,回答问题等功能的入口>

///作者:肖鑫、朱立新

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
using System.Windows.Threading;


namespace software_design
{
    //ClassStu为单个学生结构体
    public struct ClassStu
    {
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string UserSex { get; set; }
        public string UserEmail { get; set; }
        public string UserClass { get; set; }
        public bool UserSelect { get; set; }
    }
    /// <summary>
    /// ManageClass.xaml 的交互逻辑
    /// </summary>
    public partial class ManageClass : Window
    {
        //设置一个定时器timer
        DispatcherTimer timer = new DispatcherTimer();


        //GroupName,GroupUser分别为某位学生的名字和账户,用于传递参数
        public static string GroupName;
        public static string GroupUser;
        public static string Before = null;
        //infoList为学生集合
        List<ClassStu> infoList = new List<ClassStu>();
        public ManageClass()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //建立定时器，时间间隔为1s，并启动定时器
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
            Before = null;

            //UserNameTea为主界面输入的用户名
            string n = MainWindow.UserCode;
            string UserNameTea = n.ToString();
            ClassStu Stu = new ClassStu();
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
            //查询该教师管理的班级
            SqlCommand cmd2 = new SqlCommand("select 管理班级 from jsb where 职工号 = '" + UserNameTea + "'", myConnection);
            SqlDataReader sdr2 = cmd2.ExecuteReader();
            sdr2.Read();
            //TeaClass为管理的班级
            string TeaClass = sdr2[0].ToString();
            sdr2.Close();
            //查询该班级所有的学生信息
            SqlCommand cmd = new SqlCommand("select 学号,姓名,性别,班级,邮箱 from xsb where 班级 = '" + TeaClass + "'", myConnection);
            SqlDataReader sdr = cmd.ExecuteReader();
            //循环读取学生信息并加入学生列表
            while (sdr.Read())
            {
                Stu.UserCode = sdr[0].ToString();
                Stu.UserName = sdr[1].ToString();
                Stu.UserSex = sdr[2].ToString();
                Stu.UserClass = sdr[3].ToString();
                Stu.UserEmail = sdr[4].ToString();
                infoList.Add(Stu);
            }
            //绑定界面数据源为学生列表
            DG3.AutoGenerateColumns = false;
            DG3.ItemsSource = infoList;
        }
        /// <summary>
        /// 点击弹出问题界面
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            QuesAns window = new QuesAns();
            WindowStartupLocation = WindowStartupLocation.Manual;
            window.Left = 300;
            window.Top = 200;
            window.Show();
        }    
        /// <summary>
        /// 点击删除选中的学生账户
        /// </summary>
        private void Delete(object sender, RoutedEventArgs e)
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
            for (int i = 0; i < this.DG3.Items.Count; i++)
            {
                var cntr = DG3.ItemContainerGenerator.ContainerFromIndex(i);
                DataGridRow ObjROw = (DataGridRow)cntr;
                if (ObjROw != null)
                {
                    FrameworkElement objElement = DG3.Columns[5].GetCellContent(ObjROw);
                    if (objElement != null)
                    {
                        System.Windows.Controls.CheckBox objChk = (System.Windows.Controls.CheckBox)objElement;
                        //如果被选中则删除数据库中该学生的资料
                        if (objChk.IsChecked == true)
                        {
                            string Code = infoList[i].UserCode;
                            SqlCommand cmd2 = new SqlCommand("delete from xsb where 学号='" + Code + "'", myConnection);
                            cmd2.ExecuteNonQuery();

                        }
                    }
                }
            }
            myConnection.Close();
            myConnection.Dispose();
        }
        /// <summary>
        /// 点击刷新学生列表
        /// </summary>
        private void RefreshStu_Click(object sender, RoutedEventArgs e)
        {
            //UserNameTea为教师的账户名
            string n = MainWindow.UserCode;
            string UserNameTea = n.ToString();
            ClassStu Stu = new ClassStu();
            //清空学生列表
            infoList.Clear();
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
            //通过查询班级来读取该班级所有学生的信息
            SqlCommand cmd2 = new SqlCommand("select 管理班级 from jsb where 职工号 = '" + UserNameTea + "'", myConnection);
            SqlDataReader sdr2 = cmd2.ExecuteReader();
            sdr2.Read();
            string TeaClass = sdr2[0].ToString();
            sdr2.Close();
            SqlCommand cmd = new SqlCommand("select 学号,姓名,性别,班级,邮箱 from xsb where 班级 = '" + TeaClass + "'", myConnection);
            SqlDataReader sdr = cmd.ExecuteReader();
            //循环读取查询到的信息
            while (sdr.Read())
            {
                Stu.UserCode = sdr[0].ToString();
                Stu.UserName = sdr[1].ToString();
                Stu.UserSex = sdr[2].ToString();
                Stu.UserClass = sdr[3].ToString();
                Stu.UserEmail = sdr[4].ToString();
                infoList.Add(Stu);
            }
            Before = null;
            //重新绑定数据源
            DG3.AutoGenerateColumns = false;
            DG3.ItemsSource = null;
            DG3.ItemsSource = infoList;
            myConnection.Close();
            myConnection.Dispose();
        }
        /// <summary>
        /// 点击进入消息发送界面
        /// </summary>
        private void MessageSend_Click(object sender, RoutedEventArgs e)
        {
            MessageTea window = new MessageTea();
            WindowStartupLocation = WindowStartupLocation.Manual;
            window.Left = 300;
            window.Top = 200;
            window.Show();
        }
        /// <summary>
        /// 点击进入学生成长管理界面
        /// </summary>
        private void Growth_Click(object sender, RoutedEventArgs e)
        {
            //遍历学生列表
            for (int i = 0; i < this.DG3.Items.Count; i++)
            {
                var cntr = DG3.ItemContainerGenerator.ContainerFromIndex(i);
                DataGridRow ObjROw = (DataGridRow)cntr;
                if (ObjROw != null)
                {
                    FrameworkElement objElement = DG3.Columns[5].GetCellContent(ObjROw);
                    if (objElement != null)
                    {
                        System.Windows.Controls.CheckBox objChk = (System.Windows.Controls.CheckBox)objElement;
                        //如果该学生被选中则进入该学生的成长档案界面
                        if (objChk.IsChecked == true)
                        {
                            Before = null;
                            //GroupName,GroupUser为该学生的姓名和账户
                            GroupName = infoList[i].UserName;
                            GroupUser = infoList[i].UserCode;
                            GrowthManage window = new GrowthManage();
                            WindowStartupLocation = WindowStartupLocation.Manual;
                            window.Left = 300;
                            window.Top = 200;
                            window.Show();
                            break;
                        }

                    }
                }


            }
        }
        /// <summary>
        /// 点击弹出文件窗口
        /// </summary>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FileTea window = new FileTea();
            WindowStartupLocation = WindowStartupLocation.Manual;
            window.Left = 300;
            window.Top = 200;
            window.Show();
        }
        /// <summary>
        /// 点击弹出提醒设置窗口
        /// </summary>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ReminderPage window = new ReminderPage();
            WindowStartupLocation = WindowStartupLocation.Manual;
            window.Left = 300;
            window.Top = 200;
            window.Show();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            try
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
                for (int i = 0; i < this.DG3.Items.Count; i++)
                {
                    var cntr = DG3.ItemContainerGenerator.ContainerFromIndex(i);
                    DataGridRow ObjROw = (DataGridRow)cntr;
                    if (ObjROw != null)
                    {
                        FrameworkElement objElement = DG3.Columns[5].GetCellContent(ObjROw);
                        if (objElement != null)
                        {
                            System.Windows.Controls.CheckBox objChk = (System.Windows.Controls.CheckBox)objElement;
                            if (objChk.IsChecked == true)
                            {

                                if (Before != infoList[i].UserCode)
                                {
                                    Before = infoList[i].UserCode;
                                    break;
                                }
                            }
                        }
                    }
                }
                /***************************************************************************/
                //UserNameTea为教师的账户名
                string n = MainWindow.UserCode;
                string UserNameTea = n.ToString();
                ClassStu Stu = new ClassStu();
                //清空学生列表
                infoList.Clear();
                //通过查询班级来读取该班级所有学生的信息
                SqlCommand cmd2 = new SqlCommand("select 管理班级 from jsb where 职工号 = '" + UserNameTea + "'", myConnection);
                SqlDataReader sdr2 = cmd2.ExecuteReader();
                sdr2.Read();
                string TeaClass = sdr2[0].ToString();
                sdr2.Close();
                SqlCommand cmd = new SqlCommand("select 学号,姓名,性别,班级,邮箱 from xsb where 班级 = '" + TeaClass + "'", myConnection);
                SqlDataReader sdr = cmd.ExecuteReader();
                //循环读取查询到的信息
                while (sdr.Read())
                {

                    Stu.UserCode = sdr[0].ToString();
                    if (Before == null)
                    {
                        Stu.UserSelect = false;
                    }
                    else if (Stu.UserCode == Before)
                    {
                        Stu.UserSelect = true;
                    }
                    else
                    {
                        Stu.UserSelect = false;
                    }
                    Stu.UserName = sdr[1].ToString();
                    Stu.UserSex = sdr[2].ToString();
                    Stu.UserClass = sdr[3].ToString();
                    Stu.UserEmail = sdr[4].ToString();
                    infoList.Add(Stu);
                }
                //重新绑定数据源
                DG3.AutoGenerateColumns = false;
                DG3.ItemsSource = null;
                DG3.ItemsSource = infoList;
                //
                myConnection.Close();
                myConnection.Dispose();
            }
            catch
            { }

        }

    }
}

