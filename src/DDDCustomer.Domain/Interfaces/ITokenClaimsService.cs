using System.Threading.Tasks;

namespace DDDCustomer.Domain.Interfaces
{
    public interface ITokenClaimsService
    {
        Task<string> GetTokenAsync(string userName);
    }
}