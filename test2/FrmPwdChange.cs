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
    public partial class FrmPwdChange : Form
    {
        log4net.ILog log;

        public FrmPwdChange()
        {
            InitializeComponent();
            log = log4net.LogManager.GetLogger("testApp.Logging");
            StartPosition = FormStartPosition.CenterScreen;
        }
        static string connStr = ConfigurationManager.ConnectionStrings["str"].ConnectionString;

        private void FrmPwdChange_Load(object sender, EventArgs e)
        {
            string currentUser = FrmLogin.Uid;
            txtUsername.Text = currentUser;
        }

        public void btnOK_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connStr);
            string sql = "select password from Account where username ='" + txtUsername.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                string oldPwd = sdr.GetString(0).Trim();
                if (oldPwd == txtOldPwd.Text)
                {
                    if (txtNewPwd.Text.Trim() == "" || txtNewPwdConfirm.Text.Trim() == "")
                    {
                        MessageBox.Show("新密码确认不能为空!");

                        //日志记录
                        log.Info(new LogContent(FrmLogin.Uid, "修改密码", FrmLogin.UserType, "新密码不能为空"));
                        return;
                    }
                    //继续判断 如果2次新密码不相同
                    else if (txtNewPwd.Text.Trim() != txtNewPwdConfirm.Text.Trim())
                    {
                        MessageBox.Show("2次输入的新密码不一样,请重新输入!");
                        txtNewPwd.Text = "";
                        txtNewPwdConfirm.Text = "";

                        //日志记录
                        log.Info(new LogContent(FrmLogin.Uid, "修改密码", FrmLogin.UserType, "2次输入的新密码不一样，请重新输入"));
                        return;
                    }
                    else
                    {
                        sdr.Close();
                        string sqlUpdate = "update Account set password ='" + txtNewPwdConfirm.Text +
                        "' where username ='" + txtUsername.Text + "'";
                        SqlCommand cmdUp = new SqlCommand(sqlUpdate, conn);
                        if (cmdUp.ExecuteNonQuery() == 0)
                        {
                            MessageBox.Show("未知错误!");
                            return;
                        }
                        else
                        {
                            MessageBox.Show("恭喜你!密码修改成功!");
                            //日志记录
                            log.Info(new LogContent(FrmLogin.Uid, "修改密码", FrmLogin.UserType, "修改成功"));
                        }

                    }
                }
                else
                {
                    MessageBox.Show("旧密码错误或者不能为空");
                    txtOldPwd.Text = "";
                    txtNewPwd.Text = "";
                    txtNewPwdConfirm.Text = "";

                    //日志记录
                    log.Info(new LogContent(FrmLogin.Uid, "修改密码", FrmLogin.UserType, "旧密码错误或者不能为空"));
                    return;
                }
            }
            else
            {
                MessageBox.Show("用户名不存在,请重新输入!");
                txtUsername.Text = "";
                txtOldPwd.Text = "";
                txtNewPwd.Text = "";
                txtNewPwdConfirm.Text = "";

                //日志记录
                log.Info(new LogContent(FrmLogin.Uid, "修改密码", FrmLogin.UserType, "用户名不存在"));
                return;
            }
            //关闭数据库连接
            conn.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmMain main = new FrmMain();
            main.Show();
            this.Close();
            log.Info(new LogContent(FrmLogin.Uid, "修改密码", FrmLogin.UserType, "返回主菜单"));
        }
    }
}
