using ECommerceApi.Dto.Dtos.CategoryDtos;
using ECommerceApi.Dto.Dtos.StoreDtos;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Dto.Dtos.ProductDtos
{
    public class ResultProductDto
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float? Price { get; set; }
        public int? StockCount { get; set; }
        public bool IsActive { get; set; }

        public ResultStoreForProductDto Store { get; set; }

        public List<ResultCategoryForProductDto> Categories { get; set; }
    }
}
