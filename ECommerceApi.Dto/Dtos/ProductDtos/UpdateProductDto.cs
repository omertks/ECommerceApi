﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Dto.Dtos.ProductDtos
{
    public class UpdateProductDto
    {
        public ObjectId Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float? Price { get; set; }
        public int? StockCount { get; set; }
        public bool IsActive { get; set; }
    }
}
