using Application.DTOs;
using Domain.Entities;

namespace Application.Contracts
{
    public interface IUser
    {
        Task<RegistrationResponse> RegisterUserAsync(RegisterUserDTO registerUserDTO);
        Task<LoginResponse> LoginUserAsync(LoginDTO loginDTO);
        Task<ApplicationUser> GetUserInfo(int Id);
    }
}
