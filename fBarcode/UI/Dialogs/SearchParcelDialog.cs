using fBarcode.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fBarcode.UI.Dialogs
{
	public partial class SearchParcelDialog : Form
	{
		public SearchParcelDialog()
		{
			InitializeComponent();
		}

		private void searchParcelButton_Click(object sender, EventArgs e)
		{
			string varSym = searchBox.Text.Trim();
			string searchText = WarehouseManager.GenerateParcelInformationByVarSym(varSym);
			if (searchText == null)
				MessageBox.Show($"Pro variabilní symbol {varSym} nebyly nalezeny žádné záznamy", "Výsledek vyhledávání");
			else
				MessageBox.Show($"{searchText}", "Výsledek vyhledávání");
			Close();
		}
	}
}
