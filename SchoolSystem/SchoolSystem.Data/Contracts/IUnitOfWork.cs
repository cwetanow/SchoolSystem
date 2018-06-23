namespace SchoolSystem.Data.Contracts
{
	public interface IUnitOfWork
	{
		int Commit();
	}
}
