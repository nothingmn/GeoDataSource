using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoDataSource
{
    [Serializable]
    public class ISOLanguage
    {
        public string ISO_639_3 { get; set; }
        public string ISO_639_2 { get; set; }
        public string ISO_639_1 { get; set; }
        public string LanguageName { get; set; }

            
    }
}
