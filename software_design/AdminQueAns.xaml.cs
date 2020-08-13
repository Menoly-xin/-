///<summary>

///模块编号：<AdminQueAns>

///作用：<查询日问题量和答疑率,并提醒教师参与答疑>

///作者：肖鑫,田彬洋

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

namespace software_design
{
    /// <summary>
    /// AdminQueAns.xaml 的交互逻辑
    /// </summary>
    public partial class AdminQueAns : Window
    {
        //infoList为问题列表
        List<TeaAnsQues> infoList = new List<TeaAnsQues>();
        /// <summary>
        /// 从数据库查询所有的问题并显示在界面上
        /// </summary>
        public AdminQueAns()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            string n = MainWindow.UserCode;
            string UserNameTea = n.ToString();
            //Stu为单个问题的信息集合
            TeaAnsQues Stu = new TeaAnsQues();
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
            //查询所有的问题
            SqlCommand cmd = new SqlCommand("select 问题,答案,状态,姓名,学号,时间,班级 from wtb", myConnection);
            SqlDataReader sdr = cmd.ExecuteReader();
            //count为已解决的问题数量,total为总问题数量,todaytotal为今日问题数量,QueAnsRate为答疑率
            float count =0;
            float total=0;
            int todaycount = 0;
            float QueAnsRate;
            DateTime now = DateTime.Now;
            //TimeSpan sub = DateTime.Parse(sdr[5].ToString()).Date - now.Date;
            //System.Data.Entity.DbFunctions.DiffDays(sdr[5].ToString()), DateTime.Now) == 0;
            //遍历读取所有的问题并将其加入到infoList问题列表
            while (sdr.Read())
            {
          
                //MessageBox.Show(sdr[5].ToString());
                TimeSpan sub = DateTime.Parse(sdr[5].ToString()).Date - now.Date;
                Stu.TeaStatus = sdr[2].ToString();
                Stu.TeaQuestion = sdr[0].ToString();
                Stu.TeaAnswer = sdr[1].ToString();
                Stu.TeaName = sdr[3].ToString();
                Stu.TeaUser = sdr[4].ToString();
                Stu.ClassName = sdr[6].ToString();
                Stu.Time = DateTime.Parse(sdr[5].ToString().Trim());
                //将单个问题添加到问题列表
                if (sdr[2].ToString().Trim().Equals("已解决") == true)
                {
                    
                }
                else
                {
                    infoList.Add(Stu);
                }

                //infoList.Sort(delegate (TeaAnsQues x, TeaAnsQues y)
                //{
                //return y.Time.CompareTo(x.Time);
                // });
                //MessageBox.Show(sdr[2].ToString().Equals("已解决").ToString());
                //如果问题状态为已解决 则count+1
                if (sdr[2].ToString().Trim().Equals("已解决")==true)
                {
                    count+=1;
                }
                //如果问题的创建时间为今天 则todaycount+1
                if (sub.Days==0)
                { 
                    todaycount+=1; 
                }
                total++;
            }
            //对所有的问题按时间进行排序
            infoList.Sort(delegate (TeaAnsQues x, TeaAnsQues y)
            {
                return y.Time.CompareTo(x.Time);
            });
            //计算答疑率
            QueAnsRate = count /total;
            //MessageBox.Show(count.ToString());
            DayQueTotal.Content = todaycount.ToString();
            AnsRate.Content = (QueAnsRate*100).ToString()+ "%";
            //绑定DG11 的数据源为问题列表
            DG11.AutoGenerateColumns = false;
            DG11.ItemsSource = infoList;
        }
        /// <summary>
        /// 对选中的问题给对应的教师发送答疑提醒
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
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
            string MessageTemp =null;
            string Statue = "答疑提醒";
            DateTime Time = DateTime.Now;
            //遍历问题列表查询哪些问题被管理员选中,如被选中则向对应的教师发送答疑提醒
            for (int i = 0; i < this.DG11.Items.Count; i++)
            {
                var cntr = DG11.ItemContainerGenerator.ContainerFromIndex(i);
                DataGridRow ObjROw = (DataGridRow)cntr;
                if (ObjROw != null)
                {
                    FrameworkElement objElement = DG11.Columns[5].GetCellContent(ObjROw);
                    if (objElement != null)
                    {
                        System.Windows.Controls.CheckBox objChk = (System.Windows.Controls.CheckBox)objElement;
                        //如果该问题的复选框被选中,则发送答疑提醒
                        if (objChk.IsChecked == true)
                        {
                            //通过该问题的对应的班级在数据库中查找该班级班主任的账户
                            SqlCommand cmd = new SqlCommand("select 职工号 from jsb where 管理班级 = '"+ infoList[i].ClassName+"'", myConnection);
                            SqlDataReader sdr = cmd.ExecuteReader();
                            sdr.Read();
                            //Code为班主任的账户名称
                            try
                            {
                                string Code = sdr[0].ToString();
                                sdr.Close();
                                //MessageTemp为答疑提醒的内容
                                MessageTemp = "您有问题需要回答:" + infoList[i].TeaQuestion;
                                //向班主任发送答疑提醒
                                SqlCommand cmd2 = new SqlCommand("insert into xxb(发送方,接收方,消息内容,时间,状态) values ('" + Statue + "','" + Code + "','" + MessageTemp + "','" + Time.ToString() + "','" + 0 + "')", myConnection);
                                cmd2.ExecuteNonQuery();                               
                            }

                            catch { };
                            sdr.Close();

                        }
                    }
                }
            }
            MessageBox.Show("发送成功");
            myConnection.Close();
            myConnection.Dispose();
            //关闭连接
        }
    }
}
