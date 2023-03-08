using MyApp.Reposotory;
using MyApp.Services;

namespace MyApp.Models
{
    public class Game : Base
    {
        public bool IsFinished { get; set; }
        public char?[] FreeCells { get; set; }

        public Player[] Players { get; set; } = new Player[2];
        public char CurrentMove { get; set; }

        public Game()
        {
            Id = Guid.NewGuid();
            IsFinished = false;
            FreeCells = new char?[9];
        }

        
    }
}
