
namespace BeeTex.Data.Repository
{
	public interface IUnitOfWork
	{
		AppDbContext Context { get; }
		void Save();
	}
}
