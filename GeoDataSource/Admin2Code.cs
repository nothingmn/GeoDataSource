using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoDataSource
{
    [Serializable]
    public class Admin2Code
    {
        public string CountryId { get; set; }
        public string Admin1Id { get; set; }
        public string Code { get; set; }
        public string GeoNameId { get; set; }
        public string Name { get; set; }
        public string ASCIIName { get; set; }
    }
}
