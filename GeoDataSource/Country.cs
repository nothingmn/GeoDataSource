using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoDataSource
{
    [Serializable]
    public class Country
    {

        public string ISOAlpha2 { get; set; }
        public string ISOAlpha3 { get; set; }
        public string ISONumeric { get; set; }
        public string FipsCode { get; set; }
        public string Name { get; set; }
        public string Capital { get; set; }
        public string Area { get; set; }
        public string Population { get; set; }
        public string ContinentId { get; set; }
        public string Continent { get; set; }
        public string tld { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public string PhonePrefix { get; set; }
        public string PostalCodeFormat { get; set; }
        public string PostalCodeRegularExpression { get; set; }
        public string Languages { get; set; }
        public int GeoNameId { get; set; }

        public string Neighbours { get; set; }
        public string EquivalentFipsCode { get; set; }


        public IEnumerable<PhoneInformation> PhoneInformation { get; set; }

    }
}