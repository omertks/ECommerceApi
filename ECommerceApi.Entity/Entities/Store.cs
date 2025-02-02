
using ECommerceApi.Entity.Entities;
using MongoDB.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace ECommerceApi.Entity.Entities
{
    public class Store : BaseEntity
    {
        // Login işlemi icin

        public string UserName { get; set; } 
        public string Password { get; set; } 



        public string Name { get; set; }
        public float NumberOfStar { get; set; }
        public float NumberOfFollowers { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }



        public List<Order> Orders { get; set; }
        public List<Product> Products { get; set; }
        public List<User> Followers { get; set; }

    }
}
