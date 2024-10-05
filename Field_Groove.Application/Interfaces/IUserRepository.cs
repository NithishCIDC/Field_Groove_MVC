using Field_Groove.Domain.Models;

namespace Field_Groove.Application.Interfaces
{
	public interface IUserRepository
	{
		public Task Create(RegisterModel entity);
		public Task IsValidUser(LoginModel entity);
	}
}
