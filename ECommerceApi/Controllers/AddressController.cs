using AutoMapper;
using ECommerceApi.Bussiness.Abstract;
using ECommerceApi.Dto.Dtos.AddressDtos;
using ECommerceApi.Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace ECommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        private readonly IMapper _mapper;

        public AddressController(IAddressService addressService,IMapper mapper)
        {
            _addressService = addressService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAddressListByUserAsync(string userIdString)
        {
            if (ObjectId.TryParse(userIdString, out ObjectId userId))
            {
                List<Address> addresses = await _addressService.TGetFilteredListAsync((n) => n.OwnerId == userId);

                return addresses != null ? Ok(_mapper.Map<List<ResultAddressDto>>(addresses)) : NotFound();
            }
            else { return BadRequest(); }
        }


        [HttpPost]
        public async Task<IActionResult> CreateAddressByUser(CreateAddressDto createAddressDto)
        {
            if (ObjectId.TryParse(createAddressDto.OwnerId, out ObjectId userId))
            {
                await _addressService.TCreateAsync(_mapper.Map<Address>(createAddressDto));

                return Created();
            }
            else { return BadRequest(); }
        }
    }
}
