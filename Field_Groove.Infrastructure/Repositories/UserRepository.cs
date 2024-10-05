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
		public async Task Create(RegisterModel entity)
		{
			bool IsRegistered = await _dbContext.UserData.AsQueryable().AnyAsync(x => x.Email == entity.Email);
			if (!IsRegistered)
			{
				await _dbContext.UserData.AddAsync(entity);
				await _dbContext.SaveChangesAsync();
			}
			else
			{
				throw new Exception("User Already Exist");
			}
		}

		public async Task IsValidUser(LoginModel entity)
		{
			var UserDetail = await _dbContext.UserData.FindAsync(entity.Email);
			if (UserDetail is null)
			{
				throw new Exception("Invalid Credential");
			}
			if (entity.Email != UserDetail.Email)
			{
				throw new Exception("Invalid Credential");
			}
			if (entity.Password != UserDetail.Password)
			{
				throw new Exception("Incorrect Password");
			}
		}
	}
}
