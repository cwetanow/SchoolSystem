using SchoolSystem.Models;
using SchoolSystem.Models.Enums;

namespace SchoolSystem.Factories
{
	public interface ITeacherFactory
	{
		Teacher CreateTeacher(string firstName, string lastName, Subject subject);
	}
}
