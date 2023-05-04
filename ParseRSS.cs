using CodeHollow.FeedReader;
using System.Text.RegularExpressions;

namespace octosaver_windows
{
    internal partial class ParseRSS
    {
        private List<OctocatInfo> octocatInfos = new();

        public ParseRSS()
        {
        }
        
        public static async Task<ParseRSS> SetOctocatInfos()
        {
            ParseRSS view = new()
            {
                octocatInfos = await GetOctocatInfosAsync()
            };
            return view;
        }

        public OctocatInfo GetRandomOctocatInfo()
        {
            var r = new Random();
            return octocatInfos[r.Next(octocatInfos.Count)];
        }

        public static async Task<OctocatInfo> GetRandomOctocatInfoAsync()
        {
            var r = new Random();
            var infos = await GetOctocatInfosAsync();
            return infos[r.Next(infos.Count)];
        }

        private static async Task<List<OctocatInfo>> GetOctocatInfosAsync()
        {
            var feed = await FeedReader.ReadAsync("https://octodex.github.com/atom.xml");
            var re = MyRegex();
            var urls = feed
                .Items
                .Select(item =>
                {
                    string url = re
                        .Match(item.Content)
                        .Groups["url"]
                        .Value;
                    return new OctocatInfo(item.Title, url);
                })
                .ToList();
            return urls;
        }

        [GeneratedRegex("<img src=\"(?<url>.+)\"/>")]
        private static partial Regex MyRegex();
    }
}
