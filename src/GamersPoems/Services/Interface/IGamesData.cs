using GamersPoems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamersPoems.Services.Interface
{
    public interface IGamesData
    {
        IEnumerable<Game> GetAll();
    }
}
