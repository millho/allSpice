using server.Services;

namespace server.Controllers
{
    [ApiController]
    [Route("api/favorites")]
    public class FavoriteController : ControllerBase
    {
        private readonly FavoriteService _FavoriteService;
        private readonly Auth0Provider _auth;
        public FavoriteController(FavoriteService service, Auth0Provider auth)
        {
            _FavoriteService = service;
            _auth = auth;
        }
    }
}