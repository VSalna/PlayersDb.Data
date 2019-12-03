using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Players.Mvc.Models;

//using Players.Mvc.Data;
using PlayersDb.Data;

namespace Players.Mvc.Controllers
{
    public class PlayersController : Controller
    {
        private readonly ILogger<PlayersController> _logger;
        private readonly IPLayerDataRepository _repo;


        public PlayersController(ILogger<PlayersController> logger, IPLayerDataRepository repo)
        {
            _logger = logger;
            _repo =  repo;
        }

        public IActionResult Index()
        {
            var model = new IndexViewModel();
            model.Players = _repo.GetPlayers();
            return View(model);
        }
        public IActionResult Details(int id)
        {
            
            var model = _repo.GetPlayersById(id);
            return View(model);
        }


        public IActionResult Delete(int id)
        {
            _repo.DeletePlayer(id);
            var indexModel = new IndexViewModel()
            {
                Players = _repo.GetPlayers()
            };
            return View("Index", indexModel);
        }
        public IActionResult DeleteConfirmation(int id)
        {
            var indexModel = new IndexViewModel()
            {
                Players = _repo.GetPlayers(),
                ShowConfirm = true,
                ItemToDeleteId = id
            };
            return View("Index", indexModel);
        }
        public IActionResult Create()
        {
            var model = new Player();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create([FromForm] Player player)
        {
           
            var result = _repo.AddPlayer(player);

            if (result == 0)
            {
                return View(player);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Details([FromForm] Player player)
        {
            var result = _repo.UpdatePlayer(player);

            if (result)
            {
                return View(player);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
