using E.SUNBankDotNet.Entities;
using E.SUNBankDotNet.Models;
using E.SUNBankDotNet.Repositories;

namespace E.SUNBankDotNet.Services;

public interface ILikeListService
{
    Task<List<LikeListViewModel>> GetLikeList(User user);
    Task<List<LikeProductViewModel>> GetLikeProduct(User user);
    Task AddLikeProduct(LikeProductViewModel model, User user);
    Task UpdateLikeProduct(LikeProductViewModel model);
    Task DeleteLikeProduct(LikeProductViewModel model);
}

public class LikeListService : ILikeListService
{
    private readonly IFinanceDbRepo _dbRepo;

    public LikeListService(IFinanceDbRepo dbRepo)
    {
        _dbRepo = dbRepo;
    }

    public async Task<List<LikeListViewModel>> GetLikeList(User user)
    {
        var rawList = await _dbRepo.GetLikeListByUser(user);

        return rawList.Select(Finance.ToLikeListViewModel).ToList();
    }

    public async Task<List<LikeProductViewModel>> GetLikeProduct(User user)
    {
        var rawList = await _dbRepo.GetLikeListByUser(user);

        return rawList.Select(Finance.ToLikeProductViewModel).ToList();
    }
    
    public async Task AddLikeProduct(LikeProductViewModel model, User user)
    {
        await _dbRepo.AddLikeProduct(model, user);
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