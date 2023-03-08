using Microsoft.AspNetCore.Mvc;
using MyApp.Models;
using MyApp.Reposotory;

namespace MyApp.Controllers
{
    [Route("api/players")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        readonly IPlayersRepo playersRepo;
        public PlayersController(IPlayersRepo playersRepo)
        {
            this.playersRepo = playersRepo;
        }

        //GET /api/players
        [HttpGet]
        public IEnumerable<Player> Get() => playersRepo.GetPlayers();

        //GET /api/players/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var player = playersRepo.GetById(id);
            if (player == null) return NotFound();
            return Ok(player);
        }

        //POST /api/players
        [HttpPost]
        public IActionResult Post()
        {
            var player = playersRepo.CreatePlayer();
            if (player == null) return StatusCode(500);
            playersRepo.Players.Add(player);
            return Ok(player);
        }

        //DELETE /api/players/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var player = playersRepo.GetById(id);
            if (player == null) return NotFound();
            playersRepo.Players.Remove(player);
            return Ok($"Player {id} has deleted");

        }



    }
}
