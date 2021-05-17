using PeopleManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace PeopleManager.ViewModels
{
	class LoginViewModel : BaseViewModel
	{
		#region Commands
		public RelayCommand LoginCommand { get; set; }
		#endregion

		#region Properties
		public static string UserLogin { get; set; }
		public static string UserPassword { get; set; }

		#endregion

		#region Constructor
		public LoginViewModel()
		{
			UserLogin = "";
			UserPassword = "";

			LoginCommand = new RelayCommand(LogInAction, null);
		}

		#endregion

		#region Methods

		public static void LogInAction(object userPassword)
		{
			var password = ((PasswordBox)userPassword).Password;

			User user = UsersList.Instance.Users.FirstOrDefault(x => x.Login == UserLogin);

			if (user != null)
			{
				if (user.Password == password)
				{
					ApplicationState.LogIn(user);
					MainViewModel.SetActiveViewModel("People");
				}

				else
				{
					MessageBox.Show("Incorrect username or password .");
				}
			}

			else
			{
				MessageBox.Show("Incorrect username or password .");
			}
		} // LogInAction() allow user to unlock application if Password and Login are correct, in real application Password would not be stored in plain string

		#endregion


	}
}
