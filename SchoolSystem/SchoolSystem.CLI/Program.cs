using Microsoft.Extensions.Configuration;
using Ninject;
using SchoolSystem.Core.Contracts;
using SchoolSystem.Data.Contracts;
using System.IO;

namespace SchoolSystem.CLI
{
	public class Program
	{
		public static void Main()
		{
			var configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.Build();

			var kernel = new StandardKernel();
			kernel.Load(new SchoolSystemModule(configuration));

			var engine = kernel.Get<IEngine>();
			engine.Start();
		}
	}
}
