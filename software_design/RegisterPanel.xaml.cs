///<summary>

///模块编号：<RegisterPanel>

///作用：<注册界面>

///作者:肖鑫,朱立新,田彬洋

///编写日期<2019-01-07>

///</summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;


namespace software_design
{
    /// <summary>
    /// RegisterPanel.xaml 的交互逻辑
    /// </summary>
    public partial class RegisterPanel : Window
    {
        public RegisterPanel()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        /// <summary>
        /// 点击进行组测
        /// </summary>
        private void UploadClick(object sender, RoutedEventArgs e)
        {
            //UserName,Passwd,ConfirmPas,Email等分别为用户账户名,密码,确认密码,邮箱等
            string UserName = UserContent.Text.Trim();
            string Passwd = PasswordContent.Password.Trim();
            string ConfirmPas = ConfirmContent.Password.Trim();
            string Email = EmailContent.Text.Trim();           
            string IDVerify = ID.Text.Trim();
            //查询是否为空
            if (String.IsNullOrEmpty(UserName) || String.IsNullOrEmpty(Passwd) ||
               String.IsNullOrEmpty(ConfirmPas))
            {
                MessageBox.Show("用户名或密码不能为空！");
                return ;
            }


            //查询是否为空
            Regex regex = new Regex(@"\bU\S*");
            if ((regex.IsMatch(UserName)) == false)
            {
                MessageBox.Show("用户名不符合规范！");
                return;
            }

            if ((UserName.Length) != 10)
            {
                MessageBox.Show("用户名长度不符合规范！");
                return;
            }

            Regex RegEmail = new Regex(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");//w 英文字母或数字的字符串，和 [a-zA-Z0-9] 语法一样 
            Match m = RegEmail.Match(Email);
            if (m.Success)
            {

            }
            else 
            {
                MessageBox.Show("邮箱格式不正确");
                return;
            }


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
            //如果选中身份为学生,则注册为学生
            if (IDVerify.Equals("学生"))
            {
                //查询用户名是否已经存在
                SqlCommand cmd = new SqlCommand("select * from xsb where 学号 = '" + UserName + "'", myConnection);
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                //如果存在则报错
                if (sdr.HasRows)
                {
                    MessageBox.Show("该用户已注册，请直接登录", "提示");
                    myConnection.Close();
                    myConnection.Dispose();
                    return;
                }
                //否则注册为学生
                else
                {
                    sdr.Close();
                    if (Passwd.Equals(ConfirmPas))
                    {
                        //将信息上传到数据库
                        try
                        {
                            string myInsert = "insert into xsb(学号,密码,邮箱) values ('" + UserName + "','" + Passwd + "','" + Email + "')";
                            SqlCommand myCom = new SqlCommand(myInsert, myConnection);
                            myCom.ExecuteNonQuery();
                            myConnection.Close();
                            myConnection.Dispose();
                            MessageBox.Show("您已注册成功！");
                        }
                        catch
                        {
                            MessageBox.Show("输入过长,注册失败");
                            myConnection.Close();
                            myConnection.Dispose();
                            return;
                        }
                    }
                    else 
                    {
                        MessageBox.Show("密码不一致");
                        myConnection.Close();
                        myConnection.Dispose();
                        return;
                    }

                }
            }
            //该功能已经禁用
            else if (IDVerify.Equals("老师"))
            {
                MessageBox.Show("该功能已禁用,如需注册为教师请联系管理员");
                myConnection.Close();
                myConnection.Dispose();
                return;
                //SqlCommand cmd = new SqlCommand("select * from jsb where 职工号 = '" + UserName + "'", myConnection);
                //SqlDataReader sdr = cmd.ExecuteReader();
                //sdr.Read();
                //if (sdr.HasRows)
                //{
                //  MessageBox.Show("该用户已注册，请直接登录", "提示");
                //}
                //else
                //{
                //  sdr.Close();
                //string myInsert = "insert into jsb(职工号,密码,邮箱,密保,密保答案) values ('" + UserName + "','" + Passwd + "','" + Email + "','" + PasQuestion + "','" + PasAns + "')";
                //SqlCommand myCom = new SqlCommand(myInsert, myConnection);
                //myCom.ExecuteNonQuery();
                //myConnection.Close();
                //myConnection.Dispose();
                //MessageBox.Show("您已注册成功！");

                //}
            }
            
        }
        
    }
}