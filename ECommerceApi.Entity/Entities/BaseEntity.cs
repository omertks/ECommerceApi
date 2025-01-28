﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ECommerceApi.Entity.Entities
{
    public class BaseEntity
    {
        [BsonId]
        public ObjectId Id { get; set; }
    }
}
