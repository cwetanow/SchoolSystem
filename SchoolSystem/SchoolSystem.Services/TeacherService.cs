using SchoolSystem.Data.Contracts;
using SchoolSystem.Models;
using SchoolSystem.Services.Contracts;
using System;

namespace SchoolSystem.Services
{
	public class TeacherService : ITeacherService
	{
		private readonly IRepository<Teacher> repository;
		private readonly IUnitOfWork unitOfWork;

		public TeacherService(IRepository<Teacher> repository, IUnitOfWork unitOfWork)
		{
			this.repository = repository;
			this.unitOfWork = unitOfWork;
		}

		public int AddTeacher(Teacher teacher)
		{
			this.repository.Add(teacher);
			this.unitOfWork.Commit();

			return teacher.Id;
		}

		public Teacher GetTeacherById(int teacherId)
		{
			var teacher = this.repository.GetById(teacherId);

			if (teacher == null)
			{
				throw new ArgumentException("The given key was not present in the dictionary.");
			}

			return teacher;
		}

		public void RemoveTeacher(int teacherId)
		{
			var teacher = this.repository.GetById(teacherId);

			if (teacher == null)
			{
				throw new ArgumentException("The given key was not present in the dictionary.");
			}

			this.repository.Delete(teacher);
			this.unitOfWork.Commit();
		}
	}
}
