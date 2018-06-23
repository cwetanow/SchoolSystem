using SchoolSystem.Models;

namespace SchoolSystem.Services.Contracts
{
	public interface ITeacherService
	{
		int AddTeacher(Teacher teacher);

		void RemoveTeacher(int teacherId);
	}
}
