using System;

using SchoolSystem.Models.Abstractions;
using SchoolSystem.Models.Enums;

namespace SchoolSystem.Models
{
	public class Teacher : Person
	{
		public Teacher()
			: base(string.Empty, string.Empty)
		{

		}


		public Teacher(string firstName, string lastName, Subject subject)
			: base(firstName, lastName)
		{
			this.Subject = subject;
		}

		public Subject Subject { get; set; }
	}
}
