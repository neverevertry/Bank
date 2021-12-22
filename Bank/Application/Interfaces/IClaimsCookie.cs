using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IClaimsCookie
    {
        Task SignIn(string cardNumber);
        string GetCardCookie();
        Task SignOut();
    }
}
