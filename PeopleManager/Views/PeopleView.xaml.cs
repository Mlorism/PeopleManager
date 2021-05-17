using PeopleManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PeopleManager.Views
{
	/// <summary>
	/// Interaction logic for PeopleView.xaml
	/// </summary>
	public partial class PeopleView : Page
	{
		public PeopleView()
		{
			InitializeComponent();
			DataContext = new PeopleViewModel();
		}

		private void EnableButtons(object sender, DataGridCellEditEndingEventArgs e)
		{
			this.btnSave.IsEnabled = true;
			this.btnCancel.IsEnabled = true;
		}		
			

		private void ResetButtons(object sender, RoutedEventArgs e)
		{
			this.btnSave.IsEnabled = false;
			this.btnCancel.IsEnabled = false;
		}
	}
}
