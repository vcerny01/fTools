
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
			penalizationButton = new System.Windows.Forms.Button();
			searchParcelsButton = new System.Windows.Forms.Button();
			exportButton = new System.Windows.Forms.Button();
			importButton = new System.Windows.Forms.Button();
			overviewLabel = new System.Windows.Forms.Label();
			overviewBox = new System.Windows.Forms.TextBox();
			activityLogLabel = new System.Windows.Forms.Label();
			activityLogBox = new System.Windows.Forms.TextBox();
			addActivityButton = new System.Windows.Forms.Button();
			manualActivityDurationInputBox = new System.Windows.Forms.TextBox();
			manualActivityDescriptionInputBox = new System.Windows.Forms.TextBox();
			manualActivityDatePicker = new System.Windows.Forms.DateTimePicker();
			manualActivityStartTimePicker = new System.Windows.Forms.DateTimePicker();
			manualActivityDescriptionLabel = new System.Windows.Forms.Label();
			manualActivityDateLabel = new System.Windows.Forms.Label();
			manualActivityStartLabel = new System.Windows.Forms.Label();
			manualActivityDurationLabel = new System.Windows.Forms.Label();
			manualActivityEndPreviewLabel = new System.Windows.Forms.Label();
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
			eveningParcelCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightGreen;
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
			multiParcelCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightGreen;
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
			orderNumberInputBox.KeyPress += orderNumberInputBox_KeyPress;
			// 
			// wageManagmentTab
			// 
			wageManagmentTab.Controls.Add(penalizationButton);
			wageManagmentTab.Controls.Add(searchParcelsButton);
			wageManagmentTab.Controls.Add(exportButton);
			wageManagmentTab.Controls.Add(importButton);
			wageManagmentTab.Controls.Add(overviewLabel);
			wageManagmentTab.Controls.Add(overviewBox);
			wageManagmentTab.Controls.Add(activityLogLabel);
			wageManagmentTab.Controls.Add(activityLogBox);
			wageManagmentTab.Controls.Add(addActivityButton);
			wageManagmentTab.Controls.Add(manualActivityDurationInputBox);
			wageManagmentTab.Controls.Add(manualActivityDescriptionInputBox);
			wageManagmentTab.Controls.Add(manualActivityDatePicker);
			wageManagmentTab.Controls.Add(manualActivityStartTimePicker);
			wageManagmentTab.Controls.Add(manualActivityDescriptionLabel);
			wageManagmentTab.Controls.Add(manualActivityDateLabel);
			wageManagmentTab.Controls.Add(manualActivityStartLabel);
			wageManagmentTab.Controls.Add(manualActivityDurationLabel);
			wageManagmentTab.Controls.Add(manualActivityEndPreviewLabel);
			wageManagmentTab.Location = new System.Drawing.Point(4, 32);
			wageManagmentTab.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			wageManagmentTab.Name = "wageManagmentTab";
			wageManagmentTab.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			wageManagmentTab.Size = new System.Drawing.Size(827, 604);
			wageManagmentTab.TabIndex = 1;
			wageManagmentTab.Text = "Správa mzdy";
			wageManagmentTab.UseVisualStyleBackColor = true;
			// 
			// penalizationButton
			// 
			penalizationButton.Location = new System.Drawing.Point(243, 504);
			penalizationButton.Name = "penalizationButton";
			penalizationButton.Size = new System.Drawing.Size(205, 76);
			penalizationButton.TabIndex = 107;
			penalizationButton.Text = "Penalizace";
			penalizationButton.UseVisualStyleBackColor = true;
			penalizationButton.Click += penalizationButton_Click;
			// 
			// searchParcelsButton
			// 
			searchParcelsButton.Location = new System.Drawing.Point(28, 504);
			searchParcelsButton.Name = "searchParcelsButton";
			searchParcelsButton.Size = new System.Drawing.Size(205, 76);
			searchParcelsButton.TabIndex = 106;
			searchParcelsButton.Text = "Vyhledávání";
			searchParcelsButton.UseVisualStyleBackColor = true;
			searchParcelsButton.Click += searchParcelsButton_Click;
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
			overviewBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			overviewBox.Location = new System.Drawing.Point(28, 159);
			overviewBox.Multiline = true;
			overviewBox.Name = "overviewBox";
			overviewBox.ReadOnly = true;
			overviewBox.Size = new System.Drawing.Size(420, 328);
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
			activityLogBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
			addActivityButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			addActivityButton.Location = new System.Drawing.Point(650, 54);
			addActivityButton.Name = "addActivityButton";
			addActivityButton.Size = new System.Drawing.Size(150, 55);
			addActivityButton.TabIndex = 6;
			addActivityButton.Text = "Uložit";
			addActivityButton.UseVisualStyleBackColor = true;
			addActivityButton.Click += addActivityButton_Click;
			//
			// manualActivityDurationInputBox
			//
			manualActivityDurationInputBox.Location = new System.Drawing.Point(492, 70);
			manualActivityDurationInputBox.Name = "manualActivityDurationInputBox";
			manualActivityDurationInputBox.Size = new System.Drawing.Size(95, 35);
			manualActivityDurationInputBox.TabIndex = 5;
			manualActivityDurationInputBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			manualActivityDurationInputBox.TextChanged += manualActivityDurationInputBox_TextChanged;
			manualActivityDurationInputBox.KeyPress += manualActivityDurationInputBox_KeyPress;
			//
			// manualActivityDescriptionInputBox
			//
			manualActivityDescriptionInputBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			manualActivityDescriptionInputBox.Location = new System.Drawing.Point(28, 41);
			manualActivityDescriptionInputBox.Name = "manualActivityDescriptionInputBox";
			manualActivityDescriptionInputBox.Size = new System.Drawing.Size(420, 29);
			manualActivityDescriptionInputBox.TabIndex = 2;
			//
			// manualActivityDatePicker
			//
			manualActivityDatePicker.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			manualActivityDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			manualActivityDatePicker.Location = new System.Drawing.Point(28, 97);
			manualActivityDatePicker.Name = "manualActivityDatePicker";
			manualActivityDatePicker.Size = new System.Drawing.Size(130, 29);
			manualActivityDatePicker.TabIndex = 3;
			manualActivityDatePicker.ValueChanged += manualActivityDatePicker_ValueChanged;
			//
			// manualActivityStartTimePicker
			//
			manualActivityStartTimePicker.CustomFormat = "HH:mm";
			manualActivityStartTimePicker.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			manualActivityStartTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			manualActivityStartTimePicker.Location = new System.Drawing.Point(196, 97);
			manualActivityStartTimePicker.Name = "manualActivityStartTimePicker";
			manualActivityStartTimePicker.ShowUpDown = true;
			manualActivityStartTimePicker.Size = new System.Drawing.Size(92, 29);
			manualActivityStartTimePicker.TabIndex = 4;
			manualActivityStartTimePicker.ValueChanged += manualActivityStartTimePicker_ValueChanged;
			//
			// manualActivityDescriptionLabel
			//
			manualActivityDescriptionLabel.AutoSize = true;
			manualActivityDescriptionLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			manualActivityDescriptionLabel.Location = new System.Drawing.Point(28, 17);
			manualActivityDescriptionLabel.Name = "manualActivityDescriptionLabel";
			manualActivityDescriptionLabel.Size = new System.Drawing.Size(100, 21);
			manualActivityDescriptionLabel.TabIndex = 108;
			manualActivityDescriptionLabel.Text = "Popis práce:";
			//
			// manualActivityDateLabel
			//
			manualActivityDateLabel.AutoSize = true;
			manualActivityDateLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			manualActivityDateLabel.Location = new System.Drawing.Point(28, 73);
			manualActivityDateLabel.Name = "manualActivityDateLabel";
			manualActivityDateLabel.Size = new System.Drawing.Size(59, 21);
			manualActivityDateLabel.TabIndex = 109;
			manualActivityDateLabel.Text = "Datum:";
			//
			// manualActivityStartLabel
			//
			manualActivityStartLabel.AutoSize = true;
			manualActivityStartLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			manualActivityStartLabel.Location = new System.Drawing.Point(196, 73);
			manualActivityStartLabel.Name = "manualActivityStartLabel";
			manualActivityStartLabel.Size = new System.Drawing.Size(63, 21);
			manualActivityStartLabel.TabIndex = 110;
			manualActivityStartLabel.Text = "Začátek:";
			//
			// manualActivityDurationLabel
			//
			manualActivityDurationLabel.AutoSize = true;
			manualActivityDurationLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			manualActivityDurationLabel.Location = new System.Drawing.Point(492, 46);
			manualActivityDurationLabel.Name = "manualActivityDurationLabel";
			manualActivityDurationLabel.Size = new System.Drawing.Size(77, 21);
			manualActivityDurationLabel.TabIndex = 111;
			manualActivityDurationLabel.Text = "Minutáž:";
			//
			// manualActivityEndPreviewLabel
			//
			manualActivityEndPreviewLabel.AutoSize = true;
			manualActivityEndPreviewLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			manualActivityEndPreviewLabel.Location = new System.Drawing.Point(320, 101);
			manualActivityEndPreviewLabel.Name = "manualActivityEndPreviewLabel";
			manualActivityEndPreviewLabel.Size = new System.Drawing.Size(117, 21);
			manualActivityEndPreviewLabel.TabIndex = 112;
			manualActivityEndPreviewLabel.Text = "Konec: --:--";
			// 
			// chooseProfileBox
			// 
			chooseProfileBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
			chooseProfileBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			chooseProfileBox.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			chooseProfileBox.FormattingEnabled = true;
			chooseProfileBox.Location = new System.Drawing.Point(18, 13);
			chooseProfileBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			chooseProfileBox.Name = "chooseProfileBox";
			chooseProfileBox.Size = new System.Drawing.Size(411, 40);
			chooseProfileBox.TabIndex = 2;
			chooseProfileBox.SelectedIndexChanged += chooseProfileBox_SelectedIndexChanged;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(854, 711);
			Controls.Add(chooseProfileBox);
			Controls.Add(mainTabContainer);
			Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			MaximizeBox = false;
			Name = "MainForm";
			Text = "TSSM";
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
		private System.Windows.Forms.Button addActivityButton;
		private System.Windows.Forms.TextBox manualActivityDurationInputBox;
		private System.Windows.Forms.TextBox manualActivityDescriptionInputBox;
		private System.Windows.Forms.DateTimePicker manualActivityDatePicker;
		private System.Windows.Forms.DateTimePicker manualActivityStartTimePicker;
		private System.Windows.Forms.Label manualActivityDescriptionLabel;
		private System.Windows.Forms.Label manualActivityDateLabel;
		private System.Windows.Forms.Label manualActivityStartLabel;
		private System.Windows.Forms.Label manualActivityDurationLabel;
		private System.Windows.Forms.Label manualActivityEndPreviewLabel;
		private System.Windows.Forms.TextBox activityLogBox;
		private System.Windows.Forms.Label activityLogLabel;
		private System.Windows.Forms.Button exportButton;
		private System.Windows.Forms.Button importButton;
		private System.Windows.Forms.Label overviewLabel;
		private System.Windows.Forms.TextBox overviewBox;
		private System.Windows.Forms.Button searchParcelsButton;
		private System.Windows.Forms.Button penalizationButton;
	}
}

