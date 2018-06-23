using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.Data.Contracts
{
	public interface IDbContext
	{
		DbSet<TEntity> DbSet<TEntity>()
			where TEntity : class;

		int SaveChanges();

		void SetAdded<TEntry>(TEntry entity)
			where TEntry : class;

		void SetDeleted<TEntry>(TEntry entity)
			where TEntry : class;

		void SetUpdated<TEntry>(TEntry entity)
			where TEntry : class;
	}
}
