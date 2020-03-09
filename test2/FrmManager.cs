using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test2
{
    public partial class FrmManager : Form
    {
        //获取一个日志记录器
        log4net.ILog log = log4net.LogManager.GetLogger("testApp.Logging");

        public FrmManager()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        //连接字符串 获取配置文件里的连接路径
        static string connStr = ConfigurationManager.ConnectionStrings["str"].ConnectionString;

        public void btnView_Click(object sender, EventArgs e)
        {
            string sql = "select id,name,sex,major,institute,age from Student";
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(sql, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            dgv.DataSource = dt;
            log.Info(new LogContent(FrmLogin.Uid, "查看记录", FrmLogin.UserType, ""));
        }

        //添加数据
        public void btnAdd_Click(object sender, EventArgs e)
        {

            int n = 0;
            string sql = "insert into Student(name,major,sex,age,institute) values (@name,@major,@sex,@age,@institute)";

            if (txtName.Text.Trim() == "" || txtMajor.Text.Trim() == "" || txtSex.Text.Trim() == "" || txtAge.Text.Trim() == "" || txtInstitute.Text.Trim() == "")
            {
                MessageBox.Show("插入数据不能为空,请按要求插入数据!");
                return;
            }

            SqlParameter[] param ={
                                      new SqlParameter("@name",txtName.Text),
                                      new SqlParameter("@major",txtMajor.Text),
                                      new SqlParameter("@sex",txtSex.Text),
                                      new SqlParameter("@age",txtAge.Text),
                                      new SqlParameter("@institute",txtInstitute.Text)

                                  };
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            cmd.Parameters.AddRange(param);
            n = cmd.ExecuteNonQuery();
            if (n == 0)
            {
                MessageBox.Show("添加失败!");
                return;
            }
            else if (n > 0)
            {
                MessageBox.Show("添加成功!");
            }
            conn.Close();
            Refresh(true);

            log.Info(new LogContent(FrmLogin.Uid, "添加学生记录", FrmLogin.UserType,
                txtName.Text + "," + txtMajor.Text + "," + txtSex.Text + "," + txtAge.Text + "," + txtInstitute.Text));
        }

        private void Refresh(bool isAdded = false)
        {
            string sql = "select id,name,sex,major,institute,age from Student";
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(sql, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            dgv.DataSource = dt;
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            if (isAdded)
            {
                if (dt.Rows.Count > 0)
                {
                    dgv.Rows[0].Selected = false;
                }
                dgv.Rows[dt.Rows.Count - 1].Selected = true;
            };
        }

        public void btnDelete_Click(object sender, EventArgs e)
        {

            string sql = "delete from Student where 1=1";


            int id = Convert.ToInt32(dgv.CurrentRow.Cells[0].Value.ToString());

            if (dgv.CurrentRow.Selected)
            {

                sql = sql + "and Id=" + id;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                int n = 0;
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    n = cmd.ExecuteNonQuery();
                    if (n == 0)
                    {
                        MessageBox.Show("不存在的ID!");

                        //日志记录
                        log.Info(new LogContent(FrmLogin.Uid, "删除学生记录", FrmLogin.UserType, "ID不存在"));
                        return;

                    }
                    else if (n > 0)
                    {
                        MessageBox.Show("删除成功!");
                    }
                }
                conn.Close();
            }

            //日志记录
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sqlLog = "select * from Student where id = '" + id + "'";
                using (SqlCommand cmd = new SqlCommand(sqlLog, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        string Id = null, logName = null, logMajor = null, logSex = null, logAge = null, logIns = null;
                        while (reader.Read())
                        {
                            Id = reader["id"].ToString();
                            logName = reader["name"].ToString().Trim();
                            logMajor = reader["major"].ToString().Trim();
                            logSex = reader["sex"].ToString().Trim();
                            logAge = reader["age"].ToString();
                            logIns = reader["institute"].ToString().Trim();
                        }
                        log.Info(
                            new LogContent(FrmLogin.Uid, "删除记录", FrmLogin.UserType,
                            Id + ", " + logName + ", " + logMajor + ", " + logSex +
                            ", " + logAge + ", " + logIns));
                    }
                }
            }

            //删除完后 刷新一下当前数据
            Refresh();
        }

        private void FrmManager_Load(object sender, EventArgs e)
        {
            Refresh();
            cmbforTypeSelecting.Text = "全局搜索";
            cmbforTypeSelecting.Items.Add("全局搜索");
            cmbforTypeSelecting.Items.Add("编号");
            cmbforTypeSelecting.Items.Add("姓名");
            cmbforTypeSelecting.Items.Add("专业");
            cmbforTypeSelecting.Items.Add("性别");
            cmbforTypeSelecting.Items.Add("年龄");
            cmbforTypeSelecting.Items.Add("学院");
        }

        public void btnSave_Click(object sender, EventArgs e)
        {

            if (txtName.Text.Trim() == "" || txtMajor.Text.Trim() == "" || txtSex.Text.Trim() == "" || txtAge.Text.Trim() == "" || txtInstitute.Text.Trim() == "")
            {
                MessageBox.Show("文本框的输入不能为空!");

                //日志记录
                log.Info(new LogContent(FrmLogin.Uid, "保存学生记录", FrmLogin.UserType, "文本框输入为空"));
                return;
            }

            string sqlUpdate = "update Student set name ='" + txtName.Text + "',major ='"
             + txtMajor.Text + "',sex='" + txtSex.Text + "',age='" + txtAge.Text + "',institute='" + txtInstitute.Text +
            "'where Id='" + dgv.CurrentRow.Cells[0].Value.ToString() + "'";
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, conn);
            conn.Open();
            int n = cmdUpdate.ExecuteNonQuery();
            if (n == 0)
            {

                MessageBox.Show("更新失败!");
                return;// 并且返回
            }
            else if (n > 0)
            {

                MessageBox.Show("恭喜你!更新成功!");

                //日志记录
                log.Info(new LogContent(FrmLogin.Uid, "保存学生记录", FrmLogin.UserType,
                            txtName.Text + ", " + txtMajor.Text + ", " + txtSex.Text + ", " + txtAge.Text +
                            ", " + txtInstitute.Text));
            }

            conn.Close();
            //更新完以后  调用刷新方法,将更新后的数据 显示在datagridview上面
            Refresh();
        }

        string seletedValue;
        private void txtDataforQuery_TextChanged(object sender, EventArgs e)
        {
            string sql = "";
            if (txtDataforQuery.Text.Trim() == "")
            {

                sql = "select * from Student";
            }
            else if (seletedValue == "全局搜索" || cmbforTypeSelecting.Text == "全局搜索")
            {

                sql = "select * from Student where(id like'%" + txtDataforQuery.Text.Trim() + "%')" +
                    "or(name like'%" + txtDataforQuery.Text.Trim() + "%')or(major like'%" + txtDataforQuery.Text.Trim() + "%')" +
                    "or(age like'%" + txtDataforQuery.Text.Trim() + "%')or(sex like'%" + txtDataforQuery.Text.Trim() + "%')or" +
                    "(institute like'%" + txtDataforQuery.Text.Trim() + "%')";
            }
            else if (seletedValue == "id" || seletedValue == "name" || seletedValue == "major" || seletedValue == "sex" || seletedValue == "age" || seletedValue == "institute")
            {

                sql = "select * from Student where " + seletedValue + " like '%" + txtDataforQuery.Text.Trim() + "%'";
            }

            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(sql, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            dgv.DataSource = dt;
        }

        private void cmbforTypeSelecting_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strSelected = cmbforTypeSelecting.Text;
            switch (strSelected)
            {
                case "全局搜索":
                    seletedValue = "全局搜索";
                    break;
                case "编号":
                    seletedValue = "id";
                    break;
                case "姓名":
                    seletedValue = "name";
                    break;
                case "专业":
                    seletedValue = "major";
                    break;
                case "性别":
                    seletedValue = "sex";
                    break;
                case "年龄":
                    seletedValue = "age";
                    break;
                case "学院":
                    seletedValue = "institute";
                    break;
                default:
                    seletedValue = "全局搜索";
                    break;
            }
        }

        public void btnExportExcel_Click(object sender, EventArgs e)
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

        public void btnImportExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "文本文件|*.*|C#文件|*.cs|*.xlsx|*.*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            string fName = null;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fName = openFileDialog.FileName;
            }
            if (fName == "")
            {
                MessageBox.Show("未选择Excel文件");
                return;
            }
            NopiExcel.ExcelToTable(fName, dgv);
            DataGridViewToServer(dgv);
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if(e.ColumnIndex > 0)
                {
                    txtName.Text = dgv.Rows[e.RowIndex].Cells["姓名"].Value.ToString();
                    txtSex.Text = dgv.Rows[e.RowIndex].Cells["性别"].Value.ToString();
                    txtAge.Text = dgv.Rows[e.RowIndex].Cells["年龄"].Value.ToString();
                    txtMajor.Text = dgv.Rows[e.RowIndex].Cells["专业"].Value.ToString();
                    txtInstitute.Text = dgv.Rows[e.RowIndex].Cells["学院"].Value.ToString();
                }
            }
        }

        private bool DataGridViewToServer(DataGridView dgv)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "insert into Student(name, major, sex, age, institute) values (@name, @major, @sex, @age, @institute)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    for (int i = 0; i < dgv.RowCount - 1; i++)
                    {
                        SqlParameter[] param =
                        {
                            new SqlParameter("@name", dgv.Rows[i].Cells["姓名"].Value.ToString()),
                            new SqlParameter("@major", dgv.Rows[i].Cells["专业"].Value.ToString()),
                            new SqlParameter("@sex", dgv.Rows[i].Cells["性别"].Value.ToString()),
                            new SqlParameter("@age", dgv.Rows[i].Cells["年龄"].Value.ToString()),
                            new SqlParameter("@institute", dgv.Rows[i].Cells["学院"].Value.ToString())
                        };
                        cmd.Parameters.AddRange(param);
                        int n = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        if (n <= 0)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}
