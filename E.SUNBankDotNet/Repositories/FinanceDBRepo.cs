using Dapper;
using E.SUNBankDotNet.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace E.SUNBankDotNet.Repositories
{
    public interface IFinanceDBRepo
    {
        Task<IEnumerable<LikeList>> GetLikeListByUser(string userId);
        
    }

    public class FinanceDBRepo : IFinanceDBRepo
    {
        private readonly string _connectionString;

        public FinanceDBRepo(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("FinanceDB");
        }

        public async Task<IEnumerable<LikeList>> GetLikeListByUser(string userId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserID", userId);

                return (await conn.QueryAsync<LikeList>(
                    "sp_GetLikeListByUser",
                    parameters,
                    commandType: CommandType.StoredProcedure
                ));
            }
        }
    }
}
