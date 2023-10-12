using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Repositories
{
    public class IngredientRepository
    {
        private readonly IDbConnection _db;
        public IngredientRepository(IDbConnection db)
        {
            _db = db;
        }
    }
}