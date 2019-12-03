using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PlayersDb.Data;
using Newtonsoft.Json;

namespace Players.Mvc.Data
{
    public class PlayerWebApiRepository
    {
        private const string BaseUrl = "http://localhost:62474/api/players";
        public IEnumerable<Player> GetPlayers()
        {
            WebClient client = new WebClient();
            var json = client.DownloadString(BaseUrl);
            var player = JsonConvert.DeserializeObject<IEnumerable<Player>>(json);

            return player;
        }

        public Player GetPlayer(string id)
        {
            WebClient client = new WebClient();
            var json = client.DownloadString(BaseUrl + $"/{id}");
            var player = JsonConvert.DeserializeObject<Player>(json);

            return player;
        }

        public async Task<PlayerDbContext> Update(Player player)
        {

            var json = JsonConvert.SerializeObject(player);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            {
                var response = await client.PatchAsync(BaseUrl, data);
                var jsonResponse = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<PlayerDbContext>(jsonResponse);
                return result;
            }

        }
    }
}
