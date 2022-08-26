using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemaPawFinal1.Models;

namespace TemaPawFinal1.Services
{
    public class LoginService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LoginService(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<Boolean> Login(string Email, string Password, bool RememberMe)
        {
            var result = await _signInManager.PasswordSignInAsync(Email, Password, RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }
    }
}
