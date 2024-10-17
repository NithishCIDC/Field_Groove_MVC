using Field_Groove.Domain.Models;

namespace Field_Groove.Application.Interfaces
{
	public interface IUserRepository : IGenericRepository<RegisterModel>
	{
		public Task Create(RegisterModel entity);
		public Task IsValidUser(LoginModel entity);
		public Task<string> IsValidEmail(string email);

    }
}
