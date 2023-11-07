
namespace fBarcode.UI.Dialogs
{
	partial class MultiParcelDialog
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
			button1 = new System.Windows.Forms.Button();
			textBox1 = new System.Windows.Forms.TextBox();
			SuspendLayout();
			// 
			// button1
			// 
			button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			button1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			button1.Location = new System.Drawing.Point(225, 18);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(131, 49);
			button1.TabIndex = 9;
			button1.Text = "OK";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// textBox1
			// 
			textBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			textBox1.Location = new System.Drawing.Point(12, 27);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(207, 29);
			textBox1.TabIndex = 8;
			textBox1.KeyPress += textBox1_KeyPress;
			// 
			// MultiParcelDialog
			// 
			AcceptButton = button1;
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(369, 93);
			Controls.Add(textBox1);
			Controls.Add(button1);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "MultiParcelDialog";
			Text = "Počet kusů ve VK";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox1;
	}
}