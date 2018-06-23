using SchoolSystem.Providers.Contracts;
using System;

namespace SchoolSystem.Providers
{
	public class ConsoleReaderWriterProvider : IReader, IWriter
	{
		public string ReadLine()
		{
			return Console.ReadLine();
		}

		public void Write(string message)
		{
			Console.Write(message);
		}

		public void WriteLine(string message)
		{
			Console.WriteLine(message);
		}
	}
}
