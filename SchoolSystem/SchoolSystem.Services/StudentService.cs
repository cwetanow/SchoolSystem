using SchoolSystem.Data.Contracts;
using SchoolSystem.Models;
using SchoolSystem.Services.Contracts;

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
	}
}
