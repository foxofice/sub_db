namespace sub_db
{
	partial class frm_Setting
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
			this.button_OK = new System.Windows.Forms.Button();
			this.label_subs_path = new System.Windows.Forms.Label();
			this.textBox_subs_path = new System.Windows.Forms.TextBox();
			this.button_subs_path = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button_OK
			// 
			this.button_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button_OK.Location = new System.Drawing.Point(377, 42);
			this.button_OK.Name = "button_OK";
			this.button_OK.Size = new System.Drawing.Size(75, 23);
			this.button_OK.TabIndex = 3;
			this.button_OK.Text = "确定";
			this.button_OK.UseVisualStyleBackColor = true;
			this.button_OK.Click += new System.EventHandler(this.Button_OK_Click);
			// 
			// label_subs_path
			// 
			this.label_subs_path.AutoSize = true;
			this.label_subs_path.Location = new System.Drawing.Point(12, 15);
			this.label_subs_path.Name = "label_subs_path";
			this.label_subs_path.Size = new System.Drawing.Size(65, 12);
			this.label_subs_path.TabIndex = 0;
			this.label_subs_path.Text = "字幕路径：";
			// 
			// textBox_subs_path
			// 
			this.textBox_subs_path.Location = new System.Drawing.Point(83, 12);
			this.textBox_subs_path.Name = "textBox_subs_path";
			this.textBox_subs_path.Size = new System.Drawing.Size(332, 21);
			this.textBox_subs_path.TabIndex = 1;
			// 
			// button_subs_path
			// 
			this.button_subs_path.Location = new System.Drawing.Point(421, 10);
			this.button_subs_path.Name = "button_subs_path";
			this.button_subs_path.Size = new System.Drawing.Size(31, 23);
			this.button_subs_path.TabIndex = 2;
			this.button_subs_path.Text = "...";
			this.button_subs_path.UseVisualStyleBackColor = true;
			this.button_subs_path.Click += new System.EventHandler(this.Button_subs_path_Click);
			// 
			// frm_Setting
			// 
			this.AcceptButton = this.button_OK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(464, 77);
			this.Controls.Add(this.button_subs_path);
			this.Controls.Add(this.textBox_subs_path);
			this.Controls.Add(this.label_subs_path);
			this.Controls.Add(this.button_OK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frm_Setting";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "设置";
			this.TopMost = true;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Setting_FormClosing);
			this.Load += new System.EventHandler(this.frm_Setting_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TextBox textBox_subs_path;
		private System.Windows.Forms.Button button_subs_path;
		internal System.Windows.Forms.Label label_subs_path;
		internal System.Windows.Forms.Button button_OK;
	}
}