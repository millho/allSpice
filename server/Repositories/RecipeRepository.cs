using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Repositories
{
    public class RecipeRepository
    {
        private readonly IDbConnection _db;
        public RecipeRepository(IDbConnection db)
        {
            _db = db;
        }
    }
}