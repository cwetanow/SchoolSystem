namespace SchoolSystem.Models.Abstractions
{
	public abstract class Person : Entity
	{
		protected Person(string firstName, string lastName)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
		}

		public string FirstName { get; set; }

		public string LastName { get; set; }
	}
}
