using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace LR2Arena
{
    // Mostly taken from Mushu's bms-parser: https://github.com/Mushus/bms-parser
    public class BmsParser
    {
        private static Regex DefGenre = new Regex("^GENRE (.*)$");
        private static Regex DefTitle = new Regex("^TITLE (.*)$");
        private static Regex DefArtist = new Regex("^ARTIST (.*)$");
        private static Regex DefSubTitle = new Regex("^SUBTITLE (.*)$");
        private static Regex DefSubArtist = new Regex("^SUBARTIST (.*)$");
        private static Regex DefPlayLevel = new Regex("^PLAYLEVEL (\\d+)$");
        private static Regex DefTotal = new Regex("^TOTAL ([+-]?([0-9]+(\\.[0-9]*)?|\\.[0-9]+)([eE][+-]?[0-9]+)?)$");

        public BmsHeader Parse(Stream s)
        {
            var bmsData = new BmsHeader();
            using (StreamReader sr = new StreamReader(s, Encoding.GetEncoding(932)))
            {
                while (sr.Peek() > -1)
                {
                    var line = sr.ReadLine();
                    if (line.Length == 0) continue;
                    switch (line[0])
                    {
                        case '*':
                            continue;
                        case '#':
                            this.ParseDef(bmsData, line.Substring(1));
                            break;
                    }
                }
            }

            return bmsData;
        }

        void ParseDef(BmsHeader bmsData, string def)
        {
            Match m;

            m = DefGenre.Match(def);
            if (m.Success)
            {
                bmsData.Genre = m.Groups[1].Value;
                return;
            }

            m = DefTitle.Match(def);
            if (m.Success)
            {
                bmsData.Title = m.Groups[1].Value;
                return;
            }

            m = DefArtist.Match(def);
            if (m.Success)
            {
                bmsData.Artist = m.Groups[1].Value;
                return;
            }

            m = DefSubTitle.Match(def);
            if (m.Success)
            {
                bmsData.SubTitle = m.Groups[1].Value;
                return;
            }

            m = DefSubArtist.Match(def);
            if (m.Success)
            {
                bmsData.SubArtist = m.Groups[1].Value;
                return;
            }

            m = DefPlayLevel.Match(def);
            if (m.Success)
            {
                var value = int.Parse(m.Groups[1].Value);
                bmsData.PlayLevel = value;
                return;
            }

            m = DefTotal.Match(def);
            if (m.Success)
            {
                var value = double.Parse(m.Groups[1].Value);
                bmsData.Total = value;
                return;
            }
        }
    }
}
