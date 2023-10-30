
namespace fBarcode.UI
{
	partial class MainForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			mainTabContainer = new System.Windows.Forms.TabControl();
			printBarcodesTab = new System.Windows.Forms.TabPage();
			parcelInfoBoxLabel = new System.Windows.Forms.Label();
			parcelProgressStrip = new System.Windows.Forms.StatusStrip();
			parcelProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			parcelProgressLabel = new System.Windows.Forms.ToolStripStatusLabel();
			parcelInfoBox = new System.Windows.Forms.TextBox();
			saveBarcodeCheckBox = new System.Windows.Forms.CheckBox();
			confirmParcelCheckBox = new System.Windows.Forms.CheckBox();
			eveningParcelCheckBox = new System.Windows.Forms.CheckBox();
			multiParcelCheckBox = new System.Windows.Forms.CheckBox();
			createParcelButton = new System.Windows.Forms.Button();
			orderNumberInputBox = new System.Windows.Forms.TextBox();
			wageManagmentTab = new System.Windows.Forms.TabPage();
			exportButton = new System.Windows.Forms.Button();
			importButton = new System.Windows.Forms.Button();
			overviewLabel = new System.Windows.Forms.Label();
			overviewBox = new System.Windows.Forms.TextBox();
			activityLogLabel = new System.Windows.Forms.Label();
			activityLogBox = new System.Windows.Forms.TextBox();
			addActivityButton = new System.Windows.Forms.Button();
			timeInputBox = new System.Windows.Forms.TextBox();
			chooseActivityBox = new System.Windows.Forms.ComboBox();
			chooseProfileBox = new System.Windows.Forms.ComboBox();
			mainTabContainer.SuspendLayout();
			printBarcodesTab.SuspendLayout();
			parcelProgressStrip.SuspendLayout();
			wageManagmentTab.SuspendLayout();
			SuspendLayout();
			// 
			// mainTabContainer
			// 
			mainTabContainer.Controls.Add(printBarcodesTab);
			mainTabContainer.Controls.Add(wageManagmentTab);
			mainTabContainer.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			mainTabContainer.ItemSize = new System.Drawing.Size(400, 28);
			mainTabContainer.Location = new System.Drawing.Point(14, 63);
			mainTabContainer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			mainTabContainer.Name = "mainTabContainer";
			mainTabContainer.SelectedIndex = 0;
			mainTabContainer.Size = new System.Drawing.Size(835, 640);
			mainTabContainer.TabIndex = 1;
			// 
			// printBarcodesTab
			// 
			printBarcodesTab.BackColor = System.Drawing.Color.WhiteSmoke;
			printBarcodesTab.Controls.Add(parcelInfoBoxLabel);
			printBarcodesTab.Controls.Add(parcelProgressStrip);
			printBarcodesTab.Controls.Add(parcelInfoBox);
			printBarcodesTab.Controls.Add(saveBarcodeCheckBox);
			printBarcodesTab.Controls.Add(confirmParcelCheckBox);
			printBarcodesTab.Controls.Add(eveningParcelCheckBox);
			printBarcodesTab.Controls.Add(multiParcelCheckBox);
			printBarcodesTab.Controls.Add(createParcelButton);
			printBarcodesTab.Controls.Add(orderNumberInputBox);
			printBarcodesTab.Location = new System.Drawing.Point(4, 32);
			printBarcodesTab.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			printBarcodesTab.Name = "printBarcodesTab";
			printBarcodesTab.Padding = new System.Windows.Forms.Padding(4, 5, 67, 5);
			printBarcodesTab.Size = new System.Drawing.Size(827, 604);
			printBarcodesTab.TabIndex = 0;
			printBarcodesTab.Text = "Tisk štítků ";
			// 
			// parcelInfoBoxLabel
			// 
			parcelInfoBoxLabel.AutoSize = true;
			parcelInfoBoxLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			parcelInfoBoxLabel.Location = new System.Drawing.Point(18, 195);
			parcelInfoBoxLabel.Name = "parcelInfoBoxLabel";
			parcelInfoBoxLabel.Size = new System.Drawing.Size(145, 21);
			parcelInfoBoxLabel.TabIndex = 8;
			parcelInfoBoxLabel.Text = "Informace o zásilce:";
			// 
			// parcelProgressStrip
			// 
			parcelProgressStrip.AutoSize = false;
			parcelProgressStrip.Dock = System.Windows.Forms.DockStyle.None;
			parcelProgressStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { parcelProgressBar, parcelProgressLabel });
			parcelProgressStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
			parcelProgressStrip.Location = new System.Drawing.Point(18, 571);
			parcelProgressStrip.Name = "parcelProgressStrip";
			parcelProgressStrip.Size = new System.Drawing.Size(790, 24);
			parcelProgressStrip.TabIndex = 7;
			parcelProgressStrip.Text = "statusStrip1";
			// 
			// parcelProgressBar
			// 
			parcelProgressBar.Name = "parcelProgressBar";
			parcelProgressBar.Size = new System.Drawing.Size(100, 18);
			// 
			// parcelProgressLabel
			// 
			parcelProgressLabel.Name = "parcelProgressLabel";
			parcelProgressLabel.Size = new System.Drawing.Size(107, 19);
			parcelProgressLabel.Text = "Připojen k databázi";
			// 
			// parcelInfoBox
			// 
			parcelInfoBox.Anchor = System.Windows.Forms.AnchorStyles.None;
			parcelInfoBox.BackColor = System.Drawing.Color.WhiteSmoke;
			parcelInfoBox.Location = new System.Drawing.Point(18, 219);
			parcelInfoBox.Multiline = true;
			parcelInfoBox.Name = "parcelInfoBox";
			parcelInfoBox.ReadOnly = true;
			parcelInfoBox.Size = new System.Drawing.Size(790, 349);
			parcelInfoBox.TabIndex = 99;
			parcelInfoBox.TabStop = false;
			// 
			// saveBarcodeCheckBox
			// 
			saveBarcodeCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
			saveBarcodeCheckBox.BackColor = System.Drawing.Color.LightCoral;
			saveBarcodeCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightGreen;
			saveBarcodeCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			saveBarcodeCheckBox.Location = new System.Drawing.Point(18, 8);
			saveBarcodeCheckBox.Name = "saveBarcodeCheckBox";
			saveBarcodeCheckBox.Size = new System.Drawing.Size(150, 60);
			saveBarcodeCheckBox.TabIndex = 5;
			saveBarcodeCheckBox.Text = "PDF";
			saveBarcodeCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			saveBarcodeCheckBox.UseVisualStyleBackColor = false;
			// 
			// confirmParcelCheckBox
			// 
			confirmParcelCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
			confirmParcelCheckBox.BackColor = System.Drawing.Color.LightCoral;
			confirmParcelCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightGreen;
			confirmParcelCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			confirmParcelCheckBox.Location = new System.Drawing.Point(174, 8);
			confirmParcelCheckBox.Name = "confirmParcelCheckBox";
			confirmParcelCheckBox.Size = new System.Drawing.Size(150, 60);
			confirmParcelCheckBox.TabIndex = 4;
			confirmParcelCheckBox.Text = "Zkontrolovat!";
			confirmParcelCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			confirmParcelCheckBox.UseVisualStyleBackColor = false;
			// 
			// eveningParcelCheckBox
			// 
			eveningParcelCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
			eveningParcelCheckBox.BackColor = System.Drawing.Color.Moccasin;
			eveningParcelCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.Violet;
			eveningParcelCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			eveningParcelCheckBox.Location = new System.Drawing.Point(502, 8);
			eveningParcelCheckBox.Name = "eveningParcelCheckBox";
			eveningParcelCheckBox.Size = new System.Drawing.Size(150, 60);
			eveningParcelCheckBox.TabIndex = 3;
			eveningParcelCheckBox.Text = "Doposílka!";
			eveningParcelCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			eveningParcelCheckBox.UseVisualStyleBackColor = false;
			// 
			// multiParcelCheckBox
			// 
			multiParcelCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
			multiParcelCheckBox.BackColor = System.Drawing.Color.Moccasin;
			multiParcelCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.Violet;
			multiParcelCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			multiParcelCheckBox.Location = new System.Drawing.Point(658, 8);
			multiParcelCheckBox.Name = "multiParcelCheckBox";
			multiParcelCheckBox.Size = new System.Drawing.Size(150, 60);
			multiParcelCheckBox.TabIndex = 2;
			multiParcelCheckBox.Text = "VK!";
			multiParcelCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			multiParcelCheckBox.UseVisualStyleBackColor = false;
			// 
			// createParcelButton
			// 
			createParcelButton.Enabled = false;
			createParcelButton.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			createParcelButton.Location = new System.Drawing.Point(18, 123);
			createParcelButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			createParcelButton.Name = "createParcelButton";
			createParcelButton.Size = new System.Drawing.Size(790, 72);
			createParcelButton.TabIndex = 1;
			createParcelButton.Text = " Vytvořit zásilku";
			createParcelButton.UseVisualStyleBackColor = true;
			createParcelButton.Click += createParcelButton_Click;
			// 
			// orderNumberInputBox
			// 
			orderNumberInputBox.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			orderNumberInputBox.Location = new System.Drawing.Point(18, 76);
			orderNumberInputBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			orderNumberInputBox.Name = "orderNumberInputBox";
			orderNumberInputBox.Size = new System.Drawing.Size(790, 37);
			orderNumberInputBox.TabIndex = 0;
			orderNumberInputBox.TextChanged += orderNumberInputBox_TextChanged;
			// 
			// wageManagmentTab
			// 
			wageManagmentTab.Controls.Add(exportButton);
			wageManagmentTab.Controls.Add(importButton);
			wageManagmentTab.Controls.Add(overviewLabel);
			wageManagmentTab.Controls.Add(overviewBox);
			wageManagmentTab.Controls.Add(activityLogLabel);
			wageManagmentTab.Controls.Add(activityLogBox);
			wageManagmentTab.Controls.Add(addActivityButton);
			wageManagmentTab.Controls.Add(timeInputBox);
			wageManagmentTab.Controls.Add(chooseActivityBox);
			wageManagmentTab.Location = new System.Drawing.Point(4, 32);
			wageManagmentTab.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			wageManagmentTab.Name = "wageManagmentTab";
			wageManagmentTab.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			wageManagmentTab.Size = new System.Drawing.Size(827, 604);
			wageManagmentTab.TabIndex = 1;
			wageManagmentTab.Text = "Správa mzdy";
			wageManagmentTab.UseVisualStyleBackColor = true;
			// 
			// exportButton
			// 
			exportButton.Location = new System.Drawing.Point(650, 504);
			exportButton.Name = "exportButton";
			exportButton.Size = new System.Drawing.Size(150, 76);
			exportButton.TabIndex = 105;
			exportButton.Text = "Export";
			exportButton.UseVisualStyleBackColor = true;
			exportButton.Click += exportButton_Click;
			// 
			// importButton
			// 
			importButton.Location = new System.Drawing.Point(492, 504);
			importButton.Name = "importButton";
			importButton.Size = new System.Drawing.Size(150, 76);
			importButton.TabIndex = 104;
			importButton.Text = "Import";
			importButton.UseVisualStyleBackColor = true;
			importButton.Click += importButton_Click;
			// 
			// overviewLabel
			// 
			overviewLabel.AutoSize = true;
			overviewLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			overviewLabel.Location = new System.Drawing.Point(28, 135);
			overviewLabel.Name = "overviewLabel";
			overviewLabel.Size = new System.Drawing.Size(66, 21);
			overviewLabel.TabIndex = 103;
			overviewLabel.Text = "Přehled:";
			// 
			// overviewBox
			// 
			overviewBox.Anchor = System.Windows.Forms.AnchorStyles.None;
			overviewBox.BackColor = System.Drawing.Color.WhiteSmoke;
			overviewBox.Location = new System.Drawing.Point(28, 159);
			overviewBox.Multiline = true;
			overviewBox.Name = "overviewBox";
			overviewBox.ReadOnly = true;
			overviewBox.Size = new System.Drawing.Size(419, 421);
			overviewBox.TabIndex = 102;
			overviewBox.TabStop = false;
			// 
			// activityLogLabel
			// 
			activityLogLabel.AutoSize = true;
			activityLogLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			activityLogLabel.Location = new System.Drawing.Point(492, 135);
			activityLogLabel.Name = "activityLogLabel";
			activityLogLabel.Size = new System.Drawing.Size(126, 21);
			activityLogLabel.TabIndex = 101;
			activityLogLabel.Text = "Záznam činností:";
			// 
			// activityLogBox
			// 
			activityLogBox.Anchor = System.Windows.Forms.AnchorStyles.None;
			activityLogBox.BackColor = System.Drawing.Color.WhiteSmoke;
			activityLogBox.Location = new System.Drawing.Point(492, 159);
			activityLogBox.Multiline = true;
			activityLogBox.Name = "activityLogBox";
			activityLogBox.ReadOnly = true;
			activityLogBox.Size = new System.Drawing.Size(308, 328);
			activityLogBox.TabIndex = 100;
			activityLogBox.TabStop = false;
			// 
			// addActivityButton
			// 
			addActivityButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			addActivityButton.Location = new System.Drawing.Point(560, 20);
			addActivityButton.Name = "addActivityButton";
			addActivityButton.Size = new System.Drawing.Size(240, 82);
			addActivityButton.TabIndex = 6;
			addActivityButton.Text = "ENTER";
			addActivityButton.UseVisualStyleBackColor = true;
			addActivityButton.Click += addActivityButton_Click;
			// 
			// timeInputBox
			// 
			timeInputBox.Location = new System.Drawing.Point(419, 44);
			timeInputBox.Name = "timeInputBox";
			timeInputBox.Size = new System.Drawing.Size(87, 35);
			timeInputBox.TabIndex = 4;
			timeInputBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// chooseActivityBox
			// 
			chooseActivityBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
			chooseActivityBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			chooseActivityBox.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			chooseActivityBox.FormattingEnabled = true;
			chooseActivityBox.Location = new System.Drawing.Point(28, 42);
			chooseActivityBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			chooseActivityBox.Name = "chooseActivityBox";
			chooseActivityBox.Size = new System.Drawing.Size(384, 40);
			chooseActivityBox.TabIndex = 3;
			// 
			// chooseProfileBox
			// 
			chooseProfileBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
			chooseProfileBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			chooseProfileBox.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			chooseProfileBox.FormattingEnabled = true;
			chooseProfileBox.Location = new System.Drawing.Point(18, 13);
			chooseProfileBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			chooseProfileBox.Name = "chooseProfileBox";
			chooseProfileBox.Size = new System.Drawing.Size(411, 40);
			chooseProfileBox.TabIndex = 2;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(854, 711);
			Controls.Add(chooseProfileBox);
			Controls.Add(mainTabContainer);
			Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			MaximizeBox = false;
			Name = "MainForm";
			Text = "fBarcode";
			mainTabContainer.ResumeLayout(false);
			printBarcodesTab.ResumeLayout(false);
			printBarcodesTab.PerformLayout();
			parcelProgressStrip.ResumeLayout(false);
			parcelProgressStrip.PerformLayout();
			wageManagmentTab.ResumeLayout(false);
			wageManagmentTab.PerformLayout();
			ResumeLayout(false);
		}

		#endregion
		private System.Windows.Forms.TabControl mainTabContainer;
		private System.Windows.Forms.TabPage printBarcodesTab;
		private System.Windows.Forms.TabPage wageManagmentTab;
		private System.Windows.Forms.ComboBox chooseProfileBox;
		private System.Windows.Forms.TextBox orderNumberInputBox;
		private System.Windows.Forms.Button createParcelButton;
		private System.Windows.Forms.CheckBox multiParcelCheckBox;
		private System.Windows.Forms.CheckBox confirmParcelCheckBox;
		private System.Windows.Forms.CheckBox eveningParcelCheckBox;
		private System.Windows.Forms.CheckBox saveBarcodeCheckBox;
		private System.Windows.Forms.TextBox parcelInfoBox;
		private System.Windows.Forms.StatusStrip parcelProgressStrip;
		private System.Windows.Forms.ToolStripProgressBar parcelProgressBar;
		private System.Windows.Forms.ToolStripStatusLabel parcelProgressLabel;
		private System.Windows.Forms.Label parcelInfoBoxLabel;
		private System.Windows.Forms.TextBox timeInputBox;
		private System.Windows.Forms.ComboBox chooseActivityBox;
		private System.Windows.Forms.Button addActivityButton;
		private System.Windows.Forms.TextBox activityLogBox;
		private System.Windows.Forms.Label activityLogLabel;
		private System.Windows.Forms.Button exportButton;
		private System.Windows.Forms.Button importButton;
		private System.Windows.Forms.Label overviewLabel;
		private System.Windows.Forms.TextBox overviewBox;
	}
}

