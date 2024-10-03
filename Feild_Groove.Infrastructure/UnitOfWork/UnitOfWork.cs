using Feild_Groove.Infrastructure.Data;
using Feild_Groove.Infrastructure.Repositories;
using Field_Groove.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feild_Groove.Infrastructure.UnitOfWork
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
