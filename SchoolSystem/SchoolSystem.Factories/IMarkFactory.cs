using SchoolSystem.Models;
using SchoolSystem.Models.Enums;

namespace SchoolSystem.Factories
{
	public interface IMarkFactory
	{
		Mark CreateMark(Subject subject, float value);
	}
}
