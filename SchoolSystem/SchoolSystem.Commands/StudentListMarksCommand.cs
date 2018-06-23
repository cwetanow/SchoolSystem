using SchoolSystem.Commands.Contracts;
using SchoolSystem.Services.Contracts;
using System;
using System.Collections.Generic;

namespace SchoolSystem.Commands
{
	public class StudentListMarksCommand : ICommand
	{
		private readonly IStudentService service;

		public StudentListMarksCommand(IStudentService service)
		{
			this.service = service ?? throw new ArgumentNullException("service cannot be null");
		}

		public string Execute(IList<string> parameters)
		{
			var studentId = int.Parse(parameters[0]);
			var student = this.service.GetStudentById(studentId);

			return student.ListMarks();
		}
	}
}
