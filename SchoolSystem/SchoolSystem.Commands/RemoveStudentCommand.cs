using SchoolSystem.Commands.Contracts;
using SchoolSystem.Services.Contracts;
using System;
using System.Collections.Generic;

namespace SchoolSystem.Commands
{
	public class RemoveStudentCommand : ICommand
	{
		private readonly IStudentService schoolService;

		public RemoveStudentCommand(IStudentService service)
		{
			this.schoolService = service ?? throw new ArgumentNullException("service cannot be null");
		}

		public string Execute(IList<string> parameters)
		{
			var studentId = int.Parse(parameters[0]);

			this.schoolService.RemoveStudent(studentId);

			return $"Student with ID {studentId} was sucessfully removed.";
		}
	}
}
