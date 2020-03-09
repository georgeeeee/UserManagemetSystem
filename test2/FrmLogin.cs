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
    public partial class FrmLogin : Form
    {
        //获取一个日志记录器
        log4net.ILog log = log4net.LogManager.GetLogger("testApp.Logging");

        public FrmLogin()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        //用于连接配置文件App.config
        string connStr = ConfigurationManager.ConnectionStrings["str"].ConnectionString;
        
        //定义一个全局变量 Uid;
        //用于获取登录成功后的用户名
        public static string Uid;

        //定义一个全局变量 Time
        //用于获取登录成功后的用户的登录时间
        public static DateTime Time;

        //定义一个登录全局变量 用来获取 "登录" 或是"退出"
        public static string Situation;

        //定义一个全局变量UserType 用来获 登录用户的类型
        public static string UserType;

        //定义一个全局变量 数组FRight 来获取登录成功的普通用户功能权限
        public static int[] FRight;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "select password,type,rightFManager,rightFRegistration,rightFPwdChange,rightFLog from Account where username ='" + txtName.Text + "'";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read()) 
                        {
                            string pwd = sdr.GetString(0).Trim();
                            string uType = sdr.GetString(1);
                            if (pwd == txtPwd.Text)
                            {
                                Uid = txtName.Text;
                                Time = DateTime.Now;
                                Situation = "登录";
                                UserType = uType;
                                log.Info(new LogContent(FrmLogin.Uid, FrmLogin.Situation, UserType, "登录"));

                                //用户功能权限索引i  对应的数据读取器sdr里的索引是 是 i+2
                                //FRight[0] = sdr.GetInt32(2);   //RightFManager
                                //FRight[1] = sdr.GetInt32(3);   //RightFRegistration
                                //FRight[2] = sdr.GetInt32(4);   //RightFPwdChange
                                //FRight[3] = sdr.GetInt32(5);   //RightFLog

                                //如果用户为普通用户 则检查 其功能权限 管理员不被检查    
                                if (UserType == "NormalUser")
                                {
                                    FRight = new int[4];
                                    for (int i = 0; i < FRight.Length; i++)
                                    {
                                        if (sdr.GetInt32(i + 2) == 0)      //如果数据读取器中读到数据库中的权限值为0
                                        {
                                            FRight[i] = 0;                 //则赋给全局变量0  说明该功能被禁用   
                                        }
                                        else if (sdr.GetInt32(i + 2) == 1) //如果 为1 
                                        {
                                            FRight[i] = 1;                 //赋给全局变量1   该功能可用
                                        }
                                        else
                                        {
                                            FRight[i] = 0;                 //否则默认为0  该功能不可用
                                        }
                                    }
                                }

                                MessageBox.Show("系统登录成功,正在跳转主页面...");
                                FrmMain main = new FrmMain();
                                main.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("密码错误!请再次输入!");
                                txtPwd.Text = "";
                            }
                        }
                        else
                        {
                            MessageBox.Show("用户名不存在,请重新出入!");
                            txtName.Text = "";
                            txtPwd.Text = "";
                        }
                    }
                }
            }
        }

        private void btnForgetPwd_Click(object sender, EventArgs e)
        {
            FrmForgotPwd frmForgotPwd = new FrmForgotPwd();
            frmForgotPwd.Show();
            Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
