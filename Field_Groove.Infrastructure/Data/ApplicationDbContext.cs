using Field_Groove.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Field_Groove.Infrastructure.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

		public DbSet<RegisterModel> UserData { get; set; }

		public DbSet<LeadsModel> Leads { get; set; }
	}
}
