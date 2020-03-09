namespace test2
{
    partial class FrmRegistration
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUid = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.txtPwdConfirm = new System.Windows.Forms.TextBox();
            this.lblUidMsg = new System.Windows.Forms.Label();
            this.lblPwdMsg = new System.Windows.Forms.Label();
            this.lblPwdConfirmMsg = new System.Windows.Forms.Label();
            this.rdoAdministrator = new System.Windows.Forms.RadioButton();
            this.rdoNormalUser = new System.Windows.Forms.RadioButton();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(109, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(124, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "密码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(94, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "密码确认：";
            // 
            // txtUid
            // 
            this.txtUid.Location = new System.Drawing.Point(189, 78);
            this.txtUid.Name = "txtUid";
            this.txtUid.Size = new System.Drawing.Size(171, 25);
            this.txtUid.TabIndex = 3;
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(189, 136);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(171, 25);
            this.txtPwd.TabIndex = 4;
            // 
            // txtPwdConfirm
            // 
            this.txtPwdConfirm.Location = new System.Drawing.Point(189, 202);
            this.txtPwdConfirm.Name = "txtPwdConfirm";
            this.txtPwdConfirm.PasswordChar = '*';
            this.txtPwdConfirm.Size = new System.Drawing.Size(171, 25);
            this.txtPwdConfirm.TabIndex = 5;
            // 
            // lblUidMsg
            // 
            this.lblUidMsg.AutoSize = true;
            this.lblUidMsg.ForeColor = System.Drawing.Color.Red;
            this.lblUidMsg.Location = new System.Drawing.Point(186, 103);
            this.lblUidMsg.Name = "lblUidMsg";
            this.lblUidMsg.Size = new System.Drawing.Size(31, 15);
            this.lblUidMsg.TabIndex = 8;
            this.lblUidMsg.Text = "msg";
            // 
            // lblPwdMsg
            // 
            this.lblPwdMsg.AutoSize = true;
            this.lblPwdMsg.ForeColor = System.Drawing.Color.Red;
            this.lblPwdMsg.Location = new System.Drawing.Point(186, 164);
            this.lblPwdMsg.Name = "lblPwdMsg";
            this.lblPwdMsg.Size = new System.Drawing.Size(31, 15);
            this.lblPwdMsg.TabIndex = 9;
            this.lblPwdMsg.Text = "msg";
            // 
            // lblPwdConfirmMsg
            // 
            this.lblPwdConfirmMsg.AutoSize = true;
            this.lblPwdConfirmMsg.ForeColor = System.Drawing.Color.Red;
            this.lblPwdConfirmMsg.Location = new System.Drawing.Point(186, 230);
            this.lblPwdConfirmMsg.Name = "lblPwdConfirmMsg";
            this.lblPwdConfirmMsg.Size = new System.Drawing.Size(31, 15);
            this.lblPwdConfirmMsg.TabIndex = 10;
            this.lblPwdConfirmMsg.Text = "msg";
            // 
            // rdoAdministrator
            // 
            this.rdoAdministrator.AutoSize = true;
            this.rdoAdministrator.BackColor = System.Drawing.Color.Transparent;
            this.rdoAdministrator.Location = new System.Drawing.Point(147, 291);
            this.rdoAdministrator.Name = "rdoAdministrator";
            this.rdoAdministrator.Size = new System.Drawing.Size(70, 19);
            this.rdoAdministrator.TabIndex = 11;
            this.rdoAdministrator.TabStop = true;
            this.rdoAdministrator.Text = "管理员";
            this.rdoAdministrator.UseVisualStyleBackColor = false;
            // 
            // rdoNormalUser
            // 
            this.rdoNormalUser.AutoSize = true;
            this.rdoNormalUser.BackColor = System.Drawing.Color.Transparent;
            this.rdoNormalUser.Location = new System.Drawing.Point(303, 291);
            this.rdoNormalUser.Name = "rdoNormalUser";
            this.rdoNormalUser.Size = new System.Drawing.Size(85, 19);
            this.rdoNormalUser.TabIndex = 12;
            this.rdoNormalUser.TabStop = true;
            this.rdoNormalUser.Text = "普通用户";
            this.rdoNormalUser.UseVisualStyleBackColor = false;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.rdoNormalUser);
            this.groupPanel1.Controls.Add(this.txtUid);
            this.groupPanel1.Controls.Add(this.rdoAdministrator);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Controls.Add(this.lblPwdConfirmMsg);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.lblPwdMsg);
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.Controls.Add(this.lblUidMsg);
            this.groupPanel1.Controls.Add(this.txtPwd);
            this.groupPanel1.Controls.Add(this.txtPwdConfirm);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Location = new System.Drawing.Point(203, 124);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(498, 372);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 13;
            // 
            // FrmRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(221)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(933, 638);
            this.Controls.Add(this.groupPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRegistration";
            this.Text = "FrmRegistration";
            this.Load += new System.EventHandler(this.FrmRegistration_Load);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUid;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.TextBox txtPwdConfirm;
        private System.Windows.Forms.Label lblUidMsg;
        private System.Windows.Forms.Label lblPwdMsg;
        private System.Windows.Forms.Label lblPwdConfirmMsg;
        private System.Windows.Forms.RadioButton rdoAdministrator;
        private System.Windows.Forms.RadioButton rdoNormalUser;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
    }
}