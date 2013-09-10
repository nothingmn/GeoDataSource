using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoDataSource
{
    [Serializable]
    public class Continent
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string GeoNameId { get; set; }
    }
}
