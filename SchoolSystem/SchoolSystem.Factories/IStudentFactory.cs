using SchoolSystem.Models;
using SchoolSystem.Models.Enums;

namespace SchoolSystem.Factories
{
	public interface IStudentFactory
	{
		Student CreateStudent(string firstName, string lastName, Grade grade);
	}
}
