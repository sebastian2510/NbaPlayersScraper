using NbaScraper;
using NbaScraper.PlayerInfo;
using NbaScraper.Scraper;

namespace NbaScraperPage.Data
{
    public class Players
    {
        private readonly List<string> urls = new List<string>
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
            "https://www.espn.com/nba/team/_/name/cha/",
            "https://www.espn.com/nba/team/stats/_/name/mia/",
            "https://www.espn.com/nba/team/_/name/orl/",
            "https://www.espn.com/nba/team/stats/_/name/wsh/",
            "https://www.espn.com/nba/team/stats/_/name/hou/",
            "https://www.espn.com/nba/team/stats/_/name/dal/",
            "https://www.espn.com/nba/team/_/name/mem/",
            "https://www.espn.com/nba/team/stats/_/name/no/",
            "https://www.espn.com/nba/team/stats/_/name/sa/"

        };

        public List<Player> GetNbaPlayers()
        {
            List<Stats> stats = new();
            List<string> players = new();

            foreach (string url in urls)
            {
                stats.AddRange(new PointScraper().GetStats(url));
                players.AddRange(new PlayerNameScraper().GetPLayerNames(url));
            }

            List<Player> playerList = new();

            for (int i = 0; i < players.Count; i++)
            {
                playerList.Add(new Player(players[i], stats[i]));
            }

            return playerList;
        }
    }
}
