using MyApp.Models;

namespace MyApp.Reposotory
{
    public interface IPlayersRepo
    {
        public List<Player> Players { get; set; }
    }
}
