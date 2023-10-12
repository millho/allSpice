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
    }
}