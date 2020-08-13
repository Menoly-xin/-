///<summary>

///模块编号：<ForgetPaswd>

///作用：<提供忘记密码功能>

///作者:肖鑫,朱立新

///编写日期<2019-01-07>
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace software_design
{
    /// <summary>
    /// ForgetPaswd.xaml 的交互逻辑
    /// </summary>
    public partial class ForgetPaswd : Window
    {
        public ForgetPaswd()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        /// <summary>
        /// 点击进入忘记密码判断程序 
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //UserName为用户名,Passwd为新密码,ConfirmPas为新密码的确认密码,IDVerify为身份,VeCode为验证码
            string UserName = ForgetUserContent.Text.Trim();
            string Passwd = ForgetPasword.Password.Trim();
            string ConfirmPas = ConfirmForgetPasswrd.Password.Trim();
            string VeCode = VerifyCode.Text.Trim();        
            string IDVerify = ForgetID.Text.Trim();

            //判断信息是否全部填写,如果不全则提示
            if (String.IsNullOrEmpty(UserName) || String.IsNullOrEmpty(Passwd) ||
               String.IsNullOrEmpty(ConfirmPas)|| String.IsNullOrEmpty(VeCode) || String.IsNullOrEmpty(IDVerify))
            {
                MessageBox.Show("信息填写不全");
                return;
            }


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
            //如果身份是学生,则查询学生表
            if (IDVerify.Equals("学生"))
            {
                //从学生表中查询学号为UserName的学号,密保,密保答案
                SqlCommand cmd = new SqlCommand("select 学号,密保,密保答案,验证码 from xsb where 学号 = '" + UserName + "' ", myConnection);
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                //如果验证码匹配
                if (VeCode.Equals(sdr[3].ToString().Trim()))
                {
                    //如果密码与确认密码不一致,则提示
                    if (Passwd.Equals(ConfirmPas) == false)
                    {
                        MessageBox.Show("密码不一致！");
                        sdr.Close();
                        myConnection.Close();
                        myConnection.Dispose();
                        return;

                    }
                    else
                    {
                        sdr.Close();
                        string RandCode = new Random(Guid.NewGuid().GetHashCode()).Next(9999, 19999).ToString();
                        //更新数据库学号为UserName的密码
                        string myUpdate = "update xsb set 密码 = '" + ConfirmPas + "' where 学号='" + UserName + "'";
                        //string myInsert = "insert into xsb(学号,密码,邮箱,密保,密保答案) values ('" + UserName + "','" + Passwd + "','" + Email + "','" + PasQuestion + "','" + PasAns + "')";
                        SqlCommand myCom = new SqlCommand(myUpdate, myConnection);
                        myCom.ExecuteNonQuery();
                        string myUpdate2 = "update xsb set 验证码 = '" + RandCode + "' where 学号='" + UserName + "'";
                        //string myInsert = "insert into xsb(学号,密码,邮箱,密保,密保答案) values ('" + UserName + "','" + Passwd + "','" + Email + "','" + PasQuestion + "','" + PasAns + "')";
                        SqlCommand myCom2 = new SqlCommand(myUpdate2, myConnection);
                        myCom2.ExecuteNonQuery();
                        myConnection.Close();
                        myConnection.Dispose();
                        MessageBox.Show("密码更改成功！");
                    }
                }
                else 
                {
                    MessageBox.Show("用户不存在或验证码错误！修改失败");
                    sdr.Close();
                    myConnection.Close();
                    myConnection.Dispose();
                    return;
                }
                
            }
            //如果身份是教师,则查询教师表          
            else
            {
                //从教师表中查询学号为UserName的学号,密保,密保答案
                SqlCommand cmd = new SqlCommand("select 职工号,密保,密保答案,验证码 from jsb where 职工号 = '" + UserName + "' ", myConnection);
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                //如果验证码匹配
                if (VeCode.Equals(sdr[3].ToString().Trim()))
                {
                    //如果密码与确认密码不一致,则提示
                    if (Passwd.Equals(ConfirmPas) == false)
                    {
                        MessageBox.Show("密码不一致！");
                        sdr.Close();
                        myConnection.Close();
                        myConnection.Dispose();
                        return;

                    }
                    else
                    {
                        sdr.Close();
                        string RandCode = new Random(Guid.NewGuid().GetHashCode()).Next(9999, 19999).ToString();
                        //更新数据库学号为UserName的密码
                        string myUpdate = "update jsb set 密码 = '" + ConfirmPas + "' where 职工号='" + UserName + "'";
                        //string myInsert = "insert into xsb(学号,密码,邮箱,密保,密保答案) values ('" + UserName + "','" + Passwd + "','" + Email + "','" + PasQuestion + "','" + PasAns + "')";
                        SqlCommand myCom = new SqlCommand(myUpdate, myConnection);
                        myCom.ExecuteNonQuery();
                        string myUpdate2 = "update jsb set 验证码 = '" + RandCode + "' where 职工号='" + UserName + "'";
                        //string myInsert = "insert into xsb(学号,密码,邮箱,密保,密保答案) values ('" + UserName + "','" + Passwd + "','" + Email + "','" + PasQuestion + "','" + PasAns + "')";
                        SqlCommand myCom2 = new SqlCommand(myUpdate2, myConnection);
                        myCom2.ExecuteNonQuery();
                        myConnection.Close();
                        myConnection.Dispose();
                        MessageBox.Show("密码更改成功！");
                    }
                }
                else
                {
                    MessageBox.Show("用户不存在或验证码错误！修改失败");
                    sdr.Close();
                    myConnection.Close();
                    myConnection.Dispose();
                    return;
                }
            }           
            Window window = Window.GetWindow(this);//关闭父窗体
            window.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
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
            string Email = null;
            string UserName = ForgetUserContent.Text.Trim();
            string IDVerify = ForgetID.Text.Trim();
            string RandCode = new Random(Guid.NewGuid().GetHashCode()).Next(1000, 9999).ToString();
            if (IDVerify.Equals("学生")==true)
            {
                try
                {
                    SqlCommand mycmd = new SqlCommand("select 邮箱 from xsb where 学号 = '" + UserName + "' ", myConnection);
                    SqlDataReader mysdr = mycmd.ExecuteReader();
                    mysdr.Read();
                    Email = mysdr[0].ToString();
                    mysdr.Close();
                }
                catch 
                {
                    MessageBox.Show("用户名不存在");
                    return;
                }

            }
            else if (IDVerify.Equals("老师")==true)
            {
                try
                {
                    SqlCommand mycmd = new SqlCommand("select 邮箱 from jsb where 职工号 = '" + UserName + "' ", myConnection);
                    SqlDataReader mysdr = mycmd.ExecuteReader();
                    mysdr.Read();
                    Email = mysdr[0].ToString();
                    mysdr.Close();
                }
                catch 
                {
                    MessageBox.Show("用户名不存在");
                    return;
                }
            }
            else
            {
                MessageBox.Show("请先选择身份");
            }          
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            Regex RegEmail = new Regex(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");//w 英文字母或数字的字符串，和 [a-zA-Z0-9] 语法一样 
            Match m = RegEmail.Match(Email.Trim());            
            if (m.Success)
            {
                try
                {
                    //MessageBox.Show(Email);
                    msg.To.Add(Email.Trim());
                }
                catch { }                
                msg.From = new MailAddress("sociaxiao@gmail.com", "StudentManage Service", System.Text.Encoding.UTF8);
                //邮件标题 
                msg.Subject = "Forgetting Emali Service";
                //邮件标题编码   
                msg.SubjectEncoding = System.Text.Encoding.UTF8;
                //邮件主体内容
                msg.Body = "YOUR VERIFYCODE IS " + RandCode;//邮件内容   
                                                                                                                                                        //邮件内容编码 
                msg.BodyEncoding = System.Text.Encoding.UTF8;
                //设置为HTML邮件   
                msg.IsBodyHtml = true;
                //设为最高优先级
                msg.Priority = MailPriority.High;
                SmtpClient client = new SmtpClient();
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("sociaxiao@gmail.com", "XxLkoJlm1234");
                //Gmail使用的端口 
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;//经过ssl加密   
                object userState = msg;
                try
                {
                    client.Send(msg);
                    MessageBox.Show("验证码已发送至邮箱,请注意查收");

                }
                catch (System.Net.Mail.SmtpException ex)
                {
                    MessageBox.Show(ex.Message, "发送邮件出错");
                }
                //string IDVerify 为选中的身份

                #region 数据库连接
                SqlConnection myConnection2;
                string connStr2 = "Server ='" + IPAddress.ip + "'; database =测试数据库; uid =sa; pwd=1738010002";
                //string connStr = @"Server =   LAPTOP-25MJ4H0M\SQLEXPRESS; database =教学系统; Trusted_Connection=SSPI";
                myConnection2 = new SqlConnection(connStr);
                try
                {
                    myConnection2.Open();
                }
                catch (Exception)
                {
                    MessageBox.Show("连接失败");
                }
                #endregion
                if (IDVerify.Equals("学生"))
                {
                    string myUpdate = "update xsb set 验证码 = '" + RandCode + "' where 学号 = '" + UserName + "'";
                    SqlCommand myCom2 = new SqlCommand(myUpdate, myConnection2);
                    myCom2.ExecuteNonQuery();
                }
                else 
                {
                    string myUpdate = "update jsb set 验证码 = '" + RandCode + "' where 职工号 = '" + UserName + "'";
                    SqlCommand myCom2 = new SqlCommand(myUpdate, myConnection2);
                    myCom2.ExecuteNonQuery();
                }
             

            }
            else
            {
                MessageBox.Show("邮箱格式不正确,请联系管理员");
            }
        }
        
    }  
}
