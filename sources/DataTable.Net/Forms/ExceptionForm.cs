using System;
using System.Windows.Forms;

namespace DataTable.Net.Forms
{
	public partial class ExceptionForm : Form
	{
		#region Constructors

		public ExceptionForm(Exception exception)
		{
			InitializeComponent();
			exceptionTextBox.Text = exception.ToString();
		}

		#endregion Constructors
	}
}