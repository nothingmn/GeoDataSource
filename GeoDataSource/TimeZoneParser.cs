using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoDataSource
{
    public class TimeZoneParser
    {
        public static List<TimeZone> ParseFile(string File)
        {

            List<TimeZone> Names = new List<TimeZone>();
            int count = 0;
            using (System.IO.StreamReader rdr = new System.IO.StreamReader(File))
            {
                string line = "";
                do
                {
                    line = rdr.ReadLine();
                    if (!string.IsNullOrEmpty(line) && !line.StartsWith("CountryCode"))
                    {
                        TimeZone n = ParseLine(line);
                        Names.Add(n);
                    }
                    count++;
                } while (!string.IsNullOrEmpty(line));
            }

            return Names;
        }

        static TimeZone ParseLine(string Line)
        {
            TimeZone n = new TimeZone();
            string[] parts = Line.Split('\t');
            int id = 0;

            n.CountryCode = parts[0];
            n.TimeZoneId = parts[1];
            n.GMTOffSet = parts[2];
            n.DSTOffSet = parts[3];
            n.RawOffSet = parts[4];

            return n;
        }
    }
}
