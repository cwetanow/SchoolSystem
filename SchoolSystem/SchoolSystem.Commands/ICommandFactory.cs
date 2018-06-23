using SchoolSystem.Commands.Contracts;

namespace SchoolSystem.Commands
{
	public interface ICommandFactory
	{
		ICommand CreateCommand(string commandName);
	}
}
