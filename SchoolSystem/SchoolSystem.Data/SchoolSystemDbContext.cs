using Microsoft.EntityFrameworkCore;
using SchoolSystem.Data.Contracts;
using SchoolSystem.Models;

namespace SchoolSystem.Data
{
	class SchoolSystemDbContext : DbContext, IDbContext
	{
		public SchoolSystemDbContext(DbContextOptions options)
			   : base(options)
		{
		}

		public DbSet<Teacher> Teachers { get; set; }

		public DbSet<Student> Students { get; set; }

		public DbSet<TEntity> DbSet<TEntity>() where TEntity : class
		{
			return this.Set<TEntity>();
		}

		public void SetAdded<TEntry>(TEntry entity) where TEntry : class
		{
			var entry = this.Entry(entity);
			entry.State = EntityState.Added;
		}

		public void SetDeleted<TEntry>(TEntry entity) where TEntry : class
		{
			var entry = this.Entry(entity);
			entry.State = EntityState.Deleted;
		}

		public void SetUpdated<TEntry>(TEntry entity) where TEntry : class
		{
			var entry = this.Entry(entity);
			entry.State = EntityState.Modified;
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}
	}
}
