using Application.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bank.Security
{
    public class ClaimsCookie : IClaimsCookie
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ClaimsCookie(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task SignIn(string cardNumber)
        {
            var claims = new List<Claim>
            {
                new Claim("CardNumber", cardNumber)
            };

            var identity = new ClaimsIdentity(claims, "CardCookie");

            await _httpContextAccessor.HttpContext.SignInAsync("CardCookie", new ClaimsPrincipal(identity));
        }

        public string GetCardCookie() => _httpContextAccessor.HttpContext.User.FindFirst("CardNumber").Value;

        public async Task SignOut() => await _httpContextAccessor.HttpContext.SignOutAsync();

    }
}
