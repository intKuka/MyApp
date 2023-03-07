using Microsoft.AspNetCore.Mvc;
using MyApp.Models;

namespace MyApp.Reposotory
{
    public class GamesRepo : IGamesRepo
    {
        public List<Game> Games { get; set; } = new();

        public IEnumerable<Game> GetGames() => Games;

        public ActionResult<Game> GetGameById(Guid id) => Games.FirstOrDefault(x => x.Id == id);


    }
    
}
