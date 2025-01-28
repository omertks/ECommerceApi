using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Dto.Dtos.StoreDtos
{
    public class CreateStoreDto
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
    }
}
