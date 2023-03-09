using MyApp.Data;
using MyApp.Models;
using System.Text.Json;

namespace MyApp.Reposotory
{
    public class GamesRepo : IGamesRepo
    {
        public List<Game> Games { get; set; } = new();

        readonly IJsonHandler<Game> _jsonHandler;
        public GamesRepo(IJsonHandler<Game> jsonHandler) 
        {
            _jsonHandler = jsonHandler;
            _jsonHandler.JsonPath = @"Data\JsonFiles\games.json";
            _jsonHandler.LoadJsonToList(Games);
        }  


        public IEnumerable<Game> GetGames() => Games;

        public Game? GetById(Guid id) => Games.FirstOrDefault(x => x.Id == id);

        public void AddGame(Game game)
        {
            Games.Add(game);
            _jsonHandler.DumpJsonFromList(Games);
        }

        public void RemoveGame(Game game)
        {
            Games.Remove(game);
            _jsonHandler.DumpJsonFromList(Games);
        }

        public void UpdateGame()
        {
            _jsonHandler.DumpJsonFromList(Games);
        }
    }
    
}
