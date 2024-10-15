using GameApi.Application.Protocols.Db.Game;
using Microsoft.AspNetCore.Mvc;

namespace GameApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController(IGameRepository gameRepository) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var games = await gameRepository.Get();
            return Ok(games);
        }
    }
}