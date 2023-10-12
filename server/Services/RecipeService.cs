using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Repositories;

namespace server.Services
{
    public class RecipeService
    {
        private readonly RecipeRepository _repo;
        public RecipeService(RecipeRepository repo)
        {
            _repo = repo;
        }
    }
}