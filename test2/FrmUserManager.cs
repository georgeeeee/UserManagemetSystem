using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test2
{
    public partial class FrmUserManager : Form
    {
        private log4net.ILog Ilog;

        public FrmUserManager()
        {
            InitializeComponent();
            Ilog = log4net.LogManager.GetLogger("testApp.Logging");
            StartPosition = FormStartPosition.CenterScreen;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //动态设置datagridview列宽
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private int RightFManager = 0;
        private int RightFRegistration = 0;
        private int RightFPwdChange = 0;
        private int RightFLog = 0;

        //strType 用于获取 当前DataGridView 被点中行的用户类型
        private string strUType = "";
        private void CheckAllUsers()
        {

            string sql = "select * from Account";
            dgv.DataSource = SqlHelper.ExecuteDataTable(sql);
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            txtUserName.Text = dgv.Rows[e.RowIndex].Cells["username"].Value.ToString();
            txtPwd.Text = dgv.Rows[e.RowIndex].Cells["password"].Value.ToString();
            cboUserType.Text = dgv.Rows[e.RowIndex].Cells["type"].Value.ToString();


            strUType = cboUserType.Text.Trim();


            chkManager.Checked = false;
            chkRegistration.Checked = false;
            chkPwdChange.Checked = false;
            chkLog.Checked = false;

            txtUserName.Enabled = true;
            txtPwd.Enabled = true;
            cboUserType.Enabled = true;
            chkManager.Enabled = true;
            chkPwdChange.Enabled = true;
            chkRegistration.Enabled = true;
            chkLog.Enabled = true;


            if (strUType == "NormalUser")
            {

                chkManager.Checked = true;
                chkRegistration.Checked = true;
                chkManager.Checked = true;
                chkLog.Checked = true;


                RightFManager = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["manager"].Value);
                RightFRegistration = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["registration"].Value);
                RightFPwdChange = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["pwdChange"].Value);
                RightFLog = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["log"].Value);


                if (RightFManager == 1)
                    chkManager.Checked = true;
                else
                    chkManager.Checked = false;
                if (RightFRegistration == 1)
                    chkRegistration.Checked = true;
                else
                    chkRegistration.Checked = false;
                if (RightFPwdChange == 1)
                    chkPwdChange.Checked = true;
                else
                    chkPwdChange.Checked = false;
                if (RightFLog == 1)
                    chkLog.Checked = true;
                else
                    chkLog.Checked = false;

            }

            else if (strUType == "Administrator")
            {
                chkManager.Enabled = false;
                chkPwdChange.Enabled = false;
                chkRegistration.Enabled = false;
                chkLog.Enabled = false;

                txtUserName.Enabled = false;
                txtPwd.Enabled = false;
                cboUserType.Enabled = false;
            }
        }

        //查询用户信息
        private void txtUserQuery_TextChanged(object sender, EventArgs e)
        {
            string sql = "";

            if (txtUserQuery.Text.Trim() == "")
            {

                sql = "select * from Account";
            }
            else
            {
                sql = "select * from Account where username like'%" + txtUserQuery.Text.Trim() + "%'";
            }

            dgv.DataSource = SqlHelper.ExecuteDataTable(sql);

        }
        //调用查看所有用户的方法来刷新当前 DataGridView的内容
        public void btnUserCheck_Click(object sender, EventArgs e)
        {

            CheckAllUsers();
        }
        //添加用户
        public void btnUserAdd_Click(object sender, EventArgs e)
        {

            string sql = "insert into Account(username,password,type,rightFManager,rightFRegistration,rightFPwdChange,rightFLog) values (@username,@password,@type,@rightFManager,@rightFRegistration,@rightFPwdChange,@rightFLog)";


            if (txtUserName.Text.Trim() == "" || txtPwd.Text.Trim() == "" || cboUserType.Text == "")
            {
                MessageBox.Show("插入数据不能为空,请按要求插入数据!");

                //日志记录
                Ilog.Info(new LogContent(FrmLogin.Uid, "用户管理", FrmLogin.UserType, "插入数据为空"));
                return;
            }
            if (cboUserType.Text == "Administrator")
            {
                MessageBox.Show("暂不开放注册管理员功能!");
                return;
            }

            //判断 哪些CheckBox 被选中
            AdjustChecked();


            SqlParameter[] param ={
                                      new SqlParameter("@username",txtUserName.Text.Trim()),
                                      new SqlParameter("@password",txtPwd.Text.Trim()),
                                      new SqlParameter("@type",cboUserType.Text.Trim()),
                                      new SqlParameter("@rightFManager",RightFManager),
                                      new SqlParameter("@rightFRegistration",RightFRegistration),
                                      new SqlParameter("@rightFPwdChange",RightFPwdChange),
                                      new SqlParameter("@rightFLog",RightFLog)
                                  };

            int n = SqlHelper.ExcuteNonQuery(sql, param);

            if (n > 0)
            {
                MessageBox.Show("数据插入成功!");

                //日志记录
                Ilog.Info(new LogContent(FrmLogin.Uid, "用户管理", FrmLogin.UserType, "插入数据成功"));
            }
            else
            {
                MessageBox.Show("插入失败!");

                //日志记录
                Ilog.Info(new LogContent(FrmLogin.Uid, "用户管理", FrmLogin.UserType, "插入数据失败"));
                return;
            }

            //调用CheckAllUsers() 方法 用于刷新 在添加完成数据后 自动刷新数据
            CheckAllUsers();
        }

        //判断CheckBox是否被点重或是取消, 用于更新和修改用户权限
        private void AdjustChecked()
        {

            if (chkManager.Checked == true)
                RightFManager = 1;
            else
                RightFManager = 0;
            if (chkRegistration.Checked == true)
                RightFRegistration = 1;
            else
                RightFRegistration = 0;
            if (chkPwdChange.Checked == true)
                RightFPwdChange = 1;
            else
                RightFPwdChange = 0;
            if (chkLog.Checked == true)
                RightFLog = 1;
            else
                RightFLog = 0;
        }

        //保存修改的信息
        public void btnUserChange_Click(object sender, EventArgs e)
        {

            if (txtUserName.Text.Trim() == "" || txtPwd.Text.Trim() == "" || cboUserType.Text.Trim() == "")
            {
                MessageBox.Show("文本框的输入不能为空!");

                //日志记录
                Ilog.Info(new LogContent(FrmLogin.Uid, "用户管理", FrmLogin.UserType, "文本框输入为空"));
                return;
            }
            if (cboUserType.Text == "Administrator")
            {
                MessageBox.Show("暂不开放注册管理员功能!");
                return;
            }

            //判断 哪些CheckBox 被选中
            AdjustChecked();
            string sqlUpdate = "update Account set username = @username, password = @password,type=@type,rightFManager=@rightFManager,rightFRegistration=@rightFRegistration,rightFPwdChange=@rightFPwdChange,rightFLog=@rightFLog where id=@id";
            SqlParameter[] param ={
                                      new SqlParameter("@username",txtUserName.Text.Trim()),
                                      new SqlParameter("@password",txtPwd.Text.Trim()),
                                      new SqlParameter("@type",cboUserType.Text.Trim()),
                                      new SqlParameter("@rightFManager",RightFManager),
                                      new SqlParameter("@rightFRegistration",RightFRegistration),
                                      new SqlParameter("@rightFPwdChange",RightFPwdChange),
                                      new SqlParameter("@rightFLog",RightFLog),
                                      new SqlParameter("@id",dgv.CurrentRow.Cells[0].Value),
                                  };


            int n = SqlHelper.ExcuteNonQuery(sqlUpdate, param);
            if (n == 0)
            {

                MessageBox.Show("更新失败!");
                return;
            }
            else
            {
                MessageBox.Show("恭喜你!更新成功!");
                //日志记录
                Ilog.Info(new LogContent(FrmLogin.Uid, "用户管理", FrmLogin.UserType, "数据更新成功，id=" + dgv.CurrentRow.Cells[0].Value));
            }

            //保存完以后  调用刷新方法,将更新后的数据 显示在datagridview上面
            CheckAllUsers();
        }
        //删除DataGridView里 选中的用户
        public void btnUserDelete_Click(object sender, EventArgs e)
        {

            string sqlDelete = null;

            if (dgv.CurrentRow.Selected)
            {

                sqlDelete = "delete from Account where id=@id";
            }

            SqlParameter[] param = {
                                    new SqlParameter("@id",Convert.ToInt32(dgv.CurrentRow.Cells[0].Value))
                                   };
            int n = SqlHelper.ExcuteNonQuery(sqlDelete, param);


            if (n > 0)
            {
                MessageBox.Show("删除成功!");
                //日志记录
                Ilog.Info(new LogContent(FrmLogin.Uid, "用户管理", FrmLogin.UserType, "数据删除成功，id=" + dgv.CurrentRow.Cells[0].Value));
            }
            else
            {
                MessageBox.Show("不存在的ID!");
                //日志记录
                Ilog.Info(new LogContent(FrmLogin.Uid, "用户管理", FrmLogin.UserType, "ID不存在，id=" + dgv.CurrentRow.Cells[0].Value));
            }
            CheckAllUsers();
        }

        private void FrmUserManager_Load(object sender, EventArgs e)
        {
            CheckAllUsers();
            cboUserType.Items.Add("Administrator");
            cboUserType.Items.Add("NormalUser");
        }
    }
}
