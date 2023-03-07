using Microsoft.AspNetCore.Mvc;
using MyApp.Models;

namespace MyApp.Reposotory
{
    public interface IGamesRepo
    {
        public List<Game> Games { get; set; }

        public IEnumerable<Game> GetGames();

        public ActionResult<Game> GetGameById(Guid id);

    }
}
