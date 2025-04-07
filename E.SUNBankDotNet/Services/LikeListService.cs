using E.SUNBankDotNet.Models;
using E.SUNBankDotNet.Repositories;

namespace E.SUNBankDotNet.Services;

public interface ILikeListService
{
    Task<List<LikeListViewModel>> GetLikeList(string userId);
    Task AddLikeProduct(LikeListViewModel model);
    Task UpdateLikeProduct(LikeListViewModel model);
    Task DeleteLikeProduct(LikeListViewModel model);
}

public class LikeListService : ILikeListService
{
    private readonly IFinanceDbRepo _dbRepo;

    public LikeListService(IFinanceDbRepo dbRepo)
    {
        _dbRepo = dbRepo;
    }

    public async Task<List<LikeListViewModel>> GetLikeList(string userId)
    {
        var rawList = await _dbRepo.GetLikeListByUser(userId);

        return rawList.Select(x => new LikeListViewModel
        {
            UserID = x.UserID,
            ProductNo = x.ProductNo,
            ProductName = x.ProductName,
            ProductPrice = x.ProductPrice,
            FeeRate = x.FeeRate,
            OrderQuantity = x.OrderQuantity,
            Account = x.Account,
            TotalAmount = x.TotalAmount,
            TotalFee = x.TotalFee,
            Email = x.Email,
        }).ToList();
    }
    
    public async Task AddLikeProduct(LikeListViewModel model)
    {
        await _dbRepo.AddLikeProduct(model);
    }

    public async Task UpdateLikeProduct(LikeListViewModel model)
    {
        await _dbRepo.UpdateLikeProduct(model);
    }

    public async Task DeleteLikeProduct(LikeListViewModel model)
    {
        await _dbRepo.DeleteLikeProduct(model);
    }
}