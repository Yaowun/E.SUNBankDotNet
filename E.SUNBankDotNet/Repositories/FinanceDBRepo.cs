using System.Data;
using Dapper;
using E.SUNBankDotNet.Entities;
using E.SUNBankDotNet.Models;
using Microsoft.Data.SqlClient;

namespace E.SUNBankDotNet.Repositories
{
    public interface IFinanceDbRepo
    {
        Task<List<Finance>> GetLikeListByUser(string userId);
        Task AddLikeProduct(LikeListViewModel model);
        Task UpdateLikeProduct(LikeListViewModel model);
        Task DeleteLikeProduct(LikeListViewModel model);
        
    }

    public class FinanceDbRepo : IFinanceDbRepo
    {
        private readonly string _connectionString;

        public FinanceDbRepo(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("FinanceDB");
        }

        public async Task<List<Finance>> GetLikeListByUser(string userId)
        {   
            await using SqlConnection conn = new SqlConnection(_connectionString);
            
            var parameters = new DynamicParameters();
            parameters.Add("@UserID", userId);

            return (await conn.QueryAsync<Finance>(
                "sp_GetLikeListByUserID",
                parameters,
                commandType: CommandType.StoredProcedure
            )).ToList();
        }

        public async Task AddLikeProduct(LikeListViewModel model)
        {
            await using SqlConnection conn = new SqlConnection(_connectionString);

            var parameters = new DynamicParameters();
            parameters.Add("@UserID", model.UserID);
            parameters.Add("@ProductName", model.ProductName);
            parameters.Add("@ProductPrice", model.ProductPrice);
            parameters.Add("@FeeRate", model.FeeRate);
            parameters.Add("@OrderQuantity", model.OrderQuantity);
            parameters.Add("@Account", model.Account);

            await conn.ExecuteAsync(
                "sp_AddLikeProduct",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task UpdateLikeProduct(LikeListViewModel model)
        {
            await using SqlConnection conn = new SqlConnection(_connectionString);

            var parameters = new DynamicParameters();
            parameters.Add("@ProductNo", model.ProductNo);
            parameters.Add("@NewProductName", model.ProductName);
            parameters.Add("@NewPrice", model.ProductPrice);
            parameters.Add("@NewFeeRate", model.FeeRate);
            parameters.Add("@NewOrderQuantity", model.OrderQuantity);
            parameters.Add("@NewAccount", model.Account);

            await conn.ExecuteAsync(
                "sp_UpdateLikeProduct",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task DeleteLikeProduct(LikeListViewModel model)
        {
            await using SqlConnection conn = new SqlConnection(_connectionString);

            var parameters = new DynamicParameters();
            parameters.Add("@ProductNo", model.ProductNo);

            await conn.ExecuteAsync(
                "sp_DeleteLikeProduct",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
