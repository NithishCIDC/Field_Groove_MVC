using Field_Groove.Application.Interfaces;
using Field_Groove.Domain.Models;
using Field_Groove.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Field_Groove.Infrastructure.Repositories
{
	public class UserRepository : GenericRepository<RegisterModel> , IUserRepository
	{
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public async Task Create(RegisterModel entity)
		{
			bool IsRegistered = await dbContext.UserData.AsQueryable().AnyAsync(x => x.Email == entity.Email);
			if (!IsRegistered)
			{
				await dbContext.UserData.AddAsync(entity);
				await dbContext.SaveChangesAsync();
			}
			else
			{
				throw new Exception("User Already Exist");
			}
		}

        public async Task IsValidUser(LoginModel entity)
		{
			var UserDetail = await dbContext.UserData.FindAsync(entity.Email);
			if (UserDetail is null)
			{
				throw new Exception("Invalid Credential");
			}
			if (entity.Password != UserDetail.Password)
			{
				throw new Exception("Incorrect Password");
			}
		}

        public async Task<string> IsValidEmail(string email)
        {
            var UserDetail = await dbContext.UserData.FindAsync(email);
            if (UserDetail is null)
            {
                throw new Exception("User not Found");
            }
			return UserDetail.Password!;
        }

    }


}
