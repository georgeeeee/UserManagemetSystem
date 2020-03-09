using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test2
{
    public partial class FrmLog : Form
    {
        log4net.ILog log;

        public FrmLog()
        {
            InitializeComponent();
            log = log4net.LogManager.GetLogger("testApp.Logging");
            StartPosition = FormStartPosition.CenterScreen;
            //动态设置datagridview列宽
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }
        //连接字符串 获取配置文件里的连接路径
        static string connStr = ConfigurationManager.ConnectionStrings["str"].ConnectionString;
        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmMain main = new FrmMain();
            main.Show();
            this.Close();
        }

        private void FrmLog_Load(object sender, EventArgs e)
        {
            //将数据显示到DataGridView上
            ShowMsg();
        }

        //写一个窗体加载自动从数据库获取数据并显示在datagridview的方法
        public void ShowMsg()
        {
            string showSql = "select id,level,username,action,time,userType,logMessage from Log";
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(showSql, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            dgv.DataSource = dt;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //日志记录
            log.Info(new LogContent(FrmLogin.Uid, "查看日志", FrmLogin.UserType, "退出"));
            Application.Exit();
        }

        // 日志查询
        public void btnlogQuery_Click(object sender, EventArgs e)
        {
            string showSql = "";
            if (txtlogQuery.Text.Trim() == "")
            {
                showSql = "select * from Log";
            }
            else
            {
                showSql = "select * from Log where(id like'%" + txtlogQuery.Text.Trim() +
                "%')or(username like'%" + txtlogQuery.Text.Trim() + "%')or(action like'%"
                + txtlogQuery.Text.Trim() + "%')or(time like'%" + txtlogQuery.Text.Trim() + "%')";
            }
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(showSql, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            dgv.DataSource = dt;

            //日志记录
            log.Info(new LogContent(FrmLogin.Uid, "查看日志", FrmLogin.UserType, "搜索关键字：" + txtlogQuery.Text.Trim()));
        }

        public void ExpToExcel()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                string localFilePath = "";
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel Files(07版本 *.xlsx)|*.xlsx|(03版本 *.xls)|*.xls|所有文件(*.*)|*.*";
                sfd.FilterIndex = 1;
                sfd.RestoreDirectory = true;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    localFilePath = sfd.FileName.ToString(); //获得文件路径 
                }
                if (localFilePath == "")
                {
                    MessageBox.Show("未选择Excel文件");
                    return;
                }

                NopiExcel.TableToExcel(dgv, localFilePath);
            }
        }
    }
}
