using SchoolSystem.Data.Contracts;

namespace SchoolSystem.Data
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly IDbContext dbContext;

		public UnitOfWork(IDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public int Commit()
		{
			return this.dbContext.SaveChanges();
		}
	}
}
