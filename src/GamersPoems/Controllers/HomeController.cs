using GamersPoems.Models;
using GamersPoems.Services.Interface;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamersPoems.Controllers
{
    public class HomeController : Controller
    {
        private IGamesData _gamesData;

        public HomeController(IGamesData gamesData)
        {
            _gamesData = gamesData;
        }

        public IActionResult Index()
        {
            var result = _gamesData.GetAll();

            return View(result);
        }
    }
}
