using MyApp.Models;

namespace MyApp.Reposotory
{
    public interface IGamesRepo
    {
        public List<Game> Games { get; set; }

        public IEnumerable<Game> GetGames();
        public Game? GetById(Guid id);
        public void AddGame(Game game);
        public void RemoveGame(Game game);
        public void UpdateGame();
    }
}
