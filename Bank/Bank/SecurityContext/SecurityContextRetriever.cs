using Application.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bank.SecurityContext
{
    public class SecurityContextRetriever : ISecurityContextRetriever
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public string GetCardNumber => _httpContextAccessor.HttpContext.User.FindFirst("CardNumber").Value;

        public SecurityContextRetriever(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task LogIn(string cardNumber) 
        {
            var claims = new List<Claim>
            {
                new Claim("CardNumber", cardNumber)
            };

            var identity = new ClaimsIdentity(claims, "CardCookie");

            await _httpContextAccessor.HttpContext.SignInAsync("CardCookie", new ClaimsPrincipal(identity));
        }

        public async Task LogOut() => await _httpContextAccessor.HttpContext.SignOutAsync();

    }
}
