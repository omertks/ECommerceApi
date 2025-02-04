
using MongoDB.Bson;
using MongoDB.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Entity.Entities
{
    public class Comment : BaseEntity
    {
        public string Description { get; set; }
        public float NumberOfStar { get; set; }


        public ObjectId UserId { get; set; }
        public virtual User User { get; set; }

        public ObjectId ProductId { get; set; }
        public virtual Product Product { get; set; }


    }
}
