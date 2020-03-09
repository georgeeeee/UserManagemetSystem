namespace test2
{
    partial class FrmForgotPwd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmForgotPwd));
            this.lblPwd = new DevComponents.DotNetBar.LabelX();
            this.lblCfm = new DevComponents.DotNetBar.LabelX();
            this.txtPwd = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtCfm = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnCfm = new DevComponents.DotNetBar.ButtonX();
            this.btnRtn = new DevComponents.DotNetBar.ButtonX();
            this.lblUsername = new DevComponents.DotNetBar.LabelX();
            this.txtUsername = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.SuspendLayout();
            // 
            // lblPwd
            // 
            this.lblPwd.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblPwd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblPwd.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPwd.Location = new System.Drawing.Point(47, 109);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(75, 23);
            this.lblPwd.TabIndex = 0;
            this.lblPwd.Text = "新的密码";
            // 
            // lblCfm
            // 
            this.lblCfm.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblCfm.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCfm.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCfm.Location = new System.Drawing.Point(47, 176);
            this.lblCfm.Name = "lblCfm";
            this.lblCfm.Size = new System.Drawing.Size(71, 30);
            this.lblCfm.TabIndex = 1;
            this.lblCfm.Text = "确认密码";
            // 
            // txtPwd
            // 
            this.txtPwd.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtPwd.Border.Class = "TextBoxBorder";
            this.txtPwd.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPwd.DisabledBackColor = System.Drawing.Color.White;
            this.txtPwd.FocusHighlightColor = System.Drawing.Color.Cyan;
            this.txtPwd.ForeColor = System.Drawing.Color.Black;
            this.txtPwd.Location = new System.Drawing.Point(132, 110);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PreventEnterBeep = true;
            this.txtPwd.Size = new System.Drawing.Size(185, 25);
            this.txtPwd.TabIndex = 2;
            // 
            // txtCfm
            // 
            this.txtCfm.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtCfm.Border.Class = "TextBoxBorder";
            this.txtCfm.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCfm.DisabledBackColor = System.Drawing.Color.White;
            this.txtCfm.FocusHighlightColor = System.Drawing.Color.Cyan;
            this.txtCfm.ForeColor = System.Drawing.Color.Black;
            this.txtCfm.Location = new System.Drawing.Point(132, 175);
            this.txtCfm.Name = "txtCfm";
            this.txtCfm.PreventEnterBeep = true;
            this.txtCfm.Size = new System.Drawing.Size(185, 25);
            this.txtCfm.TabIndex = 3;
            // 
            // btnCfm
            // 
            this.btnCfm.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCfm.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnCfm.Location = new System.Drawing.Point(82, 240);
            this.btnCfm.Name = "btnCfm";
            this.btnCfm.Size = new System.Drawing.Size(75, 36);
            this.btnCfm.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCfm.TabIndex = 4;
            this.btnCfm.Text = "确认修改";
            this.btnCfm.Click += new System.EventHandler(this.btnCfm_Click);
            // 
            // btnRtn
            // 
            this.btnRtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRtn.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnRtn.Location = new System.Drawing.Point(207, 240);
            this.btnRtn.Name = "btnRtn";
            this.btnRtn.Size = new System.Drawing.Size(75, 36);
            this.btnRtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnRtn.TabIndex = 5;
            this.btnRtn.Text = "返回";
            this.btnRtn.Click += new System.EventHandler(this.btnRtn_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblUsername.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblUsername.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblUsername.Location = new System.Drawing.Point(51, 47);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(75, 23);
            this.lblUsername.TabIndex = 6;
            this.lblUsername.Text = "用户名";
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtUsername.Border.Class = "TextBoxBorder";
            this.txtUsername.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUsername.DisabledBackColor = System.Drawing.Color.White;
            this.txtUsername.FocusHighlightColor = System.Drawing.Color.Cyan;
            this.txtUsername.ForeColor = System.Drawing.Color.Black;
            this.txtUsername.Location = new System.Drawing.Point(132, 45);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PreventEnterBeep = true;
            this.txtUsername.Size = new System.Drawing.Size(185, 25);
            this.txtUsername.TabIndex = 1;
            // 
            // FrmForgotPwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(382, 318);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.btnRtn);
            this.Controls.Add(this.btnCfm);
            this.Controls.Add(this.txtCfm);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.lblCfm);
            this.Controls.Add(this.lblPwd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmForgotPwd";
            this.Text = "FrmForgotPwd";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX lblPwd;
        private DevComponents.DotNetBar.LabelX lblCfm;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPwd;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCfm;
        private DevComponents.DotNetBar.ButtonX btnCfm;
        private DevComponents.DotNetBar.ButtonX btnRtn;
        private DevComponents.DotNetBar.LabelX lblUsername;
        private DevComponents.DotNetBar.Controls.TextBoxX txtUsername;
    }
}