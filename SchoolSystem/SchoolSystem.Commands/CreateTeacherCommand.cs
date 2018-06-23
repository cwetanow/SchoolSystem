using SchoolSystem.Commands.Contracts;
using SchoolSystem.Factories;
using SchoolSystem.Models.Enums;
using SchoolSystem.Services.Contracts;
using System;
using System.Collections.Generic;

namespace SchoolSystem.Commands
{
	public class CreateTeacherCommand : ICommand
	{
		private readonly ITeacherFactory factory;
		private readonly ITeacherService service;

		public CreateTeacherCommand(ITeacherFactory factory, ITeacherService service)
		{
			this.factory = factory ?? throw new ArgumentNullException("factory cannot be null");
			this.service = service ?? throw new ArgumentNullException("service cannot be null");
		}

		public string Execute(IList<string> parameters)
		{
			var firstName = parameters[0];
			var lastName = parameters[1];
			var subject = (Subject)int.Parse(parameters[2]);

			var teacher = this.factory.CreateTeacher(firstName, lastName, subject);

			var id = this.service.AddTeacher(teacher);

			return $"A new teacher with name {firstName} {lastName}, subject {subject} and ID {id} was created.";
		}
	}
}
