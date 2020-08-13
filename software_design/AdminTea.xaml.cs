///<summary>

///模块编号：<AdminTea>

///作用：<管理员教师信息管理界面,展示教师列表,并可对其进行信息管理>

///作者：肖鑫、田彬洋

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
    /// AdminTea.xaml 的交互逻辑
    /// </summary>
    public partial class AdminTea : Window
    {
        //设置一个定时器timer
        DispatcherTimer timer = new DispatcherTimer();

        //GroupNameAdminTea为选中学生的姓名,GroupUserAdminTea为选中学生的账户
        public static string GroupNameAdminTea;
        public static string GroupUserAdminTea;
        public static string Before = null;
        //infoList为教师列表
        List<ClassStu> infoList = new List<ClassStu>();
        /// <summary>
        /// 查询所有教师的信息并显示在界面上
        /// </summary>
        public AdminTea()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //建立定时器，时间间隔为1s，并启动定时器
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();

            //string n = MainWindow.UserCode;
            //string UserNameTea = n.ToString();
            //Stu为单个教师的信息集合
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
            //SqlCommand cmd2 = new SqlCommand("select 管理班级 from jsb where 职工号 = '" + UserNameTea + "'", myConnection);
            //SqlDataReader sdr2 = cmd2.ExecuteReader();
            //sdr2.Read();
            //string TeaClass = sdr2[0].ToString();
            //查询所有教师的信息
            //sdr2.Close();
            SqlCommand cmd = new SqlCommand("select 职工号,姓名,性别,管理班级,邮箱 from jsb", myConnection);
            SqlDataReader sdr = cmd.ExecuteReader();
            //遍历教师信息并将其加入教师列表infoList
            while (sdr.Read())
            {
                Stu.UserCode = sdr[0].ToString();
                Stu.UserName = sdr[1].ToString();
                Stu.UserSex = sdr[2].ToString();
                Stu.UserClass = sdr[3].ToString();
                Stu.UserEmail = sdr[4].ToString();
                infoList.Add(Stu);
            }
            //绑定datagrid的数据源为教师列表
            DG10.AutoGenerateColumns = false;
            DG10.ItemsSource = infoList;
        }
       
        /// <summary>
        /// 删除教师账户
        /// </summary>
        private void Delete_Click(object sender, RoutedEventArgs e)
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
            //遍历教师列表查询该生是否被选中,如被选中,则从数据库中删除其账户
            for (int i = 0; i < this.DG10.Items.Count; i++)
            {
                var cntr = DG10.ItemContainerGenerator.ContainerFromIndex(i);
                DataGridRow ObjROw = (DataGridRow)cntr;
                if (ObjROw != null)
                {
                    FrameworkElement objElement = DG10.Columns[5].GetCellContent(ObjROw);
                    if (objElement != null)
                    {
                        System.Windows.Controls.CheckBox objChk = (System.Windows.Controls.CheckBox)objElement;
                        //如果该生的复选框被选中,则将其删除
                        if (objChk.IsChecked == true)
                        {
                            string Code = infoList[i].UserCode;
                            SqlCommand cmd2 = new SqlCommand("delete from jsb where 职工号='" + Code + "'", myConnection);
                            cmd2.ExecuteNonQuery();

                        }
                    }
                }
            }
            myConnection.Close();
            myConnection.Dispose();
            //关闭连接
            MessageBox.Show("已成功删除");
        }
        /// <summary>
        /// 刷新教师信息
        /// </summary>
        private void RefreshStu_Click(object sender, RoutedEventArgs e)
        {
            Before = null;
            //string n = MainWindow.UserCode;
            //string UserNameTea = n.ToString();
            //Stu为单个教师的信息集合
            ClassStu Stu = new ClassStu();
            //清空教师列表
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
            //SqlCommand cmd2 = new SqlCommand("select 管理班级 from jsb where 职工号 = '" + UserNameTea + "'", myConnection);
            //SqlDataReader sdr2 = cmd2.ExecuteReader();
            //sdr2.Read();
            //string TeaClass = sdr2[0].ToString();
            //sdr2.Close();
            //查询所有的教师信息
            SqlCommand cmd = new SqlCommand("select 职工号,姓名,性别,管理班级,邮箱 from jsb", myConnection);
            SqlDataReader sdr = cmd.ExecuteReader();
            //遍历读取教师信息并加入到教师列表
            while (sdr.Read())
            {
                Stu.UserCode = sdr[0].ToString();
                Stu.UserName = sdr[1].ToString();
                Stu.UserSex = sdr[2].ToString();
                Stu.UserClass = sdr[3].ToString();
                Stu.UserEmail = sdr[4].ToString();
                infoList.Add(Stu);
            }
            //重新绑定datagrid的数据源为infoList
            DG10.AutoGenerateColumns = false;
            DG10.ItemsSource = null;
            DG10.ItemsSource = infoList;
        }
        /// <summary>
        /// 修改教师信息
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //遍历学生列表查询是否被选中,如有学生被选中则进入信息修改界面,并将其学号赋值给GroupUserAdminTea
            for (int i = 0; i < this.DG10.Items.Count; i++)
            {
                var cntr = DG10.ItemContainerGenerator.ContainerFromIndex(i);
                DataGridRow ObjROw = (DataGridRow)cntr;
                if (ObjROw != null)
                {
                    FrameworkElement objElement = DG10.Columns[5].GetCellContent(ObjROw);
                    if (objElement != null)
                    {
                        System.Windows.Controls.CheckBox objChk = (System.Windows.Controls.CheckBox)objElement;
                        //如果该生的复选框被选中,则进入该生的信息修改界面
                        if (objChk.IsChecked == true)
                        {
                            GroupNameAdminTea = infoList[i].UserName;
                            GroupUserAdminTea = infoList[i].UserCode;
                            //弹出信息修改界面
                            AdminInfTeaChange window = new AdminInfTeaChange();
                            WindowStartupLocation = WindowStartupLocation.Manual;
                            window.Left = 300;
                            window.Top = 200;
                            window.Show();
                            //退出循环
                            break;
                        }

                    }
                }


            }
        }
        /// <summary>
        ///添加教师账户
        /// </summary>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //弹出教师注册界面
            TeaAdd window = new TeaAdd();
            WindowStartupLocation = WindowStartupLocation.Manual;
            window.Left = 300;
            window.Top = 200;
            window.Show();
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
            for (int i = 0; i < this.DG10.Items.Count; i++)
            {
                var cntr = DG10.ItemContainerGenerator.ContainerFromIndex(i);
                DataGridRow ObjROw = (DataGridRow)cntr;
                if (ObjROw != null)
                {
                    FrameworkElement objElement = DG10.Columns[5].GetCellContent(ObjROw);
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

            //string n = MainWindow.UserCode;
            //string UserNameTea = n.ToString();
            //Stu为单个教师的信息集合
            ClassStu Stu = new ClassStu();
            //清空教师列表
            infoList.Clear();
            //SqlCommand cmd2 = new SqlCommand("select 管理班级 from jsb where 职工号 = '" + UserNameTea + "'", myConnection);
            //SqlDataReader sdr2 = cmd2.ExecuteReader();
            //sdr2.Read();
            //string TeaClass = sdr2[0].ToString();
            //sdr2.Close();
            //查询所有的教师信息
            SqlCommand cmd = new SqlCommand("select 职工号,姓名,性别,管理班级,邮箱 from jsb", myConnection);
            SqlDataReader sdr = cmd.ExecuteReader();
            //遍历读取教师信息并加入到教师列表
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
            //重新绑定datagrid的数据源为infoList
            DG10.AutoGenerateColumns = false;
            DG10.ItemsSource = null;
            DG10.ItemsSource = infoList;

        }

    }
}
