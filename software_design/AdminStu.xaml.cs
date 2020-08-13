///<summary>

///模块编号：<AdminStu>

///作用：<管理员学生信息管理界面,展示学生列表,并可对其进行信息管理>

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
    /// AdminStu.xaml 的交互逻辑
    /// </summary>
    public partial class AdminStu : Window
    {
        //设置一个定时器timer
        DispatcherTimer timer = new DispatcherTimer();

        //GroupNameAdmin为选中学生的姓名,GroupUserAdmin为选中学生的账户
        public static string GroupNameAdmin;
        public static string GroupUserAdmin;
        public static string Before = null;
        //infoList为学生列表
        List<ClassStu> infoList = new List<ClassStu>();
        /// <summary>
        /// 查询所有学生的信息并显示在界面上
        /// </summary>
        public AdminStu()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //建立定时器，时间间隔为1s，并启动定时器
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();

            //string n = MainWindow.UserCode;
            //string UserNameTea = n.ToString();
            //Stu为单个学生的信息集合
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
            //endregion
            //SqlCommand cmd2 = new SqlCommand("select 管理班级 from jsb where 职工号 = '" + UserNameTea + "'", myConnection);
            //SqlDataReader sdr2 = cmd2.ExecuteReader();
            //sdr2.Read();
            //string TeaClass = sdr2[0].ToString();
            //sdr2.Close();
            //查询所有学生的信息
            SqlCommand cmd = new SqlCommand("select 学号,姓名,性别,班级,邮箱 from xsb", myConnection);
            SqlDataReader sdr = cmd.ExecuteReader();
            //遍历学生信息并将其加入学生列表infoList
            while (sdr.Read())
            {
                Stu.UserCode = sdr[0].ToString();
                Stu.UserName = sdr[1].ToString();
                Stu.UserSex = sdr[2].ToString();
                Stu.UserClass = sdr[3].ToString();
                Stu.UserEmail = sdr[4].ToString();
                infoList.Add(Stu);
            }
            //绑定datagrid的数据源为学生列表
            DG9.AutoGenerateColumns = false;
            DG9.ItemsSource = infoList;
        }
       

        /// <summary>
        /// 刷新学生信息
        /// </summary>
        private void RefreshStu_Click(object sender, RoutedEventArgs e)
        {
            Before = null;
            //string n = MainWindow.UserCode;
            //string UserNameTea = n.ToString();
            //Stu为单个学生的信息集合
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
            //查询所有的学生信息
            SqlCommand cmd = new SqlCommand("select 学号,姓名,性别,班级,邮箱 from xsb", myConnection);
            SqlDataReader sdr = cmd.ExecuteReader();
            //遍历读取学生信息并加入到学生列表
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
            DG9.AutoGenerateColumns = false;
            DG9.ItemsSource = null;
            DG9.ItemsSource = infoList;
        }
        /// <summary>
        /// 删除学生账户
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
            //遍历学生列表查询该生是否被选中,如被选中,则从数据库中删除其账户
            for (int i = 0; i < this.DG9.Items.Count; i++)
            {
                var cntr = DG9.ItemContainerGenerator.ContainerFromIndex(i);
                DataGridRow ObjROw = (DataGridRow)cntr;
                if (ObjROw != null)
                {
                    FrameworkElement objElement = DG9.Columns[5].GetCellContent(ObjROw);
                    if (objElement != null)
                    {
                        System.Windows.Controls.CheckBox objChk = (System.Windows.Controls.CheckBox)objElement;
                        //如果该生的复选框被选中,则将其删除
                        if (objChk.IsChecked == true)
                        {
                            //Code为被选中学生的学号
                            string Code = infoList[i].UserCode;
                            //从数据库中删除该生的账户
                            SqlCommand cmd2 = new SqlCommand("delete from xsb where 学号='" + Code + "'", myConnection);
                            cmd2.ExecuteNonQuery();

                        }
                    }
                }
            }
            myConnection.Close();
            myConnection.Dispose();
            //关闭连接
            MessageBox.Show("已成功删除选中的账户");

        }
        /// <summary>
        /// 修改学生信息
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //遍历学生列表查询是否被选中,如有学生被选中则进入信息修改界面,并将其学号赋值给GroupUserAdmin
            for (int i = 0; i < this.DG9.Items.Count; i++)
            {
                var cntr = DG9.ItemContainerGenerator.ContainerFromIndex(i);
                DataGridRow ObjROw = (DataGridRow)cntr;
                if (ObjROw != null)
                {
                    FrameworkElement objElement = DG9.Columns[5].GetCellContent(ObjROw);
                    if (objElement != null)
                    {
                        System.Windows.Controls.CheckBox objChk = (System.Windows.Controls.CheckBox)objElement;
                        //如果该生的复选框被选中,则进入该生的信息修改界面
                        if (objChk.IsChecked == true)
                        {
                            GroupNameAdmin = infoList[i].UserName;
                            GroupUserAdmin = infoList[i].UserCode;
                            //弹出信息修改界面
                            AdminInfStuChange window = new AdminInfStuChange();
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
            for (int i = 0; i < this.DG9.Items.Count; i++)
            {
                var cntr = DG9.ItemContainerGenerator.ContainerFromIndex(i);
                DataGridRow ObjROw = (DataGridRow)cntr;
                if (ObjROw != null)
                {
                    FrameworkElement objElement = DG9.Columns[5].GetCellContent(ObjROw);
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
            //Stu为单个学生的信息集合
            ClassStu Stu = new ClassStu();
            //清空教师列表
            infoList.Clear();
            //SqlCommand cmd2 = new SqlCommand("select 管理班级 from jsb where 职工号 = '" + UserNameTea + "'", myConnection);
            //SqlDataReader sdr2 = cmd2.ExecuteReader();
            //sdr2.Read();
            //string TeaClass = sdr2[0].ToString();
            //sdr2.Close();
            //查询所有的学生信息
            SqlCommand cmd = new SqlCommand("select 学号,姓名,性别,班级,邮箱 from xsb", myConnection);
            SqlDataReader sdr = cmd.ExecuteReader();
            //遍历读取学生信息并加入到学生列表
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
            DG9.AutoGenerateColumns = false;
            DG9.ItemsSource = null;
            DG9.ItemsSource = infoList;

        }

    }
}
