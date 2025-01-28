using ECommerceApi.Contexts;
using ECommerceApi.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using System.Linq.Expressions;

namespace ECommerceApi.DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        EDbContext _context;

        public GenericRepository(EDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ObjectId id)
        {
            var a = await GetByIdAsync(id);
            _context.Set<T>().Remove(a);
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(ObjectId id)
        {
            return await _context.Set<T>().FindAsync(id);
            //return await _context.Set<T>().FirstOrDefaultAsync(id));
        }


        public async Task<List<T>> GetListAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetFilteredListAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
