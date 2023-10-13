using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Models;
using server.Repositories;

namespace server.Services
{
    public class IngredientService
    {
        private readonly IngredientRepository _repo;
        private readonly RecipeService _recipeService;
        public IngredientService(IngredientRepository repo, RecipeService recipeService)
        {
            _repo = repo;
            _recipeService = recipeService;
        }

        internal Ingredient Create(Ingredient ingredientData)
        {
            Ingredient ingredient = _repo.Create(ingredientData);
            return ingredient;
        }

        internal List<Ingredient> GetIngredients(int recipeId)
        {
            List<Ingredient> ingredients = _repo.GetIngredients(recipeId);
            return ingredients;
        }

        internal Ingredient Get(int ingredientId)
        {
            Ingredient ingredient = _repo.Get(ingredientId);
            if (ingredient == null) throw new Exception($"Ingredient not found (id:{ingredientId})");
            return ingredient;
        }

        internal string Archive(int ingredientId, string userId)
        {
            Ingredient ingredient = this.Get(ingredientId);
            Recipe recipe = _recipeService.Get(ingredient.RecipeId);
            if (recipe.CreatorId != userId) throw new Exception("Unauthorized");
            _repo.Archive(ingredientId);
            return $"Ingredient archived (id:{ingredientId})";
        }
    }
}