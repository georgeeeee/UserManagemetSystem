using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace test2
{
    public partial class FrmMain : Office2007Form
    {
        private log4net.ILog log;
        private FrmManager frmManager;
        private FrmUserManager userManager;
        private FrmRegistration registration;
        private FrmLog frmLog;
        private FrmPwdChange pwdChange;

        public FrmMain()
        {
            InitializeComponent();
            log = log4net.LogManager.GetLogger("testApp.Logging");
            StartPosition = FormStartPosition.CenterScreen;
            EnableGlass = false;
            ribbonTabItem1.Select();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            lblCurrentUser.Text = "当前登录用户为: " + FrmLogin.Uid + " 用户类型 " + FrmLogin.UserType + " 登录时间为:" + FrmLogin.Time;

            int intTime = FrmLogin.Time.Hour;
            string uType = FrmLogin.UserType;
            if (intTime >= 0 && intTime < 6)
            {
                if (uType == "Administrator")
                    lblSayHi.Text = "尊敬的  " + FrmLogin.Uid + " 深夜了,该休息了!";
                else if (uType == "NormalUser")
                    lblSayHi.Text = "亲爱的  " + FrmLogin.Uid + "凌晨了,要赶紧休息哦!";
            }
            else if (intTime >= 6 && intTime < 12)
            {
                if (uType == "Administrator")
                    lblSayHi.Text = "尊敬的  " + FrmLogin.Uid + "  早上好!";
                else if (uType == "NormalUser")
                    lblSayHi.Text = "亲爱的  " + FrmLogin.Uid + " 早上好!";
            }
            else if (intTime >= 12 && intTime < 18)
            {
                if (uType == "Administrator")
                    lblSayHi.Text = "尊敬的  " + FrmLogin.Uid + " 下午好!";
                else if (uType == "NormalUser")
                    lblSayHi.Text = "亲爱的  " + FrmLogin.Uid + " 下午好!";
            }
            //晚上
            else if (intTime >= 18 && intTime < 24)
            {
                if (uType == "Administrator")
                    lblSayHi.Text = "尊敬的  " + FrmLogin.Uid + " 晚上好!";
                else if (uType == "NormalUser")
                    lblSayHi.Text = "亲爱的  " + FrmLogin.Uid + " 晚上好!";
            }
            else  
                lblSayHi.Text = "欢迎使用简易学生管理系统" + FrmLogin.Uid;

            //窗体加载的时候 自动获取 并判断普通用户的功能权限

            //当用户为普通用户的时候 需要判断下其功能权限  管理员不接受检查
            if (uType == "NormalUser")
            {
                ribTabUser.Enabled = false;
                ribTabUser.Visible = false;
                if (FrmLogin.FRight[0] == 1) //对应的功能权限为1的时候 本功能开放   
                {
                    ribTabStu.Enabled = true;
                    ribTabStu.Visible = true;
                }
                else                        //否则 禁用本功能
                {
                    ribTabStu.Enabled = false;
                    ribTabStu.Visible = false;
                }
                if (FrmLogin.FRight[1] == 1)
                {
                    ribTabRegister.Enabled = true;
                    ribTabRegister.Visible = true;
                }
                else
                {
                    ribTabRegister.Enabled = false;
                    ribTabRegister.Visible = false;
                }
                if (FrmLogin.FRight[2] == 1)
                {
                    ribTabPwdChange.Enabled = true;
                    ribTabPwdChange.Visible = true;
                }
                else
                {
                    ribTabPwdChange.Enabled = false;
                    ribTabPwdChange.Visible = false;
                }
                if (FrmLogin.FRight[3] == 1)
                {
                    ribTabLog.Enabled = true;
                    ribTabLog.Visible = true;
                }
                else
                {
                    ribTabLog.Enabled = false;
                    ribTabLog.Visible = false;
                }
            }
            if (uType == "Administrator")
            {
                ribTabUser.Enabled = true;
                ribTabUser.Visible = true;
            }
        }

        private void ribTabStu_Click(object sender, EventArgs e)
        {
            ribPanelStu.Show();
            if (frmManager == null)
            {
                frmManager = new FrmManager();
                frmManager.TopLevel = false;
            }
            panel1.Controls.Clear();
            panel1.Controls.Add(frmManager);
            frmManager.Show();
            //日志记录
            log.Info(new LogContent(FrmLogin.Uid, "主菜单", FrmLogin.UserType, "管理界面"));
        }

        private void ribTabUser_Click(object sender, EventArgs e)
        {
            if (userManager == null)
            {
                userManager = new FrmUserManager();
                userManager.TopLevel = false;
            }
            panel1.Controls.Clear();
            panel1.Controls.Add(userManager);
            userManager.Show();
            //日志记录
            log.Info(new LogContent(FrmLogin.Uid, "主菜单", FrmLogin.UserType, "用户管理"));
        }

        private void ribTab_Click(object sender, EventArgs e)
        {
            if (registration == null)
            {
                registration = new FrmRegistration();
                registration.TopLevel = false;
            }
            panel1.Controls.Clear();
            panel1.Controls.Add(registration);
            registration.Show();
            //日志记录
            log.Info(new LogContent(FrmLogin.Uid, "主菜单", FrmLogin.UserType, "用户注册"));
        }

        private void ribTabLog_Click(object sender, EventArgs e)
        {
            if (frmLog == null)
            {
                frmLog = new FrmLog();
                frmLog.TopLevel = false;
            }
            panel1.Controls.Clear();
            panel1.Controls.Add(frmLog);
            frmLog.Show();
            //日志记录
            log.Info(new LogContent(FrmLogin.Uid, "主菜单", FrmLogin.UserType, "日志查询"));
        }

        private void ribTabPwdChange_Click(object sender, EventArgs e)
        {
            if (pwdChange == null)
            {
                pwdChange = new FrmPwdChange();
                pwdChange.TopLevel = false;
            }
            panel1.Controls.Clear();
            panel1.Controls.Add(pwdChange);
            pwdChange.Show();
            //日志记录
            log.Info(new LogContent(FrmLogin.Uid, "主菜单", FrmLogin.UserType, "修改密码"));
        }

        private void ribTabLogin_Click(object sender, EventArgs e)
        {
            FrmLogin login = new FrmLogin();
            login.Show();
            this.Hide();
            //日志记录
            log.Info(new LogContent(FrmLogin.Uid, "主菜单", FrmLogin.UserType, "重新登录"));
        }

        private void ribTabExit_Click(object sender, EventArgs e)
        {
            //日志记录
            log.Info(new LogContent(FrmLogin.Uid, "主菜单", FrmLogin.UserType, "退出程序"));
            //直接退出应用程序
            Application.Exit();
        }

        private void btnStuList_Click(object sender, EventArgs e)
        {
            frmManager.btnView_Click(sender, e);
        }

        private void btnStuAdd_Click(object sender, EventArgs e)
        {
            frmManager.btnAdd_Click(sender, e);
        }

        private void btnStuDel_Click(object sender, EventArgs e)
        {
            frmManager.btnDelete_Click(sender, e);
        }

        private void btnStuSave_Click(object sender, EventArgs e)
        {
            frmManager.btnSave_Click(sender, e);
        }

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            frmManager.btnExportExcel_Click(sender, e);
        }

        private void btnExcelImport_Click(object sender, EventArgs e)
        {
            frmManager.btnImportExcel_Click(sender, e);
        }

        private void btnUserList_Click(object sender, EventArgs e)
        {
            userManager.btnUserCheck_Click(sender, e);
        }

        private void btnUserAdd_Click(object sender, EventArgs e)
        {
            userManager.btnUserAdd_Click(sender, e);
        }

        private void btnUserSave_Click(object sender, EventArgs e)
        {
            userManager.btnUserChange_Click(sender, e);
        }

        private void btnUserDel_Click(object sender, EventArgs e)
        {
            userManager.btnUserDelete_Click(sender, e);
        }

        private void btnRegist_Click(object sender, EventArgs e)
        {
            registration.btnRegister_Click(sender, e);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmLog.btnlogQuery_Click(sender, e);
        }

        private void btnAlterPwd_Click(object sender, EventArgs e)
        {
            pwdChange.btnOK_Click(sender, e);
        }

        private void ribbonPanel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Color FColor = Color.White;
            Color TColor = Color.LightSkyBlue;
            Brush b = new LinearGradientBrush(ribbonPanel1.ClientRectangle, FColor, TColor, LinearGradientMode.Vertical);
            g.FillRectangle(b, this.ClientRectangle);
        }

        private void btnExcelExp_Click(object sender, EventArgs e)
        {
            frmLog.ExpToExcel();
        }
    }
}
