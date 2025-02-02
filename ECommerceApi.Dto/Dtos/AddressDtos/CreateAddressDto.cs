using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Dto.Dtos.AddressDtos
{
    public class CreateAddressDto
    {
        public string? OwnerId { get; set; }
        public string? Name { get; set; }
        public string? Description{ get; set; }
    }
}
