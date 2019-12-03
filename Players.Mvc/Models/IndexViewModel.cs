using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlayersDb.Data;
namespace Players.Mvc.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Player> Players { get; set; }
        public bool ShowConfirm { get; internal set; }
        public int ItemToDeleteId { get; internal set; }
    }
}
