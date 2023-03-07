using Microsoft.AspNetCore.Mvc;
using MyApp.Models;
using MyApp.Reposotory;
using MyApp.Services;

namespace MyApp.Controllers
{
    [ApiController]
    [Route("api/main")]
    public class MainController : ControllerBase
    {
        IPlayersRepo playersRepo;
        IGamesRepo gamesRepo;
        GameManager manager;

        public MainController(IPlayersRepo playersRepo, IGamesRepo gamesRepo)
        {
            this.playersRepo = playersRepo;
            this.gamesRepo = gamesRepo;
            manager = new GameManager(playersRepo, gamesRepo);
        }

        //GET /api/main
        [HttpGet]
        public IEnumerable<Game> Get() => gamesRepo.GetGames();

        //GET /api/main/id
        [HttpGet("{id}")]
        public ActionResult<Game> GetById(Guid id)
        {
            var game = gamesRepo.GetGameById(id);
            if (game == null) return NotFound();
            return game;
        }

        //POST /api/main
        [HttpPost]
        public ActionResult<Game> Create()
        {
            var gameId = manager.CreateGame();
            if(gameId == Guid.Empty) return BadRequest("Not enough available players");
            return GetById(gameId);
        }

        //PUT /api/main/id/finish
        [HttpDelete("{id}/finish")]
        public ActionResult<Game> Delete(Guid id)
        {
            var game = gamesRepo.Games.FirstOrDefault(x => x.Id == id);
            if(game == null) return NotFound();
            manager.FinishGame(game);
            if(game.IsFinished) gamesRepo.Games.Remove(game);
            return Ok($"Game {id} has deleted");
        }
    }
}