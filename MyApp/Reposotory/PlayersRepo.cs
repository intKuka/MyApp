using MyApp.Models;

namespace MyApp.Reposotory
{
    public class PlayersRepo : IPlayersRepo
    {
        public List<Player> Players { get; set; } = new(){
            new Player(),
            new Player()
        };
        
    

        

        
    }
}
