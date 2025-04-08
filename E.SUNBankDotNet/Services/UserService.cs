using E.SUNBankDotNet.Domains;
using E.SUNBankDotNet.Models;
using E.SUNBankDotNet.Repositories;

namespace E.SUNBankDotNet.Services;

public class UserService : IUserService
{
    private readonly IFinanceDbRepo _dbRepo;

    public UserService(IFinanceDbRepo dbRepo)
    {
        _dbRepo = dbRepo;
    }

    public async Task<bool> IsUserExists(Customer customer)
    {
        return await _dbRepo.IsUserExists(customer);
    }

    public async Task CreateUser(Customer customer)
    {
        await _dbRepo.InsertUser(customer);
    }

    public async Task<Customer?> Authenticate(Customer customer)
    {
        return (await _dbRepo.Authenticate(customer));
    }
}