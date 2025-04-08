using E.SUNBankDotNet.Domains;
using E.SUNBankDotNet.Entities;
using E.SUNBankDotNet.Models;

namespace E.SUNBankDotNet.Repositories;

public interface IFinanceDbRepo
{
    Task<List<Finance>> GetLikeListByUser(Customer customer);
    Task AddLikeProduct(LikeProductViewModel model, Customer customer);
    Task UpdateLikeProduct(LikeProductViewModel model);
    Task DeleteLikeProduct(LikeProductViewModel model);
        
    Task<bool> IsUserExists(Customer customer);
    Task InsertUser(Customer customer);
    Task<Customer?> Authenticate(Customer customer);
}