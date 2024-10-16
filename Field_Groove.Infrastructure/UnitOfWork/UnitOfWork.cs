using Field_Groove.Application.Interfaces;
using Field_Groove.Infrastructure.Data;
using Field_Groove.Infrastructure.Repositories;

namespace Field_Groove.Infrastructure.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
        private readonly ApplicationDbContext dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
		{
            this.dbContext = dbContext;

			UserRepository = new UserRepository(dbContext);

			Leads = new LeadsRepository(dbContext);

		}
		public IUserRepository UserRepository { get; private set; }

        public ILeadRepository Leads { get; private set; }

        public void Dispose()
        {
            
        }

        public async Task Save()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
