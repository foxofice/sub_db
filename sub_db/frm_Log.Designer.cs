namespace sub_db
{
	partial class frm_Log
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
			listView_Log = new ListView();
			columnHeader_Time = new ColumnHeader();
			columnHeader_Log = new ColumnHeader();
			SuspendLayout();
			// 
			// listView_Log
			// 
			listView_Log.Columns.AddRange(new ColumnHeader[] { columnHeader_Time, columnHeader_Log });
			listView_Log.Dock = DockStyle.Fill;
			listView_Log.FullRowSelect = true;
			listView_Log.GridLines = true;
			listView_Log.Location = new Point(0, 0);
			listView_Log.Margin = new Padding(3, 2, 3, 2);
			listView_Log.Name = "listView_Log";
			listView_Log.Size = new Size(784, 561);
			listView_Log.TabIndex = 1;
			listView_Log.UseCompatibleStateImageBehavior = false;
			listView_Log.View = View.Details;
			listView_Log.Resize += listView_Log_Resize;
			// 
			// columnHeader_Time
			// 
			columnHeader_Time.Text = "时间";
			columnHeader_Time.Width = 122;
			// 
			// columnHeader_Log
			// 
			columnHeader_Log.Text = "日志";
			columnHeader_Log.Width = 641;
			// 
			// frm_Log
			// 
			AutoScaleDimensions = new SizeF(6F, 12F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(784, 561);
			Controls.Add(listView_Log);
			Font = new Font("新宋体", 9F);
			Margin = new Padding(3, 2, 3, 2);
			Name = "frm_Log";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "日志";
			FormClosing += frm_Log_FormClosing;
			Load += frm_Log_Load;
			ResumeLayout(false);
		}

		#endregion

		private ListView listView_Log;
		private ColumnHeader columnHeader_Time;
		private ColumnHeader columnHeader_Log;
	}
}