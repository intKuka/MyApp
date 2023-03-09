using MyApp.Models;
using MyApp.Reposotory;

namespace MyApp.Services
{
    public class GameManager
    {
        readonly IPlayersRepo playersRepository;
        Player[] players;
        readonly char[] gameSides = { 'X', 'O' };

        public GameManager(IPlayersRepo playersRepo)
        {
            playersRepository = playersRepo;
        }

        public Game? GameSetting()
        {
            if (FindFreePlayers(playersRepository.Players))
            {
                var game = new Game { Players = players };
                game.Players[0].InGame = true;
                game.CurrentMove = gameSides[0];
                game.Players[1].InGame = true;
                return game;
            }
            else return null;            
        }

        public void MakeMark(short index, ref Game game)
        {
            if (IsValidMark(index, ref game) == false) return;
            if(game.Players[0].Side == game.CurrentMove)
            {
                game.FreeCells[index] = game.Players[0].Side;
                game.CurrentMove = gameSides[1];
            }
            else
            {
                game.FreeCells[index] = game.Players[1].Side;
                game.CurrentMove = gameSides[0];
            }
            return;
        }

        //Check if player invokes outOfRange or tries to mark the a used cell 
        static bool IsValidMark(short index, ref Game game)
        {
            if(index > 8 || index < 0) return false;
            if (game.FreeCells[index] == null) return true;
            else return false;
        }

        public void FinishGame(Game game)
        {
            game.Players[0].InGame = false;
            game.Players[1].InGame = false;
            game.Players[0].Side = '\0';
            game.Players[1].Side = '\0';
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
