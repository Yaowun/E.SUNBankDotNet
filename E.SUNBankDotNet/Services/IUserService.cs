using E.SUNBankDotNet.Domains;

namespace E.SUNBankDotNet.Services;

public interface IUserService
{
    Task<bool> IsUserExists(Customer customer);
    Task CreateUser(Customer customer);
    Task<Customer?> Authenticate(Customer customer);
}