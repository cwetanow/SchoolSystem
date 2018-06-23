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
using System.Linq;
using SchoolSystem.Commands.Contracts;
using Ninject;
using SchoolSystem.Factories;
using SchoolSystem.Services.Contracts;
using SchoolSystem.Services;

namespace SchoolSystem.CLI
{
	public class SchoolSystemModule : NinjectModule
	{
		private const string CreateStudentCommandName = "CreateStudent";

		private readonly IConfigurationRoot configuration;

		public SchoolSystemModule(IConfigurationRoot configuration)
		{
			this.configuration = configuration;
		}

		public override void Load()
		{
			// Commands
			this.Bind<ICommand>()
			   .ToMethod(context =>
			   {
				   var commandParameterName = (string)context.Parameters.ToList()[0].GetValue(context, context.Request.Target);

				   return context.Kernel.Get<ICommand>(commandParameterName);
			   })
			   .When(request => true);

			this.Bind<ICommand>().To<CreateStudentCommand>().Named(CreateStudentCommandName);

			// Factories
			this.Bind<ICommandFactory>()
				.ToFactory()
				.InSingletonScope();

			this.Bind<IStudentFactory>()
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

			// Services
			this.Bind<IStudentService>()
				.To<StudentService>()
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
