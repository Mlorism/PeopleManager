using PeopleManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows;
using System.Xml.Serialization;
using System.Text.RegularExpressions;

namespace PeopleManager.ViewModels
{
	class PeopleViewModel : BaseViewModel
	{
		#region Commands		
		public RelayCommand SaveCommand { get; set; }
		public RelayCommand CancelCommand { get; set; }
		public RelayCommand DeleteCommand { get; set; }
		#endregion

		#region Properties
		private static ObservableCollection<Person> people;

		public static ObservableCollection<Person> People
		{
			get { return people; }
			set { 
				people = value;
				RaiseStaticPropertyChanged("People");
			}
		}

		public static string LoggedInUser {
			get {
				return ApplicationState.LoogedInUser.Login;
			}
		}

		public static event EventHandler<PropertyChangedEventArgs> StaticPropertyChanged;
		#endregion

		public PeopleViewModel()
		{
			People = new ObservableCollection<Person>();		
			
			SaveCommand = new RelayCommand(Save, null);
			CancelCommand = new RelayCommand(Cancel, null);
			DeleteCommand = new RelayCommand(Delete, null);
		}


		#region Methods
						
		public void Save(object x)
		{
			if (ValidateData())
			{
				foreach (Person person in People)
				{
					person.Age = CalculateAge(person.DateOfBirth);
				}

				string mainPath = AppDomain.CurrentDomain.BaseDirectory;
				string usersPath = mainPath + "UsersProfiles";
				string userProfilePath = usersPath + @$"/{ApplicationState.LoogedInUser.Login}";
				string userDataPath = userProfilePath + @"/people.xml";

				if (!Directory.Exists(usersPath))
				{
					Directory.CreateDirectory(usersPath);

				}

				if (!Directory.Exists(userProfilePath))
				{
					Directory.CreateDirectory(userProfilePath);
				}

				XmlSerializer serialiser = new XmlSerializer(typeof(ObservableCollection<Person>));
				TextWriter Filestream = new StreamWriter(userDataPath);
				serialiser.Serialize(Filestream, People);
				Filestream.Close();

				Cancel(new object());
			}


		} // Save() People collection to xml file
		public void Cancel(object x)
		{
			string mainPath = AppDomain.CurrentDomain.BaseDirectory;
			string filePath = mainPath + $@"UsersProfiles/{ApplicationState.LoogedInUser.Login}/people.xml";

			if (File.Exists(filePath))
			{
				XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Person>));
				StreamReader reader = new StreamReader(filePath);
				People = (ObservableCollection<Person>)serializer.Deserialize(reader);
				reader.Close();
			}

			else
			{
				People = new ObservableCollection<Person>();
			}

		} // Cancel() load People collection from xml file
		public void Delete(object person)
		{
			if (person.GetType() == typeof(Person))
			{
				Person targetPerson = (Person)person;
				MessageBoxResult dialog = MessageBox.Show($"Are you sure to delete {targetPerson.FirstName} {targetPerson.LastName}? This person will be deleted permanently.", "Delete", MessageBoxButton.YesNo);

				switch (dialog)
				{	
					case MessageBoxResult.Yes:
						People.Remove((Person)person);
						Save(new object());
						break;
					case MessageBoxResult.No:
						break;
				}				 
			}

			else MessageBox.Show("That person does not exist yet.");
			
		} //Delete person from People collection and xml file
		static void RaiseStaticPropertyChanged(string propertyName)
		{
			StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
		} // RaiseStaticPropertyChanged()
		public int CalculateAge(DateTime birth)
		{			
			int age = DateTime.Now.Year - birth.Year;
			if (DateTime.Now.DayOfYear < birth.DayOfYear)
			{
				age -= 1;
			}

			return age;
		} // CalculateAge()
		public bool ValidateData()
		{
			Regex lettersWithDashRegex = new Regex("^[a-zA-ZżźćńółęąśŻŹĆĄŚĘŁÓŃ-]+$");
			Regex streetTownRegex = new Regex("^[0-9a-zA-ZżźćńółęąśŻŹĆĄŚĘŁÓŃ .,-]+$");
			Regex postalRegex = new Regex("^[0-9-]+$");
			Regex phoneRegex = new Regex("^[0-9- +]+$");

			foreach (Person person in People)
			{
				if (person.FirstName == null || !lettersWithDashRegex.IsMatch(person.FirstName))
				{
					MessageBox.Show($"First name data format for {person.FirstName} {person.LastName} is incorrect or missing.");
					return false;
				}

				if (person.LastName == null || !lettersWithDashRegex.IsMatch(person.LastName))
				{
					MessageBox.Show($"Last name data format for {person.FirstName} {person.LastName} is incorrect or missing.");
					return false;
				}

				if (person.StreetName == null || !streetTownRegex.IsMatch(person.StreetName))
				{
					MessageBox.Show($"Street name dataformat for {person.FirstName} {person.LastName} is incorrect or missing.");
					return false;
				}

				if (person.HouseNumber < 1)
				{
					MessageBox.Show($"House number data format for {person.FirstName} {person.LastName} is incorrect.");
					return false;
				}

				if (person.PostalCode == null || !postalRegex.IsMatch(person.PostalCode))
				{
					MessageBox.Show($"Postal code data format for {person.FirstName} {person.LastName} is incorrect or missing.");
					return false;
				}

				if (person.Town == null || !streetTownRegex.IsMatch(person.Town))
				{
					MessageBox.Show($"Town data format for {person.FirstName} {person.LastName} is incorrect or missing.");
					return false;
				}

				if (person.PhoneNumber == null || !phoneRegex.IsMatch(person.PhoneNumber))
				{
					MessageBox.Show($"Phone number data format for {person.FirstName} {person.LastName} is incorrect or missing.");
					return false;
				}	
				
				if (person.DateOfBirth.Year < 1900)
				{
					MessageBox.Show($"{person.FirstName} {person.LastName} is to old to be still alive. Please correct date of birth.");
					return false;
				}
			}

			return true;
		} // ValidateData() in People collection before saving to xml file

		#endregion

	}


}
