using E.SUNBankDotNet.Domains;
using E.SUNBankDotNet.Entities;
using E.SUNBankDotNet.Models;
using E.SUNBankDotNet.Repositories;

namespace E.SUNBankDotNet.Services;

public class LikeListService : ILikeListService
{
    private readonly IFinanceDbRepo _dbRepo;

    public LikeListService(IFinanceDbRepo dbRepo)
    {
        _dbRepo = dbRepo;
    }

    public async Task<List<LikeListViewModel>> GetLikeList(Customer customer)
    {
        var rawList = await _dbRepo.GetLikeListByUser(customer);

        return rawList.Select(Finance.ToLikeListViewModel).ToList();
    }

    public async Task<List<LikeProductViewModel>> GetLikeProduct(Customer customer)
    {
        var rawList = await _dbRepo.GetLikeListByUser(customer);

        return rawList.Select(Finance.ToLikeProductViewModel).ToList();
    }
    
    public async Task AddLikeProduct(LikeProductViewModel model, Customer customer)
    {
        await _dbRepo.AddLikeProduct(model, customer);
    }

    public async Task UpdateLikeProduct(LikeProductViewModel model)
    {
        await _dbRepo.UpdateLikeProduct(model);
    }

    public async Task DeleteLikeProduct(LikeProductViewModel model)
    {
        await _dbRepo.DeleteLikeProduct(model);
    }
}