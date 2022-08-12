using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthServer.Core.DTOs;
using AuthServer.Core.Services;
using IdentityAuthServer.API.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace IdentityAuthServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : CustomBaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
        {
            throw new CustomException("Veri tabanı ile ilgili bir hata meydana geldi");
            return ActionResultInstance(await _userService.CreateUserAsync(createUserDto));
        }


       // [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            string name = HttpContext.User.Identity.Name;
            return ActionResultInstance(await _userService.GetUserByNameAsync(name));

        }
    }
}
