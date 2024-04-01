using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Villa.DataAccessLayer.Abstract;
using Villa.DataAccessLayer.Context;

namespace Villa.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly VillaContext _villaContext;

        public GenericRepository(VillaContext villaContext)
        {
            _villaContext = villaContext;
        }

        public async Task<int> CountAsync()
        {
            return await _villaContext.Set<T>().CountAsync();
        }

        public async Task CreateAsync(T entity)
        {
            await _villaContext.AddRangeAsync(entity);
            await _villaContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(ObjectId id)
        {
            var value = await GetByIdAsync(id);
            if(value != null)
            {
                _villaContext.Remove(value);
                await _villaContext.SaveChangesAsync();
            }
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _villaContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(ObjectId id)
        {
            return await _villaContext.Set<T>().FindAsync(id); //Null dönebilir diyor
        }

        public async Task<T> GetFilteredAsync(Expression<Func<T, bool>> filter)
        {
            return await _villaContext.Set<T>().Where(filter).FirstOrDefaultAsync();  //Null dönebilir diyor
        }

        public async Task<List<T>> GetFilteredListAsync(Expression<Func<T, bool>> filter)
        {
            return await _villaContext.Set<T>().Where(filter).ToListAsync();
        }

        public async Task<List<T>> LastFiveList(Expression<Func<T, object>> filter,int count)
        {
            return await _villaContext.Set<T>().OrderByDescending(filter).Take(count).ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _villaContext.Update(entity);
            await _villaContext.SaveChangesAsync();
        }
    }
}
