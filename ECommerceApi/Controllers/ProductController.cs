using AutoMapper;
using ECommerceApi.Bussiness.Abstract;
using ECommerceApi.Dto.Dtos.CategoryDtos;
using ECommerceApi.Dto.Dtos.ProductDtos;
using ECommerceApi.Dto.Dtos.StoreDtos;
using ECommerceApi.Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Linq.Expressions;
using ZstdSharp.Unsafe;

namespace ECommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductService _productService;

        ICategoryService _categoryService;
        IStoreService _storeService;

        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IStoreService storeService, IMapper mapper, ICategoryService categoryService)
        {
            _productService = productService;
            _mapper = mapper;
            _storeService = storeService;
            _categoryService = categoryService;
        }


        // Buraya Bak
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.TGetListAsync();

            // Store bilgileri null geliyor id hariç

            //List<ResultProductDto> result = _mapper.Map<List<ResultProductDto>>(products);            
            
            return Ok(products);
        }

        [HttpGet("{idString}", Name = "GetProductById")]
        public async Task<IActionResult> GetAllProducts(string idString)
        {
            ObjectId objectId = ObjectId.Parse(idString); // burayı TryParse a çevir

            var product = await _productService.TGetByIdAsync(objectId);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ResultProductDto>(product));
        }

        [HttpGet("search/name/{name}", Name = "SearchProductByName")] // buraya bak
        public async Task<IActionResult> SearchProductByName(string name)
        {
            var rs = await _productService.TGetFilteredListAsync((a) => a.Name.ToLower().Contains(name.ToLower()));

            if (rs == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<ResultProductDto>>(rs));
        }

        [HttpGet("search/price")]
        public async Task<IActionResult> SearchProductByPrice(int? min, int? max, string? name, string? description, bool? isActive)
        {
            Expression<Func<Product, bool>> fn;

            if (min != null && max != null)
            {
                fn = (n) => n.Price <= max && n.Price >= min;
            }
            else if (min != null)
            {
                fn = (n) => n.Price >= min;
            }
            else if (max != null)
            {
                fn = (n) => n.Price <= max;
            }
            else if (!String.IsNullOrEmpty(name))
            {
                fn = (a) => a.Name.ToLower().Contains(name.ToLower());
            }
            else if (!String.IsNullOrEmpty(description))
            {
                fn = (a) => a.Description.ToLower().Contains(description.ToLower());
            }
            else if (isActive != null)
            {
                fn = (n) => n.IsActive == isActive;
            }
            else
            {
                return BadRequest();
            }

            List<Product> products = await _productService.TGetFilteredListAsync(fn);

            return products != null ? Ok(_mapper.Map<List<ResultProductDto>>(products)) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            if (ObjectId.TryParse(createProductDto.StoreId, out ObjectId objectId)) // object Id Kontrol
            {

                var product = _mapper.Map<Product>(createProductDto);

                product.Categories = new List<Category>();

                foreach (string categoryId in createProductDto.CategoriesIds)
                {
                    if (ObjectId.TryParse(categoryId, out ObjectId cId))
                    {
                        var c = await _categoryService.TGetByIdAsync(cId);
                        product.Categories.Add(c);
                    }
                    else { return BadRequest("Kategoriler Tanımsız"); }
                }

                await _productService.TCreateAsync(product);

                return Created(); // status 201
            }
            else { return BadRequest("Store Tanımsız"); }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(string idString, UpdateProductDto updateProductDto)
        {
            // Bu Kısmı İncele

            var dbProduct = await (_productService.TGetByIdAsync(ObjectId.Parse(idString)));

            dbProduct.Name = updateProductDto.Name;
            dbProduct.Description = updateProductDto.Description;
            dbProduct.Price = updateProductDto.Price;
            dbProduct.StockCount = updateProductDto.StockCount;
            dbProduct.IsActive = updateProductDto.IsActive;

            await _productService.TUpdateAsync(dbProduct);

            return Ok(); // status 200
        }

        [HttpDelete("{idString}")]
        public async Task<IActionResult> DeleteProduct(string idString)
        {
            var dbProduct = await (_productService.TGetByIdAsync(ObjectId.Parse(idString)));

            await _productService.TDeleteAsync(ObjectId.Parse(idString));

            return NoContent(); // Delete işlemlerinde body dönülmez
        }

    }
}
