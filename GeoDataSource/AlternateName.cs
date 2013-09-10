using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoDataSource
{
    [Serializable]
    public class AlternateName
    {
        public string Id { get; set; }
        public string GeoNameId { get; set; }
        public string Language { get; set; }
        public string Name { get; set; }
        public string Preferred { get; set; }
        public string Short { get; set; }
    }
}
