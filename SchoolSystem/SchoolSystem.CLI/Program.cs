using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Ninject;
using Ninject.Extensions.Factory;
using SchoolSystem.Core.Contracts;
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
			kernel.Load(new FuncModule());
			kernel.Load(new SchoolSystemModule(configuration));

			var engine = kernel.Get<IEngine>();
			engine.Start();
		}
	}
}
