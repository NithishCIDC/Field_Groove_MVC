
namespace Field_Groove.Application.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		public IUserRepository UserRepository { get; }

		public ILeadRepository Leads { get; }

        Task Save();
    }
}
