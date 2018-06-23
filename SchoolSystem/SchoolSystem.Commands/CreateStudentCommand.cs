using SchoolSystem.Commands.Contracts;
using SchoolSystem.Factories;
using SchoolSystem.Models.Enums;
using SchoolSystem.Services.Contracts;
using System;
using System.Collections.Generic;

namespace SchoolSystem.Commands
{
	public class CreateStudentCommand : ICommand
	{
		private readonly IStudentFactory factory;
		private readonly IStudentService service;

		public CreateStudentCommand(IStudentFactory factory, IStudentService service)
		{
			this.factory = factory ?? throw new ArgumentNullException("factory cannot be null");
			this.service = service ?? throw new ArgumentNullException("service cannot be null");
		}

		public string Execute(IList<string> parameters)
		{
			var firstName = parameters[0];
			var lastName = parameters[1];
			var grade = (Grade)int.Parse(parameters[2]);

			var student = this.factory.CreateStudent(firstName, lastName, grade);

			var id = this.service.AddStudent(student);

			return $"A new student with name {firstName} {lastName}, grade {grade} and ID {id} was created.";
		}
	}
}
