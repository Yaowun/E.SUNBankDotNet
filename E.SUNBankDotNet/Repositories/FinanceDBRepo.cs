using System.Data;
using Dapper;
using E.SUNBankDotNet.Domains;
using E.SUNBankDotNet.Entities;
using E.SUNBankDotNet.Models;
using Microsoft.Data.SqlClient;

namespace E.SUNBankDotNet.Repositories
{
    public class FinanceDbRepo : IFinanceDbRepo
    {
        private readonly string _connectionString;

        public FinanceDbRepo(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("FinanceDB");
        }

        public async Task<List<Finance>> GetLikeListByUser(Customer customer)
        {   
            await using SqlConnection conn = new SqlConnection(_connectionString);
            
            var parameters = new DynamicParameters();
            parameters.Add("@UserID", customer.UserID);

            return (await conn.QueryAsync<Finance>(
                "sp_GetLikeListByUserID",
                parameters,
                commandType: CommandType.StoredProcedure
            )).ToList();
        }

        public async Task AddLikeProduct(LikeProductViewModel model, Customer customer)
        {
            await using SqlConnection conn = new SqlConnection(_connectionString);

            var parameters = new DynamicParameters();
            parameters.Add("@UserID", customer.UserID);
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
        
        public async Task<bool> IsUserExists(Customer customer)
        {
            await using SqlConnection conn = new SqlConnection(_connectionString);

            var parameters = new DynamicParameters();
            parameters.Add("@UserID", customer.UserID);

            var result = await conn.ExecuteScalarAsync<int>(
                "sp_IsUserExists",
                parameters
            );
            return result > 0;
        }

        public async Task InsertUser(Customer customer)
        {
            await using SqlConnection conn = new SqlConnection(_connectionString);

            var parameters = new DynamicParameters();
            parameters.Add("@UserID", customer.UserID);
            parameters.Add("@UserName", customer.UserName);
            parameters.Add("@Email", customer.Email);

            await conn.ExecuteAsync(
                "sp_InsertUser",
                parameters
            );
        }
        

        public async Task<Customer?> Authenticate(Customer customer)
        {
            await using SqlConnection conn = new SqlConnection(_connectionString);

            var parameters = new DynamicParameters();
            parameters.Add("@UserID", customer.UserID);
            parameters.Add("@Email", customer.Email);

            return await conn.QueryFirstOrDefaultAsync<Customer>(
                "sp_Authenticate",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
