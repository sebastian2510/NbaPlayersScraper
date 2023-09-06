using HtmlAgilityPack;
using NbaScraper.PlayerInfo;
using NbaScraper.Scraper;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;

namespace NbaScraper
{
    internal class Program
    {
        private static List<string> urls = new List<string>
        {
            "https://www.espn.com/nba/team/stats/_/name/bos/",
            "https://www.espn.com/nba/team/stats/_/name/ny/",
            "https://www.espn.com/nba/team/stats/_/name/bkn/",
            "https://www.espn.com/nba/team/stats/_/name/phi/",
            "https://www.espn.com/nba/team/stats/_/name/tor/",
            "https://www.espn.com/nba/team/stats/_/name/chi/",
            "https://www.espn.com/nba/team/stats/_/name/cle/",
            "https://www.espn.com/nba/team/stats/_/name/det/",
            "https://www.espn.com/nba/team/stats/_/name/ind/",
            "https://www.espn.com/nba/team/stats/_/name/mil/",
            "https://www.espn.com/nba/team/stats/_/name/min/",
            "https://www.espn.com/nba/team/stats/_/name/den/",
            "https://www.espn.com/nba/team/stats/_/name/okc/",
            "https://www.espn.com/nba/team/stats/_/name/por/",
            "https://www.espn.com/nba/team/stats/_/name/utah/",
            "https://www.espn.com/nba/team/stats/_/name/gs/",
            "https://www.espn.com/nba/team/stats/_/name/lac/",
            "https://www.espn.com/nba/team/stats/_/name/lal/",
            "https://www.espn.com/nba/team/stats/_/name/phx/",
            "https://www.espn.com/nba/team/stats/_/name/sac/",
            "https://www.espn.com/nba/team/stats/_/name/atl/",
            "https://www.espn.com/nba/team/stats/_/name/cha/",
            "https://www.espn.com/nba/team/stats/_/name/mia/",
            "https://www.espn.com/nba/team/stats/_/name/orl/",
            "https://www.espn.com/nba/team/stats/_/name/wsh/",
            "https://www.espn.com/nba/team/stats/_/name/hou/",
            "https://www.espn.com/nba/team/stats/_/name/dal/",
            "https://www.espn.com/nba/team/stats/_/name/mem/",
            "https://www.espn.com/nba/team/stats/_/name/no/",
            "https://www.espn.com/nba/team/stats/_/name/sa/"

        };

        private static void Main(string[] args)
        {
            List<Stats> stats = new();
            List<string> players = new();
            foreach (string url in urls)
            {
                Console.WriteLine($"Starting url: {url}");
                stats.AddRange(new PointScraper().PrintAllStats(url));
                players.AddRange(new PlayerNameScraper().GetPLayerNames(url));
                Console.WriteLine($"Finished url: {url}");
            }

            // Merge the two lists into Player objects
            List<Player> playersList = new();
            for (int i = 0; i < players.Count; i++)
            {
                playersList.Add(new Player(players[i], stats[i]));
            }

            // Print the players
            foreach (Player player in playersList)
            {
                Console.WriteLine($"Name: {player.Name}");
                foreach (var stat in player.Stats.GetType().GetProperties())
                {
                    Console.WriteLine($"{stat.Name}: {stat.GetValue(player.Stats)}");
                }
                Console.WriteLine(Environment.NewLine + Environment.NewLine);
            }
        }
    }
}
