using GamersPoems.Models;
using GamersPoems.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamersPoems.Services
{
    public class GamesData : IGamesData
    {
        public IEnumerable<Game> GetAll()
        {
            List<Game> games = new List<Game>();

            games.Add(new Game() { Name = "Mortal Kombat 2", Id = 1 });
            games.Add(new Game() { Name = "Mega-lo-Mania", Id = 2 });
            games.Add(new Game() { Name = "Dune II", Id = 3 });

            return games;
        }
    }
}
