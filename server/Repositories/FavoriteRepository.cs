using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Models;

namespace server.Repositories
{
    public class FavoriteRepository
    {
        private readonly IDbConnection _db;
        public FavoriteRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Favorite Create(Favorite favoriteData)
        {
            string sql = @"
            INSERT INTO favorites (accountId, recipeId)
            VALUES (@accountId, @recipeId);

            SELECT *
            FROM favorites
            WHERE id = LAST_INSERT_ID()
            ;";
            Favorite favorite = _db.Query<Favorite>(sql, favoriteData).FirstOrDefault();
            return favorite;
        }
    }
}