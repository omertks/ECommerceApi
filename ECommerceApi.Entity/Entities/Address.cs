using ECommerceApi.Entity.Entities;
using MongoDB.Bson;
using MongoDB.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Entity.Entities
{
    public class Address : BaseEntity
    {
        // Buraya Şehir ilçe falan eklenebilir.
        public string Name { get; set; }
        public string Description { get; set; }


        public ObjectId OwnerId { get; set; }
        public virtual User Owner { get; set; }
    }
}
