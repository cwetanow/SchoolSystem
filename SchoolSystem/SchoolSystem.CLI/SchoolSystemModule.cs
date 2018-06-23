using Ninject.Activation;
using Ninject.Modules;
using SchoolSystem.Data;
using SchoolSystem.Data.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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
			this.Kernel.Bind<IDbContext>()
				.To<SchoolSystemDbContext>()
				.InThreadScope()
				.WithConstructorArgument("options", (context) => this.GetDbContextOptions(context));

			this.Kernel.Bind(typeof(IRepository<>))
				.To(typeof(EfRepository<>))
				.InThreadScope();

			this.Kernel.Bind<IUnitOfWork>()
				.To<UnitOfWork>()
				.InThreadScope();
		}

		private DbContextOptions GetDbContextOptions(IContext context)
		{
			var connectionString = this.configuration.GetConnectionString("Default");

			return SqlServerDbContextOptionsExtensions
				.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
		}
	}
}
