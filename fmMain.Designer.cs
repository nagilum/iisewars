namespace iisewars {
	partial class fmMain {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmMain));
			this.label1 = new System.Windows.Forms.Label();
			this.tbSolutionFile = new System.Windows.Forms.TextBox();
			this.btSolutionFile = new System.Windows.Forms.Button();
			this.btGo = new System.Windows.Forms.Button();
			this.lbStep1 = new System.Windows.Forms.Label();
			this.lbStep2 = new System.Windows.Forms.Label();
			this.lbStep3 = new System.Windows.Forms.Label();
			this.pbStep1 = new System.Windows.Forms.PictureBox();
			this.pbStep2 = new System.Windows.Forms.PictureBox();
			this.pbStep3 = new System.Windows.Forms.PictureBox();
			this.pbStep4 = new System.Windows.Forms.PictureBox();
			this.lbStep4 = new System.Windows.Forms.Label();
			this.lbSearchingForVS = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pbStep1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbStep2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbStep3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbStep4)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(67, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Solution File:";
			// 
			// tbSolutionFile
			// 
			this.tbSolutionFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbSolutionFile.Location = new System.Drawing.Point(15, 25);
			this.tbSolutionFile.Name = "tbSolutionFile";
			this.tbSolutionFile.Size = new System.Drawing.Size(312, 20);
			this.tbSolutionFile.TabIndex = 1;
			// 
			// btSolutionFile
			// 
			this.btSolutionFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btSolutionFile.Location = new System.Drawing.Point(333, 22);
			this.btSolutionFile.Name = "btSolutionFile";
			this.btSolutionFile.Size = new System.Drawing.Size(42, 26);
			this.btSolutionFile.TabIndex = 2;
			this.btSolutionFile.Text = "...";
			this.btSolutionFile.UseVisualStyleBackColor = true;
			this.btSolutionFile.Click += new System.EventHandler(this.btSolutionFile_Click);
			// 
			// btGo
			// 
			this.btGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btGo.Location = new System.Drawing.Point(381, 22);
			this.btGo.Name = "btGo";
			this.btGo.Size = new System.Drawing.Size(42, 26);
			this.btGo.TabIndex = 3;
			this.btGo.Text = "Go";
			this.btGo.UseVisualStyleBackColor = true;
			this.btGo.Click += new System.EventHandler(this.btGo_Click);
			// 
			// lbStep1
			// 
			this.lbStep1.AutoSize = true;
			this.lbStep1.ForeColor = System.Drawing.SystemColors.ControlDark;
			this.lbStep1.Location = new System.Drawing.Point(44, 69);
			this.lbStep1.Name = "lbStep1";
			this.lbStep1.Size = new System.Drawing.Size(172, 13);
			this.lbStep1.TabIndex = 4;
			this.lbStep1.Text = "Configure IIS Express with Local IP";
			// 
			// lbStep2
			// 
			this.lbStep2.AutoSize = true;
			this.lbStep2.ForeColor = System.Drawing.SystemColors.ControlDark;
			this.lbStep2.Location = new System.Drawing.Point(44, 92);
			this.lbStep2.Name = "lbStep2";
			this.lbStep2.Size = new System.Drawing.Size(192, 13);
			this.lbStep2.TabIndex = 5;
			this.lbStep2.Text = "Enable Access to the URL for All Users";
			// 
			// lbStep3
			// 
			this.lbStep3.AutoSize = true;
			this.lbStep3.ForeColor = System.Drawing.SystemColors.ControlDark;
			this.lbStep3.Location = new System.Drawing.Point(44, 115);
			this.lbStep3.Name = "lbStep3";
			this.lbStep3.Size = new System.Drawing.Size(169, 13);
			this.lbStep3.TabIndex = 6;
			this.lbStep3.Text = "Open the Port in Windows Firewall";
			// 
			// pbStep1
			// 
			this.pbStep1.Image = global::iisewars.Properties.Resources.check_icon;
			this.pbStep1.Location = new System.Drawing.Point(22, 67);
			this.pbStep1.Name = "pbStep1";
			this.pbStep1.Size = new System.Drawing.Size(16, 16);
			this.pbStep1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pbStep1.TabIndex = 8;
			this.pbStep1.TabStop = false;
			this.pbStep1.Visible = false;
			// 
			// pbStep2
			// 
			this.pbStep2.Image = global::iisewars.Properties.Resources.check_icon;
			this.pbStep2.Location = new System.Drawing.Point(22, 90);
			this.pbStep2.Name = "pbStep2";
			this.pbStep2.Size = new System.Drawing.Size(16, 16);
			this.pbStep2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pbStep2.TabIndex = 9;
			this.pbStep2.TabStop = false;
			this.pbStep2.Visible = false;
			// 
			// pbStep3
			// 
			this.pbStep3.Image = global::iisewars.Properties.Resources.check_icon;
			this.pbStep3.Location = new System.Drawing.Point(22, 113);
			this.pbStep3.Name = "pbStep3";
			this.pbStep3.Size = new System.Drawing.Size(16, 16);
			this.pbStep3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pbStep3.TabIndex = 10;
			this.pbStep3.TabStop = false;
			this.pbStep3.Visible = false;
			// 
			// pbStep4
			// 
			this.pbStep4.Image = global::iisewars.Properties.Resources.check_icon;
			this.pbStep4.Location = new System.Drawing.Point(22, 135);
			this.pbStep4.Name = "pbStep4";
			this.pbStep4.Size = new System.Drawing.Size(16, 16);
			this.pbStep4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pbStep4.TabIndex = 12;
			this.pbStep4.TabStop = false;
			this.pbStep4.Visible = false;
			// 
			// lbStep4
			// 
			this.lbStep4.AutoSize = true;
			this.lbStep4.ForeColor = System.Drawing.SystemColors.ControlDark;
			this.lbStep4.Location = new System.Drawing.Point(44, 137);
			this.lbStep4.Name = "lbStep4";
			this.lbStep4.Size = new System.Drawing.Size(189, 13);
			this.lbStep4.TabIndex = 11;
			this.lbStep4.Text = "Run Solution in Visual Studio as Admin";
			// 
			// lbSearchingForVS
			// 
			this.lbSearchingForVS.Location = new System.Drawing.Point(12, 94);
			this.lbSearchingForVS.Name = "lbSearchingForVS";
			this.lbSearchingForVS.Size = new System.Drawing.Size(411, 21);
			this.lbSearchingForVS.TabIndex = 13;
			this.lbSearchingForVS.Text = "Searching for Visual Studio...";
			this.lbSearchingForVS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lbSearchingForVS.Visible = false;
			// 
			// fmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(435, 176);
			this.Controls.Add(this.pbStep4);
			this.Controls.Add(this.lbStep4);
			this.Controls.Add(this.pbStep3);
			this.Controls.Add(this.pbStep2);
			this.Controls.Add(this.pbStep1);
			this.Controls.Add(this.lbStep3);
			this.Controls.Add(this.lbStep2);
			this.Controls.Add(this.lbStep1);
			this.Controls.Add(this.btGo);
			this.Controls.Add(this.btSolutionFile);
			this.Controls.Add(this.tbSolutionFile);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lbSearchingForVS);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "fmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "IIS Express WebApp Remote Share";
			this.Load += new System.EventHandler(this.fmMain_Load);
			((System.ComponentModel.ISupportInitialize)(this.pbStep1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbStep2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbStep3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbStep4)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbSolutionFile;
		private System.Windows.Forms.Button btSolutionFile;
		private System.Windows.Forms.Button btGo;
		private System.Windows.Forms.Label lbStep1;
		private System.Windows.Forms.Label lbStep2;
		private System.Windows.Forms.Label lbStep3;
		private System.Windows.Forms.PictureBox pbStep1;
		private System.Windows.Forms.PictureBox pbStep2;
		private System.Windows.Forms.PictureBox pbStep3;
		private System.Windows.Forms.PictureBox pbStep4;
		private System.Windows.Forms.Label lbStep4;
		private System.Windows.Forms.Label lbSearchingForVS;
	}
}

