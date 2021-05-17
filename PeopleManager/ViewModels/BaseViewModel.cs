using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PeopleManager.ViewModels
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;		

		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		} // OnPropertyChanged()

	}
}
