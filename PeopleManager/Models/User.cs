using System;
using System.Collections.Generic;
using System.Text;

namespace PeopleManager.Models
{
	public class User
	{
		public int Id { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }
		//in full application the password should be encrypted 
	}
}
