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
			label_Name = new Label();
			textBox_Name = new TextBox();
			label_SubName = new Label();
			textBox_SubName = new TextBox();
			label_Extension = new Label();
			textBox_Extension = new TextBox();
			label_Providers = new Label();
			textBox_Providers = new TextBox();
			label_Desc = new Label();
			textBox_Desc = new TextBox();
			label_Type = new Label();
			comboBox_Type = new ComboBox();
			label_Source = new Label();
			comboBox_Source = new ComboBox();
			checkBox_Time = new CheckBox();
			dateTimePicker_Time = new DateTimePicker();
			linkLabel_Reset = new LinkLabel();
			button_Search = new Button();
			comboBox_Time = new ComboBox();
			SuspendLayout();
			// 
			// label_Name
			// 
			label_Name.AutoSize = true;
			label_Name.Location = new Point(12, 15);
			label_Name.Name = "label_Name";
			label_Name.Size = new Size(65, 12);
			label_Name.TabIndex = 1;
			label_Name.Text = "番剧名称：";
			// 
			// textBox_Name
			// 
			textBox_Name.Location = new Point(167, 12);
			textBox_Name.Name = "textBox_Name";
			textBox_Name.Size = new Size(177, 21);
			textBox_Name.TabIndex = 2;
			// 
			// label_SubName
			// 
			label_SubName.AutoSize = true;
			label_SubName.Location = new Point(12, 42);
			label_SubName.Name = "label_SubName";
			label_SubName.Size = new Size(65, 12);
			label_SubName.TabIndex = 3;
			label_SubName.Text = "字幕名称：";
			// 
			// textBox_SubName
			// 
			textBox_SubName.Location = new Point(167, 39);
			textBox_SubName.Name = "textBox_SubName";
			textBox_SubName.Size = new Size(177, 21);
			textBox_SubName.TabIndex = 4;
			// 
			// label_Extension
			// 
			label_Extension.AutoSize = true;
			label_Extension.Location = new Point(12, 69);
			label_Extension.Name = "label_Extension";
			label_Extension.Size = new Size(89, 12);
			label_Extension.TabIndex = 5;
			label_Extension.Text = "字幕文件后缀：";
			// 
			// textBox_Extension
			// 
			textBox_Extension.Location = new Point(167, 66);
			textBox_Extension.Name = "textBox_Extension";
			textBox_Extension.Size = new Size(177, 21);
			textBox_Extension.TabIndex = 6;
			// 
			// label_Providers
			// 
			label_Providers.AutoSize = true;
			label_Providers.Location = new Point(12, 96);
			label_Providers.Name = "label_Providers";
			label_Providers.Size = new Size(95, 12);
			label_Providers.TabIndex = 7;
			label_Providers.Text = "提供者/字幕组：";
			// 
			// textBox_Providers
			// 
			textBox_Providers.Location = new Point(167, 93);
			textBox_Providers.Name = "textBox_Providers";
			textBox_Providers.Size = new Size(177, 21);
			textBox_Providers.TabIndex = 8;
			// 
			// label_Desc
			// 
			label_Desc.AutoSize = true;
			label_Desc.Location = new Point(12, 123);
			label_Desc.Name = "label_Desc";
			label_Desc.Size = new Size(41, 12);
			label_Desc.TabIndex = 9;
			label_Desc.Text = "描述：";
			// 
			// textBox_Desc
			// 
			textBox_Desc.Location = new Point(167, 120);
			textBox_Desc.Name = "textBox_Desc";
			textBox_Desc.Size = new Size(177, 21);
			textBox_Desc.TabIndex = 10;
			// 
			// label_Type
			// 
			label_Type.AutoSize = true;
			label_Type.Location = new Point(12, 150);
			label_Type.Name = "label_Type";
			label_Type.Size = new Size(41, 12);
			label_Type.TabIndex = 11;
			label_Type.Text = "类型：";
			// 
			// comboBox_Type
			// 
			comboBox_Type.FormattingEnabled = true;
			comboBox_Type.Location = new Point(167, 147);
			comboBox_Type.Name = "comboBox_Type";
			comboBox_Type.Size = new Size(177, 20);
			comboBox_Type.TabIndex = 12;
			// 
			// label_Source
			// 
			label_Source.AutoSize = true;
			label_Source.Location = new Point(12, 176);
			label_Source.Name = "label_Source";
			label_Source.Size = new Size(41, 12);
			label_Source.TabIndex = 13;
			label_Source.Text = "片源：";
			// 
			// comboBox_Source
			// 
			comboBox_Source.FormattingEnabled = true;
			comboBox_Source.Location = new Point(167, 173);
			comboBox_Source.Name = "comboBox_Source";
			comboBox_Source.Size = new Size(177, 20);
			comboBox_Source.TabIndex = 14;
			// 
			// checkBox_Time
			// 
			checkBox_Time.AutoSize = true;
			checkBox_Time.Location = new Point(12, 201);
			checkBox_Time.Name = "checkBox_Time";
			checkBox_Time.Size = new Size(84, 16);
			checkBox_Time.TabIndex = 15;
			checkBox_Time.Text = "放送日期：";
			checkBox_Time.UseVisualStyleBackColor = true;
			checkBox_Time.CheckedChanged += checkBox_Time_CheckedChanged;
			// 
			// dateTimePicker_Time
			// 
			dateTimePicker_Time.Enabled = false;
			dateTimePicker_Time.Location = new Point(212, 199);
			dateTimePicker_Time.Name = "dateTimePicker_Time";
			dateTimePicker_Time.Size = new Size(132, 21);
			dateTimePicker_Time.TabIndex = 17;
			// 
			// linkLabel_Reset
			// 
			linkLabel_Reset.AutoSize = true;
			linkLabel_Reset.Location = new Point(12, 223);
			linkLabel_Reset.Name = "linkLabel_Reset";
			linkLabel_Reset.Size = new Size(77, 12);
			linkLabel_Reset.TabIndex = 18;
			linkLabel_Reset.TabStop = true;
			linkLabel_Reset.Text = "重置搜索条件";
			linkLabel_Reset.LinkClicked += linkLabel_Reset_LinkClicked;
			// 
			// button_Search
			// 
			button_Search.Location = new Point(12, 238);
			button_Search.Name = "button_Search";
			button_Search.Size = new Size(332, 23);
			button_Search.TabIndex = 19;
			button_Search.Text = "搜索";
			button_Search.UseVisualStyleBackColor = true;
			button_Search.Click += button_Search_Click;
			// 
			// comboBox_Time
			// 
			comboBox_Time.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBox_Time.Enabled = false;
			comboBox_Time.FormattingEnabled = true;
			comboBox_Time.Items.AddRange(new object[] { "<", "=", ">" });
			comboBox_Time.Location = new Point(167, 199);
			comboBox_Time.Name = "comboBox_Time";
			comboBox_Time.Size = new Size(39, 20);
			comboBox_Time.TabIndex = 16;
			// 
			// frm_Search
			// 
			AutoScaleDimensions = new SizeF(6F, 12F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(356, 273);
			Controls.Add(comboBox_Time);
			Controls.Add(button_Search);
			Controls.Add(linkLabel_Reset);
			Controls.Add(dateTimePicker_Time);
			Controls.Add(checkBox_Time);
			Controls.Add(comboBox_Source);
			Controls.Add(comboBox_Type);
			Controls.Add(textBox_Desc);
			Controls.Add(label_Source);
			Controls.Add(textBox_Providers);
			Controls.Add(label_Type);
			Controls.Add(label_Desc);
			Controls.Add(textBox_Extension);
			Controls.Add(label_Providers);
			Controls.Add(textBox_SubName);
			Controls.Add(label_Extension);
			Controls.Add(textBox_Name);
			Controls.Add(label_SubName);
			Controls.Add(label_Name);
			Font = new Font("新宋体", 9F);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Margin = new Padding(3, 2, 3, 2);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "frm_Search";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "高级查找";
			FormClosing += frm_Search_FormClosing;
			Load += frm_Search_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label_Name;
		private TextBox textBox_Name;
		private Label label_SubName;
		private TextBox textBox_SubName;
		private Label label_Extension;
		private TextBox textBox_Extension;
		private Label label_Providers;
		private TextBox textBox_Providers;
		private Label label_Desc;
		private TextBox textBox_Desc;
		private Label label_Type;
		private ComboBox comboBox_Type;
		private Label label_Source;
		private ComboBox comboBox_Source;
		private CheckBox checkBox_Time;
		private DateTimePicker dateTimePicker_Time;
		private LinkLabel linkLabel_Reset;
		private Button button_Search;
		private ComboBox comboBox_Time;
	}
}