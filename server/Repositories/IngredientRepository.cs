using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Models;

namespace server.Repositories
{
    public class IngredientRepository
    {
        private readonly IDbConnection _db;
        public IngredientRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Ingredient Create(Ingredient ingredientData)
        {
            string sql = @"
            INSERT INTO ingredients
            (name, quantity, recipeId)
            VALUES
            (@name, @quantity, @recipeId);

            SELECT *
            FROM ingredients
            WHERE id = LAST_INSERT_ID()
            ;";
            Ingredient ingredient = _db.Query<Ingredient>(sql, ingredientData).FirstOrDefault();
            return ingredient;
        }

        internal List<Ingredient> GetIngredients(int recipeId)
        {
            string sql = @"
            SELECT *
            FROM ingredients
            WHERE recipeId = @recipeId
            ;";
            List<Ingredient> ingredients = _db.Query<Ingredient>(sql, new { recipeId }).ToList();
            return ingredients;
        }

        internal Ingredient Get(int ingredientId)
        {
            string sql = @"
            SELECT *
            FROM ingredients
            WHERE id = @ingredientId
            ;";
            Ingredient ingredient = _db.Query<Ingredient>(sql, new { ingredientId }).FirstOrDefault();
            return ingredient;
        }

        internal void Archive(int ingredientId)
        {
            string sql = @"
            DELETE
            FROM ingredients
            WHERE id = @ingredientId
            ;";
            _db.Execute(sql, new { ingredientId });
        }
    }
}