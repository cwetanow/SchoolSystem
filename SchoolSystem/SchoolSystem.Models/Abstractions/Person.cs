using System;
using System.Text.RegularExpressions;

namespace SchoolSystem.Models.Abstractions
{
	public abstract class Person : Entity
	{
		private const int MinNameLenght = 2;
		private const int MaxNameLenght = 31;

		private readonly string stringCharactersExceptionMessage = $"must contain only latin characters.";
		private readonly string stringLenghtExceptionMessage = $"be in lenght between {MinNameLenght} and {MaxNameLenght} long.";

		private string firstName;
		private string lastName;

		protected Person(string firstName, string lastName)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
		}

		public string FirstName
		{
			get
			{
				return this.firstName;
			}

			set
			{
				// ReGex is one of the cleanest way of doing validations. It doesn't mean that you have to do it this way as well.
				if (!Regex.Match(value, "^[A-Za-z]+$").Success)
				{
					throw new ArgumentException($"FirstName {this.stringCharactersExceptionMessage}");
				}

				if (value.Length < MinNameLenght || value.Length > MaxNameLenght)
				{
					throw new ArgumentException($"LastName {this.stringLenghtExceptionMessage}");
				}

				this.firstName = value;
			}
		}

		public string LastName
		{
			get
			{
				return this.lastName;
			}

			set
			{
				if (!Regex.Match(value, "^[A-Za-z]+$").Success)
				{
					throw new ArgumentException($"FirstName {this.stringCharactersExceptionMessage}");
				}

				if (value.Length < MinNameLenght || value.Length > MaxNameLenght)
				{
					throw new ArgumentException($"LastName {this.stringLenghtExceptionMessage}");
				}

				this.lastName = value;
			}
		}
	}
}
