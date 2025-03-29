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
    public class AlbumRepository : IAlbumRepository
    {
        private readonly SqlConfiguration _sqlConfiguration;

        public AlbumRepository(SqlConfiguration sqlConfiguration)
        {
            _sqlConfiguration = sqlConfiguration;
        }

        protected SqlConnection DbConnection()
        {
            return new SqlConnection(_sqlConfiguration.ConnectionString);
        }

        public async Task<bool> Add(Album album)
        {
            var db = DbConnection();
            var sql = @"INSERT INTO Albums (title, gender_id, song_count, total_duration) 
                        VALUES (@Title, @GenderId, @SongCount, @TotalDuration)";
            var result = await db.ExecuteAsync(sql, new { album.Title, album.GenderId, album.SongCount, album.TotalDuration });
            return result > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var db = DbConnection();
            var sql = @"DELETE Albums
                        WHERE Id = @Id";
            var result = await db.ExecuteAsync(sql, new { Id = id });
            return result > 0;
        }

        public async Task<Album> GetById(int id)
        {
            var db = DbConnection();
            var sql = @"SELECT id, title, gender_id AS GenderId, song_count AS SongCount, total_duration AS TotalDuration
                        FROM Albums
                        WHERE Id = @Id";
            return await db.QueryFirstOrDefaultAsync<Album>(sql, new { Id = id });
        }

        public async Task<IEnumerable<Album>> GetAll()
        {
            var db = DbConnection();
            var sqlCommand = @"SELECT A.id, title, song_count AS SongCount, total_duration AS TotalDuration, G.Id, G.Name
                       FROM Albums A
                       INNER JOIN Genders G on A.gender_id = G.Id";

            var result = await db.QueryAsync<Album, Gender, Album>(
                sqlCommand,
                (album, gender) =>
                {
                    album.Gender = gender;
                    return album;
                },
                splitOn: "Id"
            );

            return result;
        }

        public async Task<bool> Update(Album album)
        {
            var db = DbConnection();
            var sql = @"UPDATE Albums 
                        SET title = @Title, gender_id = @GenderId, song_count = @SongCount, total_duration = @TotalDuration
                        WHERE id = @Id";
            var result = await db.ExecuteAsync(sql, new { album.Id, album.Title, album.GenderId, album.SongCount, album.TotalDuration });
            return result > 0;
        }
    }
}
