namespace fBarcode.UI.Dialogs
{
	partial class ImportForm
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
			importLabel = new System.Windows.Forms.Label();
			workersImportButton = new System.Windows.Forms.Button();
			jobsImportButton = new System.Windows.Forms.Button();
			activitiesImportButton = new System.Windows.Forms.Button();
			finishedParcelsImportButton = new System.Windows.Forms.Button();
			SuspendLayout();
			// 
			// importLabel
			// 
			importLabel.AutoSize = true;
			importLabel.Location = new System.Drawing.Point(125, 27);
			importLabel.Name = "importLabel";
			importLabel.Size = new System.Drawing.Size(253, 30);
			importLabel.TabIndex = 0;
			importLabel.Text = "Zvolte položku pro import";
			// 
			// workersImportButton
			// 
			workersImportButton.Location = new System.Drawing.Point(12, 87);
			workersImportButton.Name = "workersImportButton";
			workersImportButton.Size = new System.Drawing.Size(220, 60);
			workersImportButton.TabIndex = 1;
			workersImportButton.Text = "Zaměstnanci";
			workersImportButton.UseVisualStyleBackColor = true;
			// 
			// jobsImportButton
			// 
			jobsImportButton.Location = new System.Drawing.Point(252, 87);
			jobsImportButton.Name = "jobsImportButton";
			jobsImportButton.Size = new System.Drawing.Size(220, 60);
			jobsImportButton.TabIndex = 2;
			jobsImportButton.Text = "Typy činností";
			jobsImportButton.UseVisualStyleBackColor = true;
			// 
			// activitiesImportButton
			// 
			activitiesImportButton.Location = new System.Drawing.Point(12, 153);
			activitiesImportButton.Name = "activitiesImportButton";
			activitiesImportButton.Size = new System.Drawing.Size(220, 60);
			activitiesImportButton.TabIndex = 3;
			activitiesImportButton.Text = "Proběhlé činnosti";
			activitiesImportButton.UseVisualStyleBackColor = true;
			// 
			// finishedParcelsImportButton
			// 
			finishedParcelsImportButton.Location = new System.Drawing.Point(252, 153);
			finishedParcelsImportButton.Name = "finishedParcelsImportButton";
			finishedParcelsImportButton.Size = new System.Drawing.Size(220, 60);
			finishedParcelsImportButton.TabIndex = 4;
			finishedParcelsImportButton.Text = "Dokončené zásilky";
			finishedParcelsImportButton.UseVisualStyleBackColor = true;
			// 
			// ImportForm
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(484, 251);
			Controls.Add(finishedParcelsImportButton);
			Controls.Add(activitiesImportButton);
			Controls.Add(jobsImportButton);
			Controls.Add(workersImportButton);
			Controls.Add(importLabel);
			Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			Name = "ImportForm";
			Text = "Import";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private System.Windows.Forms.Label importLabel;
		private System.Windows.Forms.Button workersImportButton;
		private System.Windows.Forms.Button jobsImportButton;
		private System.Windows.Forms.Button activitiesImportButton;
		private System.Windows.Forms.Button finishedParcelsImportButton;
	}
}