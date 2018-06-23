using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SchoolSystem.Data;
using System.IO;

namespace SchoolSystem.CLI
{
	public class DbContextFactory : IDesignTimeDbContextFactory<SchoolSystemDbContext>
	{
		public SchoolSystemDbContext CreateDbContext(string[] args)
		{
			var configuration = new ConfigurationBuilder()
						.SetBasePath(Directory.GetCurrentDirectory())
						.AddJsonFile("appsettings.json")
						.Build();

			var connectionString = configuration.GetConnectionString("Default");

			var options = SqlServerDbContextOptionsExtensions
					.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;

			return new SchoolSystemDbContext(options);
		}
	}
}
