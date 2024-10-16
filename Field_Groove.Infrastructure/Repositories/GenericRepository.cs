using Field_Groove.Application.Interfaces;
using Field_Groove.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Field_Groove.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        protected readonly ApplicationDbContext dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Add(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
            await dbContext.SaveChangesAsync();

        }

        public async Task Delete(int id)
        {
            var delete = await GetById(id);

            if (delete != null)
            {
                dbContext.Set<T>().Remove(delete);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var user = await dbContext.Set<T>().ToListAsync();
            return user;
        }

        public async Task<T> GetById(int id)
        {
            var entity = await dbContext.Set<T>().FindAsync(id);

            return entity!;
        }

        public async Task Update(T entity)
        {
            dbContext.Set<T>().Update(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
