namespace sub_db
{
	partial class frm_Search
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
			this.label_Name = new System.Windows.Forms.Label();
			this.textBox_Name = new System.Windows.Forms.TextBox();
			this.radioButton_Time_EarlierThan = new System.Windows.Forms.RadioButton();
			this.radioButton_Time_Equal = new System.Windows.Forms.RadioButton();
			this.radioButton_Time_LaterThan = new System.Windows.Forms.RadioButton();
			this.label_Type = new System.Windows.Forms.Label();
			this.comboBox_Type = new System.Windows.Forms.ComboBox();
			this.comboBox_Source = new System.Windows.Forms.ComboBox();
			this.label_Source = new System.Windows.Forms.Label();
			this.label_SubName = new System.Windows.Forms.Label();
			this.textBox_SubName = new System.Windows.Forms.TextBox();
			this.textBox_Extension = new System.Windows.Forms.TextBox();
			this.label_Extension = new System.Windows.Forms.Label();
			this.textBox_Providers = new System.Windows.Forms.TextBox();
			this.label_Providers = new System.Windows.Forms.Label();
			this.textBox_Desc = new System.Windows.Forms.TextBox();
			this.label_Desc = new System.Windows.Forms.Label();
			this.dateTimePicker_Time = new System.Windows.Forms.DateTimePicker();
			this.checkBox_Time = new System.Windows.Forms.CheckBox();
			this.button_Search = new System.Windows.Forms.Button();
			this.linkLabel_Reset = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// label_Name
			// 
			this.label_Name.AutoSize = true;
			this.label_Name.Location = new System.Drawing.Point(12, 15);
			this.label_Name.Name = "label_Name";
			this.label_Name.Size = new System.Drawing.Size(65, 12);
			this.label_Name.TabIndex = 0;
			this.label_Name.Text = "影片名称：";
			// 
			// textBox_Name
			// 
			this.textBox_Name.Location = new System.Drawing.Point(113, 12);
			this.textBox_Name.Name = "textBox_Name";
			this.textBox_Name.Size = new System.Drawing.Size(230, 21);
			this.textBox_Name.TabIndex = 1;
			// 
			// radioButton_Time_EarlierThan
			// 
			this.radioButton_Time_EarlierThan.AutoSize = true;
			this.radioButton_Time_EarlierThan.Checked = true;
			this.radioButton_Time_EarlierThan.Enabled = false;
			this.radioButton_Time_EarlierThan.Location = new System.Drawing.Point(116, 202);
			this.radioButton_Time_EarlierThan.Name = "radioButton_Time_EarlierThan";
			this.radioButton_Time_EarlierThan.Size = new System.Drawing.Size(29, 16);
			this.radioButton_Time_EarlierThan.TabIndex = 15;
			this.radioButton_Time_EarlierThan.TabStop = true;
			this.radioButton_Time_EarlierThan.Text = "<";
			this.radioButton_Time_EarlierThan.UseVisualStyleBackColor = true;
			// 
			// radioButton_Time_Equal
			// 
			this.radioButton_Time_Equal.AutoSize = true;
			this.radioButton_Time_Equal.Enabled = false;
			this.radioButton_Time_Equal.Location = new System.Drawing.Point(151, 202);
			this.radioButton_Time_Equal.Name = "radioButton_Time_Equal";
			this.radioButton_Time_Equal.Size = new System.Drawing.Size(29, 16);
			this.radioButton_Time_Equal.TabIndex = 16;
			this.radioButton_Time_Equal.Text = "=";
			this.radioButton_Time_Equal.UseVisualStyleBackColor = true;
			// 
			// radioButton_Time_LaterThan
			// 
			this.radioButton_Time_LaterThan.AutoSize = true;
			this.radioButton_Time_LaterThan.Enabled = false;
			this.radioButton_Time_LaterThan.Location = new System.Drawing.Point(186, 202);
			this.radioButton_Time_LaterThan.Name = "radioButton_Time_LaterThan";
			this.radioButton_Time_LaterThan.Size = new System.Drawing.Size(29, 16);
			this.radioButton_Time_LaterThan.TabIndex = 17;
			this.radioButton_Time_LaterThan.Text = ">";
			this.radioButton_Time_LaterThan.UseVisualStyleBackColor = true;
			// 
			// label_Type
			// 
			this.label_Type.AutoSize = true;
			this.label_Type.Location = new System.Drawing.Point(12, 150);
			this.label_Type.Name = "label_Type";
			this.label_Type.Size = new System.Drawing.Size(41, 12);
			this.label_Type.TabIndex = 10;
			this.label_Type.Text = "类型：";
			// 
			// comboBox_Type
			// 
			this.comboBox_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_Type.FormattingEnabled = true;
			this.comboBox_Type.Location = new System.Drawing.Point(113, 147);
			this.comboBox_Type.Name = "comboBox_Type";
			this.comboBox_Type.Size = new System.Drawing.Size(230, 20);
			this.comboBox_Type.TabIndex = 11;
			// 
			// comboBox_Source
			// 
			this.comboBox_Source.FormattingEnabled = true;
			this.comboBox_Source.Location = new System.Drawing.Point(113, 173);
			this.comboBox_Source.Name = "comboBox_Source";
			this.comboBox_Source.Size = new System.Drawing.Size(230, 20);
			this.comboBox_Source.TabIndex = 13;
			// 
			// label_Source
			// 
			this.label_Source.AutoSize = true;
			this.label_Source.Location = new System.Drawing.Point(12, 176);
			this.label_Source.Name = "label_Source";
			this.label_Source.Size = new System.Drawing.Size(41, 12);
			this.label_Source.TabIndex = 12;
			this.label_Source.Text = "片源：";
			// 
			// label_SubName
			// 
			this.label_SubName.AutoSize = true;
			this.label_SubName.Location = new System.Drawing.Point(12, 42);
			this.label_SubName.Name = "label_SubName";
			this.label_SubName.Size = new System.Drawing.Size(65, 12);
			this.label_SubName.TabIndex = 2;
			this.label_SubName.Text = "字幕名称：";
			// 
			// textBox_SubName
			// 
			this.textBox_SubName.Location = new System.Drawing.Point(113, 39);
			this.textBox_SubName.Name = "textBox_SubName";
			this.textBox_SubName.Size = new System.Drawing.Size(230, 21);
			this.textBox_SubName.TabIndex = 3;
			// 
			// textBox_Extension
			// 
			this.textBox_Extension.Location = new System.Drawing.Point(113, 66);
			this.textBox_Extension.Name = "textBox_Extension";
			this.textBox_Extension.Size = new System.Drawing.Size(230, 21);
			this.textBox_Extension.TabIndex = 5;
			// 
			// label_Extension
			// 
			this.label_Extension.AutoSize = true;
			this.label_Extension.Location = new System.Drawing.Point(12, 69);
			this.label_Extension.Name = "label_Extension";
			this.label_Extension.Size = new System.Drawing.Size(89, 12);
			this.label_Extension.TabIndex = 4;
			this.label_Extension.Text = "字幕文件后缀：";
			// 
			// textBox_Providers
			// 
			this.textBox_Providers.Location = new System.Drawing.Point(113, 93);
			this.textBox_Providers.Name = "textBox_Providers";
			this.textBox_Providers.Size = new System.Drawing.Size(230, 21);
			this.textBox_Providers.TabIndex = 7;
			// 
			// label_Providers
			// 
			this.label_Providers.AutoSize = true;
			this.label_Providers.Location = new System.Drawing.Point(12, 96);
			this.label_Providers.Name = "label_Providers";
			this.label_Providers.Size = new System.Drawing.Size(95, 12);
			this.label_Providers.TabIndex = 6;
			this.label_Providers.Text = "提供者/字幕组：";
			// 
			// textBox_Desc
			// 
			this.textBox_Desc.Location = new System.Drawing.Point(113, 120);
			this.textBox_Desc.Name = "textBox_Desc";
			this.textBox_Desc.Size = new System.Drawing.Size(230, 21);
			this.textBox_Desc.TabIndex = 9;
			// 
			// label_Desc
			// 
			this.label_Desc.AutoSize = true;
			this.label_Desc.Location = new System.Drawing.Point(12, 123);
			this.label_Desc.Name = "label_Desc";
			this.label_Desc.Size = new System.Drawing.Size(41, 12);
			this.label_Desc.TabIndex = 8;
			this.label_Desc.Text = "描述：";
			// 
			// dateTimePicker_Time
			// 
			this.dateTimePicker_Time.Enabled = false;
			this.dateTimePicker_Time.Location = new System.Drawing.Point(221, 199);
			this.dateTimePicker_Time.Name = "dateTimePicker_Time";
			this.dateTimePicker_Time.Size = new System.Drawing.Size(122, 21);
			this.dateTimePicker_Time.TabIndex = 18;
			// 
			// checkBox_Time
			// 
			this.checkBox_Time.AutoSize = true;
			this.checkBox_Time.Location = new System.Drawing.Point(14, 203);
			this.checkBox_Time.Name = "checkBox_Time";
			this.checkBox_Time.Size = new System.Drawing.Size(96, 16);
			this.checkBox_Time.TabIndex = 14;
			this.checkBox_Time.Text = "影片放送日期";
			this.checkBox_Time.UseVisualStyleBackColor = true;
			this.checkBox_Time.CheckedChanged += new System.EventHandler(this.CheckBox_Time_CheckedChanged);
			// 
			// button_Search
			// 
			this.button_Search.Location = new System.Drawing.Point(12, 255);
			this.button_Search.Name = "button_Search";
			this.button_Search.Size = new System.Drawing.Size(331, 23);
			this.button_Search.TabIndex = 20;
			this.button_Search.Text = "搜索";
			this.button_Search.UseVisualStyleBackColor = true;
			this.button_Search.Click += new System.EventHandler(this.Button_Search_Click);
			// 
			// linkLabel_Reset
			// 
			this.linkLabel_Reset.AutoSize = true;
			this.linkLabel_Reset.Location = new System.Drawing.Point(12, 226);
			this.linkLabel_Reset.Name = "linkLabel_Reset";
			this.linkLabel_Reset.Size = new System.Drawing.Size(77, 12);
			this.linkLabel_Reset.TabIndex = 19;
			this.linkLabel_Reset.TabStop = true;
			this.linkLabel_Reset.Text = "重置搜索条件";
			this.linkLabel_Reset.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_Reset_LinkClicked);
			// 
			// frm_Search
			// 
			this.AcceptButton = this.button_Search;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(355, 290);
			this.Controls.Add(this.linkLabel_Reset);
			this.Controls.Add(this.button_Search);
			this.Controls.Add(this.checkBox_Time);
			this.Controls.Add(this.radioButton_Time_EarlierThan);
			this.Controls.Add(this.dateTimePicker_Time);
			this.Controls.Add(this.radioButton_Time_Equal);
			this.Controls.Add(this.radioButton_Time_LaterThan);
			this.Controls.Add(this.label_Desc);
			this.Controls.Add(this.textBox_Desc);
			this.Controls.Add(this.label_Providers);
			this.Controls.Add(this.textBox_Providers);
			this.Controls.Add(this.label_Extension);
			this.Controls.Add(this.textBox_Extension);
			this.Controls.Add(this.textBox_SubName);
			this.Controls.Add(this.label_SubName);
			this.Controls.Add(this.label_Source);
			this.Controls.Add(this.comboBox_Source);
			this.Controls.Add(this.comboBox_Type);
			this.Controls.Add(this.label_Type);
			this.Controls.Add(this.textBox_Name);
			this.Controls.Add(this.label_Name);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frm_Search";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "高级查找";
			this.TopMost = true;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Search_FormClosing);
			this.Load += new System.EventHandler(this.frm_Search_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TextBox textBox_Name;
		private System.Windows.Forms.RadioButton radioButton_Time_EarlierThan;
		private System.Windows.Forms.RadioButton radioButton_Time_Equal;
		private System.Windows.Forms.RadioButton radioButton_Time_LaterThan;
		private System.Windows.Forms.TextBox textBox_SubName;
		private System.Windows.Forms.TextBox textBox_Extension;
		private System.Windows.Forms.TextBox textBox_Providers;
		private System.Windows.Forms.TextBox textBox_Desc;
		private System.Windows.Forms.DateTimePicker dateTimePicker_Time;
		internal System.Windows.Forms.Label label_Name;
		internal System.Windows.Forms.Label label_Type;
		internal System.Windows.Forms.Label label_Source;
		internal System.Windows.Forms.Label label_SubName;
		internal System.Windows.Forms.Label label_Extension;
		internal System.Windows.Forms.Label label_Providers;
		internal System.Windows.Forms.Label label_Desc;
		internal System.Windows.Forms.CheckBox checkBox_Time;
		internal System.Windows.Forms.LinkLabel linkLabel_Reset;
		internal System.Windows.Forms.Button button_Search;
		internal System.Windows.Forms.ComboBox comboBox_Type;
		internal System.Windows.Forms.ComboBox comboBox_Source;
	}
}