using System.Security;
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

        internal Recipe Get(int recipeId)
        {
            Recipe recipe = _repo.Get(recipeId);
            if (recipe == null) throw new Exception($"Recipe not found (id:{recipeId})");
            return recipe;
        }

        internal string Archive(int recipeId, string userId)
        {
            Recipe recipe = this.Get(recipeId);
            if (recipe.CreatorId != userId) throw new Exception("Unauthorized");
            _repo.Archive(recipeId);
            return $"Recipe Archived (id:{recipeId})";
        }

        internal Recipe Edit(Recipe recipeData)
        {
            Recipe recipe = this.Get(recipeData.Id);
            if (recipeData.CreatorId != recipe.CreatorId) throw new Exception("Unauthorized");
            recipe.Title = recipeData.Title ?? recipe.Title;
            recipe.Instructions = recipeData.Instructions ?? recipe.Instructions;
            recipe.Img = recipeData.Img ?? recipe.Img;
            recipe.Category = recipeData.Category ?? recipe.Category;
            _repo.Edit(recipe);
            return recipe;
        }
    }
}