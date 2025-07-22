namespace sub_db
{
	partial class frm_UpdateDatabase
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
			radioButton_UseLocalData = new RadioButton();
			radioButton_UseRemoteData = new RadioButton();
			tabControl_Main = new TabControl();
			tabPage_Local = new TabPage();
			radioButton_Local_Scan_Partial = new RadioButton();
			groupBox_Local_Scan_Partial = new GroupBox();
			checkBox_Local_Scan_Partial_Type = new CheckBox();
			checkBox_Local_Scan_Partial_Years = new CheckBox();
			pictureBox_Local_Scan_Partial_Type = new PictureBox();
			checkedListBox_Local_Scan_Partial_Type = new CheckedListBox();
			textBox_Local_Scan_Partial_Years = new TextBox();
			radioButton_Local_ScanAll = new RadioButton();
			tabPage_Remote = new TabPage();
			numericUpDown_Remote_Download_Threads = new NumericUpDown();
			label_Remote_Download_Threads = new Label();
			button_Start = new Button();
			button_Stop = new Button();
			statusStrip_Main = new StatusStrip();
			toolStripProgressBar_Update = new ToolStripProgressBar();
			toolStripStatusLabel_Log = new ToolStripStatusLabel();
			tabControl_Main.SuspendLayout();
			tabPage_Local.SuspendLayout();
			groupBox_Local_Scan_Partial.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox_Local_Scan_Partial_Type).BeginInit();
			tabPage_Remote.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_Remote_Download_Threads).BeginInit();
			statusStrip_Main.SuspendLayout();
			SuspendLayout();
			// 
			// radioButton_UseLocalData
			// 
			radioButton_UseLocalData.AutoSize = true;
			radioButton_UseLocalData.Location = new Point(12, 12);
			radioButton_UseLocalData.Name = "radioButton_UseLocalData";
			radioButton_UseLocalData.Size = new Size(155, 16);
			radioButton_UseLocalData.TabIndex = 1;
			radioButton_UseLocalData.Text = "本地字幕数据 -> db.xml";
			radioButton_UseLocalData.UseVisualStyleBackColor = true;
			radioButton_UseLocalData.CheckedChanged += radioButton_UseLocalData_CheckedChanged;
			// 
			// radioButton_UseRemoteData
			// 
			radioButton_UseRemoteData.AutoSize = true;
			radioButton_UseRemoteData.Location = new Point(215, 12);
			radioButton_UseRemoteData.Name = "radioButton_UseRemoteData";
			radioButton_UseRemoteData.Size = new Size(149, 16);
			radioButton_UseRemoteData.TabIndex = 2;
			radioButton_UseRemoteData.Text = "远程 db.xml -> db.xml";
			radioButton_UseRemoteData.UseVisualStyleBackColor = true;
			// 
			// tabControl_Main
			// 
			tabControl_Main.Controls.Add(tabPage_Local);
			tabControl_Main.Controls.Add(tabPage_Remote);
			tabControl_Main.Location = new Point(12, 34);
			tabControl_Main.Name = "tabControl_Main";
			tabControl_Main.SelectedIndex = 0;
			tabControl_Main.Size = new Size(445, 165);
			tabControl_Main.TabIndex = 3;
			// 
			// tabPage_Local
			// 
			tabPage_Local.Controls.Add(radioButton_Local_Scan_Partial);
			tabPage_Local.Controls.Add(groupBox_Local_Scan_Partial);
			tabPage_Local.Controls.Add(radioButton_Local_ScanAll);
			tabPage_Local.Location = new Point(4, 22);
			tabPage_Local.Name = "tabPage_Local";
			tabPage_Local.Padding = new Padding(3);
			tabPage_Local.Size = new Size(437, 139);
			tabPage_Local.TabIndex = 0;
			tabPage_Local.Text = "本地扫描设置";
			tabPage_Local.UseVisualStyleBackColor = true;
			// 
			// radioButton_Local_Scan_Partial
			// 
			radioButton_Local_Scan_Partial.AutoSize = true;
			radioButton_Local_Scan_Partial.Location = new Point(89, 6);
			radioButton_Local_Scan_Partial.Name = "radioButton_Local_Scan_Partial";
			radioButton_Local_Scan_Partial.Size = new Size(71, 16);
			radioButton_Local_Scan_Partial.TabIndex = 5;
			radioButton_Local_Scan_Partial.Text = "部分扫描";
			radioButton_Local_Scan_Partial.UseVisualStyleBackColor = true;
			radioButton_Local_Scan_Partial.CheckedChanged += radioButton_Local_Scan_Partial_CheckedChanged;
			// 
			// groupBox_Local_Scan_Partial
			// 
			groupBox_Local_Scan_Partial.Controls.Add(checkBox_Local_Scan_Partial_Type);
			groupBox_Local_Scan_Partial.Controls.Add(checkBox_Local_Scan_Partial_Years);
			groupBox_Local_Scan_Partial.Controls.Add(pictureBox_Local_Scan_Partial_Type);
			groupBox_Local_Scan_Partial.Controls.Add(checkedListBox_Local_Scan_Partial_Type);
			groupBox_Local_Scan_Partial.Controls.Add(textBox_Local_Scan_Partial_Years);
			groupBox_Local_Scan_Partial.Location = new Point(6, 28);
			groupBox_Local_Scan_Partial.Name = "groupBox_Local_Scan_Partial";
			groupBox_Local_Scan_Partial.Size = new Size(425, 105);
			groupBox_Local_Scan_Partial.TabIndex = 6;
			groupBox_Local_Scan_Partial.TabStop = false;
			groupBox_Local_Scan_Partial.Text = "部分扫描设置";
			// 
			// checkBox_Local_Scan_Partial_Type
			// 
			checkBox_Local_Scan_Partial_Type.AutoSize = true;
			checkBox_Local_Scan_Partial_Type.Enabled = false;
			checkBox_Local_Scan_Partial_Type.Location = new Point(6, 20);
			checkBox_Local_Scan_Partial_Type.Name = "checkBox_Local_Scan_Partial_Type";
			checkBox_Local_Scan_Partial_Type.Size = new Size(48, 16);
			checkBox_Local_Scan_Partial_Type.TabIndex = 7;
			checkBox_Local_Scan_Partial_Type.Text = "类型";
			checkBox_Local_Scan_Partial_Type.UseVisualStyleBackColor = true;
			checkBox_Local_Scan_Partial_Type.CheckedChanged += checkBox_Local_Scan_Partial_Type_CheckedChanged;
			// 
			// checkBox_Local_Scan_Partial_Years
			// 
			checkBox_Local_Scan_Partial_Years.AutoSize = true;
			checkBox_Local_Scan_Partial_Years.Enabled = false;
			checkBox_Local_Scan_Partial_Years.Location = new Point(6, 78);
			checkBox_Local_Scan_Partial_Years.Name = "checkBox_Local_Scan_Partial_Years";
			checkBox_Local_Scan_Partial_Years.Size = new Size(48, 16);
			checkBox_Local_Scan_Partial_Years.TabIndex = 9;
			checkBox_Local_Scan_Partial_Years.Text = "年份";
			checkBox_Local_Scan_Partial_Years.UseVisualStyleBackColor = true;
			checkBox_Local_Scan_Partial_Years.CheckedChanged += checkBox_Local_Scan_Partial_Years_CheckedChanged;
			// 
			// pictureBox_Local_Scan_Partial_Type
			// 
			pictureBox_Local_Scan_Partial_Type.Image = res_main.Refresh;
			pictureBox_Local_Scan_Partial_Type.Location = new Point(403, 20);
			pictureBox_Local_Scan_Partial_Type.Name = "pictureBox_Local_Scan_Partial_Type";
			pictureBox_Local_Scan_Partial_Type.Size = new Size(16, 16);
			pictureBox_Local_Scan_Partial_Type.TabIndex = 5;
			pictureBox_Local_Scan_Partial_Type.TabStop = false;
			pictureBox_Local_Scan_Partial_Type.Click += pictureBox_Local_Scan_Partial_Type_Click;
			// 
			// checkedListBox_Local_Scan_Partial_Type
			// 
			checkedListBox_Local_Scan_Partial_Type.Enabled = false;
			checkedListBox_Local_Scan_Partial_Type.FormattingEnabled = true;
			checkedListBox_Local_Scan_Partial_Type.Location = new Point(60, 20);
			checkedListBox_Local_Scan_Partial_Type.Name = "checkedListBox_Local_Scan_Partial_Type";
			checkedListBox_Local_Scan_Partial_Type.Size = new Size(337, 52);
			checkedListBox_Local_Scan_Partial_Type.TabIndex = 8;
			// 
			// textBox_Local_Scan_Partial_Years
			// 
			textBox_Local_Scan_Partial_Years.Location = new Point(60, 78);
			textBox_Local_Scan_Partial_Years.Name = "textBox_Local_Scan_Partial_Years";
			textBox_Local_Scan_Partial_Years.PlaceholderText = "范例：2001, 2008-2012, 2020";
			textBox_Local_Scan_Partial_Years.ReadOnly = true;
			textBox_Local_Scan_Partial_Years.Size = new Size(359, 21);
			textBox_Local_Scan_Partial_Years.TabIndex = 10;
			// 
			// radioButton_Local_ScanAll
			// 
			radioButton_Local_ScanAll.AutoSize = true;
			radioButton_Local_ScanAll.Location = new Point(6, 6);
			radioButton_Local_ScanAll.Name = "radioButton_Local_ScanAll";
			radioButton_Local_ScanAll.Size = new Size(71, 16);
			radioButton_Local_ScanAll.TabIndex = 4;
			radioButton_Local_ScanAll.Text = "全部扫描";
			radioButton_Local_ScanAll.UseVisualStyleBackColor = true;
			// 
			// tabPage_Remote
			// 
			tabPage_Remote.Controls.Add(numericUpDown_Remote_Download_Threads);
			tabPage_Remote.Controls.Add(label_Remote_Download_Threads);
			tabPage_Remote.Location = new Point(4, 22);
			tabPage_Remote.Name = "tabPage_Remote";
			tabPage_Remote.Padding = new Padding(3);
			tabPage_Remote.Size = new Size(437, 139);
			tabPage_Remote.TabIndex = 1;
			tabPage_Remote.Text = "远程下载设置";
			tabPage_Remote.UseVisualStyleBackColor = true;
			// 
			// numericUpDown_Remote_Download_Threads
			// 
			numericUpDown_Remote_Download_Threads.Location = new Point(113, 6);
			numericUpDown_Remote_Download_Threads.Name = "numericUpDown_Remote_Download_Threads";
			numericUpDown_Remote_Download_Threads.Size = new Size(62, 21);
			numericUpDown_Remote_Download_Threads.TabIndex = 12;
			numericUpDown_Remote_Download_Threads.TextAlign = HorizontalAlignment.Center;
			numericUpDown_Remote_Download_Threads.Value = new decimal(new int[] { 4, 0, 0, 0 });
			// 
			// label_Remote_Download_Threads
			// 
			label_Remote_Download_Threads.AutoSize = true;
			label_Remote_Download_Threads.Location = new Point(6, 8);
			label_Remote_Download_Threads.Name = "label_Remote_Download_Threads";
			label_Remote_Download_Threads.Size = new Size(77, 12);
			label_Remote_Download_Threads.TabIndex = 11;
			label_Remote_Download_Threads.Text = "下载线程数：";
			// 
			// button_Start
			// 
			button_Start.Location = new Point(12, 205);
			button_Start.Name = "button_Start";
			button_Start.Size = new Size(115, 23);
			button_Start.TabIndex = 13;
			button_Start.Text = "开始扫描";
			button_Start.UseVisualStyleBackColor = true;
			button_Start.Click += button_Start_Click;
			// 
			// button_Stop
			// 
			button_Stop.Enabled = false;
			button_Stop.Location = new Point(133, 205);
			button_Stop.Name = "button_Stop";
			button_Stop.Size = new Size(115, 23);
			button_Stop.TabIndex = 14;
			button_Stop.Text = "停止扫描";
			button_Stop.UseVisualStyleBackColor = true;
			button_Stop.Click += button_Stop_Click;
			// 
			// statusStrip_Main
			// 
			statusStrip_Main.Items.AddRange(new ToolStripItem[] { toolStripProgressBar_Update, toolStripStatusLabel_Log });
			statusStrip_Main.Location = new Point(0, 231);
			statusStrip_Main.Name = "statusStrip_Main";
			statusStrip_Main.Size = new Size(469, 22);
			statusStrip_Main.TabIndex = 15;
			// 
			// toolStripProgressBar_Update
			// 
			toolStripProgressBar_Update.Name = "toolStripProgressBar_Update";
			toolStripProgressBar_Update.Size = new Size(50, 16);
			toolStripProgressBar_Update.Style = ProgressBarStyle.Continuous;
			toolStripProgressBar_Update.Visible = false;
			// 
			// toolStripStatusLabel_Log
			// 
			toolStripStatusLabel_Log.Name = "toolStripStatusLabel_Log";
			toolStripStatusLabel_Log.Size = new Size(13, 17);
			toolStripStatusLabel_Log.Text = "-";
			toolStripStatusLabel_Log.Visible = false;
			// 
			// frm_UpdateDatabase
			// 
			AutoScaleDimensions = new SizeF(6F, 12F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(469, 253);
			Controls.Add(statusStrip_Main);
			Controls.Add(button_Stop);
			Controls.Add(button_Start);
			Controls.Add(tabControl_Main);
			Controls.Add(radioButton_UseRemoteData);
			Controls.Add(radioButton_UseLocalData);
			Font = new Font("新宋体", 9F);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Margin = new Padding(3, 2, 3, 2);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "frm_UpdateDatabase";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "更新数据库";
			FormClosing += frm_UpdateDatabase_FormClosing;
			Load += frm_UpdateDatabase_Load;
			tabControl_Main.ResumeLayout(false);
			tabPage_Local.ResumeLayout(false);
			tabPage_Local.PerformLayout();
			groupBox_Local_Scan_Partial.ResumeLayout(false);
			groupBox_Local_Scan_Partial.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox_Local_Scan_Partial_Type).EndInit();
			tabPage_Remote.ResumeLayout(false);
			tabPage_Remote.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_Remote_Download_Threads).EndInit();
			statusStrip_Main.ResumeLayout(false);
			statusStrip_Main.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private RadioButton radioButton_UseLocalData;
		private RadioButton radioButton_UseRemoteData;
		private TabControl tabControl_Main;
		private TabPage tabPage_Local;
		private TabPage tabPage_Remote;
		private RadioButton radioButton_Local_Scan_Partial;
		private RadioButton radioButton_Local_ScanAll;
		private NumericUpDown numericUpDown_Remote_Download_Threads;
		private Label label_Remote_Download_Threads;
		private Button button_Start;
		private Button button_Stop;
		private StatusStrip statusStrip_Main;
		private ToolStripProgressBar toolStripProgressBar_Update;
		private ToolStripStatusLabel toolStripStatusLabel_Log;
		private TextBox textBox_Local_Scan_Partial_Years;
		private GroupBox groupBox_Local_Scan_Partial;
		private CheckedListBox checkedListBox_Local_Scan_Partial_Type;
		private PictureBox pictureBox_Local_Scan_Partial_Type;
		private CheckBox checkBox_Local_Scan_Partial_Years;
		private CheckBox checkBox_Local_Scan_Partial_Type;
	}
}