using ECommerceApi.Bussiness.Abstract;
using ECommerceApi.DataAccess.Abstract;
using ECommerceApi.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Bussiness.Concrete
{
    public class StoreManager : GenericManager<Store>, IStoreService
    {
        public StoreManager(IGenericRepository<Store> genericRepository) : base(genericRepository)
        {
        }
    }
}
