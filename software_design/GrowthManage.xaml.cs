///<summary>

///模块编号：<GrowthManage>

///作用：<学生档案功能界面，此界面呈现教师对学生大一到大四的学期评价，并且可以进行修改提交>

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
    /// GrowthManage.xaml 的交互逻辑
    /// </summary>
    public partial class GrowthManage : Window
    {
        //设置一个定时器timer
        DispatcherTimer timer = new DispatcherTimer();
        public int RadioSelect = 0;
        public int RadioSelect2 = 0;
        /// <summary>
        /// 学生档案功能界面初始化，根据管理班级界面选中的学生用户名读取数据库xsb表中对应的大一至大四的教师评价呈现在界面中(初始默认呈现大一评价)，
        /// 并且提供教师修改学生档案按键以及刷新按键
        /// </summary>
        public GrowthManage()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //建立定时器，时间间隔为1s，并启动定时器
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
            //ManageClass.GroupName为管理班级界面CheckBox选中学生的学号
            HisName.Content = ManageClass.GroupName;
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
            //根据ManageClass.GroupName（选定的学生用户名）读取大一的学期评价
            SqlCommand cmd = new SqlCommand("select 大一 from xsb where 学号 = '" + ManageClass.GroupUser + "'", myConnection);
            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            //将大一学期评价打印在GrowthText中
            GrowthText.Text = sdr[0].ToString();
            sdr.Close();
            //关闭数据库连接
            myConnection.Close();
        }
        /// <summary>
        /// 点击"刷新"按键，可以看到更改后的信息，或者其他学期的信息
        /// </summary>
        private void ReFresh_Click(object sender, RoutedEventArgs e)
        {
            if (one.IsChecked == true)
            {
                //如果大一被选中则设置RadioSelect2为0,下面依次是大二大三大四
                RadioSelect2 = 0;
            }
            else if (two.IsChecked == true)
            {            
                RadioSelect2 = 1;
            }
            else if (three.IsChecked == true)
            {               
                RadioSelect2 = 2;
            }
            else
            {
                RadioSelect2 = 3;
            }
            if (RadioSelect == RadioSelect2)
            {

            }
            //SelectItem存储选定的RadioButton内容
            else
            { string SelectItem;
                if (one.IsChecked == true)
                {
                    //读取大一学期的学生档案
                    SelectItem = "select 大一 from xsb where 学号 = '" + ManageClass.GroupUser + "'";
                }
                else if (two.IsChecked == true)
                {
                    //读取大二学期的学生档案
                    SelectItem = "select 大二 from xsb where 学号 = '" + ManageClass.GroupUser + "'";
                }
                else if (three.IsChecked == true)
                {
                    //读取大三学期的学生档案
                    SelectItem = "select 大三 from xsb where 学号 = '" + ManageClass.GroupUser + "'";
                }
                else
                {
                    //读取大四学期的学生档案
                    SelectItem = "select 大四 from xsb where 学号 = '" + ManageClass.GroupUser + "'";
                }
                //ManageClass.GroupName为管理班级界面CheckBox选中学生的学号
                HisName.Content = ManageClass.GroupName;
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
                //读取对应学生的学期档案
                SqlCommand cmd = new SqlCommand(SelectItem, myConnection);
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                //将读取到的学生档案打印在对话框中
                GrowthText.Text = sdr[0].ToString();
                sdr.Close();
                //关闭数据库连接
                myConnection.Close();
            }
            RadioSelect = RadioSelect2;
        }
        //定时刷新
        void timer_Tick(object sender, EventArgs e)
        {
            ReFresh_Click(null, null);
        }
        /// <summary>
        /// 提交教师输入的学生档案
        /// </summary>

        private void 提交_Click(object sender, RoutedEventArgs e)
        {
            //SelectItem存储选定的RadioButton内容
            string SelectItem;
            //TextUpload存储对话框中的内容
            string TextUpload = GrowthText.Text;
            //判定要存储的信息是对应哪一个学期
            if (one.IsChecked == true)
            {
                //大一
                SelectItem = "update  xsb set 大一='" + TextUpload + "'where 学号='" + ManageClass.GroupUser + "' ";
            }
            else if (two.IsChecked == true)
            {
                //大二
                SelectItem = "update  xsb set 大二='" + TextUpload + "'where 学号='" + ManageClass.GroupUser + "' ";
            }
            else if (three.IsChecked == true)
            {
                //大三
                SelectItem = "update  xsb set 大三='" + TextUpload + "'where 学号='" + ManageClass.GroupUser + "' ";
            }
            else
            {
                //大四
                SelectItem = "update  xsb set 大四='" + TextUpload + "'where 学号='" + ManageClass.GroupUser + "' ";
            }
            HisName.Content = ManageClass.GroupName;
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
            //将信息提交至数据库
            SqlCommand myCom = new SqlCommand(SelectItem, myConnection);
            myCom.ExecuteNonQuery();
            MessageBox.Show("提交成功");
            //关闭数据连接
            myConnection.Close();
            myConnection.Dispose();
        }
    }
}
