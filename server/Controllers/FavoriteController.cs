using server.Models;
using server.Services;

namespace server.Controllers
{
    [ApiController]
    [Route("api/favorites")]
    public class FavoriteController : ControllerBase
    {
        private readonly FavoriteService _favoriteService;
        private readonly Auth0Provider _auth;
        public FavoriteController(FavoriteService service, Auth0Provider auth)
        {
            _favoriteService = service;
            _auth = auth;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Favorite>> Create([FromBody] Favorite favoriteData)
        {
            try
            {
                Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
                favoriteData.AccountId = userInfo.Id;
                Favorite favorite = _favoriteService.Create(favoriteData);
                return favorite;
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [Authorize]
        [HttpDelete("{favoriteId}")]
        public async Task<ActionResult<string>> Archive(int favoriteId)
        {
            try
            {
                Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
                string message = _favoriteService.Archive(favoriteId);
                return message;
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}