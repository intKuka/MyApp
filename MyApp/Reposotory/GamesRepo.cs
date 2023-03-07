using MyApp.Models;

namespace MyApp.Reposotory
{
    public class GamesRepo : IGamesRepo
    {
        public List<Game> Games { get; set; } = new();

        public IEnumerable<Game> GetGames() => Games;

        public Game? GetById(Guid id) => Games.FirstOrDefault(x => x.Id == id);


    }
    
}
