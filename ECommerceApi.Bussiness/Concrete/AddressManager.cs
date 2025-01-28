using ECommerceApi.Bussiness.Abstract;
using ECommerceApi.DataAccess.Abstract;
using ECommerceApi.Entity.Entities;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Bussiness.Concrete
{
    public class AddressManager : GenericManager<Address>, IAddressService
    {
        public AddressManager(IGenericRepository<Address> genericRepository) : base(genericRepository)
        {
        }
    }
}
