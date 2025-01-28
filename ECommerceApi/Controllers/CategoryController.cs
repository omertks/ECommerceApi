using AutoMapper;
using ECommerceApi.Bussiness.Abstract;
using ECommerceApi.Dto.Dtos.CategoryDtos;
using ECommerceApi.Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace ECommerceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        
        private readonly ICategoryService _categoryService;

        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService,IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryListAsync()
        {
            List<Category> result = await _categoryService.TGetListAsync();

            return Ok(_mapper.Map<List<ResultCategoryDto>>(result));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto category)
        {

            await _categoryService.TCreateAsync(_mapper.Map<Category>(category));

            return Created();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(string categoryId)
        {
            if(ObjectId.TryParse(categoryId, out ObjectId categoryObjectId))
            {
                await _categoryService.TDeleteAsync(categoryObjectId);

                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

    }
}
