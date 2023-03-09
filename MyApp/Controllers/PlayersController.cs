using Microsoft.AspNetCore.Mvc;
using MyApp.Data;
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
        public IEnumerable<Player> GetAll() => playersRepo.GetPlayers();

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
        public IActionResult PostPlayer()
        {
            var player = playersRepo.CreatePlayer();
            if (player == null) return StatusCode(500);
            return Ok(player);
        }

        //DELETE /api/players/{id}
        [HttpDelete("{id}")]
        public IActionResult DeletePlayer(Guid id)
        {
            var player = playersRepo.GetById(id);
            if(player == null) return NotFound();
            playersRepo.DeletePlayer(player);
            return Ok($"Player {id} has deleted");
        }



    }
}
