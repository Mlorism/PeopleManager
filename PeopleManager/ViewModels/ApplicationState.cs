using PeopleManager.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeopleManager.ViewModels
{
	static class ApplicationState
	{
		#region Properties
		
		private static User loogedInUser;

		public static User LoogedInUser
		{
			get { return loogedInUser; }
			set { loogedInUser = value; }
		}


		#endregion

		#region Methods
		public static void LogIn(User user)
		{
			LoogedInUser = user;
		}
		#endregion

	}
}
