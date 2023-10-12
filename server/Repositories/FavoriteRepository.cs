using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Repositories
{
    public class FavoriteRepository
    {
        private readonly IDbConnection _db;
        public FavoriteRepository(IDbConnection db)
        {
            _db = db;
        }
    }
}