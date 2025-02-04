
using MongoDB.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Entity.Entities
{
    public class User : BaseEntity
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public string MailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public bool Gender { get; set; }


        
        public virtual List<Address> Addresses { get; set; }
        public virtual List<Store> FollowingStores { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
