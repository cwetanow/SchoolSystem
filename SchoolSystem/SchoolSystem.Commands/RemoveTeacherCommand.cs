using SchoolSystem.Commands.Contracts;
using SchoolSystem.Services.Contracts;
using System;
using System.Collections.Generic;

namespace SchoolSystem.Commands
{
	public class RemoveTeacherCommand : ICommand
	{
		private readonly ITeacherService service;

		public RemoveTeacherCommand(ITeacherService service)
		{
			this.service = service ?? throw new ArgumentNullException("service cannot be null");
		}

		public string Execute(IList<string> parameters)
		{
			var teacherId = int.Parse(parameters[0]);

			this.service.RemoveTeacher(teacherId);

			return $"Teacher with ID {teacherId} was sucessfully removed.";
		}
	}
}
