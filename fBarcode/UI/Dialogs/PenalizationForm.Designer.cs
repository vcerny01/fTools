namespace fBarcode.UI.Dialogs
{
	partial class PenalizationForm
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
			activeWorkerLabel = new System.Windows.Forms.Label();
			searchParcelButton = new System.Windows.Forms.Button();
			penalizatioinRateLabel = new System.Windows.Forms.Label();
			penalizationCountInputBox = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			SuspendLayout();
			// 
			// activeWorkerLabel
			// 
			activeWorkerLabel.AutoSize = true;
			activeWorkerLabel.Location = new System.Drawing.Point(14, 9);
			activeWorkerLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			activeWorkerLabel.Name = "activeWorkerLabel";
			activeWorkerLabel.Size = new System.Drawing.Size(197, 25);
			activeWorkerLabel.TabIndex = 0;
			activeWorkerLabel.Text = "Zvolený zaměstnanec:";
			// 
			// searchParcelButton
			// 
			searchParcelButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			searchParcelButton.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			searchParcelButton.Location = new System.Drawing.Point(14, 101);
			searchParcelButton.Name = "searchParcelButton";
			searchParcelButton.Size = new System.Drawing.Size(452, 56);
			searchParcelButton.TabIndex = 1;
			searchParcelButton.Text = "OK";
			searchParcelButton.UseVisualStyleBackColor = true;
			searchParcelButton.Click += searchParcelButton_Click;
			// 
			// penalizatioinRateLabel
			// 
			penalizatioinRateLabel.AutoSize = true;
			penalizatioinRateLabel.Location = new System.Drawing.Point(12, 49);
			penalizatioinRateLabel.Name = "penalizatioinRateLabel";
			penalizatioinRateLabel.Size = new System.Drawing.Size(257, 25);
			penalizatioinRateLabel.TabIndex = 3;
			penalizatioinRateLabel.Text = " Sazba pro penalizaci: 42 min";
			// 
			// penalizationCountInputBox
			// 
			penalizationCountInputBox.Location = new System.Drawing.Point(412, 46);
			penalizationCountInputBox.Name = "penalizationCountInputBox";
			penalizationCountInputBox.Size = new System.Drawing.Size(54, 33);
			penalizationCountInputBox.TabIndex = 0;
			penalizationCountInputBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			penalizationCountInputBox.TextChanged += penalizationCountInputBox_TextChanged;
			penalizationCountInputBox.KeyPress += penalizationCountInputBox_KeyPress;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(323, 49);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(23, 25);
			label1.TabIndex = 6;
			label1.Text = "X";
			// 
			// PenalizationForm
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(478, 169);
			Controls.Add(label1);
			Controls.Add(penalizationCountInputBox);
			Controls.Add(penalizatioinRateLabel);
			Controls.Add(searchParcelButton);
			Controls.Add(activeWorkerLabel);
			Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			Margin = new System.Windows.Forms.Padding(5);
			Name = "PenalizationForm";
			Text = "Penalizace";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private System.Windows.Forms.Label activeWorkerLabel;
		private System.Windows.Forms.Button searchParcelButton;
		private System.Windows.Forms.Label penalizatioinRateLabel;
		private System.Windows.Forms.TextBox penalizationCountInputBox;
		private System.Windows.Forms.Label label1;
	}
}