using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Field_Groove.Application.Interfaces
{
	public interface IUnitOfWork
	{
		public IUserRepository UserRepository { get; }
	}
}
