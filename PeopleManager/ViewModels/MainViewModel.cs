using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace PeopleManager.ViewModels
{
	public class MainViewModel : BaseViewModel
	{
		#region Properties
		private static BaseViewModel selectedViewModel = new LoginViewModel();		
		public static event EventHandler <PropertyChangedEventArgs> StaticPropertyChanged;

		public static BaseViewModel SelectedViewModel
		{
			get { return selectedViewModel; }
			set { 
				selectedViewModel = value;
				RaiseStaticPropertyChanged("SelectedViewModel");
			}
		}
		#endregion

		#region Methods

		public static void SetActiveViewModel(string ViewModel)
		{
			if (ViewModel == "People")
			{
				SelectedViewModel = new PeopleViewModel();
			}

			else if (ViewModel == "Login")
			{
				SelectedViewModel = new LoginViewModel();
			}

			else
			{
				MessageBox.Show("ViewModel doesn't exist");
			}
		} // SetActiveViewModel() change active ViewModel, with more than 2 ViewModels switch would be more elegant

		static void RaiseStaticPropertyChanged(string propertyName)
		{
			StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
		} // RaiseStaticPropertyChanged()

		#endregion

	}
}
