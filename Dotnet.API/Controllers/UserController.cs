using System.Net;
using Dotnet.API.Dtos.OTP;
using Dotnet.API.Dtos.User;
using Dotnet.API.Exceptions;
using Dotnet.API.Extensions;
using Dotnet.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;

    public UserController(ILogger<UserController> logger,
                          IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpPost("otp")]
    public async Task SendOTP([FromBody] OTPDto dto)
    {
        await _userService.SendOTPAsync(dto.MobileNumber);
    }

    [HttpPost("confirm-otp")]
    public async Task<string> ConfirmOTP([FromBody] OTPConfirmationDto dto)
    {
        return await _userService.ConfirmOTPAsync(dto.MobileNumber, dto.Code);
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpGet("who-am-i")]
    public async Task<WhoAmIDto> WhoAmI()
    {
        return await _userService.WhoAmIAsync(User.GetMobileNumberClaim());
    }
}
