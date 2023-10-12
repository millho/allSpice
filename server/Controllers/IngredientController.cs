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
    }
}