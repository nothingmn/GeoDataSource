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
        public void GetCanada()
        {
            var canada = GeoData.Current.GetCountry("CA");
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
