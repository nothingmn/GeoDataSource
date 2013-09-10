using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoDataSource
{
    public class FeatureCodeParser
    {
        public static List<FeatureCode> ParseFile(string File)
        {

            List<FeatureCode> Names = new List<FeatureCode>();
            int count = 0;
            using (System.IO.StreamReader rdr = new System.IO.StreamReader(File))
            {
                string line = "";
                do
                {
                    line = rdr.ReadLine();
                    if (!string.IsNullOrEmpty(line) && !line.StartsWith("CountryCode"))
                    {
                        FeatureCode n = ParseLine(line);
                        Names.Add(n);
                    }
                    count++;
                } while (!string.IsNullOrEmpty(line));
            }

            return Names;
        }

        static FeatureCode ParseLine(string Line)
        {
            FeatureCode n = new FeatureCode();
            string[] parts = Line.Split('\t');
            int id = 0;

            if (parts[0].Contains("."))
            {
                var codeAndClass = parts[0].Split('.');
                n.Code = codeAndClass[0];
                n.Class = codeAndClass[1];
            }
            else
            {
                n.Code = parts[0];
                n.Class = parts[0];
            }
            n.Name = parts[1];
            n.Description = parts[2];

            return n;
        }
    }
}
