using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Villa.BusniessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        Task TCreateAsync(T entity);
        Task TUpdateAsync(T entity);
        Task TDeleteAsync(ObjectId id);
        Task<List<T>> TGetAllAsync();
        Task<T> TGetByIdAsync(ObjectId id);
        Task<int> TCountAsync();
        Task<List<T>> TGetFilteredListAsync(Expression<Func<T, bool>> filter);
        Task<T> TGetFilteredAsync(Expression<Func<T, bool>> filter);
        Task<List<T>> TLastFiveList(Expression<Func<T, object>> filter, int count);
    }
}
