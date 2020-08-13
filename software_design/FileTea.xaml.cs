///<summary>

///模块编号：<FileTea>

///作用：<教师的文件上传界面>

///作者:肖鑫,朱立新,田彬洋

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
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Windows.Threading;

namespace software_design
{
    /// <summary>
    /// FileTea.xaml 的交互逻辑
    /// </summary>
    public partial class FileTea : Window
    {        
        //infoList为所有文件的集合
        List<Filename> infoList = new List<Filename>();
        public FileTea()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //Stu为单个文件的信息集
            Filename Stu = new Filename();
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
            //从服务器中查询所有文件的列表
            SqlCommand cmd2 = new SqlCommand("select 上传人,文件标题 from zyb", myConnection);
            SqlDataReader sdr2 = cmd2.ExecuteReader();
            //循环读取数据库文件并将其添加到文件列表
            while (sdr2.Read())
            {
                Stu.Uploader = sdr2[0].ToString();
                Stu.File_Name = sdr2[1].ToString();
                infoList.Add(Stu);
            }
            sdr2.Close();
            myConnection.Close();
            //关闭数据库连接
            myConnection.Dispose();
            //绑定datagrid的数据源为文件列表
            DG_FilStu.AutoGenerateColumns = false;
            DG_FilStu.ItemsSource = infoList;
        }
        /// <summary>
        /// 输入上传用户名来搜索文件
        /// </summary>
        private void SearchFile_Click(object sender, RoutedEventArgs e)
        {
            //清空文件列表
            infoList.Clear();
            //Stu为单个文件
            Filename Stu = new Filename();
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
            //从数据库读取上传人为输入值的文件
            SqlCommand cmd2 = new SqlCommand("select 上传人,文件标题 from zyb where 上传人 = '" + FileBox.Text + "'", myConnection);
            SqlDataReader sdr2 = cmd2.ExecuteReader();
            //循环读取文件并将其加入文件列表
            while (sdr2.Read())
            {
                Stu.Uploader = sdr2[0].ToString();
                Stu.File_Name = sdr2[1].ToString();
                infoList.Add(Stu);
            }
            sdr2.Close();
            myConnection.Close();
            myConnection.Dispose();
            //关闭连接
            //重新绑定datagrid数据源
            DG_FilStu.AutoGenerateColumns = false;
            DG_FilStu.ItemsSource = null;
            DG_FilStu.ItemsSource = infoList;
        }     
        /// <summary>
        /// 刷新文件列表
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //清空文件列表
            infoList.Clear();
            //Stu为单个文件
            Filename Stu = new Filename();
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
            //从数据库查询所有的文件
            SqlCommand cmd2 = new SqlCommand("select 上传人,文件标题 from zyb", myConnection);
            SqlDataReader sdr2 = cmd2.ExecuteReader();
            //循环读取文件并将其加入文件列表
            while (sdr2.Read())
            {
                Stu.Uploader = sdr2[0].ToString();
                Stu.File_Name = sdr2[1].ToString();
                infoList.Add(Stu);
            }
            sdr2.Close();
            myConnection.Close();
            //关闭连接
            myConnection.Dispose();
            //重新绑定datagird数据源为文件列表
            DG_FilStu.AutoGenerateColumns = false;
            DG_FilStu.ItemsSource = null;
            DG_FilStu.ItemsSource = infoList;
        }
        /// <summary>
        /// 点击上传文件到服务器
        /// </summary>
        private void Upload_Click(object sender, RoutedEventArgs e)
        {
            //打开文件对话框
            Microsoft.Win32.OpenFileDialog op = new Microsoft.Win32.OpenFileDialog();
            //默认文件夹为c盘
            op.InitialDirectory = @"c:\";
            op.RestoreDirectory = true;
            //op.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            op.Filter = "所有文件(*.*)|*.*";
            //弹出文件对话框
            op.ShowDialog();
            if (op.FileName.Length == 0)
            {
                MessageBox.Show("已取消上传");
            }
            else
            {
                //TextBox1.Text = op.FileName;
                //fs为该文件路径下的文件的比特流
                string FIleName = System.IO.Path.GetFileNameWithoutExtension(op.FileName) + System.IO.Path.GetExtension(op.FileName);//文件名没有扩展名       
                                                                                                                                     //MessageBox.Show(FIleName);
                FileStream fs = new FileStream(op.FileName, FileMode.Open);
                BinaryReader br = new BinaryReader(fs);
                Byte[] byData = br.ReadBytes((int)fs.Length);
                fs.Close();

                string conn = "Server ='" + IPAddress.ip + "'; database =测试数据库; uid =sa; pwd=1738010002";

                SqlConnection myconn = new SqlConnection(conn);
                myconn.Open();
                //上传比特流到数据库
                string str = "insert into zyb (文件标题,上传人,文件) values('" + FIleName + "','" + MainWindow.UserCode + "',@file)";
                SqlCommand mycomm = new SqlCommand(str, myconn);
                mycomm.Parameters.Add("@file", SqlDbType.Binary, byData.Length);
                mycomm.Parameters["@file"].Value = byData;
                mycomm.ExecuteNonQuery();
                myconn.Close();
                MessageBox.Show("上传成功");
                Button_Click(null, null);
            }
        }
        /// <summary>
        /// 下载文件
        /// </summary>
        private void download_Click(object sender, RoutedEventArgs e)
        {
            //查询文件列表并确认哪些文件被选中
            for (int i = 0; i < this.DG_FilStu.Items.Count; i++)
            {
                var cntr = DG_FilStu.ItemContainerGenerator.ContainerFromIndex(i);
                DataGridRow ObjROw = (DataGridRow)cntr;
                if (ObjROw != null)
                {
                    FrameworkElement objElement = DG_FilStu.Columns[2].GetCellContent(ObjROw);
                    if (objElement != null)
                    {
                        System.Windows.Controls.CheckBox objChk = (System.Windows.Controls.CheckBox)objElement;
                        //如果该文件的复选框为选中,则下载该文件
                        if (objChk.IsChecked == true)
                        {
                            //从数据库中下载文件名为infoList[i].File_Name的文件
                            string conn = "Server ='" + IPAddress.ip + "'; database =测试数据库; uid =sa; pwd=1738010002";
                            string str = "select 文件 from zyb where 文件标题= '" + infoList[i].File_Name + "'";
                            SqlConnection myconn = new SqlConnection(conn);
                            SqlDataAdapter sda = new SqlDataAdapter(str, conn);
                            DataSet myds = new DataSet();
                            myconn.Open();
                            sda.Fill(myds);
                            myconn.Close();
                            Microsoft.Win32.SaveFileDialog op = new Microsoft.Win32.SaveFileDialog();
                            //默认文件夹为c盘
                            op.InitialDirectory = @"c:\";
                            op.RestoreDirectory = true;
                            //op.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
                            op.FileName = infoList[i].File_Name;
                            op.Filter = "所有文件(*.*)|*.*";
                            //显示下载文件对话框
                            op.ShowDialog();
                            //TextBox1.Text = op.FileName;
                            if (op.FileName == infoList[i].File_Name)
                            {
                                MessageBox.Show("已取消下载");
                            }
                            else
                            {
                                //从数据库读取文件类型和比特流,然后将其下载到选中的路径
                                Byte[] Files = (Byte[])myds.Tables[0].Rows[0]["文件"];
                                string path = op.FileName;
                                BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate));
                                bw.Write(Files);
                                bw.Close();
                                MessageBox.Show("文件下载成功");
                            }
                        }
                    }
                }
            }
        }
    }
}
