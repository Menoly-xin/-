///<summary>

///模块编号：<ReminderPage>

///作用：<教师提醒设置界面>

///作者:肖鑫,田彬洋

///编写日期<2019-01-07> 修改日期<2020-01-09>

///<summary>

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
    //Reminders为单个提醒的结构体
    /// <summary>
    /// ReminderPage.xaml 的交互逻辑
    /// </summary>
    public partial class ReminderPage : Window
    {
        //infoList为提醒列表
        List<MessageStu> infoList = new List<MessageStu>();
        public ReminderPage()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;   
        }
        /// <summary>
        /// 点击设置提醒
        /// </summary>
        private void Set_Click(object sender, RoutedEventArgs e)
        {
            //UserNameTea为教师账户名
            string n = MainWindow.UserCode;
            string UserNameTea = n.ToString();
            string Send = "定时提醒";
            infoList.Clear();
            MessageStu Stu = new MessageStu();
            //Reminders Stu = new Reminders();
            //FunctionUserNameTea.Content = UserNameTea;
            //数据库连接
            SqlConnection myConnection;
            //string connStr = @"Server =   LAPTOP-25MJ4H0M\SQLEXPRESS; database =教学系统; Trusted_Connection=SSPI";
            string connStr = "Server ='" + IPAddress.ip + "'; database =测试数据库; uid =sa; pwd=1738010002";
            myConnection = new SqlConnection(connStr);
            try
            {
                myConnection.Open();
            }
            catch
            {
                MessageBox.Show("连接失败");
            }           
            //查询该教师管理的班级
            SqlCommand cmd2 = new SqlCommand("select 管理班级 from jsb where 职工号 = '" + UserNameTea + "'", myConnection);
            SqlDataReader sdr2 = cmd2.ExecuteReader();
            sdr2.Read();
            //Class为班级
            string Class = sdr2[0].ToString();
            sdr2.Close();
            SqlCommand cmd3 = new SqlCommand("select 学号 from xsb where 班级 = '" + Class + "'", myConnection);
            SqlDataReader sdr3 = cmd3.ExecuteReader();
            //Stu.UserCode为学号
            while (sdr3.Read())
            {
                Stu.UserCode = sdr3[0].ToString();
                infoList.Add(Stu);
            }
            sdr3.Close();
            for(int i = 0;i<infoList.Count;i++)
            {
                SqlConnection myConnection2;
                //string connStr = @"Server =   LAPTOP-25MJ4H0M\SQLEXPRESS; database =教学系统; Trusted_Connection=SSPI";
                string connStr2 = "Server ='" + IPAddress.ip + "'; database =测试数据库; uid =sa; pwd=1738010002";
                myConnection2 = new SqlConnection(connStr2);
                try
                {
                    myConnection2.Open();
                }
                catch
                {
                    MessageBox.Show("连接失败");
                }
                string RemindContent2 = RemindContent.Text.ToString();
                string RemindTime2 = Year.Text.ToString().Trim() + "." + Month.Text.ToString().Trim() + "." + Day.Text.ToString().Trim() + " " + Hour.Text.ToString().Trim() + ":" + Minute.Text.ToString().Trim() + ":00";
                //将提醒上传到数据库 
                // RemindContent2为提醒的内容RemindTime2为提醒的时间        
                SqlCommand cmd4 = new SqlCommand("insert into xxb(发送方,接收方,消息内容,时间,状态) values ('" + Send.Trim() + "','" + infoList[i].UserCode.ToString().Trim()+ "','" + RemindContent2.Trim() + "','" + RemindTime2 + "','" + 0 + "')", myConnection2);
                cmd4.ExecuteNonQuery();
                myConnection2.Close();
                myConnection2.Dispose();
            }
            sdr3.Close();
            myConnection.Close();
            myConnection.Dispose();            
            MessageBox.Show("定时消息设置成功");
        }

    }
}
