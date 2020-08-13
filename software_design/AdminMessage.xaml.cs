///<summary>

///模块编号：<AdminMessage>

///作用：<管理员向选中的学生和教师发送消息>

///作者：肖鑫、田彬洋

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

namespace software_design
{
    //AdminMessageTea为DataGrid绑定的结构体
    public struct AdminMessageTea
    {
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string UserSex { get; set; }
        public string UserEmail { get; set; }
        public string UserClass { get; set; }
        public DateTime Time { get; set; }

    }
    /// <summary>
    /// AdminMessage.xaml 的交互逻辑
    /// </summary>
    public partial class AdminMessage : Window
    {
        //InfoStuList为学生列表
        //InfoTeaList为教师列表
        List<MessageStu> InfoStuList = new List<MessageStu>();
        List<AdminMessageTea> InfoTeaList = new List<AdminMessageTea>();
        /// <summary>
        /// 查询教师和学生列表并将其分别展示在两个界面上
        /// </summary>
        public AdminMessage()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //string n = MainWindow.UserCode;
            //string UserNameTea = n.ToString();
            //Stu,Tea分别为单个学生和教师的信息集合
            MessageStu Stu = new MessageStu();
            AdminMessageTea Tea = new AdminMessageTea();
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
            //查询所有的学生信息
            SqlCommand cmd = new SqlCommand("select 学号,姓名,性别,班级,邮箱 from xsb", myConnection);
            SqlDataReader sdr = cmd.ExecuteReader();
            //依次读取并将其加入学生列表
            while (sdr.Read())
            {
                Stu.UserCode = sdr[0].ToString();
                Stu.UserName = sdr[1].ToString();
                Stu.UserSex = sdr[2].ToString();
                Stu.UserClass = sdr[3].ToString();
                Stu.UserEmail = sdr[4].ToString();
                InfoStuList.Add(Stu);
            }
            //绑定DG12 datagrid 的数据源为学生列表
            DG12.AutoGenerateColumns = false;
            DG12.ItemsSource = InfoStuList;
            sdr.Close();
            //查询所有的教师信息
            SqlCommand cmd2 = new SqlCommand("select 职工号,姓名,性别,管理班级,邮箱 from jsb", myConnection);
            SqlDataReader sdr2 = cmd2.ExecuteReader();
            //依次读取并将其加入学生列表
            while (sdr2.Read())
            {
                Tea.UserCode = sdr2[0].ToString();
                Tea.UserName = sdr2[1].ToString();
                Tea.UserSex = sdr2[2].ToString();
                Tea.UserClass = sdr2[3].ToString();
                Tea.UserEmail = sdr2[4].ToString();
                InfoTeaList.Add(Tea);
            }
            //绑定DG13 datagrid 的数据源为教师列表
            DG13.AutoGenerateColumns = false;
            DG13.ItemsSource = InfoTeaList;
        }
        /// <summary>
        /// 读取界面中消息栏的内容并发送消息给选中的学生和教师
        /// </summary>
        private void SendMessage_Click(object sender, RoutedEventArgs e)
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
            //MessageTemp存储界面中消息栏的内容
            string MessageTemp = Message.Text;
            string Statue = "管理员";
            //now为系统时间
            DateTime now = DateTime.Now;
            //遍历学生列表查询选中的学生,当某个学生被选中时向其发送消息
            for (int i = 0; i < this.DG12.Items.Count; i++)
            {
                var cntr = DG12.ItemContainerGenerator.ContainerFromIndex(i);
                DataGridRow ObjROw = (DataGridRow)cntr;
                if (ObjROw != null)
                {
                    FrameworkElement objElement = DG12.Columns[4].GetCellContent(ObjROw);
                    if (objElement != null)
                    {
                        System.Windows.Controls.CheckBox objChk = (System.Windows.Controls.CheckBox)objElement;
                        //如果复选框为选中状态
                        if (objChk.IsChecked == true)
                        {
                            //Code为被选中学生的学号
                            string Code = InfoStuList[i].UserCode;
                            //向其发送消息
                            SqlCommand cmd2 = new SqlCommand("insert into xxb(发送方,接收方,消息内容,时间,状态) values ('" + Statue + "','" + Code + "','" + MessageTemp + "','" + now.ToString() + "','" + 0 + "')", myConnection);
                            cmd2.ExecuteNonQuery();

                        }
                    }
                }
            }
            //DateTime now = DateTime.Now;
            //遍历教师列表查询选中的教师,当某个教师被选中时向其发送消息
            for (int i = 0; i < this.DG13.Items.Count; i++)
            {
                var cntr = DG13.ItemContainerGenerator.ContainerFromIndex(i);
                DataGridRow ObjROw = (DataGridRow)cntr;
                if (ObjROw != null)
                {
                    FrameworkElement objElement = DG13.Columns[4].GetCellContent(ObjROw);
                    if (objElement != null)
                    {
                        System.Windows.Controls.CheckBox objChk = (System.Windows.Controls.CheckBox)objElement;
                        //如果复选框为选中状态
                        if (objChk.IsChecked == true)
                        {
                            //Code为被选中学生的学号
                            string Code = InfoTeaList[i].UserCode;
                            //向其发送消息
                            SqlCommand cmd2 = new SqlCommand("insert into xxb(发送方,接收方,消息内容,时间,状态) values ('" + Statue + "','" + Code + "','" + MessageTemp + "','" + now.ToString() + "','" + 0 + "')", myConnection);
                            cmd2.ExecuteNonQuery();

                        }
                    }
                }
            }
            MessageBox.Show("发送成功");
            myConnection.Close();
            //关闭连接
            myConnection.Dispose();
        }
    }
}
