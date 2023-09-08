
namespace fBarcode.UI.Dialogs
{
	partial class ConfirmParcelDialog
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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.noButton = new System.Windows.Forms.Button();
			this.yesButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.SystemColors.Window;
			this.textBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.textBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.textBox1.HideSelection = false;
			this.textBox1.Location = new System.Drawing.Point(12, 12);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(360, 29);
			this.textBox1.TabIndex = 0;
			this.textBox1.TabStop = false;
			this.textBox1.Text = "Pokračovat v tisku štítku pro tuto zásilku?";
			// 
			// noButton
			// 
			this.noButton.DialogResult = System.Windows.Forms.DialogResult.No;
			this.noButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.noButton.Location = new System.Drawing.Point(195, 49);
			this.noButton.Name = "noButton";
			this.noButton.Size = new System.Drawing.Size(177, 50);
			this.noButton.TabIndex = 1;
			this.noButton.Text = "NE";
			this.noButton.UseVisualStyleBackColor = true;
			// 
			// yesButton
			// 
			this.yesButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.yesButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.yesButton.Location = new System.Drawing.Point(12, 49);
			this.yesButton.Name = "yesButton";
			this.yesButton.Size = new System.Drawing.Size(177, 50);
			this.yesButton.TabIndex = 0;
			this.yesButton.Text = "ANO";
			this.yesButton.UseVisualStyleBackColor = true;
			// 
			// ContinueDialog
			// 
			this.AcceptButton = this.yesButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.noButton;
			this.ClientSize = new System.Drawing.Size(384, 111);
			this.Controls.Add(this.yesButton);
			this.Controls.Add(this.noButton);
			this.Controls.Add(this.textBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ContinueDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Schválení zásilky";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button noButton;
		private System.Windows.Forms.Button yesButton;
	}
}