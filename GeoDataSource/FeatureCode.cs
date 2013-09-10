using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoDataSource
{
    [Serializable]
    public class FeatureCode
    {
        public string Code { get; set; }
        public string Class { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
