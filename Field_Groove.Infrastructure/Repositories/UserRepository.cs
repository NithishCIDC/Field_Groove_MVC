using Field_Groove.Application.Interfaces;
using Field_Groove.Domain.Models;
using Field_Groove.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Field_Groove.Infrastructure.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly ApplicationDbContext _dbContext;

		public UserRepository(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task<string> Create(RegisterModel entity)
		{
			if (entity is not null)
			{
				bool IsRegistered = await _dbContext.UserData.AsQueryable().AnyAsync(x => x.Email == entity.Email);
				if (!IsRegistered)
				{
					await _dbContext.UserData.AddAsync(entity);
					await _dbContext.SaveChangesAsync();
					return "Successfully Registered";
				}
				return "User Already Exist";
			}
			return "Not Valid";
		}

		public async Task<string> IsValidUser(LoginModel entity)
		{
			var UserDetail = await _dbContext.UserData.FindAsync(entity.Email);
			if (UserDetail is null)
			{
				return "Invalid Credential";
			}
			if (UserDetail is not null && entity.Email != UserDetail.Email)
			{
				return "Invalid Credential";
			}
			if (UserDetail is not null && entity.Password != UserDetail.Password)
			{
				return "Incorrect Password";
			}
			return "Loggined Successfully";
		}
	}
}
