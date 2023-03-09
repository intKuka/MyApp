using Microsoft.AspNetCore.Mvc;
using MyApp.Data;
using MyApp.Models;
using MyApp.Reposotory;
using MyApp.Services;

namespace MyApp.Controllers
{
    [ApiController]
    [Route("api/games")]
    public class GamesController : ControllerBase
    {
        readonly IGamesRepo gamesRepo;
        readonly GameManager manager;

        public GamesController(IPlayersRepo playersRepo, IGamesRepo gamesRepo)
        {            
            this.gamesRepo = gamesRepo;
            manager = new GameManager(playersRepo);
        }

        //GET /api/games
        [HttpGet]
        public IEnumerable<Game> Get() => gamesRepo.GetGames();

        //GET /api/games/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var game = gamesRepo.GetById(id);
            if (game == null) return NotFound();
            return Ok(game);
        }

        //POST /api/games
        [HttpPost]
        public IActionResult PostGame()
        {
            var game = manager.GameSetting();
            if(game == null) return BadRequest("Not enough available players");
            gamesRepo.AddGame(game);
            return Ok(game);
        }

        //DELETE /api/games/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteGame(Guid id)
        {
            var game = gamesRepo.GetById(id);
            if(game == null) return NotFound();
            manager.FinishGame(game);
            gamesRepo.RemoveGame(game);
            return Ok($"Game {id} has deleted");
        }

        //PATCH /api/games/{id}?cell={cell}
        [HttpPatch("{id}")]
        public IActionResult MakeMove(Guid id, short cell)
        {
            var game = gamesRepo.GetById(id);
            if(game == null) return NotFound();
            manager.MakeMark(cell, ref game);
            gamesRepo.UpdateGame();
            return Ok(game);
        }
    }
}