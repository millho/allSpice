using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Repositories;

namespace server.Services
{
    public class IngredientService
    {
        private readonly IngredientRepository _repo;
        public IngredientService(IngredientRepository repo)
        {
            _repo = repo;
        }
    }
}