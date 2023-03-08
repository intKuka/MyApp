using Microsoft.AspNetCore.Mvc;
using MyApp.Models;
using MyApp.Reposotory;
using MyApp.Services;

namespace MyApp.Controllers
{
    [ApiController]
    [Route("api/info")]
    public class GamesController : ControllerBase
    {
        IGamesRepo gamesRepo;
        GameManager manager;

        public GamesController(IPlayersRepo playersRepo, IGamesRepo gamesRepo)
        {            
            this.gamesRepo = gamesRepo;
            manager = new GameManager(playersRepo, gamesRepo);
        }

        //GET /api/main
        [HttpGet]
        public IEnumerable<Game> Get() => gamesRepo.GetGames();

        //GET /api/main/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var game = gamesRepo.GetById(id);
            if (game == null) return NotFound();
            return Ok(game);
        }

        //POST /api/main
        [HttpPost]
        public IActionResult Post()
        {
            var game = manager.CreateGame();
            if(game == null) return BadRequest("Not enough available players");
            return Ok(game);
        }

        //DELETE /api/main/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var game = gamesRepo.GetById(id);
            if(game == null) return NotFound();
            manager.FinishGame(game);
            if(game.IsFinished) gamesRepo.Games.Remove(game);            
            return Ok($"Game {id} has deleted");

        }

        //PUT /api/main/{id}?cell={cell}
        [HttpPatch("{id}")]
        public IActionResult Patch(Guid id, short cell)
        {
            var game = gamesRepo.GetById(id);
            if(game == null) return NotFound();
            manager.MakeMove(cell, ref game);
            return Ok(game);
        }
    }
}