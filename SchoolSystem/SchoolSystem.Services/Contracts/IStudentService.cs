using SchoolSystem.Models;

namespace SchoolSystem.Services.Contracts
{
	public interface IStudentService
	{
		int AddStudent(Student student);

		void RemoveStudent(int studentId);

		Student GetStudentById(int studentId);

		void AddMark(Student student, Mark mark);
	}
}
