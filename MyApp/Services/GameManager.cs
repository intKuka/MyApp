using MyApp.Models;
using MyApp.Reposotory;

namespace MyApp.Services
{
    public class GameManager
    {
        IPlayersRepo playersRepository;
        IGamesRepo gamesRepository;
        Player[] players;
        readonly char[] gameSides = { 'X', 'O' };

        public GameManager(IPlayersRepo playersRepo, IGamesRepo gamesRepo)
        {
            playersRepository = playersRepo;
            gamesRepository = gamesRepo;
        }

        public Guid CreateGame()
        {
            if (FindFreePlayers(playersRepository.Players))
            {
                var game = new Game { Players = players };
                gamesRepository.Games.Add(game);
                game.Players[0].InGame = true;
                game.Players[1].InGame = true;
                return game.Id;
            }
            else return Guid.Empty;            
        }

        public void FinishGame(Game game)
        {
            game.Players[0].InGame = false;
            game.Players[1].InGame = false;
            game.IsFinished = true;
        }

        /// <param name="allPlayers">List of all existing players</param>
        /// <returns>Boolean that defines can the game be created</returns>
        bool FindFreePlayers(IEnumerable<Player> allPlayers)
        {
            int playPlaces = 0;
            players = new Player[2];

            foreach (var player in allPlayers)
            {
                if (player.InGame == false)
                {
                    players[playPlaces] = player;
                    players[playPlaces].Side = gameSides[playPlaces];
                    playPlaces++;
                }
                if (playPlaces == 2) return true;
            }
            return false;
        }
    }
}
