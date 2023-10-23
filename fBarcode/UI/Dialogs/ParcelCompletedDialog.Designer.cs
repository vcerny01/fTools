
namespace fBarcode.UI.Dialogs
{
	partial class ParcelCompletedDialog
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
			yesButton = new System.Windows.Forms.Button();
			noButton = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
			SuspendLayout();
			// 
			// yesButton
			// 
			yesButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
			yesButton.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			yesButton.Location = new System.Drawing.Point(14, 77);
			yesButton.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			yesButton.Name = "yesButton";
			yesButton.Size = new System.Drawing.Size(255, 88);
			yesButton.TabIndex = 2;
			yesButton.Text = "ANO";
			yesButton.UseVisualStyleBackColor = true;
			// 
			// noButton
			// 
			noButton.DialogResult = System.Windows.Forms.DialogResult.No;
			noButton.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			noButton.Location = new System.Drawing.Point(279, 77);
			noButton.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			noButton.Name = "noButton";
			noButton.Size = new System.Drawing.Size(255, 88);
			noButton.TabIndex = 3;
			noButton.Text = "NE";
			noButton.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			label1.ForeColor = System.Drawing.Color.Red;
			label1.Location = new System.Drawing.Point(17, 34);
			label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(517, 25);
			label1.TabIndex = 4;
			label1.Text = "Tato zásilka byla už jednou zpracována, chcete pokračovat?";
			// 
			// ParcelCompletedDialog
			// 
			AcceptButton = yesButton;
			AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Window;
			ClientSize = new System.Drawing.Size(559, 188);
			Controls.Add(label1);
			Controls.Add(noButton);
			Controls.Add(yesButton);
			Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "ParcelCompletedDialog";
			Text = "Potvrzenzí už zpracované zásilky";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private System.Windows.Forms.Button yesButton;
		private System.Windows.Forms.Button noButton;
		private System.Windows.Forms.Label label1;
	}
}