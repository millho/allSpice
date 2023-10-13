using server.Models;
using server.Services;

namespace server.Controllers
{
    [ApiController]
    [Route("api/ingredients")]
    public class IngredientController : ControllerBase
    {
        private readonly IngredientService _ingredientService;
        private readonly Auth0Provider _auth;
        public IngredientController(IngredientService service, Auth0Provider auth)
        {
            _ingredientService = service;
            _auth = auth;
        }

        [Authorize]
        [HttpPost]
        public ActionResult<Ingredient> Create([FromBody] Ingredient ingredientData)
        {
            try
            {
                Ingredient ingredient = _ingredientService.Create(ingredientData);
                return Ok(ingredient);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [Authorize]
        [HttpDelete("{ingredientId}")]
        public async Task<ActionResult<String>> Archive(int ingredientId)
        {
            try
            {
                Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
                string message = _ingredientService.Archive(ingredientId, userInfo.Id);
                return message;
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}