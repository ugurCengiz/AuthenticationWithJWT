using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthServer.Core.DTOs;
using AuthServer.Core.Services;

namespace IdentityAuthServer.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : CustomBaseController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateToken(LoginDto loginDto)
        {
            var result = await _authenticationService.CreateToken(loginDto);
            return ActionResultInstance(result);

        }

        [HttpPost]
        public  IActionResult CreateTokenByClient(ClientLoginDto clientLoginDto)
        {
            var result =  _authenticationService.CreateTokenByClient(clientLoginDto);
            return ActionResultInstance(result);
        }


        [HttpPost]

        public async Task<IActionResult> RevokeRefreshToken(RefreshTokenDto refreshToken)
        {
            var result = await _authenticationService.RevokeRefreshToken(refreshToken.Token);

            return ActionResultInstance(result);

        }

        [HttpPost]

        public async Task<IActionResult> CreateTokenByRefreshToken(RefreshTokenDto refreshTokenDto)
        {
            var result = await _authenticationService.CreateTokenByRefreshToken(refreshTokenDto.Token);
            return ActionResultInstance(result);
        }





    }
}
