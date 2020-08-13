///<summary>

///模块编号：<AdminInfTeaChange>

///作用：<教师信息修改>

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
    /// <summary>
    /// AdminInfTeaChange.xaml 的交互逻辑
    /// </summary>
    public partial class AdminInfTeaChange : Window
    {
        /// <summary>
        /// 查询需要修改的老师的信息并展示在该界面
        /// </summary>
        public AdminInfTeaChange()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //AdminStu.GroupUserAdmin为前一界面选中的学生学号
            string n = AdminTea.GroupUserAdminTea;
            string UserNameTea = n.ToString();
            #region 数据库连接
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
            //从数据库查询该教师的信息并显示在界面上
            SqlCommand cmd = new SqlCommand("select 姓名,管理班级,邮箱,性别 from jsb where 职工号 = '" + UserNameTea + "'", myConnection);
            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            if (sdr[0].ToString() == null)
            {
                InfName.Text = "未设置";
            }
            else
            {
                InfName.Text = sdr[0].ToString();
            }

            if (sdr[1].ToString() == null)
            {
                InfClass.Text = "未设置";
            }
            else
            {
                InfClass.Text = sdr[1].ToString();
            }
            if (sdr[3].ToString() == null)
            {
                InfSex.Text = "未设置";
            }
            else
            {
                InfSex.Text = sdr[3].ToString();
            }
            InfEmail.Text = sdr[2].ToString();
            sdr.Close();
            //关闭连接
            myConnection.Close();
        }
        /// <summary>
        /// 修改姓名
        /// </summary>
        private void ButtonName_Click(object sender, RoutedEventArgs e)
        {
            //判断输入的长度以防数据溢出
            if (InfName.Text.Trim().Length >= 10)
            {
                MessageBox.Show("输入过长,输入最多五个汉字");
            }
            else
            {
                #region 数据库连接
                SqlConnection myConnection;
                //n为上一界面选中的职工号
                string n = AdminTea.GroupUserAdminTea;
                string UserNameTea = n.ToString();
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
                //修改数据库中的姓名
                string myUpdate = "update jsb set 姓名 = '" + InfName.Text.Trim() + "' where 职工号 = '" + UserNameTea + "'";
                SqlCommand myCom = new SqlCommand(myUpdate, myConnection);
                myCom.ExecuteNonQuery();
                myConnection.Close();
                myConnection.Dispose();
                //关闭连接
                MessageBox.Show("更改成功！");
            }

        }
        /// <summary>
        /// 修改性别
        /// </summary>
        private void ButtonSex_Click(object sender, RoutedEventArgs e)
        {
            //判断输入的长度以防数据溢出
            if (InfSex.Text.Length >= 10)
            {
                MessageBox.Show("输入过长,输入最多五个汉字");
            }
            else
            {
                #region 数据库连接
                SqlConnection myConnection;
                //n为上一界面选中的职工号
                string n = AdminTea.GroupUserAdminTea;
                string UserNameTea = n.ToString();
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
                //修改数据库中的性别
                string myUpdate = "update jsb set 性别 = '" + InfSex.Text + "' where 职工号 = '" + UserNameTea + "'";
                SqlCommand myCom = new SqlCommand(myUpdate, myConnection);
                myCom.ExecuteNonQuery();
                myConnection.Close();
                myConnection.Dispose();
                //关闭连接
                MessageBox.Show("更改成功！");
            }

        }
        /// <summary>
        /// 修改班级
        /// </summary>
        private void BUttonClass_Click(object sender, RoutedEventArgs e)
        {
            //判断输入的长度以防数据溢出
            if (InfClass.Text.Trim().Length >= 10)
            {
                MessageBox.Show("输入过长,输入类似\"电信1704\"的形式");
            }
            else
            {
                #region 数据库连接
                SqlConnection myConnection;
                //n为上一界面选中的职工号
                string n = AdminTea.GroupUserAdminTea;
                string UserNameTea = n.ToString();
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
                //修改数据库中的班级
                string myUpdate = "update xsb set 管理班级 = '" + InfClass.Text.Trim() + "' where 职工号 = '" + UserNameTea + "'";
                SqlCommand myCom = new SqlCommand(myUpdate, myConnection);
                myCom.ExecuteNonQuery();
                myConnection.Close();
                myConnection.Dispose();
                //关闭连接
                MessageBox.Show("更改成功！");
            }
        }
        /// <summary>
        /// 修改邮箱
        /// </summary>
        private void ButtonEmail_Click(object sender, RoutedEventArgs e)
        {
            //判断输入的长度以防数据溢出
            if (InfEmail.Text.Trim().Length >= 1000)
            {
                MessageBox.Show("输入过长");
            }
            else
            {
                #region 数据库连接
                SqlConnection myConnection;
                //n为上一界面选中的职工号
                string n = AdminTea.GroupUserAdminTea;
                string UserNameTea = n.ToString();
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
                //修改数据库中的邮箱
                string myUpdate = "update xsb set 邮箱 = '" + InfEmail.Text.Trim() + "' where 职工号 = '" + UserNameTea + "'";
                SqlCommand myCom = new SqlCommand(myUpdate, myConnection);
                myCom.ExecuteNonQuery();
                myConnection.Close();
                myConnection.Dispose();
                //关闭连接
                MessageBox.Show("更改成功！");
            }
        }
    }
}
