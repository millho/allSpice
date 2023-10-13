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
                return Ok(newRecipe);
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
                return Ok(recipes);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{recipeId}")]
        public ActionResult<Recipe> Get(int recipeId)
        {
            try
            {
                Recipe recipe = _recipeService.Get(recipeId);
                return Ok(recipe);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [Authorize]
        [HttpDelete("{recipeId}")]
        public async Task<ActionResult<string>> Archive(int recipeId)
        {
            try
            {
                Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
                string message = _recipeService.Archive(recipeId, userInfo.Id);
                return Ok(message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [Authorize]
        [HttpPut("{recipeId}")]
        public async Task<ActionResult<Recipe>> Edit([FromBody] Recipe recipeData, int recipeId)
        {
            try
            {
                Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
                recipeData.Id = recipeId;
                recipeData.CreatorId = userInfo.Id;
                Recipe recipe = _recipeService.Edit(recipeData);
                return Ok(recipe);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}