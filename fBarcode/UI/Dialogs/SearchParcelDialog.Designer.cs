namespace fBarcode.UI.Dialogs
{
	partial class SearchParcelDialog
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
			searchParcelButton = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
			searchBox = new System.Windows.Forms.TextBox();
			SuspendLayout();
			// 
			// searchParcelButton
			// 
			searchParcelButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			searchParcelButton.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			searchParcelButton.Location = new System.Drawing.Point(262, 31);
			searchParcelButton.Name = "searchParcelButton";
			searchParcelButton.Size = new System.Drawing.Size(131, 49);
			searchParcelButton.TabIndex = 1;
			searchParcelButton.Text = "OK";
			searchParcelButton.UseVisualStyleBackColor = true;
			searchParcelButton.Click += searchParcelButton_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			label1.Location = new System.Drawing.Point(14, 21);
			label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(151, 17);
			label1.TabIndex = 13;
			label1.Text = "Variabilní symbol zásilky:";
			// 
			// searchBox
			// 
			searchBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			searchBox.Location = new System.Drawing.Point(14, 44);
			searchBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			searchBox.Name = "searchBox";
			searchBox.Size = new System.Drawing.Size(240, 29);
			searchBox.TabIndex = 0;
			// 
			// SearchParcelDialog
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(414, 106);
			Controls.Add(searchParcelButton);
			Controls.Add(label1);
			Controls.Add(searchBox);
			Name = "SearchParcelDialog";
			Text = "Vyhledávání zásilky";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private System.Windows.Forms.Button searchParcelButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox searchBox;
	}
}