using SchoolSystem.Commands;
using SchoolSystem.Commands.Contracts;
using SchoolSystem.Providers.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SchoolSystem.Providers
{
	public class CommandParserProvider : IParser
	{
		private readonly ICommandFactory factory;

		public CommandParserProvider(ICommandFactory factory)
		{
			this.factory = factory;
		}

		public ICommand ParseCommand(string fullCommand)
		{
			var commandName = fullCommand.Split(' ')[0];

			var command = this.factory.CreateCommand(commandName);

			return command;
		}

		public IList<string> ParseParameters(string fullCommand)
		{
			var commandParts = fullCommand.Split(' ')
				.ToList();
			commandParts.RemoveAt(0);

			if (!commandParts.Any())
			{
				return null;
			}

			return commandParts;
		}
	}
}
