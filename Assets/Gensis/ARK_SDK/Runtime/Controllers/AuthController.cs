using ARK.SDK.Core;
using ARK.SDK.Services;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

namespace ARK.SDK.Controllers
{
    public class AuthController
    {
        private readonly AuthService authService;

        public AuthController(AuthService authService)
        {
            this.authService = authService;
        }

        public async UniTask<string> LoginAsync(string email, string password)
        {
            try
            {
                return await authService.LoginAsync(email, password);
            }
            catch (SDKException ex)
            {
                throw new SDKException(ex.ErrorType, $"LoginAsync failed: {ex.Message}");
            }
        }
    }
}