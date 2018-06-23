using SchoolSystem.Data.Contracts;
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

		public Teacher GetTeacherById(int teacherId)
		{
			return this.repository.GetById(teacherId);
		}

		public void RemoveTeacher(int teacherId)
		{
			var teacher = this.repository.GetById(teacherId);

			if (teacher == null)
			{
				return;
			}

			this.repository.Delete(teacher);
			this.unitOfWork.Commit();
		}
	}
}
