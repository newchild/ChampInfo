namespace ChampInfo
{
	partial class Form1
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
			if (disposing && (components != null))
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
			this.ConnectButton = new System.Windows.Forms.Button();
			this.NameLabel = new System.Windows.Forms.Label();
			this.SpellQ = new System.Windows.Forms.Label();
			this.SpellW = new System.Windows.Forms.Label();
			this.SpellE = new System.Windows.Forms.Label();
			this.SpellR = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// ConnectButton
			// 
			this.ConnectButton.Location = new System.Drawing.Point(12, 12);
			this.ConnectButton.Name = "ConnectButton";
			this.ConnectButton.Size = new System.Drawing.Size(120, 51);
			this.ConnectButton.TabIndex = 0;
			this.ConnectButton.Text = "Fetch Info";
			this.ConnectButton.UseVisualStyleBackColor = true;
			this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
			// 
			// NameLabel
			// 
			this.NameLabel.AutoSize = true;
			this.NameLabel.Location = new System.Drawing.Point(12, 81);
			this.NameLabel.Name = "NameLabel";
			this.NameLabel.Size = new System.Drawing.Size(35, 13);
			this.NameLabel.TabIndex = 1;
			this.NameLabel.Text = "label1";
			// 
			// SpellQ
			// 
			this.SpellQ.AutoSize = true;
			this.SpellQ.Location = new System.Drawing.Point(12, 270);
			this.SpellQ.Name = "SpellQ";
			this.SpellQ.Size = new System.Drawing.Size(35, 13);
			this.SpellQ.TabIndex = 3;
			this.SpellQ.Text = "label2";
			// 
			// SpellW
			// 
			this.SpellW.AutoSize = true;
			this.SpellW.Location = new System.Drawing.Point(212, 270);
			this.SpellW.Name = "SpellW";
			this.SpellW.Size = new System.Drawing.Size(35, 13);
			this.SpellW.TabIndex = 5;
			this.SpellW.Text = "label2";
			this.SpellW.Click += new System.EventHandler(this.SpellW_Click);
			// 
			// SpellE
			// 
			this.SpellE.AutoSize = true;
			this.SpellE.Location = new System.Drawing.Point(454, 270);
			this.SpellE.Name = "SpellE";
			this.SpellE.Size = new System.Drawing.Size(35, 13);
			this.SpellE.TabIndex = 7;
			this.SpellE.Text = "label2";
			// 
			// SpellR
			// 
			this.SpellR.AutoSize = true;
			this.SpellR.Location = new System.Drawing.Point(692, 270);
			this.SpellR.Name = "SpellR";
			this.SpellR.Size = new System.Drawing.Size(35, 13);
			this.SpellR.TabIndex = 9;
			this.SpellR.Text = "label2";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(165, 28);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(310, 20);
			this.textBox1.TabIndex = 11;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(15, 302);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(186, 278);
			this.textBox2.TabIndex = 12;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(215, 302);
			this.textBox3.Multiline = true;
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(224, 278);
			this.textBox3.TabIndex = 13;
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(457, 302);
			this.textBox4.Multiline = true;
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(224, 278);
			this.textBox4.TabIndex = 14;
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(695, 302);
			this.textBox5.Multiline = true;
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(224, 278);
			this.textBox5.TabIndex = 15;
			this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1010, 603);
			this.Controls.Add(this.textBox5);
			this.Controls.Add(this.textBox4);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.SpellR);
			this.Controls.Add(this.SpellE);
			this.Controls.Add(this.SpellW);
			this.Controls.Add(this.SpellQ);
			this.Controls.Add(this.NameLabel);
			this.Controls.Add(this.ConnectButton);
			this.Name = "Form1";
			this.Text = "LoL ChampGrabber";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button ConnectButton;
		private System.Windows.Forms.Label NameLabel;
		private System.Windows.Forms.Label SpellQ;
		private System.Windows.Forms.Label SpellW;
		private System.Windows.Forms.Label SpellE;
		private System.Windows.Forms.Label SpellR;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.TextBox textBox5;
	}
}

