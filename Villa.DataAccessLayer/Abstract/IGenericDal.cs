using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Villa.EntityLayer.Entities;

namespace Villa.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(ObjectId id);
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(ObjectId id);
        Task<int> CountAsync();
        Task<List<T>> GetFilteredListAsync(Expression<Func<T,bool>> filter);
        Task<T> GetFilteredAsync(Expression<Func<T,bool>> filter);
        Task<List<T>> LastFiveList(Expression<Func<T,object>> filter,int count);
    }
}
