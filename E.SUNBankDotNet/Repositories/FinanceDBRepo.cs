using System.Data;
using Dapper;
using E.SUNBankDotNet.Entities;
using E.SUNBankDotNet.Models;
using Microsoft.Data.SqlClient;

namespace E.SUNBankDotNet.Repositories
{
    public interface IFinanceDbRepo
    {
        Task<List<Finance>> GetLikeListByUser(User user);
        Task AddLikeProduct(LikeProductViewModel model, User user);
        Task UpdateLikeProduct(LikeProductViewModel model);
        Task DeleteLikeProduct(LikeProductViewModel model);
        
    }

    public class FinanceDbRepo : IFinanceDbRepo
    {
        private readonly string _connectionString;

        public FinanceDbRepo(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("FinanceDB");
        }

        public async Task<List<Finance>> GetLikeListByUser(User user)
        {   
            await using SqlConnection conn = new SqlConnection(_connectionString);
            
            var parameters = new DynamicParameters();
            parameters.Add("@UserID", user.UserID);

            return (await conn.QueryAsync<Finance>(
                "sp_GetLikeListByUserID",
                parameters,
                commandType: CommandType.StoredProcedure
            )).ToList();
        }

        public async Task AddLikeProduct(LikeProductViewModel model, User user)
        {
            await using SqlConnection conn = new SqlConnection(_connectionString);

            var parameters = new DynamicParameters();
            parameters.Add("@UserID", user.UserID);
            parameters.Add("@ProductName", model.ProductName);
            parameters.Add("@ProductPrice", model.Price);
            parameters.Add("@FeeRate", model.FeeRate);
            parameters.Add("@OrderQuantity", model.OrderQuantity);
            parameters.Add("@Account", model.Account);

            await conn.ExecuteAsync(
                "sp_AddLikeProduct",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task UpdateLikeProduct(LikeProductViewModel model)
        {
            await using SqlConnection conn = new SqlConnection(_connectionString);

            var parameters = new DynamicParameters();
            parameters.Add("@SN", model.SN);
            parameters.Add("@NewProductName", model.ProductName);
            parameters.Add("@NewPrice", model.Price);
            parameters.Add("@NewFeeRate", model.FeeRate);
            parameters.Add("@NewOrderQuantity", model.OrderQuantity);
            parameters.Add("@NewAccount", model.Account);

            await conn.ExecuteAsync(
                "sp_UpdateLikeProduct",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task DeleteLikeProduct(LikeProductViewModel model)
        {
            await using SqlConnection conn = new SqlConnection(_connectionString);

            var parameters = new DynamicParameters();
            parameters.Add("@SN", model.SN);

            await conn.ExecuteAsync(
                "sp_DeleteLikeProduct",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
