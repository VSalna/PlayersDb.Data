using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlayersDb.Data;
namespace Players.Mvc.Models
{
    public class DetailsViewModel
    {
        public Player Player { get; set; }

        public string ErrorMessage { get; set; }
    }
}
