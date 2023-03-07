using MyApp.Reposotory;
using MyApp.Services;

namespace MyApp.Models
{
    public class Game : Base
    {
        public bool IsFinished { get; set; }
        public bool[] FreeCells { get; set; }
        public Player[] Players { get; set; } = new Player[2];

        public Game()
        {
            Id = Guid.NewGuid();
            IsFinished = false;
            FreeCells = new bool[9];
            Array.Fill(FreeCells, false);
        }

        
    }
}
