namespace test2
{
    partial class FrmLog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtlogQuery = new System.Windows.Forms.TextBox();
            this.dgv = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.logid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usrname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.action = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usrtype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logmsg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "搜索:";
            // 
            // txtlogQuery
            // 
            this.txtlogQuery.Location = new System.Drawing.Point(181, 36);
            this.txtlogQuery.Name = "txtlogQuery";
            this.txtlogQuery.Size = new System.Drawing.Size(195, 25);
            this.txtlogQuery.TabIndex = 4;
            // 
            // dgv
            // 
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.logid,
            this.level,
            this.usrname,
            this.action,
            this.time,
            this.usrtype,
            this.logmsg});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9.07563F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dgv.Location = new System.Drawing.Point(43, 84);
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 27;
            this.dgv.Size = new System.Drawing.Size(849, 502);
            this.dgv.TabIndex = 6;
            // 
            // logid
            // 
            this.logid.DataPropertyName = "id";
            this.logid.HeaderText = "编号";
            this.logid.Name = "logid";
            // 
            // level
            // 
            this.level.DataPropertyName = "level";
            this.level.HeaderText = "日志等级";
            this.level.Name = "level";
            // 
            // usrname
            // 
            this.usrname.DataPropertyName = "username";
            this.usrname.HeaderText = "用户名";
            this.usrname.Name = "usrname";
            // 
            // action
            // 
            this.action.DataPropertyName = "action";
            this.action.HeaderText = "动作";
            this.action.Name = "action";
            // 
            // time
            // 
            this.time.DataPropertyName = "time";
            this.time.HeaderText = "时间";
            this.time.Name = "time";
            // 
            // usrtype
            // 
            this.usrtype.DataPropertyName = "userType";
            this.usrtype.HeaderText = "用户类型";
            this.usrtype.Name = "usrtype";
            // 
            // logmsg
            // 
            this.logmsg.DataPropertyName = "logMessage";
            this.logmsg.HeaderText = "日志内容";
            this.logmsg.Name = "logmsg";
            // 
            // FrmLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(221)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(933, 638);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.txtlogQuery);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmLog";
            this.Text = "FrmLog";
            this.Load += new System.EventHandler(this.FrmLog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtlogQuery;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn logid;
        private System.Windows.Forms.DataGridViewTextBoxColumn level;
        private System.Windows.Forms.DataGridViewTextBoxColumn usrname;
        private System.Windows.Forms.DataGridViewTextBoxColumn action;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn usrtype;
        private System.Windows.Forms.DataGridViewTextBoxColumn logmsg;
    }
}