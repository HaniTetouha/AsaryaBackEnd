﻿using AsaryaBackEnd.Core.DTOs;
using Microsoft.AspNetCore.Identity;

namespace AsaryaBackEnd.Service.Interfaces
{
    public interface IUserAuthenticationRepository
    {
        Task<IdentityResult> RegisterUserAsync(UserRegistrationDto userForRegistration);
        Task<bool> ValidateUserAsync(UserLoginDto loginDto);
        Task<string> CreateTokenAsync();
    }
}
