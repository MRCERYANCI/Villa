using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Villa.BusniessLayer.Abstract;
using Villa.DataAccessLayer.Abstract;

namespace Villa.BusniessLayer.Concrete
{
    public class GenericServiceManager<T> : IGenericService<T> where T : class
    {
        private readonly IGenericDal<T> _genericDal;

        public GenericServiceManager(IGenericDal<T> genericDal)
        {
            _genericDal = genericDal;
        }

        public async Task<int> TCountAsync()
        {
            return await _genericDal.CountAsync();
        }

        public async Task TCreateAsync(T entity)
        {
            await _genericDal.CreateAsync(entity);  
        }

        public async Task TDeleteAsync(ObjectId id)
        {
            await _genericDal.DeleteAsync(id); 
        }

        public async Task<List<T>> TGetAllAsync()
        {
            return await _genericDal.GetAllAsync();
        }

        public async Task<T> TGetByIdAsync(ObjectId id)
        {
            return await _genericDal.GetByIdAsync(id);
        }

        public async Task<T> TGetFilteredAsync(Expression<Func<T, bool>> filter)
        {
            return await _genericDal.GetFilteredAsync(filter);
        }

        public async Task<List<T>> TGetFilteredListAsync(Expression<Func<T, bool>> filter)
        {
            return await _genericDal.GetFilteredListAsync(filter);
        }

        public async Task<List<T>> TLastFiveList(Expression<Func<T, object>> filter, int count)
        {
            return await _genericDal.LastFiveList(filter, count);
        }

        public async Task TUpdateAsync(T entity)
        {
            await _genericDal.UpdateAsync(entity);
        }
    }
}
