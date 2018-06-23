using Microsoft.EntityFrameworkCore;
using SchoolSystem.Data.Contracts;
using SchoolSystem.Models;
using SchoolSystem.Services.Contracts;
using System.Linq;

namespace SchoolSystem.Services
{
	public class StudentService : IStudentService
	{
		private readonly IRepository<Student> repository;
		private readonly IUnitOfWork unitOfWork;

		public StudentService(IRepository<Student> repository, IUnitOfWork unitOfWork)
		{
			this.repository = repository;
			this.unitOfWork = unitOfWork;
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
