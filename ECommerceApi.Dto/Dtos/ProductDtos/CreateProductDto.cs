using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Dto.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float? Price { get; set; }
        public int? StockCount { get; set; }

        
        public List<string> PicturesLinks { get; set; }
        public string StoreId { get; set; } // buradanda tam emin değilim
        public List<string> CategoriesIds { get; set; } // categories
    }
}
