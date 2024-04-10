using System.Net;
using api.Entities;
using Dotnet.API.Configurations;
using Dotnet.API.Dtos.User;
using Dotnet.API.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Dotnet.API.Services
{
    public interface IUserService
    {
        Task<string> ConfirmOTPAsync(string mobileNumber, string code);
        Task SendOTPAsync(string MobileNumber);
        Task<WhoAmIDto> WhoAmIAsync(string userMobileNumber);
    }

    public class UserService : IUserService
    {
        private readonly IJWTService _jWTService;
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        public UserService(UserManager<User> userManager, IJWTService jWTService, IConfiguration configuration)
        {
            _configuration = configuration;
            _userManager = userManager;
            _jWTService = jWTService;
        }

        public async Task SendOTPAsync(string MobileNumber)
        {

        }

        public async Task<string> ConfirmOTPAsync(string mobileNumber, string code)
        {
            var user = await _userManager.Users.Where(usr => usr.MobileNumber == mobileNumber).FirstOrDefaultAsync();
            if (user == null)
            {
                var userCreationResult = await _userManager.CreateAsync(new User()
                {
                    MobileNumber = mobileNumber,
                    UserName = mobileNumber,
                    Active = true,
                    CreatedAt = DateTimeOffset.Now
                });
                if (!userCreationResult.Succeeded)
                    throw new CustomException((int)HttpStatusCode.InternalServerError, "User creation failed", new Exception(String.Join(", ", userCreationResult.Errors)));
            }

            if (code != "1234")
                throw new CustomException((int)HttpStatusCode.BadRequest, "OTP code is not valid");

            var jWTConfigurations = _configuration.GetSection("JWT").Get<JWTConfigurations>();
            if (jWTConfigurations is null)
                throw new CustomException((int)HttpStatusCode.InternalServerError, "JWT Configuration is null");

            return _jWTService.GenerateToken(mobileNumber, jWTConfigurations);
        }

        public async Task<WhoAmIDto> WhoAmIAsync(string userMobileNumber)
        {
            var user = await _userManager.Users.Where(usr => usr.MobileNumber == userMobileNumber).FirstOrDefaultAsync();
            if (user == null)
                throw new CustomException((int)HttpStatusCode.BadRequest, "User doesn't exist");

            return new WhoAmIDto()
            {
                MobileNumber = user.MobileNumber,
                UserName = user.UserName ?? ""
            };
        }
    }
}