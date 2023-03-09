using MyApp.Data;
using MyApp.Models;
using System.Numerics;
using System.Text.Json;

namespace MyApp.Reposotory
{
    public class PlayersRepo : IPlayersRepo
    {
        public List<Player> Players { get; set; } = new();
        readonly IJsonHandler<Player> _jsonHandler;

        public PlayersRepo(IJsonHandler<Player> jsonHandler)
        {
            _jsonHandler = jsonHandler;
            _jsonHandler.JsonPath = @"Data\JsonFiles\players.json";
            _jsonHandler.LoadJsonToList(Players);
        }


        public IEnumerable<Player> GetPlayers() => Players;

        public Player? GetById(Guid id) => Players.FirstOrDefault(p => p.Id == id);

        public Player? CreatePlayer()
        {
            var player = new Player();
            if (player == null) return null;
            Players.Add(new Player());
            _jsonHandler.DumpJsonFromList(Players);
            return player;
        }

        public void DeletePlayer(Player player)
        {            
            Players.Remove(player);
            _jsonHandler.DumpJsonFromList(Players);
        }
    }
}
