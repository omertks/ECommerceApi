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
    public class CategoryManager : GenericManager<Category>, ICategoryService
    {
        public CategoryManager(IGenericRepository<Category> genericRepository) : base(genericRepository)
        {
        }
    }
}
