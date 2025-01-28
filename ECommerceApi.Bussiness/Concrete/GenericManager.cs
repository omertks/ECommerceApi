using ECommerceApi.Bussiness.Abstract;
using ECommerceApi.DataAccess.Abstract;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Bussiness.Concrete
{
    public class GenericManager<T> : IGenericService<T> where T : class
    {

        private readonly IGenericRepository<T> _genericRepository;

        public GenericManager(IGenericRepository<T> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task TCreateAsync(T entity)
        {
            await _genericRepository.CreateAsync(entity);
        }

        public async Task TDeleteAsync(ObjectId id)
        {
            await _genericRepository.DeleteAsync(id);
        }

        public async Task<T> TGetByIdAsync(ObjectId id)
        {
            return await _genericRepository.GetByIdAsync(id);
        }

        public async Task<List<T>> TGetFilteredListAsync(Expression<Func<T, bool>> expression)
        {
            return await _genericRepository.GetFilteredListAsync(expression);
        }

        public async Task<List<T>> TGetListAsync()
        {
            return await _genericRepository.GetListAsync();
        }

        public async Task TUpdateAsync(T entity)
        {
            await _genericRepository.UpdateAsync(entity);
        }
    }
}
