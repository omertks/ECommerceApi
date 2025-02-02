using AutoMapper;
using ECommerceApi.Bussiness.Abstract;
using ECommerceApi.Dto.Dtos.UserDtos;
using ECommerceApi.Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserList()
        {
            var users = await _userService.TGetListAsync();
            return users != null ? Ok(_mapper.Map<List<ResultUserDto>>(users)) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
        {
            if (createUserDto != null && !String.IsNullOrEmpty(createUserDto.Name)) // Controls
            {
                await _userService.TCreateAsync(_mapper.Map<User>(createUserDto));

                return Created();
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
