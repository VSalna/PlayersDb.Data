using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayersDb.Data;
namespace Players.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private IPLayerDataRepository _repo;
        public PlayersController(IPLayerDataRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IEnumerable<Player> GetPLayers()
        {
            return _repo.GetPlayers();
        }
        [HttpPost]
        public int AddPlayer([FromBody] Player player)
        {
            return _repo.AddPlayer(player);
        }
        [HttpGet("{id}")]
        public Player GetPlayer(int id)
        {
            return _repo.GetPlayersById(id);
        }
    }
}