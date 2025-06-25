namespace sub_db
{
	partial class frm_Mainform
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.dataGridView_Main = new System.Windows.Forms.DataGridView();
			this.textBox_Filter = new System.Windows.Forms.TextBox();
			this.linkLabel_FilterHelp = new System.Windows.Forms.LinkLabel();
			this.toolStrip_Main = new System.Windows.Forms.ToolStrip();
			this.toolStripButton_UpdateDB = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton_Folder = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton_URL = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton_Search = new System.Windows.Forms.ToolStripButton();
			this.toolStripSplitButton_Languages = new System.Windows.Forms.ToolStripSplitButton();
			this.toolStripButton_Settings = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton_About = new System.Windows.Forms.ToolStripButton();
			this.statusStrip_Main = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel_ItemsCount = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel_MovieCount = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel_ErrorMsg = new System.Windows.Forms.ToolStripStatusLabel();
			this.pictureBox_Search = new System.Windows.Forms.PictureBox();
			this.radioButton_SearchByName = new System.Windows.Forms.RadioButton();
			this.radioButton_SearchBySQL = new System.Windows.Forms.RadioButton();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_Main)).BeginInit();
			this.toolStrip_Main.SuspendLayout();
			this.statusStrip_Main.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_Search)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView_Main
			// 
			this.dataGridView_Main.AllowUserToAddRows = false;
			this.dataGridView_Main.AllowUserToDeleteRows = false;
			this.dataGridView_Main.AllowUserToOrderColumns = true;
			this.dataGridView_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView_Main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView_Main.Location = new System.Drawing.Point(0, 55);
			this.dataGridView_Main.Name = "dataGridView_Main";
			this.dataGridView_Main.ReadOnly = true;
			this.dataGridView_Main.RowTemplate.Height = 23;
			this.dataGridView_Main.Size = new System.Drawing.Size(1008, 649);
			this.dataGridView_Main.TabIndex = 4;
			this.dataGridView_Main.ColumnDisplayIndexChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DataGridView_Main_ColumnDisplayIndexChanged);
			this.dataGridView_Main.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DataGridView_Main_ColumnWidthChanged);
			// 
			// textBox_Filter
			// 
			this.textBox_Filter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_Filter.Location = new System.Drawing.Point(244, 28);
			this.textBox_Filter.Name = "textBox_Filter";
			this.textBox_Filter.Size = new System.Drawing.Size(713, 21);
			this.textBox_Filter.TabIndex = 2;
			this.textBox_Filter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_Filter_KeyPress);
			// 
			// linkLabel_FilterHelp
			// 
			this.linkLabel_FilterHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.linkLabel_FilterHelp.AutoSize = true;
			this.linkLabel_FilterHelp.Location = new System.Drawing.Point(985, 31);
			this.linkLabel_FilterHelp.Name = "linkLabel_FilterHelp";
			this.linkLabel_FilterHelp.Size = new System.Drawing.Size(17, 12);
			this.linkLabel_FilterHelp.TabIndex = 3;
			this.linkLabel_FilterHelp.TabStop = true;
			this.linkLabel_FilterHelp.Text = "？";
			this.linkLabel_FilterHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_FilterHelp_LinkClicked);
			// 
			// toolStrip_Main
			// 
			this.toolStrip_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_UpdateDB,
            this.toolStripButton_Folder,
            this.toolStripButton_URL,
            this.toolStripButton_Search,
            this.toolStripSplitButton_Languages,
            this.toolStripButton_Settings,
            this.toolStripSeparator1,
            this.toolStripButton_About});
			this.toolStrip_Main.Location = new System.Drawing.Point(0, 0);
			this.toolStrip_Main.Name = "toolStrip_Main";
			this.toolStrip_Main.Size = new System.Drawing.Size(1008, 25);
			this.toolStrip_Main.TabIndex = 0;
			this.toolStrip_Main.Text = "toolStrip1";
			// 
			// toolStripButton_UpdateDB
			// 
			this.toolStripButton_UpdateDB.Image = global::sub_db.Resource1.DB_Refresh;
			this.toolStripButton_UpdateDB.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton_UpdateDB.Name = "toolStripButton_UpdateDB";
			this.toolStripButton_UpdateDB.Size = new System.Drawing.Size(146, 22);
			this.toolStripButton_UpdateDB.Text = "更新数据库(Ctrl + F5)";
			this.toolStripButton_UpdateDB.Click += new System.EventHandler(this.ToolStripButton_UpdateDB_Click);
			// 
			// toolStripButton_Folder
			// 
			this.toolStripButton_Folder.Image = global::sub_db.Resource1.folder;
			this.toolStripButton_Folder.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton_Folder.Name = "toolStripButton_Folder";
			this.toolStripButton_Folder.Size = new System.Drawing.Size(174, 22);
			this.toolStripButton_Folder.Text = "打开本地文件夹(Alt+Enter)";
			this.toolStripButton_Folder.Click += new System.EventHandler(this.ToolStripButton_Folder_Click);
			// 
			// toolStripButton_URL
			// 
			this.toolStripButton_URL.Image = global::sub_db.Resource1.link;
			this.toolStripButton_URL.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton_URL.Name = "toolStripButton_URL";
			this.toolStripButton_URL.Size = new System.Drawing.Size(158, 22);
			this.toolStripButton_URL.Text = "打开远程链接(Ctrl + F1)";
			this.toolStripButton_URL.Click += new System.EventHandler(this.ToolStripButton_URL_Click);
			// 
			// toolStripButton_Search
			// 
			this.toolStripButton_Search.Image = global::sub_db.Resource1.Search;
			this.toolStripButton_Search.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton_Search.Name = "toolStripButton_Search";
			this.toolStripButton_Search.Size = new System.Drawing.Size(134, 22);
			this.toolStripButton_Search.Text = "高级查找(Ctrl + F3)";
			this.toolStripButton_Search.Click += new System.EventHandler(this.ToolStripButton_Search_Click);
			// 
			// toolStripSplitButton_Languages
			// 
			this.toolStripSplitButton_Languages.Image = global::sub_db.Resource1.Languages;
			this.toolStripSplitButton_Languages.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripSplitButton_Languages.Name = "toolStripSplitButton_Languages";
			this.toolStripSplitButton_Languages.Size = new System.Drawing.Size(135, 22);
			this.toolStripSplitButton_Languages.Text = "语言(Languages)";
			// 
			// toolStripButton_Settings
			// 
			this.toolStripButton_Settings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton_Settings.Image = global::sub_db.Resource1.Settings;
			this.toolStripButton_Settings.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton_Settings.Name = "toolStripButton_Settings";
			this.toolStripButton_Settings.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton_Settings.Text = "设置";
			this.toolStripButton_Settings.Click += new System.EventHandler(this.ToolStripButton_Settings_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripButton_About
			// 
			this.toolStripButton_About.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton_About.Image = global::sub_db.Resource1.About;
			this.toolStripButton_About.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton_About.Name = "toolStripButton_About";
			this.toolStripButton_About.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton_About.Text = "关于";
			this.toolStripButton_About.Click += new System.EventHandler(this.ToolStripButton_About_Click);
			// 
			// statusStrip_Main
			// 
			this.statusStrip_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_ItemsCount,
            this.toolStripStatusLabel_MovieCount,
            this.toolStripStatusLabel_ErrorMsg});
			this.statusStrip_Main.Location = new System.Drawing.Point(0, 707);
			this.statusStrip_Main.Name = "statusStrip_Main";
			this.statusStrip_Main.Size = new System.Drawing.Size(1008, 22);
			this.statusStrip_Main.TabIndex = 5;
			this.statusStrip_Main.Text = "statusStrip1";
			// 
			// toolStripStatusLabel_ItemsCount
			// 
			this.toolStripStatusLabel_ItemsCount.Name = "toolStripStatusLabel_ItemsCount";
			this.toolStripStatusLabel_ItemsCount.Size = new System.Drawing.Size(55, 17);
			this.toolStripStatusLabel_ItemsCount.Text = "0 条记录";
			// 
			// toolStripStatusLabel_MovieCount
			// 
			this.toolStripStatusLabel_MovieCount.Name = "toolStripStatusLabel_MovieCount";
			this.toolStripStatusLabel_MovieCount.Size = new System.Drawing.Size(55, 17);
			this.toolStripStatusLabel_MovieCount.Text = "0 部影片";
			// 
			// toolStripStatusLabel_ErrorMsg
			// 
			this.toolStripStatusLabel_ErrorMsg.ForeColor = System.Drawing.Color.Red;
			this.toolStripStatusLabel_ErrorMsg.Name = "toolStripStatusLabel_ErrorMsg";
			this.toolStripStatusLabel_ErrorMsg.Size = new System.Drawing.Size(63, 17);
			this.toolStripStatusLabel_ErrorMsg.Text = "(err_msg)";
			this.toolStripStatusLabel_ErrorMsg.Visible = false;
			// 
			// pictureBox_Search
			// 
			this.pictureBox_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox_Search.Image = global::sub_db.Resource1.Search;
			this.pictureBox_Search.Location = new System.Drawing.Point(963, 30);
			this.pictureBox_Search.Name = "pictureBox_Search";
			this.pictureBox_Search.Size = new System.Drawing.Size(16, 16);
			this.pictureBox_Search.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox_Search.TabIndex = 5;
			this.pictureBox_Search.TabStop = false;
			this.pictureBox_Search.Click += new System.EventHandler(this.PictureBox_Search_Click);
			// 
			// radioButton_SearchByName
			// 
			this.radioButton_SearchByName.AutoSize = true;
			this.radioButton_SearchByName.Checked = true;
			this.radioButton_SearchByName.Location = new System.Drawing.Point(12, 29);
			this.radioButton_SearchByName.Name = "radioButton_SearchByName";
			this.radioButton_SearchByName.Size = new System.Drawing.Size(95, 16);
			this.radioButton_SearchByName.TabIndex = 6;
			this.radioButton_SearchByName.TabStop = true;
			this.radioButton_SearchByName.Text = "根据名称查找";
			this.radioButton_SearchByName.UseVisualStyleBackColor = true;
			// 
			// radioButton_SearchBySQL
			// 
			this.radioButton_SearchBySQL.AutoSize = true;
			this.radioButton_SearchBySQL.Location = new System.Drawing.Point(119, 29);
			this.radioButton_SearchBySQL.Name = "radioButton_SearchBySQL";
			this.radioButton_SearchBySQL.Size = new System.Drawing.Size(119, 16);
			this.radioButton_SearchBySQL.TabIndex = 7;
			this.radioButton_SearchBySQL.Text = "使用查询语句查找";
			this.radioButton_SearchBySQL.UseVisualStyleBackColor = true;
			// 
			// frm_Mainform
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1008, 729);
			this.Controls.Add(this.radioButton_SearchBySQL);
			this.Controls.Add(this.radioButton_SearchByName);
			this.Controls.Add(this.statusStrip_Main);
			this.Controls.Add(this.toolStrip_Main);
			this.Controls.Add(this.pictureBox_Search);
			this.Controls.Add(this.linkLabel_FilterHelp);
			this.Controls.Add(this.textBox_Filter);
			this.Controls.Add(this.dataGridView_Main);
			this.Name = "frm_Mainform";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Subtitles DataBase";
			this.Activated += new System.EventHandler(this.frm_Mainform_Activated);
			this.Deactivate += new System.EventHandler(this.frm_Mainform_Deactivate);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Mainform_FormClosing);
			this.Load += new System.EventHandler(this.frm_Mainform_Load);
			this.ResizeEnd += new System.EventHandler(this.frm_Mainform_ResizeEnd);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_Main)).EndInit();
			this.toolStrip_Main.ResumeLayout(false);
			this.toolStrip_Main.PerformLayout();
			this.statusStrip_Main.ResumeLayout(false);
			this.statusStrip_Main.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_Search)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.LinkLabel linkLabel_FilterHelp;
		internal System.Windows.Forms.DataGridView dataGridView_Main;
		private System.Windows.Forms.ToolStrip toolStrip_Main;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		internal System.Windows.Forms.ToolStripSplitButton toolStripSplitButton_Languages;
		internal System.Windows.Forms.ToolStripButton toolStripButton_UpdateDB;
		internal System.Windows.Forms.ToolStripButton toolStripButton_Settings;
		internal System.Windows.Forms.ToolStripButton toolStripButton_About;
		internal System.Windows.Forms.ToolStripButton toolStripButton_Search;
		internal System.Windows.Forms.PictureBox pictureBox_Search;
		internal System.Windows.Forms.TextBox textBox_Filter;
		private System.Windows.Forms.StatusStrip statusStrip_Main;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_ItemsCount;
		internal System.Windows.Forms.ToolStripButton toolStripButton_Folder;
		internal System.Windows.Forms.ToolStripButton toolStripButton_URL;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_MovieCount;
		internal System.Windows.Forms.RadioButton radioButton_SearchByName;
		internal System.Windows.Forms.RadioButton radioButton_SearchBySQL;
		internal System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_ErrorMsg;
	}
}

