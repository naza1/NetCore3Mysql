using System;
using System.Threading.Tasks;
using AutoMapper;
using BeachMdq.Api.Dtos;
using BeachMdq.Api.Services;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeachMdq.Api.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(
            IUserService userService,
            IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }


        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterDto registerDto)
        {
            var user = _mapper.Map<User>(registerDto);

            try
            {
                var result = await _userService.Register(user);
                
                if(result.Success)
                    return Ok("User created correctly");

                return NotFound(result.Errors);
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
