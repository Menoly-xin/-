///<summary>

///模块编号：<InfChangeStu>

///作用：<学生修改个人信息以及密码，此界面可实现学生修改个人信息以及密码>

///作者：朱立新、肖鑫

///编写日期<2019-10-28>

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
    /// <summary>
    /// InfChangeStu.xaml 的交互逻辑
    /// </summary>
    public partial class InfChangeStu : Window
    {
        ///<summary>

        ///修改个人信息界面初始化，将对应框架中打印对应的个人信息。若未设置个人信息，则打印"未设置"

        ///</summary>
        public InfChangeStu()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            string n = MainWindow.UserCode;
            //UserNameStu为登录用户名
            string UserNameStu = n.ToString();

            #region 连接数据库
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

            //根据UserNameStu（登录用户名）选择出对应的个人信息
            SqlCommand cmd = new SqlCommand("select 姓名,班级,邮箱,性别 from xsb where 学号 = '" + UserNameStu + "'", myConnection);
            SqlDataReader sdr = cmd.ExecuteReader();
            //读取并存储个人信息在sdr中
            sdr.Read();
            //判断个人信息，若为空，则打印"未设置"；否则将信息打印在对应个人信息框中
            if (sdr[0].ToString() == null)
            {
                //姓名为空时
                InfName.Text = "未设置";
            }
            else
            {
                //姓名不为空，打印教师姓名
                InfName.Text = sdr[0].ToString();
            }

            if (sdr[1].ToString() == null)
            {
                //班级为空时
                InfClass.Text = "未设置";
            }
            else
            {
                //班级不为空，打印班级
                InfClass.Text = sdr[1].ToString();
            }
            if (sdr[3].ToString() == null)
            {
                //性别为空时
                InfSex.Text = "未设置";
            }
            else
            {
                //性别不为空，打印教师性别
                InfSex.Text = sdr[3].ToString();
            }
            //由于邮箱在注册时已填写，故不必判断是否为空，可直接打印
            InfEmail.Text = sdr[2].ToString();
            sdr.Close();
            //关闭数据库连接
            myConnection.Close();
        }
        /// <summary>
        /// 点击姓名对应的"修改"按键，对输入信息长度进行判断，若不合法则提醒，否则修改成功
        /// </summary>
        private void ButtonName_Click(object sender, RoutedEventArgs e)
        {
            //对输入信息长度进行判断,若长度不合法，进行提醒
            if (InfName.Text.Trim().Length >= 10)
            {
                MessageBox.Show("名字输入过长,输入最多五个汉字");
            }
            else if (InfSex.Text.Length >= 10)
            {
                MessageBox.Show("性别输入过长,输入最多五个汉字");
            }
            else if (InfClass.Text.Trim().Length >= 10)
            {
                MessageBox.Show("班级输入过长,输入类似\"电信1704\"的形式");
            }
            else if (InfEmail.Text.Trim().Length >= 1000)
            {
                MessageBox.Show("邮箱输入过长");
            }
            else
            {
                SqlConnection myConnection;
                string n = MainWindow.UserCode;
                //UserNameStu为登录用户名
                string UserNameStu = n.ToString();

                #region 连接数据库
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

                //更新信息
                string myUpdate = "update xsb set 姓名 = '" + InfName.Text.Trim() + "',性别 = '" + InfSex.Text + "',班级 = '" + InfClass.Text.Trim() + "',邮箱 = '" + InfEmail.Text.Trim() + "' where 学号 = '" + UserNameStu + "'";
                SqlCommand myCom = new SqlCommand(myUpdate, myConnection);
                myCom.ExecuteNonQuery();
                //关闭数据库连接
                myConnection.Close();
                myConnection.Dispose();
                MessageBox.Show("更改成功！");
            }

        }
        /// <summary>
        /// 点击密码对应的"修改"按键，对输入信息长度、旧密码的正确性以及两次输入密码一致性进行判断，若不合法则提醒，否则修改成功
        /// </summary>  
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection myConnection;
            string n = MainWindow.UserCode;
            //UserNameStu为登录用户名
            string UserNameStu = n.ToString();

            #region 连接数据库
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

            //通过用户名来获取旧密码
            SqlCommand cmd = new SqlCommand("select * from xsb where 学号 = '" + UserNameStu + "'and 密码 = '"+InfOldPas.Text+"' ", myConnection);
            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            //sdr.Close();
            //if (string.Equals(sdr["学号"].ToString()+ sdr["密保"].ToString()+ sdr["密保答案"].ToString(), UserName + ForgetSecurityQs + ForgetSecurityAns))
            //判断密码的合法性
            if (sdr.HasRows)
            {
                if (InfNewPas.Text.Equals(InfComPas.Text) == false)
                {
                    //两次密码输入不一致，提醒
                    MessageBox.Show("新密码与确认密码不一致！");
                    sdr.Close();
                    //关闭数据库连接
                    myConnection.Close();
                    myConnection.Dispose();
                }
                else
                {
                    //更新密码
                    sdr.Close();
                    string myUpdate = "update xsb set 密码='" + InfNewPas.Text + "' where 学号='" + UserNameStu + "'";
                    //string myInsert = "insert into xsb(学号,密码,邮箱,密保,密保答案) values ('" + UserName + "','" + Passwd + "','" + Email + "','" + PasQuestion + "','" + PasAns + "')";
                    SqlCommand myCom = new SqlCommand(myUpdate, myConnection);
                    myCom.ExecuteNonQuery();
                    //关闭数据库连接
                    myConnection.Close();
                    myConnection.Dispose();
                    MessageBox.Show("密码更改成功！");
                }
            }
            else
            {
                //输入的旧密码跟数据库中的密码不一致
                MessageBox.Show("密码错误！修改失败");
                sdr.Close();
                //关闭数据库连接
                myConnection.Close();
                myConnection.Dispose();
            }
        }
    }
}
