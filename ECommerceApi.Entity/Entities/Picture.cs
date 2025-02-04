
using MongoDB.Bson;
using MongoDB.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Entity.Entities
{
    public class Picture:BaseEntity
    {
        public string Name { get; set; }
        public string Link { get; set; }


        public ObjectId ProductId { get; set; }
        public virtual Product Product { get; set; }

    }
}
