using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace GeoDataSource.Tests
{
    [TestFixture]
    public class CountriesTests
    {

        [Test]
        public void GetCountries()
        {
            var countries = GeoData.Current.Countries;
            Assert.IsNotNull(countries);

        }

        [Test]
        public void GetInvalidCountryTest()
        {
            var invalid = GeoData.Current.GetCountry("3R!");
            Assert.IsNull(invalid);
        }

        [Test]
        public void GetCanada()
        {
            var canada = GeoData.Current.GetCountry("CA");
            Assert.IsNotNull(canada);

        }
        [Test]
        public void GetProvinceBC()
        {
            var canada = GeoData.Current.GetCountry("CA");
            var provinces= GeoData.Current.ProvincesByCountry(canada);
            var bc = (from p in provinces where p.Name == "British Columbia" select p). FirstOrDefault();
            Assert.IsNotNull(bc);

        }
        [Test]
        public void GetProvinceBCTimeZone()
        {
            var canada = GeoData.Current.GetCountry("CA");
            var provinces = GeoData.Current.ProvincesByCountry(canada);
            var bc = (from p in provinces where p.Name == "British Columbia" select p).FirstOrDefault();

            var bcTimeZone = GeoData.Current.TimeZone(bc);

            Assert.IsNotNull(bcTimeZone);
           
        }
        [Test]
        public void GetProvinceBCTimeGMTIsMinus8()
        {
            var canada = GeoData.Current.GetCountry("CA");
            var provinces = GeoData.Current.ProvincesByCountry(canada);
            var bc = (from p in provinces where p.Name == "British Columbia" select p).FirstOrDefault();

            var bcTimeZone = GeoData.Current.TimeZone(bc);

            Assert.IsTrue(bcTimeZone.GMTOffSet == -8);

        }
        [Test]
        public void GetCanadaISONumeric()
        {
            var canada = GeoData.Current.GetCountry("124");
            Assert.IsNotNull(canada);

        }
        [Test]
        public void GetUSAByThreeLetter()
        {
            var usa = GeoData.Current.GetCountry("USA");
            Assert.IsNotNull(usa);

        }
        [Test]
        public void GetUSAByTwoLetter()
        {
            var usa = GeoData.Current.GetCountry("US");
            Assert.IsNotNull(usa);

        }
        [Test]
        public void GetUSAByName()
        {
            var usa = GeoData.Current.GetCountry("United States");
            Assert.IsNotNull(usa);

        }
        [Test]
        public void GetUSAByFips()
        {
            var usa = GeoData.Current.GetCountry("US");
            Assert.IsNotNull(usa);

        }


    }
}
