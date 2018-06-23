using SchoolSystem.Models;

namespace SchoolSystem.Services.Contracts
{
	public interface IStudentService
	{
		int AddStudent(Student student);

		void RemoveStudent(int studentId);
	}
}
