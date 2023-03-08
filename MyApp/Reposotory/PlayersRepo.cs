using MyApp.Models;

namespace MyApp.Reposotory
{
    public class PlayersRepo : IPlayersRepo
    {
        public List<Player> Players { get; set; } = new(){
            new Player(),
            new Player()
        };

        public IEnumerable<Player> GetPlayers() => Players;
        public Player? GetById(Guid id) => Players.FirstOrDefault(p => p.Id == id);

    }
}
