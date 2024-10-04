using Field_Groove.Domain.Models;

namespace Field_Groove.Application.Interfaces
{
	public interface IUserRepository
	{
		public Task<string> Create(RegisterModel entity);
		public Task<string> IsValidUser(LoginModel entity);
	}
}
