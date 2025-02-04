using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ECommerceApi.Entity.Entities
{
    public class BaseEntity
    {
        public ObjectId Id { get; set; }
    }
}
