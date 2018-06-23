using SchoolSystem.Commands.Contracts;
using SchoolSystem.Factories;
using SchoolSystem.Services.Contracts;
using System;
using System.Collections.Generic;

namespace SchoolSystem.Commands
{
	public class TeacherAddMarkCommand : ICommand
	{
		private readonly IMarkFactory markFactory;
		private readonly IStudentService studentService;
		private readonly ITeacherService teacherService;

		public TeacherAddMarkCommand(IMarkFactory factory, IStudentService studentService, ITeacherService teacherService)
		{
			this.markFactory = factory ?? throw new ArgumentNullException("factory cannot be null");
			this.studentService = studentService ?? throw new ArgumentNullException("studentService cannot be null");
			this.teacherService = teacherService ?? throw new ArgumentNullException("teacherService cannot be null");
		}

		public string Execute(IList<string> parameters)
		{
			var teacherId = int.Parse(parameters[0]);
			var studentId = int.Parse(parameters[1]);
			var markValue = float.Parse(parameters[2]);

			var student = this.studentService.GetStudentById(studentId);
			var teacher = this.teacherService.GetTeacherById(teacherId);

			var mark = this.markFactory.CreateMark(teacher.Subject, markValue);

			this.studentService.AddMark(student, mark);

			return $"Teacher {teacher.FirstName} {teacher.LastName} added mark {mark.Value} to student {student.FirstName} {student.LastName} in {teacher.Subject}.";
		}
	}
}
