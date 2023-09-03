
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
            chooseProfileBox = new System.Windows.Forms.ComboBox();
            mainTabContainer.SuspendLayout();
            printBarcodesTab.SuspendLayout();
            parcelProgressStrip.SuspendLayout();
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
            parcelInfoBox.Enabled = false;
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
            wageManagmentTab.Location = new System.Drawing.Point(4, 32);
            wageManagmentTab.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            wageManagmentTab.Name = "wageManagmentTab";
            wageManagmentTab.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            wageManagmentTab.Size = new System.Drawing.Size(827, 604);
            wageManagmentTab.TabIndex = 1;
            wageManagmentTab.Text = "Správa mzdy";
            wageManagmentTab.UseVisualStyleBackColor = true;
            // 
            // chooseProfileBox
            // 
            chooseProfileBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            chooseProfileBox.FormattingEnabled = true;
            chooseProfileBox.Location = new System.Drawing.Point(218, 12);
            chooseProfileBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            chooseProfileBox.Name = "chooseProfileBox";
            chooseProfileBox.Size = new System.Drawing.Size(473, 38);
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
            Text = "Form1";
            mainTabContainer.ResumeLayout(false);
            printBarcodesTab.ResumeLayout(false);
            printBarcodesTab.PerformLayout();
            parcelProgressStrip.ResumeLayout(false);
            parcelProgressStrip.PerformLayout();
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
    }
}

