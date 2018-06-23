using Microsoft.EntityFrameworkCore;
using SchoolSystem.Data.Contracts;
using SchoolSystem.Models;
using SchoolSystem.Services.Contracts;
using System;
using System.Linq;

namespace SchoolSystem.Services
{
	public class StudentService : IStudentService
	{
		public const int MaxStudentMarksCount = 20;

		private readonly IRepository<Student> repository;
		private readonly IUnitOfWork unitOfWork;

		public StudentService(IRepository<Student> repository, IUnitOfWork unitOfWork)
		{
			this.repository = repository;
			this.unitOfWork = unitOfWork;
		}

		public void AddMark(Student student, Mark mark)
		{
			if (student.Marks.Count >= MaxStudentMarksCount)
			{
				throw new ArgumentException($"The student's marks count exceed the maximum count of {MaxStudentMarksCount} marks");
			}

			student.Marks.Add(mark);

			this.repository.Update(student);
			this.unitOfWork.Commit();
		}

		public int AddStudent(Student student)
		{
			this.repository.Add(student);
			this.unitOfWork.Commit();

			return student.Id;
		}

		public Student GetStudentById(int studentId)
		{
			var student = this.repository.All
					.Include(s => s.Marks)
					.FirstOrDefault(s => s.Id == studentId);

			return student;
		}

		public void RemoveStudent(int studentId)
		{
			var student = this.repository.GetById(studentId);

			if (student == null)
			{
				return;
			}

			this.repository.Delete(student);
			this.unitOfWork.Commit();
		}
	}
}
