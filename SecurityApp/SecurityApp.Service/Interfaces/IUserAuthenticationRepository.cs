using Microsoft.AspNetCore.Identity;
using SecurityApp.Core.Dtos;
using SecurityApp.Core.Models;
using System.Threading.Tasks;

namespace SecurityApp.Service.Interfaces
{

    public interface IUserAuthenticationRepository
    {
        Task<IdentityResult> RegisterUserAsync(UserRegistrationDto userForRegistration);
        Task<bool> ValidateUserAsync(UserLoginDto loginDto);
        Task<string> CreateTokenAsync();
    }

}