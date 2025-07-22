namespace sub_db
{
    partial class frm_Mainform
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			toolStrip_Main = new ToolStrip();
			toolStripButton_UpdateDB = new ToolStripButton();
			toolStripButton_Folder = new ToolStripButton();
			toolStripButton_URL = new ToolStripButton();
			toolStripButton_Search = new ToolStripButton();
			toolStripButton_Log = new ToolStripButton();
			toolStripSplitButton_Languages = new ToolStripSplitButton();
			toolStripSeparator1 = new ToolStripSeparator();
			toolStripButton_About = new ToolStripButton();
			radioButton_SearchByName = new RadioButton();
			radioButton_SearchBySQL = new RadioButton();
			textBox_Filter = new TextBox();
			pictureBox_Search = new PictureBox();
			linkLabel_FilterHelp = new LinkLabel();
			statusStrip_Main = new StatusStrip();
			toolStripStatusLabel_ItemsCount = new ToolStripStatusLabel();
			toolStripStatusLabel_MovieCount = new ToolStripStatusLabel();
			toolStripStatusLabel_ErrorMsg = new ToolStripStatusLabel();
			dataGridView_Main = new DataGridView();
			label_SubsPath = new Label();
			textBox_SubsPath = new TextBox();
			button_SubsPath = new Button();
			timer_SaveConfig = new System.Windows.Forms.Timer(components);
			toolStrip_Main.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox_Search).BeginInit();
			statusStrip_Main.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dataGridView_Main).BeginInit();
			SuspendLayout();
			// 
			// toolStrip_Main
			// 
			toolStrip_Main.Font = new Font("新宋体", 9F);
			toolStrip_Main.Items.AddRange(new ToolStripItem[] { toolStripButton_UpdateDB, toolStripButton_Folder, toolStripButton_URL, toolStripButton_Search, toolStripButton_Log, toolStripSplitButton_Languages, toolStripSeparator1, toolStripButton_About });
			toolStrip_Main.Location = new Point(0, 0);
			toolStrip_Main.Name = "toolStrip_Main";
			toolStrip_Main.Size = new Size(1384, 25);
			toolStrip_Main.TabIndex = 1;
			// 
			// toolStripButton_UpdateDB
			// 
			toolStripButton_UpdateDB.Image = res_main.DB_Refresh;
			toolStripButton_UpdateDB.ImageTransparentColor = Color.Magenta;
			toolStripButton_UpdateDB.Name = "toolStripButton_UpdateDB";
			toolStripButton_UpdateDB.Size = new Size(109, 22);
			toolStripButton_UpdateDB.Text = "更新数据库(F5)";
			toolStripButton_UpdateDB.Click += toolStripButton_UpdateDB_Click;
			// 
			// toolStripButton_Folder
			// 
			toolStripButton_Folder.Image = res_main.folder;
			toolStripButton_Folder.ImageTransparentColor = Color.Magenta;
			toolStripButton_Folder.Name = "toolStripButton_Folder";
			toolStripButton_Folder.Size = new Size(175, 22);
			toolStripButton_Folder.Text = "打开本地文件夹(Alt+Enter)";
			toolStripButton_Folder.Click += toolStripButton_Folder_Click;
			// 
			// toolStripButton_URL
			// 
			toolStripButton_URL.Image = res_main.link;
			toolStripButton_URL.ImageTransparentColor = Color.Magenta;
			toolStripButton_URL.Name = "toolStripButton_URL";
			toolStripButton_URL.Size = new Size(121, 22);
			toolStripButton_URL.Text = "打开远程链接(F1)";
			toolStripButton_URL.Click += toolStripButton_URL_Click;
			// 
			// toolStripButton_Search
			// 
			toolStripButton_Search.Image = res_main.Search;
			toolStripButton_Search.ImageTransparentColor = Color.Magenta;
			toolStripButton_Search.Name = "toolStripButton_Search";
			toolStripButton_Search.Size = new Size(97, 22);
			toolStripButton_Search.Text = "高级查找(F3)";
			toolStripButton_Search.Click += toolStripButton_Search_Click;
			// 
			// toolStripButton_Log
			// 
			toolStripButton_Log.Image = res_main.Log;
			toolStripButton_Log.ImageTransparentColor = Color.Magenta;
			toolStripButton_Log.Name = "toolStripButton_Log";
			toolStripButton_Log.Size = new Size(73, 22);
			toolStripButton_Log.Text = "日志(F4)";
			toolStripButton_Log.Click += toolStripButton_Log_Click;
			// 
			// toolStripSplitButton_Languages
			// 
			toolStripSplitButton_Languages.Image = res_main.Languages;
			toolStripSplitButton_Languages.ImageTransparentColor = Color.Magenta;
			toolStripSplitButton_Languages.Name = "toolStripSplitButton_Languages";
			toolStripSplitButton_Languages.Size = new Size(127, 22);
			toolStripSplitButton_Languages.Text = "语言(Languages)";
			// 
			// toolStripSeparator1
			// 
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new Size(6, 25);
			// 
			// toolStripButton_About
			// 
			toolStripButton_About.DisplayStyle = ToolStripItemDisplayStyle.Image;
			toolStripButton_About.Image = res_main.About;
			toolStripButton_About.ImageTransparentColor = Color.Magenta;
			toolStripButton_About.Name = "toolStripButton_About";
			toolStripButton_About.Size = new Size(23, 22);
			toolStripButton_About.Text = "关于";
			toolStripButton_About.Click += toolStripButton_About_Click;
			// 
			// radioButton_SearchByName
			// 
			radioButton_SearchByName.AutoSize = true;
			radioButton_SearchByName.Checked = true;
			radioButton_SearchByName.Location = new Point(12, 55);
			radioButton_SearchByName.Margin = new Padding(3, 2, 3, 2);
			radioButton_SearchByName.Name = "radioButton_SearchByName";
			radioButton_SearchByName.Size = new Size(95, 16);
			radioButton_SearchByName.TabIndex = 5;
			radioButton_SearchByName.TabStop = true;
			radioButton_SearchByName.Text = "根据名称查找";
			radioButton_SearchByName.UseVisualStyleBackColor = true;
			// 
			// radioButton_SearchBySQL
			// 
			radioButton_SearchBySQL.AutoSize = true;
			radioButton_SearchBySQL.Location = new Point(125, 55);
			radioButton_SearchBySQL.Margin = new Padding(3, 2, 3, 2);
			radioButton_SearchBySQL.Name = "radioButton_SearchBySQL";
			radioButton_SearchBySQL.Size = new Size(119, 16);
			radioButton_SearchBySQL.TabIndex = 6;
			radioButton_SearchBySQL.Text = "使用查询语句查找";
			radioButton_SearchBySQL.UseVisualStyleBackColor = true;
			// 
			// textBox_Filter
			// 
			textBox_Filter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			textBox_Filter.Location = new Point(322, 54);
			textBox_Filter.Margin = new Padding(3, 2, 3, 2);
			textBox_Filter.Name = "textBox_Filter";
			textBox_Filter.Size = new Size(1005, 21);
			textBox_Filter.TabIndex = 7;
			textBox_Filter.KeyPress += textBox_Filter_KeyPress;
			// 
			// pictureBox_Search
			// 
			pictureBox_Search.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			pictureBox_Search.Image = res_main.Search;
			pictureBox_Search.Location = new Point(1333, 55);
			pictureBox_Search.Margin = new Padding(3, 2, 3, 2);
			pictureBox_Search.Name = "pictureBox_Search";
			pictureBox_Search.Size = new Size(16, 16);
			pictureBox_Search.TabIndex = 3;
			pictureBox_Search.TabStop = false;
			pictureBox_Search.Click += pictureBox_Search_Click;
			// 
			// linkLabel_FilterHelp
			// 
			linkLabel_FilterHelp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			linkLabel_FilterHelp.AutoSize = true;
			linkLabel_FilterHelp.Location = new Point(1355, 57);
			linkLabel_FilterHelp.Name = "linkLabel_FilterHelp";
			linkLabel_FilterHelp.Size = new Size(17, 12);
			linkLabel_FilterHelp.TabIndex = 8;
			linkLabel_FilterHelp.TabStop = true;
			linkLabel_FilterHelp.Text = "？";
			linkLabel_FilterHelp.LinkClicked += linkLabel_FilterHelp_LinkClicked;
			// 
			// statusStrip_Main
			// 
			statusStrip_Main.Font = new Font("新宋体", 9F);
			statusStrip_Main.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel_ItemsCount, toolStripStatusLabel_MovieCount, toolStripStatusLabel_ErrorMsg });
			statusStrip_Main.Location = new Point(0, 739);
			statusStrip_Main.Name = "statusStrip_Main";
			statusStrip_Main.Padding = new Padding(1, 0, 12, 0);
			statusStrip_Main.Size = new Size(1384, 22);
			statusStrip_Main.TabIndex = 10;
			// 
			// toolStripStatusLabel_ItemsCount
			// 
			toolStripStatusLabel_ItemsCount.Name = "toolStripStatusLabel_ItemsCount";
			toolStripStatusLabel_ItemsCount.Size = new Size(53, 17);
			toolStripStatusLabel_ItemsCount.Text = "0 条记录";
			// 
			// toolStripStatusLabel_MovieCount
			// 
			toolStripStatusLabel_MovieCount.Name = "toolStripStatusLabel_MovieCount";
			toolStripStatusLabel_MovieCount.Size = new Size(53, 17);
			toolStripStatusLabel_MovieCount.Text = "0 部番剧";
			// 
			// toolStripStatusLabel_ErrorMsg
			// 
			toolStripStatusLabel_ErrorMsg.ForeColor = Color.Red;
			toolStripStatusLabel_ErrorMsg.Name = "toolStripStatusLabel_ErrorMsg";
			toolStripStatusLabel_ErrorMsg.Size = new Size(59, 17);
			toolStripStatusLabel_ErrorMsg.Text = "(err_msg)";
			toolStripStatusLabel_ErrorMsg.Visible = false;
			// 
			// dataGridView_Main
			// 
			dataGridView_Main.AllowUserToAddRows = false;
			dataGridView_Main.AllowUserToDeleteRows = false;
			dataGridView_Main.AllowUserToOrderColumns = true;
			dataGridView_Main.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dataGridView_Main.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView_Main.Location = new Point(0, 79);
			dataGridView_Main.Margin = new Padding(3, 2, 3, 2);
			dataGridView_Main.Name = "dataGridView_Main";
			dataGridView_Main.ReadOnly = true;
			dataGridView_Main.Size = new Size(1384, 658);
			dataGridView_Main.TabIndex = 9;
			dataGridView_Main.ColumnDisplayIndexChanged += dataGridView_Main_ColumnDisplayIndexChanged;
			dataGridView_Main.ColumnWidthChanged += dataGridView_Main_ColumnWidthChanged;
			// 
			// label_SubsPath
			// 
			label_SubsPath.AutoSize = true;
			label_SubsPath.Location = new Point(12, 31);
			label_SubsPath.Name = "label_SubsPath";
			label_SubsPath.Size = new Size(65, 12);
			label_SubsPath.TabIndex = 2;
			label_SubsPath.Text = "字幕路径：";
			// 
			// textBox_SubsPath
			// 
			textBox_SubsPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			textBox_SubsPath.Location = new Point(107, 28);
			textBox_SubsPath.Name = "textBox_SubsPath";
			textBox_SubsPath.Size = new Size(1220, 21);
			textBox_SubsPath.TabIndex = 3;
			textBox_SubsPath.TextChanged += textBox_SubsPath_TextChanged;
			// 
			// button_SubsPath
			// 
			button_SubsPath.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			button_SubsPath.Location = new Point(1333, 26);
			button_SubsPath.Name = "button_SubsPath";
			button_SubsPath.Size = new Size(39, 23);
			button_SubsPath.TabIndex = 4;
			button_SubsPath.Text = "...";
			button_SubsPath.UseVisualStyleBackColor = true;
			button_SubsPath.Click += button_SubsPath_Click;
			// 
			// timer_SaveConfig
			// 
			timer_SaveConfig.Enabled = true;
			timer_SaveConfig.Interval = 2000;
			timer_SaveConfig.Tick += timer_SaveConfig_Tick;
			// 
			// frm_Mainform
			// 
			AutoScaleDimensions = new SizeF(6F, 12F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1384, 761);
			Controls.Add(button_SubsPath);
			Controls.Add(textBox_SubsPath);
			Controls.Add(label_SubsPath);
			Controls.Add(dataGridView_Main);
			Controls.Add(statusStrip_Main);
			Controls.Add(linkLabel_FilterHelp);
			Controls.Add(pictureBox_Search);
			Controls.Add(textBox_Filter);
			Controls.Add(radioButton_SearchBySQL);
			Controls.Add(radioButton_SearchByName);
			Controls.Add(toolStrip_Main);
			DoubleBuffered = true;
			Font = new Font("新宋体", 9F);
			Margin = new Padding(3, 2, 3, 2);
			Name = "frm_Mainform";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Subtitles DataBase";
			FormClosing += frm_Mainform_FormClosing;
			Load += frm_Mainform_Load;
			ResizeEnd += frm_Mainform_ResizeEnd;
			toolStrip_Main.ResumeLayout(false);
			toolStrip_Main.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox_Search).EndInit();
			statusStrip_Main.ResumeLayout(false);
			statusStrip_Main.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dataGridView_Main).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private ToolStrip toolStrip_Main;
		private ToolStripButton toolStripButton_UpdateDB;
		private ToolStripButton toolStripButton_Folder;
		private ToolStripButton toolStripButton_URL;
		private ToolStripButton toolStripButton_Search;
		private ToolStripSplitButton toolStripSplitButton_Languages;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripButton toolStripButton_About;
		private RadioButton radioButton_SearchByName;
		private RadioButton radioButton_SearchBySQL;
		private TextBox textBox_Filter;
		private PictureBox pictureBox_Search;
		private LinkLabel linkLabel_FilterHelp;
		private StatusStrip statusStrip_Main;
		private ToolStripStatusLabel toolStripStatusLabel_ItemsCount;
		private ToolStripStatusLabel toolStripStatusLabel_MovieCount;
		private ToolStripStatusLabel toolStripStatusLabel_ErrorMsg;
		private DataGridView dataGridView_Main;
		private Label label_SubsPath;
		private TextBox textBox_SubsPath;
		private Button button_SubsPath;
		private System.Windows.Forms.Timer timer_SaveConfig;
		private ToolStripButton toolStripButton_Log;
	}
}
