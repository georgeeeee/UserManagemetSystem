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
    public partial class FrmForgotPwd : Form
    {
        //获取一个日志记录器
        log4net.ILog log = log4net.LogManager.GetLogger("testApp.Logging");
        string connStr = ConfigurationManager.ConnectionStrings["str"].ConnectionString;

        public FrmForgotPwd()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// 点击返回按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRtn_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();
            Hide();
        }

        /// <summary>
        /// 点击确认修改按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCfm_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                //打开数据库连接
                conn.Open();
                string sql = "select id from dbo.Account " +
                    "where username = '" + username + "'" +
                    "and type = 'NormalUser'";
                try
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                MessageBox.Show("用户名不存在");
                                //日志记录
                                log.Info(new LogContent(username, "修改密码", "NormalUser", "用户名不存在"));
                            }
                            else
                            {
                                if (txtPwd.Text.Trim() != txtCfm.Text.Trim())
                                {
                                    MessageBox.Show("确认密码不一致");
                                    //日志记录
                                    log.Info(new LogContent(username, "修改密码", "NormalUser", "确认密码不一致"));
                                }
                                else
                                {
                                    reader.Close();
                                    FrmLogin frmLogin = new FrmLogin();
                                    frmLogin.Show();
                                    Hide();
                                    //插入新密码
                                    string sqlUpdate = "update Account set password = '" + txtPwd.Text + "'" +
                                                            "where username = '" + username + "'";
                                    if (new SqlCommand(sqlUpdate, conn).ExecuteNonQuery() >= 0)
                                    {
                                        MessageBox.Show("密码修改成功！");
                                        //日志记录
                                        log.Info(new LogContent(username, "修改密码", "NormalUser", "密码修改成功"));
                                    }
                                    else
                                    {
                                        MessageBox.Show("密码修改失败");
                                        //日志记录
                                        log.Info(new LogContent(username, "修改密码", "NormalUser", "密码修改失败"));
                                    }
                                }
                            }
                        }
                    }
                } catch(Exception error)
                {
                    //日志记录
                    log.Error(new LogContent(username, "修改密码", "NormalUser", error.Message));
                }   
            }
        }
    }
}
