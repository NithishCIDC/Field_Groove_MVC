using Feild_Groove.Domain.Models;
using Feild_Groove.Infrastructure.Data;
using Field_Groove.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feild_Groove.Infrastructure.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Create(RegisterModel  entity)
		{
			await _dbContext.UserData.AddAsync(entity);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<string>  IsRegisterd(LoginModel entity)
		{
			if(entity is not null)
			{
				var UserDetail = await _dbContext.UserData.FindAsync(entity.Email);
				if(UserDetail is not null && entity.Email != UserDetail.Email) 
				{
					return "Invalid Credential";
				}
				if(UserDetail is not null && entity.Password != UserDetail.Password)
				{
					return "Incorrect Password";
				}
			}
			return "OK";
		}
	}
}
