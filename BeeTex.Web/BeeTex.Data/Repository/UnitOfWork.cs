namespace BeeTex.Data.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		public AppDbContext Context { get; }
		public UnitOfWork(AppDbContext context)
		{
			this.Context = context;
		}

		public void Save()
		{
			Context.SaveChanges();
		}

	}
}

