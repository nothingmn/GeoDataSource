using System;
using System.Collections.Generic;

namespace GeoDataSource
{
    [Serializable]
    public class GeoName
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string AsciiName { get; set; }
        public List<string> AlternateNames { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string FeatureClass { get; set; }
        public string FeatureCodeId { get; set; }
        public FeatureCode FeatureCode { get; set; }
        public string CountryCode { get; set; }
        public string AlternateCountryCode { get; set; }
        public string Admin1Code { get; set; }
        public string Admin2Code { get; set; }
        public string Admin3Code { get; set; }
        public string Admin4Code { get; set; }
        public long Population { get; set; }
        public int Elevation { get; set; }
        public string DigitalElevationModel { get; set; }
        public string TimeZoneId { get; set; }
        public TimeZone TimeZone { get; set; }
        public DateTime LastModified { get; set; }
        public string TwoLetterName { get; set; }
        public Country CountryInformation { get; set; }
    }
}
