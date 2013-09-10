using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoDataSource
{
    [Serializable]
    public class TimeZone
    {
        public string CountryCode { get; set; }
        public string TimeZoneId { get; set; }
        public string Name { get; set; }
        public string GMTOffSet { get; set; }
        public string DSTOffSet { get; set; }
        public string RawOffSet { get; set; }

    }
}
