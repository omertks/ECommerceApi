using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.EntityFrameworkCore;
using ECommerceApi.Entity.Entities;

namespace ECommerceApi.Entity.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
