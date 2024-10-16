using Field_Groove.Application.Interfaces;
using Field_Groove.Domain.Models;
using Field_Groove.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Field_Groove.Infrastructure.Repositories
{
    public class LeadsRepository : GenericRepository<LeadsModel> , ILeadRepository
    {
        public LeadsRepository(ApplicationDbContext dbcontext) : base(dbcontext){ }



    }
}
