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
			this.listView_Log = new System.Windows.Forms.ListView();
			this.columnHeader_Time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader_Log = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.label_Log = new System.Windows.Forms.Label();
			this.progressBar_Update = new System.Windows.Forms.ProgressBar();
			this.pictureBox_Stop = new System.Windows.Forms.PictureBox();
			this.pictureBox_Start = new System.Windows.Forms.PictureBox();
			this.radioButton_UseLocalData = new System.Windows.Forms.RadioButton();
			this.radioButton_UseRemoteData = new System.Windows.Forms.RadioButton();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_Stop)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_Start)).BeginInit();
			this.SuspendLayout();
			// 
			// listView_Log
			// 
			this.listView_Log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listView_Log.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_Time,
            this.columnHeader_Log});
			this.listView_Log.FullRowSelect = true;
			this.listView_Log.GridLines = true;
			this.listView_Log.HideSelection = false;
			this.listView_Log.Location = new System.Drawing.Point(0, 0);
			this.listView_Log.Name = "listView_Log";
			this.listView_Log.Size = new System.Drawing.Size(634, 411);
			this.listView_Log.TabIndex = 0;
			this.listView_Log.UseCompatibleStateImageBehavior = false;
			this.listView_Log.View = System.Windows.Forms.View.Details;
			this.listView_Log.Resize += new System.EventHandler(this.ListView_Log_Resize);
			// 
			// columnHeader_Time
			// 
			this.columnHeader_Time.Text = "时间";
			this.columnHeader_Time.Width = 122;
			// 
			// columnHeader_Log
			// 
			this.columnHeader_Log.Text = "日志";
			this.columnHeader_Log.Width = 491;
			// 
			// label_Log
			// 
			this.label_Log.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_Log.AutoSize = true;
			this.label_Log.Location = new System.Drawing.Point(236, 419);
			this.label_Log.Name = "label_Log";
			this.label_Log.Size = new System.Drawing.Size(11, 12);
			this.label_Log.TabIndex = 1;
			this.label_Log.Text = "-";
			this.label_Log.Visible = false;
			// 
			// progressBar_Update
			// 
			this.progressBar_Update.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar_Update.Location = new System.Drawing.Point(238, 439);
			this.progressBar_Update.Maximum = 10000;
			this.progressBar_Update.Name = "progressBar_Update";
			this.progressBar_Update.Size = new System.Drawing.Size(384, 10);
			this.progressBar_Update.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progressBar_Update.TabIndex = 2;
			this.progressBar_Update.Visible = false;
			// 
			// pictureBox_Stop
			// 
			this.pictureBox_Stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.pictureBox_Stop.Enabled = false;
			this.pictureBox_Stop.Image = global::sub_db.Resource1.Stop2;
			this.pictureBox_Stop.Location = new System.Drawing.Point(50, 417);
			this.pictureBox_Stop.Name = "pictureBox_Stop";
			this.pictureBox_Stop.Size = new System.Drawing.Size(32, 32);
			this.pictureBox_Stop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox_Stop.TabIndex = 4;
			this.pictureBox_Stop.TabStop = false;
			this.pictureBox_Stop.Click += new System.EventHandler(this.PictureBox_Stop_Click);
			// 
			// pictureBox_Start
			// 
			this.pictureBox_Start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.pictureBox_Start.Image = global::sub_db.Resource1.Start;
			this.pictureBox_Start.Location = new System.Drawing.Point(12, 417);
			this.pictureBox_Start.Name = "pictureBox_Start";
			this.pictureBox_Start.Size = new System.Drawing.Size(32, 32);
			this.pictureBox_Start.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox_Start.TabIndex = 3;
			this.pictureBox_Start.TabStop = false;
			this.pictureBox_Start.Click += new System.EventHandler(this.PictureBox_Start_Click);
			// 
			// radioButton_UseLocalData
			// 
			this.radioButton_UseLocalData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.radioButton_UseLocalData.AutoSize = true;
			this.radioButton_UseLocalData.Checked = true;
			this.radioButton_UseLocalData.Location = new System.Drawing.Point(88, 417);
			this.radioButton_UseLocalData.Name = "radioButton_UseLocalData";
			this.radioButton_UseLocalData.Size = new System.Drawing.Size(119, 16);
			this.radioButton_UseLocalData.TabIndex = 5;
			this.radioButton_UseLocalData.TabStop = true;
			this.radioButton_UseLocalData.Text = "使用本地字幕数据";
			this.radioButton_UseLocalData.UseVisualStyleBackColor = true;
			// 
			// radioButton_UseRemoteData
			// 
			this.radioButton_UseRemoteData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.radioButton_UseRemoteData.AutoSize = true;
			this.radioButton_UseRemoteData.Location = new System.Drawing.Point(88, 433);
			this.radioButton_UseRemoteData.Name = "radioButton_UseRemoteData";
			this.radioButton_UseRemoteData.Size = new System.Drawing.Size(131, 16);
			this.radioButton_UseRemoteData.TabIndex = 6;
			this.radioButton_UseRemoteData.Text = "使用服务器字幕数据";
			this.radioButton_UseRemoteData.UseVisualStyleBackColor = true;
			// 
			// frm_UpdateDatabase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(634, 461);
			this.Controls.Add(this.radioButton_UseRemoteData);
			this.Controls.Add(this.radioButton_UseLocalData);
			this.Controls.Add(this.progressBar_Update);
			this.Controls.Add(this.label_Log);
			this.Controls.Add(this.pictureBox_Stop);
			this.Controls.Add(this.pictureBox_Start);
			this.Controls.Add(this.listView_Log);
			this.Name = "frm_UpdateDatabase";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "更新数据库";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_UpdateDatabase_FormClosing);
			this.Load += new System.EventHandler(this.frm_UpdateDatabase_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_Stop)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_Start)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView listView_Log;
		private System.Windows.Forms.Label label_Log;
		internal System.Windows.Forms.ColumnHeader columnHeader_Time;
		internal System.Windows.Forms.ColumnHeader columnHeader_Log;
		internal System.Windows.Forms.PictureBox pictureBox_Start;
		internal System.Windows.Forms.PictureBox pictureBox_Stop;
		internal System.Windows.Forms.ProgressBar progressBar_Update;
		internal System.Windows.Forms.RadioButton radioButton_UseLocalData;
		internal System.Windows.Forms.RadioButton radioButton_UseRemoteData;
	}
}