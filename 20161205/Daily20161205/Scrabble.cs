using System.Linq;

namespace Daily20161205
{
    public static class Scrabble
    {
        public static bool CanFormWordWithTiles(string word, string tilesAsString)
        {

            var wordCountMap = word.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
            var tileCountMap = tilesAsString.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());

            var wildcardsAvailable = 0;
            tileCountMap.TryGetValue('?', out wildcardsAvailable);

            foreach (var entry in wordCountMap)
            {
                var required = entry.Value;
                var onHand = 0;
                tileCountMap.TryGetValue(entry.Key, out onHand);

                if (onHand >= required) continue;
                var difference = required - onHand;
                if (wildcardsAvailable >= difference)
                {
                    wildcardsAvailable -= difference;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}