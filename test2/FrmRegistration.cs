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
    public partial class FrmRegistration : Form
    {
        log4net.ILog log;

        public FrmRegistration()
        {
            InitializeComponent();
            log = log4net.LogManager.GetLogger("testApp.Logging");
            StartPosition = FormStartPosition.CenterScreen;
        }
        
        static string connStr = ConfigurationManager.ConnectionStrings["str"].ConnectionString;
        public void btnRegister_Click(object sender, EventArgs e)
        {

            string sql = "select username from Account where username='" + txtUid.Text + "'";
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.Read())
            {
                lblUidMsg.Text = "用户名已存在,请重新输入!";
                //日志记录
                log.Info(new LogContent(FrmLogin.Uid, "注册", FrmLogin.UserType, "用户名已存在"));

                return;
            }

            else if (txtUid.Text.Trim() == "")
            {
                lblUidMsg.Text = "用户名不能为空!";
                //日志记录
                log.Info(new LogContent(FrmLogin.Uid, "注册", FrmLogin.UserType, "用户名不能为空"));
            }

            else if (txtPwd.Text.Trim() == "")
            {
                lblPwdMsg.Text = "密码不能为空!";
                lblUidMsg.Text = "";
                log.Info(new LogContent(FrmLogin.Uid, "注册", FrmLogin.UserType, "密码不能为空"));
            }
            else if (txtPwdConfirm.Text.Trim() == "")
            {
                lblPwdConfirmMsg.Text = "验证密码不能为空!";
                lblUidMsg.Text = "";
                lblPwdMsg.Text = "";

                //日志记录
                log.Info(new LogContent(FrmLogin.Uid, "注册", FrmLogin.UserType, "验证密码不能为空"));
            }
            else if (txtPwd.Text.Trim() != txtPwdConfirm.Text.Trim())
            {
                lblPwdMsg.Text = "2次密码必须一样!";
                lblPwdConfirmMsg.Text = "请重新输入!";

                //日志记录
                log.Info(new LogContent(FrmLogin.Uid, "注册", FrmLogin.UserType, "两次密码不一致"));
                return;
            }
            else
            {
                lblUidMsg.Text = "";
                lblPwdMsg.Text = "";
                lblPwdConfirmMsg.Text = "";
                conn.Close();

                string uType = "";
                int rightFManager = 0;
                int rightFRegistration = 0;
                int rightFPwdChange = 0;
                int rightFLog = 0;

                if (rdoAdministrator.Checked)
                {
                    uType = "Administrator";
                    rightFManager = 1;
                    rightFRegistration = 1;
                    rightFPwdChange = 1;
                    rightFLog = 1;
                }
                else if (rdoNormalUser.Checked)
                {
                    uType = "NormalUser";
                }
                else
                {
                    uType = "NormalUser";
                }

                string sqlInsert = "insert into Account(username,password,type,rightFManager,rightFRegistration,rightFPwdChange,rightFLog) values(@username,@password,@type,@rightFManager,@rightFRegistration,@rightFPwdChange,@rightFLog)";
                SqlParameter[] param = {
                                        new SqlParameter("@username",txtUid.Text),
                                        new SqlParameter("@password",txtPwd.Text),
                                        new SqlParameter("@type",uType),
                                        new SqlParameter("@rightFManager",rightFManager),
                                        new SqlParameter("@rightFRegistration",rightFRegistration),
                                        new SqlParameter("@rightFPwdChange",rightFPwdChange),
                                        new SqlParameter("@rightFLog",rightFLog)
                                    };
                SqlConnection connInsert = new SqlConnection(connStr);
                SqlCommand cmdInsert = new SqlCommand(sqlInsert, connInsert);
                connInsert.Open();
                cmdInsert.Parameters.AddRange(param);
                int n = cmdInsert.ExecuteNonQuery();
                if (n == 0)
                {
                    MessageBox.Show("注册失败!,请重新输入");
                    log.Info(new LogContent(FrmLogin.Uid, "注册", FrmLogin.UserType, "注册失败"));
                    return;
                }
                else
                {
                    MessageBox.Show("注册成功!");

                    //日志记录
                    string logSql = "Select id from Account where username = '" + txtUid.Text + "'";
                    using (SqlCommand logCmd = new SqlCommand(logSql, connInsert))
                    {
                        using (SqlDataReader logReader = logCmd.ExecuteReader())
                        {
                            while (logReader.Read())
                            {
                                string id = logReader["id"].ToString();
                                log.Info(new LogContent(FrmLogin.Uid, "注册", FrmLogin.UserType, "注册成功，id=" + id));
                            }
                        }
                    }
                    txtUid.Text = "";
                    txtPwd.Text = "";
                    txtPwdConfirm.Text = "";
                }
                connInsert.Close();
            }
        }

        private void FrmRegistration_Load(object sender, EventArgs e)
        {
            lblUidMsg.Text = "";
            lblPwdMsg.Text = "";
            lblPwdConfirmMsg.Text = "";
            rdoNormalUser.Checked = true;
        }
    }
}
