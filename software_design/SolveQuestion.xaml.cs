///<summary>

///模块编号：<SolveQuestion>

///作用：<教师问题回答界面>

///作者:肖鑫、田彬洋

///编写日期<2019-11-20>

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
    /// SolveQuestion.xaml 的交互逻辑
    /// </summary>
    public partial class SolveQuestion : Window
    {
        public SolveQuestion()
        {
            //显示问题和姓名
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            string n1 = QuesAns.QuestionUser;
            string QuestionUser1 = n1.ToString();
            string n2 = QuesAns.Question;
            string Question1 = n2.ToString();
            question.Text = Question1;
        }
        /// <summary>
        /// 点击上传问题答案
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ans.Text.Trim().Length != 0)
            //数据库连接

            {
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
                //Answer为答案内容
                string Answer = ans.Text;
                string Statue = "已解决";
                //更新该问题的答案为Answer
                SqlCommand cmd = new SqlCommand("update wtb set 答案='" + Answer + "' where 学号='" + QuesAns.QuestionUser + "'and 问题 = '" + QuesAns.Question + "'", myConnection);
                cmd.ExecuteNonQuery();
                //更新状态为已解决
                SqlCommand cmd2 = new SqlCommand("update wtb set 状态='" + Statue + "' where 学号='" + QuesAns.QuestionUser + "'and 问题 = '" + QuesAns.Question + "'", myConnection);
                MessageBox.Show("提交成功");
                cmd2.ExecuteNonQuery();
                myConnection.Close();
                myConnection.Dispose();
                Window window = Window.GetWindow(this);//关闭父窗体
                window.Close();
            }
            else
            {
                MessageBox.Show("答案不能为空");
            }
        }

        private void ans_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
