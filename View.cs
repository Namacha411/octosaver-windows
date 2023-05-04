using CodeHollow.FeedReader;
using System.Text.RegularExpressions;

namespace octsaver_windows
{
    internal partial class View
    {
        private List<OctcatInfo> octcatInfos = new();

        public View()
        {
        }
        
        public static async Task<View> SetOctcatUrls()
        {
            View view = new()
            {
                octcatInfos = await GetOctcatInfosAsync()
            };
            return view;
        }

        public OctcatInfo GetRandomOctcatUrl()
        {
            var r = new Random();
            return octcatInfos[r.Next(octcatInfos.Count)];
        }

        public static async Task<OctcatInfo> GetRandomOctcatInfoAsync()
        {
            var r = new Random();
            var infos = await GetOctcatInfosAsync();
            return infos[r.Next(infos.Count)];
        }

        private static async Task<List<OctcatInfo>> GetOctcatInfosAsync()
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
                    return new OctcatInfo(item.Title, url);
                })
                .ToList();
            return urls;
        }

        [GeneratedRegex("<img src=\"(?<url>.+)\"/>")]
        private static partial Regex MyRegex();
    }
}
