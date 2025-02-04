
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Entity.Entities
{
    public class OrdersItems: BaseEntity
    {

        public ObjectId OrderId { get; set; }
        public virtual Order? Order { get; set; }

        public ObjectId? ProductId { get; set; }
        public virtual Product? Product { get; set; }


        // Bu Kısım o ürünün sipariş anındaki bilgilerini tutabilmek için
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; } // adet
    }
}
