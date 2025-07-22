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
			pictureBox_Icon = new PictureBox();
			label_ChangeLog = new Label();
			textBox_ChangeLog = new TextBox();
			button_OK = new Button();
			linkLabel_Github1 = new LinkLabel();
			linkLabel_Github2 = new LinkLabel();
			linkLabel_Website = new LinkLabel();
			((System.ComponentModel.ISupportInitialize)pictureBox_Icon).BeginInit();
			SuspendLayout();
			// 
			// pictureBox_Icon
			// 
			pictureBox_Icon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			pictureBox_Icon.Location = new Point(690, 11);
			pictureBox_Icon.Margin = new Padding(3, 2, 3, 2);
			pictureBox_Icon.Name = "pictureBox_Icon";
			pictureBox_Icon.Size = new Size(32, 32);
			pictureBox_Icon.TabIndex = 0;
			pictureBox_Icon.TabStop = false;
			// 
			// label_ChangeLog
			// 
			label_ChangeLog.AutoSize = true;
			label_ChangeLog.Location = new Point(12, 33);
			label_ChangeLog.Name = "label_ChangeLog";
			label_ChangeLog.Size = new Size(65, 12);
			label_ChangeLog.TabIndex = 1;
			label_ChangeLog.Text = "更新日志：";
			// 
			// textBox_ChangeLog
			// 
			textBox_ChangeLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			textBox_ChangeLog.Location = new Point(10, 47);
			textBox_ChangeLog.Margin = new Padding(3, 2, 3, 2);
			textBox_ChangeLog.Multiline = true;
			textBox_ChangeLog.Name = "textBox_ChangeLog";
			textBox_ChangeLog.ReadOnly = true;
			textBox_ChangeLog.ScrollBars = ScrollBars.Both;
			textBox_ChangeLog.Size = new Size(714, 376);
			textBox_ChangeLog.TabIndex = 2;
			// 
			// button_OK
			// 
			button_OK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			button_OK.Location = new Point(647, 427);
			button_OK.Margin = new Padding(3, 2, 3, 2);
			button_OK.Name = "button_OK";
			button_OK.Size = new Size(75, 23);
			button_OK.TabIndex = 6;
			button_OK.Text = "确定";
			button_OK.UseVisualStyleBackColor = true;
			button_OK.Click += button_OK_Click;
			// 
			// linkLabel_Github1
			// 
			linkLabel_Github1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			linkLabel_Github1.AutoSize = true;
			linkLabel_Github1.Location = new Point(12, 440);
			linkLabel_Github1.Name = "linkLabel_Github1";
			linkLabel_Github1.Size = new Size(227, 12);
			linkLabel_Github1.TabIndex = 3;
			linkLabel_Github1.TabStop = true;
			linkLabel_Github1.Text = "https://github.com/foxofice/sub_share";
			linkLabel_Github1.LinkClicked += linkLabel_Github_LinkClicked;
			// 
			// linkLabel_Github2
			// 
			linkLabel_Github2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			linkLabel_Github2.AutoSize = true;
			linkLabel_Github2.Location = new Point(245, 440);
			linkLabel_Github2.Name = "linkLabel_Github2";
			linkLabel_Github2.Size = new Size(209, 12);
			linkLabel_Github2.TabIndex = 4;
			linkLabel_Github2.TabStop = true;
			linkLabel_Github2.Text = "https://github.com/foxofice/sub_db";
			linkLabel_Github2.LinkClicked += linkLabel_Github_LinkClicked;
			// 
			// linkLabel_Website
			// 
			linkLabel_Website.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			linkLabel_Website.AutoSize = true;
			linkLabel_Website.Location = new Point(460, 440);
			linkLabel_Website.Name = "linkLabel_Website";
			linkLabel_Website.Size = new Size(29, 12);
			linkLabel_Website.TabIndex = 5;
			linkLabel_Website.TabStop = true;
			linkLabel_Website.Text = "官网";
			linkLabel_Website.LinkClicked += linkLabel_Website_LinkClicked;
			// 
			// frm_About
			// 
			AcceptButton = button_OK;
			AutoScaleDimensions = new SizeF(6F, 12F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(734, 461);
			Controls.Add(linkLabel_Website);
			Controls.Add(linkLabel_Github2);
			Controls.Add(linkLabel_Github1);
			Controls.Add(button_OK);
			Controls.Add(textBox_ChangeLog);
			Controls.Add(label_ChangeLog);
			Controls.Add(pictureBox_Icon);
			Font = new Font("新宋体", 9F);
			Margin = new Padding(3, 2, 3, 2);
			Name = "frm_About";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "关于 Subtitles DataBase";
			FormClosing += frm_About_FormClosing;
			Load += frm_About_Load;
			((System.ComponentModel.ISupportInitialize)pictureBox_Icon).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private PictureBox pictureBox_Icon;
		private Label label_ChangeLog;
		private TextBox textBox_ChangeLog;
		private Button button_OK;
		private LinkLabel linkLabel_Github1;
		private LinkLabel linkLabel_Github2;
		private LinkLabel linkLabel_Website;
	}
}