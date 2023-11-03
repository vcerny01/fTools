namespace fBarcode.UI.Dialogs
{
	partial class ExportForm
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
			exportLabel = new System.Windows.Forms.Label();
			finishedParcelsExportButton = new System.Windows.Forms.Button();
			activitiesExportButton = new System.Windows.Forms.Button();
			jobsExportButton = new System.Windows.Forms.Button();
			workersExportButton = new System.Windows.Forms.Button();
			createReportButton = new System.Windows.Forms.Button();
			reportTimeIntervalChooser = new System.Windows.Forms.ComboBox();
			reportTimIntervalLabel = new System.Windows.Forms.Label();
			deleteInputBox = new System.Windows.Forms.TextBox();
			deleteButton = new System.Windows.Forms.Button();
			SuspendLayout();
			// 
			// exportLabel
			// 
			exportLabel.AutoSize = true;
			exportLabel.Location = new System.Drawing.Point(121, 107);
			exportLabel.Name = "exportLabel";
			exportLabel.Size = new System.Drawing.Size(251, 30);
			exportLabel.TabIndex = 1;
			exportLabel.Text = "Zvolte položku pro export";
			// 
			// finishedParcelsExportButton
			// 
			finishedParcelsExportButton.Location = new System.Drawing.Point(252, 239);
			finishedParcelsExportButton.Name = "finishedParcelsExportButton";
			finishedParcelsExportButton.Size = new System.Drawing.Size(220, 60);
			finishedParcelsExportButton.TabIndex = 8;
			finishedParcelsExportButton.Text = "Dokončené zásilky";
			finishedParcelsExportButton.UseVisualStyleBackColor = true;
			finishedParcelsExportButton.Click += finishedParcelsExportButton_Click;
			// 
			// activitiesExportButton
			// 
			activitiesExportButton.Location = new System.Drawing.Point(12, 239);
			activitiesExportButton.Name = "activitiesExportButton";
			activitiesExportButton.Size = new System.Drawing.Size(220, 60);
			activitiesExportButton.TabIndex = 7;
			activitiesExportButton.Text = "Proběhlé činnosti";
			activitiesExportButton.UseVisualStyleBackColor = true;
			activitiesExportButton.Click += activitiesExportButton_Click;
			// 
			// jobsExportButton
			// 
			jobsExportButton.Location = new System.Drawing.Point(252, 173);
			jobsExportButton.Name = "jobsExportButton";
			jobsExportButton.Size = new System.Drawing.Size(220, 60);
			jobsExportButton.TabIndex = 6;
			jobsExportButton.Text = "Typy činností";
			jobsExportButton.UseVisualStyleBackColor = true;
			jobsExportButton.Click += jobsExportButton_Click;
			// 
			// workersExportButton
			// 
			workersExportButton.Location = new System.Drawing.Point(12, 173);
			workersExportButton.Name = "workersExportButton";
			workersExportButton.Size = new System.Drawing.Size(220, 60);
			workersExportButton.TabIndex = 5;
			workersExportButton.Text = "Zaměstnanci";
			workersExportButton.UseVisualStyleBackColor = true;
			workersExportButton.Click += workersExportButton_Click;
			// 
			// createReportButton
			// 
			createReportButton.Location = new System.Drawing.Point(12, 12);
			createReportButton.Name = "createReportButton";
			createReportButton.Size = new System.Drawing.Size(275, 68);
			createReportButton.TabIndex = 9;
			createReportButton.Text = "Vytvořit výkaz";
			createReportButton.UseVisualStyleBackColor = true;
			createReportButton.Click += createReportButton_Click;
			// 
			// reportTimeIntervalChooser
			// 
			reportTimeIntervalChooser.Anchor = System.Windows.Forms.AnchorStyles.Top;
			reportTimeIntervalChooser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			reportTimeIntervalChooser.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			reportTimeIntervalChooser.FormattingEnabled = true;
			reportTimeIntervalChooser.Location = new System.Drawing.Point(296, 40);
			reportTimeIntervalChooser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			reportTimeIntervalChooser.Name = "reportTimeIntervalChooser";
			reportTimeIntervalChooser.Size = new System.Drawing.Size(175, 38);
			reportTimeIntervalChooser.TabIndex = 10;
			// 
			// reportTimIntervalLabel
			// 
			reportTimIntervalLabel.AutoSize = true;
			reportTimIntervalLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			reportTimIntervalLabel.Location = new System.Drawing.Point(293, 15);
			reportTimIntervalLabel.Name = "reportTimIntervalLabel";
			reportTimIntervalLabel.Size = new System.Drawing.Size(178, 20);
			reportTimIntervalLabel.TabIndex = 11;
			reportTimIntervalLabel.Text = "Časový interval pro výkaz:";
			// 
			// deleteInputBox
			// 
			deleteInputBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			deleteInputBox.Location = new System.Drawing.Point(12, 328);
			deleteInputBox.Name = "deleteInputBox";
			deleteInputBox.Size = new System.Drawing.Size(253, 29);
			deleteInputBox.TabIndex = 12;
			// 
			// deleteButton
			// 
			deleteButton.BackColor = System.Drawing.SystemColors.ControlLight;
			deleteButton.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
			deleteButton.FlatAppearance.BorderSize = 4;
			deleteButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MistyRose;
			deleteButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
			deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			deleteButton.Location = new System.Drawing.Point(271, 309);
			deleteButton.Name = "deleteButton";
			deleteButton.Size = new System.Drawing.Size(200, 60);
			deleteButton.TabIndex = 13;
			deleteButton.Text = "Vymazat záznam";
			deleteButton.UseVisualStyleBackColor = false;
			deleteButton.Click += deleteButton_Click;
			// 
			// ExportForm
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(484, 381);
			Controls.Add(deleteButton);
			Controls.Add(deleteInputBox);
			Controls.Add(reportTimIntervalLabel);
			Controls.Add(reportTimeIntervalChooser);
			Controls.Add(createReportButton);
			Controls.Add(finishedParcelsExportButton);
			Controls.Add(activitiesExportButton);
			Controls.Add(jobsExportButton);
			Controls.Add(workersExportButton);
			Controls.Add(exportLabel);
			Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			Name = "ExportForm";
			Text = "ExportForm";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private System.Windows.Forms.Label exportLabel;
		private System.Windows.Forms.Button finishedParcelsExportButton;
		private System.Windows.Forms.Button activitiesExportButton;
		private System.Windows.Forms.Button jobsExportButton;
		private System.Windows.Forms.Button workersExportButton;
		private System.Windows.Forms.Button createReportButton;
		private System.Windows.Forms.ComboBox reportTimeIntervalChooser;
		private System.Windows.Forms.Label reportTimIntervalLabel;
		private System.Windows.Forms.TextBox deleteInputBox;
		private System.Windows.Forms.Button deleteButton;
	}
}