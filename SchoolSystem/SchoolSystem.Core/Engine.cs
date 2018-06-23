using SchoolSystem.Core.Contracts;
using SchoolSystem.Providers.Contracts;
using System;

namespace SchoolSystem.Core
{
	public class Engine : IEngine
	{
		private const string TerminationCommand = "End";
		private const string NullProvidersExceptionMessage = "cannot be null.";

		private readonly IReader reader;
		private readonly IWriter writer;
		private readonly IParser parser;


		public Engine(IReader readerProvider, IWriter writerProvider, IParser parserProvider)
		{
			this.reader = readerProvider ?? throw new ArgumentNullException($"Reader {NullProvidersExceptionMessage}");
			this.writer = writerProvider ?? throw new ArgumentNullException($"Writer {NullProvidersExceptionMessage}");
			this.parser = parserProvider ?? throw new ArgumentNullException($"Parser {NullProvidersExceptionMessage}");
		}

		public void Start()
		{
			while (true)
			{
				try
				{
					var commandAsString = this.reader.ReadLine();

					if (commandAsString == TerminationCommand)
					{
						break;
					}

					this.ProcessCommand(commandAsString);
				}
				catch (Exception ex)
				{
					this.writer.WriteLine(ex.Message);
				}
			}
		}

		private void ProcessCommand(string commandAsString)
		{

		}
	}
}
