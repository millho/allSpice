using server.Models;
using server.Services;

namespace server.Controllers
{
    [ApiController]
    [Route("api/recipes")]
    public class RecipeController : ControllerBase
    {
        private readonly RecipeService _recipeService;
        private readonly Auth0Provider _auth;
        public RecipeController(RecipeService service, Auth0Provider auth)
        {
            _recipeService = service;
            _auth = auth;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Recipe>> Create([FromBody] Recipe recipe)
        {
            try
            {
                Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
                recipe.CreatorId = userInfo.Id;
                Recipe newRecipe = _recipeService.Create(recipe);
                return newRecipe;
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<Recipe>> Get()
        {
            try
            {
                List<Recipe> recipes = _recipeService.Get();
                return recipes;
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}