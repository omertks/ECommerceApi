
using ECommerceApi.Entity.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.EntityFrameworkCore;

namespace ECommerceApi.Entity.Entities
{
    public class Product : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float? Price { get; set; }
        public int? StockCount { get; set; }
        public float NumberOfStar { get; set; }
        public bool IsActive { get; set; } // default true yap


        public List<Category> Categories { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Picture> Pictures { get; set; }


        public ObjectId StoreId { get; set; }
        public Store? Store { get; set; }

    }
}



//[BsonId]
//[BsonElement(Order = 0)] // yazılırken bu field'ın kaçıncı sırada olacağını belirtiyoruz
//public ObjectId Id { get; set; }
//[BsonElement(Order = 1)]
//public string? Name { get; set; }
//[BsonElement(Order = 2)]
//public string? Description { get; set; }
//[BsonElement(Order = 3)]
//public float? Price { get; set; }
//[BsonElement(Order = 4)]
//public int? StockCount { get; set; }
//[BsonElement(Order = 5)]
//public bool IsActive { get; set; } // default true yap


//// Buraya Yorumlarda gelebilir. Duruma Göre
//public List<Category> Categories { get; set; }
//public Store? Store { get; set; }
