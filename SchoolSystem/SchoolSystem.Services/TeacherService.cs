﻿using SchoolSystem.Data.Contracts;
using SchoolSystem.Models;
using SchoolSystem.Services.Contracts;

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
	}
}
