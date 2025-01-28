using AutoMapper;
using ECommerceApi.Bussiness.Abstract;
using ECommerceApi.Dto.Dtos.StoreDtos;
using ECommerceApi.Entity.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {

        IStoreService _storeService;
        IMapper _mapper;

        public StoreController(IStoreService storeService,IMapper mapper)
        {
            _storeService = storeService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetStoreList()
        {
            return Ok(_mapper.Map<List<ResultStoreDto>>(await _storeService.TGetListAsync()));
        }

        [HttpPost]
        public async Task<IActionResult> CreateStore(CreateStoreDto store)
        {
            await _storeService.TCreateAsync(_mapper.Map<Store>(store));
            
            return Created();
        }

    }
}
