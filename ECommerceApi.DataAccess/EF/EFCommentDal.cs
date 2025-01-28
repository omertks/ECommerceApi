using ECommerceApi.Contexts;
using ECommerceApi.DataAccess.Abstract;
using ECommerceApi.DataAccess.Repositories;
using ECommerceApi.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.DataAccess.EF
{
    public class EFCommentDal : GenericRepository<Comment>, ICommentRepository
    {
        public EFCommentDal(EDbContext context) : base(context)
        {
        }
    }
}
