///<summary>

///模块编号：<MessageTea>

///作用：<教师消息发送界面>

///作者:肖鑫,朱立新

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
using System.Data;

namespace software_design
{
    //MessageStu为单个学生的信息结构体
    public struct MessageStu
    {
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string UserSex { get; set; }
        public string UserEmail { get; set; }
        public string UserClass { get; set; }
        public DateTime Time { get; set; }
    }
    /// <summary>
    /// MessageTea.xaml 的交互逻辑
    /// </summary>
    public partial class MessageTea : Window
    {
        List<MessageStu> infoList = new List<MessageStu>();
        public MessageTea()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //UserNameTea为教师的账户名
            string n = MainWindow.UserCode;
            string UserNameTea = n.ToString();
            MessageStu Stu = new MessageStu();
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
            //TeaClass为该教师管理的班级
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
            //绑定界面数据源
            DG5.AutoGenerateColumns = false;
            DG5.ItemsSource = infoList;
        }
        /// <summary>
        /// 点击向选中的学生发送消息
        /// </summary>
        private void SendMessage_Click(object sender, RoutedEventArgs e)
        {
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
            //MessageTemp为要发送的消息
            string MessageTemp = Message.Text;
            string Statue = "班主任";
            //Time为当前时间
            DateTime Time = DateTime.Now;
            //循环读取学生列表查询是否被选中
            for (int i = 0; i < this.DG5.Items.Count; i++)
            {
                var cntr = DG5.ItemContainerGenerator.ContainerFromIndex(i);
                DataGridRow ObjROw = (DataGridRow)cntr;
                if (ObjROw != null)
                {
                    FrameworkElement objElement = DG5.Columns[5].GetCellContent(ObjROw);
                    if (objElement != null)
                    {
                        System.Windows.Controls.CheckBox objChk = (System.Windows.Controls.CheckBox)objElement;
                        //如果被选中则向其发送消息
                        if (objChk.IsChecked == true)
                        {
                            string Code = infoList[i].UserCode;
                            SqlCommand cmd2 = new SqlCommand("insert into xxb(发送方,接收方,消息内容,时间,状态) values ('" + Statue + "','" + Code + "','" + MessageTemp + "','" + Time.ToString() + "','" + 0 + "')", myConnection);
                            cmd2.ExecuteNonQuery();

                        }
                    }
                }
            }
            MessageBox.Show("发送成功");
            myConnection.Close();
            myConnection.Dispose();
        }
    }
}
