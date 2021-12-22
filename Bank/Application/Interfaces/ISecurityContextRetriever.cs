using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISecurityContextRetriever
    {
        Task LogIn(string cardNumber);
        string GetCardNumber { get; }
        Task LogOut();
    }
}
