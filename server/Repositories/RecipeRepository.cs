using server.Models;

namespace server.Repositories
{
    public class RecipeRepository
    {
        private readonly IDbConnection _db;
        public RecipeRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Recipe Create(Recipe recipe)
        {
            string sql = @"
            INSERT INTO recipes
            (title, instructions, category, img, creatorId)
            VALUE
            (@title, @instructions, @category, @img, @creatorId);

            SELECT
            acc.*, rec.*
            FROM recipes rec
            JOIN accounts acc ON acc.id = rec.creatorId
            WHERE rec.id = LAST_INSERT_ID()
            ;";
            Recipe newRecipe = _db.Query<Account, Recipe, Recipe>(sql, (account, recipe) =>
            {
                recipe.Creator = account;
                return recipe;
            }, recipe).FirstOrDefault();
            return newRecipe;
        }

        internal List<Recipe> Get()
        {
            string sql = @"
            ;";
            List<Recipe> recipes = _db.Query<Account, Recipe, Recipe>(sql, (account, recipe) =>
            {
                recipe.Creator = account;
                return recipe;
            }).ToList();
            return recipes;
        }
    }
}