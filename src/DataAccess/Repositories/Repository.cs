using System.Linq;
using System.Collections.Generic;
using DataAccess.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace DataAccess.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly FruitContext _context;

        public Repository(FruitContext context)
            => _context = context;

        public async Task<IEnumerable<T>> AllAsync()
            => await _context.Set<T>().ToListAsync();

        public async Task<T> CreateAsync(T entity)
        {
            //entity.Id = Guid.NewGuid().ToString();
            entity.DateUpdated = DateTime.Now;
            entity.Id = Guid.NewGuid().ToString();
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<string> DeleteAsync(string id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();

            return id.ToString();
        }

        public async Task<T> GetByIdAsync(string id)
            => await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<T> UpdateAsync(T entity)
        {
            entity.DateUpdated = DateTime.Now;

            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
