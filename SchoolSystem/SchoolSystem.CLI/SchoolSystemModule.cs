using Ninject.Activation;
using Ninject.Modules;
using SchoolSystem.Data;
using SchoolSystem.Data.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SchoolSystem.Providers.Contracts;
using SchoolSystem.Providers;
using SchoolSystem.Commands;
using Ninject.Extensions.Factory;
using SchoolSystem.Core.Contracts;
using SchoolSystem.Core;

namespace SchoolSystem.CLI
{
	public class SchoolSystemModule : NinjectModule
	{
		private readonly IConfigurationRoot configuration;

		public SchoolSystemModule(IConfigurationRoot configuration)
		{
			this.configuration = configuration;
		}

		public override void Load()
		{
			// Commands

			// Factories
			this.Bind<ICommandFactory>()
				.ToFactory()
				.InSingletonScope();

			// Providers
			this.Bind<IReader>()
				.To<ConsoleReaderWriterProvider>()
				.InSingletonScope();

			this.Bind<IWriter>()
				.To<ConsoleReaderWriterProvider>()
				.InSingletonScope();

			this.Bind<IParser>()
				.To<CommandParserProvider>()
				.InSingletonScope();

			// Data
			this.Bind<IDbContext>()
				.To<SchoolSystemDbContext>()
				.InThreadScope()
				.WithConstructorArgument("options", (context) => this.GetDbContextOptions(context));

			this.Bind(typeof(IRepository<>))
				.To(typeof(EfRepository<>))
				.InThreadScope();

			this.Bind<IUnitOfWork>()
				.To<UnitOfWork>()
				.InThreadScope();

			// Core
			this.Bind<IEngine>()
				.To<Engine>();
		}

		private DbContextOptions GetDbContextOptions(IContext context)
		{
			var connectionString = this.configuration.GetConnectionString("Default");

			return SqlServerDbContextOptionsExtensions
				.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
		}
	}
}
