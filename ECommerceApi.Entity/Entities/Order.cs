
using MongoDB.Bson;
using MongoDB.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Entity.Entities
{
    public class Order : BaseEntity
    {
        public string? OrderCode { get; set; }
        public DateTime? OrderDate { get; set; }


        public ObjectId StoreId { get; set; }
        public Store? Store { get; set; }

        public ObjectId OwnerId { get; set; }
        public User? Owner { get; set; }

        public List<OrdersItems>? OrdersItems { get; set; }
    }
}
