using server.Models;
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

        internal Recipe Create(Recipe recipe)
        {
            Recipe newRecipe = _repo.Create(recipe);
            return newRecipe;
        }

        internal List<Recipe> Get()
        {
            List<Recipe> recipes = _repo.Get();
            return recipes;
        }
    }
}