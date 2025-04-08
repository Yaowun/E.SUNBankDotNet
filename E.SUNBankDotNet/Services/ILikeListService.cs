using E.SUNBankDotNet.Domains;
using E.SUNBankDotNet.Models;

namespace E.SUNBankDotNet.Services;

public interface ILikeListService
{
    Task<List<LikeListViewModel>> GetLikeList(Customer customer);
    Task<List<LikeProductViewModel>> GetLikeProduct(Customer customer);
    Task AddLikeProduct(LikeProductViewModel model, Customer customer);
    Task UpdateLikeProduct(LikeProductViewModel model);
    Task DeleteLikeProduct(LikeProductViewModel model);
}