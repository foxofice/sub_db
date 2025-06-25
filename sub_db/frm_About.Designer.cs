namespace sub_db
{
	partial class frm_About
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
			if(disposing && (components != null))
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
			this.pictureBox_Icon = new System.Windows.Forms.PictureBox();
			this.label_ChangeLog = new System.Windows.Forms.Label();
			this.textBox_ChangeLog = new System.Windows.Forms.TextBox();
			this.button_OK = new System.Windows.Forms.Button();
			this.linkLabel_Website = new System.Windows.Forms.LinkLabel();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_Icon)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox_Icon
			// 
			this.pictureBox_Icon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox_Icon.Location = new System.Drawing.Point(340, 12);
			this.pictureBox_Icon.Name = "pictureBox_Icon";
			this.pictureBox_Icon.Size = new System.Drawing.Size(32, 32);
			this.pictureBox_Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox_Icon.TabIndex = 1;
			this.pictureBox_Icon.TabStop = false;
			// 
			// label_ChangeLog
			// 
			this.label_ChangeLog.AutoSize = true;
			this.label_ChangeLog.Location = new System.Drawing.Point(12, 32);
			this.label_ChangeLog.Name = "label_ChangeLog";
			this.label_ChangeLog.Size = new System.Drawing.Size(167, 12);
			this.label_ChangeLog.TabIndex = 0;
			this.label_ChangeLog.Text = "Subtitles DataBase 更新日志";
			// 
			// textBox_ChangeLog
			// 
			this.textBox_ChangeLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_ChangeLog.Location = new System.Drawing.Point(12, 50);
			this.textBox_ChangeLog.Multiline = true;
			this.textBox_ChangeLog.Name = "textBox_ChangeLog";
			this.textBox_ChangeLog.ReadOnly = true;
			this.textBox_ChangeLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_ChangeLog.Size = new System.Drawing.Size(360, 270);
			this.textBox_ChangeLog.TabIndex = 1;
			// 
			// button_OK
			// 
			this.button_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button_OK.Location = new System.Drawing.Point(297, 326);
			this.button_OK.Name = "button_OK";
			this.button_OK.Size = new System.Drawing.Size(75, 23);
			this.button_OK.TabIndex = 3;
			this.button_OK.Text = "确定";
			this.button_OK.UseVisualStyleBackColor = true;
			this.button_OK.Click += new System.EventHandler(this.Button_OK_Click);
			// 
			// linkLabel_Website
			// 
			this.linkLabel_Website.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.linkLabel_Website.AutoSize = true;
			this.linkLabel_Website.Location = new System.Drawing.Point(12, 337);
			this.linkLabel_Website.Name = "linkLabel_Website";
			this.linkLabel_Website.Size = new System.Drawing.Size(227, 12);
			this.linkLabel_Website.TabIndex = 2;
			this.linkLabel_Website.TabStop = true;
			this.linkLabel_Website.Text = "https://github.com/foxofice/sub_share";
			this.linkLabel_Website.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_Website_LinkClicked);
			// 
			// frm_About
			// 
			this.AcceptButton = this.button_OK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(384, 361);
			this.Controls.Add(this.linkLabel_Website);
			this.Controls.Add(this.button_OK);
			this.Controls.Add(this.textBox_ChangeLog);
			this.Controls.Add(this.label_ChangeLog);
			this.Controls.Add(this.pictureBox_Icon);
			this.Name = "frm_About";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "关于 Subtitles DataBase";
			this.TopMost = true;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_About_FormClosing);
			this.Load += new System.EventHandler(this.frm_About_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_Icon)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox_Icon;
		private System.Windows.Forms.TextBox textBox_ChangeLog;
		private System.Windows.Forms.LinkLabel linkLabel_Website;
		internal System.Windows.Forms.Label label_ChangeLog;
		internal System.Windows.Forms.Button button_OK;
	}
}