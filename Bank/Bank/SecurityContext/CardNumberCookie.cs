using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Bank.SecurityContext
{
    public class CardNumberCookie : ISecurityContextRetriever
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public string GetCardNumber => _httpContextAccessor.HttpContext.Session.GetString("CardNumber");

        public CardNumberCookie(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Task LogIn(string cardNumber)
        {
            _httpContextAccessor.HttpContext.Session.SetString("CardNumber", cardNumber);
            return Task.CompletedTask;
        }

        public Task LogOut()
        { 
            _httpContextAccessor.HttpContext.Session.Clear();
            return Task.CompletedTask;
        }

        public Task PassIn(string cardNumber)
        {
            throw new System.NotImplementedException();
        }
    }
}
