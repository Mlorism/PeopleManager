using PeopleManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PeopleManager.ViewModels
{
	class UsersList
	{
		#region Properties

		private static readonly ObservableCollection<User> users = new ObservableCollection<User>();
		public ObservableCollection<User> Users => users;

		#endregion

		#region Constructor

		private static readonly UsersList instance = new UsersList();

		public static UsersList Instance => instance;

		static UsersList() => Refresh();

		#endregion

		#region Methods

		public static void Refresh()
		{
			if (Instance.Users.Count < 1)
			{
				User buffer = new User
				{
					Id = 1,
					Login = "admin",
					Password = "admin1"
				};

				Instance.Users.Add(buffer);

				buffer = new User
				{
					Id = 2,
					Login = "ZUrbanowska",
					Password = "Ksiezniczka*49"
				};

				Instance.Users.Add(buffer);

				buffer = new User
				{
					Id = 3,
					Login = "MKonopnicka",
					Password = "Rota42/"
				};

				Instance.Users.Add(buffer);

				buffer = new User
				{
					Id = 4,
					Login = "JBrzechwa",
					Password = "Kleks98+"
				};

				Instance.Users.Add(buffer);

				buffer = new User
				{
					Id = 5,
					Login = "JTuwim",
					Password = "Bambo94-"
				};

				Instance.Users.Add(buffer);
			}
		} //Refresh()
		//check if users exist in the list if not create few dummy Users, in full application there would be a additional module to create and manage users

		#endregion


	}
}
