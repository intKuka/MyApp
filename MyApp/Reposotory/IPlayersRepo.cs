using MyApp.Models;

namespace MyApp.Reposotory
{
    public interface IPlayersRepo
    {
        public List<Player> Players { get; set; }
        public IEnumerable<Player> GetPlayers();
        public Player? GetById(Guid id);
        public Player? CreatePlayer();
        public void DeletePlayer(Player player);
    }
}
