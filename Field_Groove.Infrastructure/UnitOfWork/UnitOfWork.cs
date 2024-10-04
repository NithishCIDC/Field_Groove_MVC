using Field_Groove.Application.Interfaces;
using Field_Groove.Infrastructure.Data;
using Field_Groove.Infrastructure.Repositories;

namespace Field_Groove.Infrastructure.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		public UnitOfWork(ApplicationDbContext dbContext)
		{
			UserRepository = new UserRepository(dbContext);

		}
		public IUserRepository UserRepository { get; private set; }
	}
}
