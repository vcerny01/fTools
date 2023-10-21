
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
			noButton = new System.Windows.Forms.Button();
			yesButton = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
			SuspendLayout();
			// 
			// noButton
			// 
			noButton.DialogResult = System.Windows.Forms.DialogResult.No;
			noButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			noButton.Location = new System.Drawing.Point(195, 49);
			noButton.Name = "noButton";
			noButton.Size = new System.Drawing.Size(177, 50);
			noButton.TabIndex = 1;
			noButton.Text = "NE";
			noButton.UseVisualStyleBackColor = true;
			// 
			// yesButton
			// 
			yesButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
			yesButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			yesButton.Location = new System.Drawing.Point(12, 49);
			yesButton.Name = "yesButton";
			yesButton.Size = new System.Drawing.Size(177, 50);
			yesButton.TabIndex = 0;
			yesButton.Text = "ANO";
			yesButton.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			label1.Location = new System.Drawing.Point(12, 9);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(356, 25);
			label1.TabIndex = 2;
			label1.Text = "Pokračovat v tisku štítku pro tuto zásilku?";
			// 
			// ConfirmParcelDialog
			// 
			AcceptButton = yesButton;
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			CancelButton = noButton;
			ClientSize = new System.Drawing.Size(384, 111);
			Controls.Add(label1);
			Controls.Add(yesButton);
			Controls.Add(noButton);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "ConfirmParcelDialog";
			ShowIcon = false;
			ShowInTaskbar = false;
			Text = "Schválení zásilky";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private System.Windows.Forms.Button noButton;
		private System.Windows.Forms.Button yesButton;
		private System.Windows.Forms.Label label1;
	}
}