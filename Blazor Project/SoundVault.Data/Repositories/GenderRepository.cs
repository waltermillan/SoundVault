using SoundVault.Model.Entities;
using System;
using Dapper;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVault.Data.Repositories
{
    public class GenderRepository : IGenderRepository
    {
        private readonly SqlConfiguration _sqlConfiguration;

        public GenderRepository(SqlConfiguration sqlConfiguration)
        {
            _sqlConfiguration = sqlConfiguration;
        }

        protected SqlConnection DbConnection()
        {
            return new SqlConnection(_sqlConfiguration.ConnectionString);
        }

        public async Task<bool> Add(Gender gender)
        {
            var db = DbConnection();
            var sql = @"INSERT INTO Genders (Name) 
                        VALUES (@Name)";
            var result = await db.ExecuteAsync(sql, new { gender.Name });
            return result > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var db = DbConnection();
            var sql = @"DELETE Genders
                        WHERE Id = @Id";
            var result = await db.ExecuteAsync(sql, new { Id = id });
            return result > 0;
        }

        public async Task<Gender> GetById(int id)
        {
            var db = DbConnection();
            var sql = @"SELECT * 
                        FROM Genders
                        WHERE Id = @Id";
            return await db.QueryFirstOrDefaultAsync<Gender>(sql, new { Id = id });
        }

        public async Task<IEnumerable<Gender>> GetAll()
        {
            var db = DbConnection();
            var sqlCommand = @"SELECT * 
                               FROM Genders";
            return await db.QueryAsync<Gender>(sqlCommand, new {});    
        }

        public async Task<bool> Update(Gender gender)
        {
            var db = DbConnection();
            var sql = @"UPDATE Genders 
                        SET Name = @Name
                        WHERE Id = @Id";
            var result = await db.ExecuteAsync(sql, new { gender.Name, gender.Id });
            return result > 0;
        }
    }
}
