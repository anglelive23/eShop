﻿namespace eShop.Application.Contracts
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(RegisterModel model);
        Task<AuthModel> LoginAsync(LoginModel model);
        Task<AuthModel> RequestTokenAsync(TokenRequestModel model);
        Task<AuthModel> GetTokenAsync(ApplicationUser user);
        Task<AuthModel> RefreshTokenAsync(string refreshToken);
        Task<AuthModel> RevokeAndGenerate(string refreshToken);
        Task<bool> RevokeTokenAsync(string token);
    }
}
