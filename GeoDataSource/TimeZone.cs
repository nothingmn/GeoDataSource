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
        public double GMTOffSet { get; set; }
        public double DSTOffSet { get; set; }
        public double RawOffSet { get; set; }

    }
}
