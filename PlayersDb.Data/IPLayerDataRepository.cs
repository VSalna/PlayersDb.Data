using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersDb.Data
{
    public interface IPLayerDataRepository
    {

        List<Player> GetPlayers();
        
        int AddPlayer(Player player);

       
        Player GetPlayersById(int id);

        bool UpdatePlayer(Player player);

        void DeletePlayer(int id);
    }
}
