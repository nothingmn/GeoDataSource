using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace GeoDataSource.Tests
{
    [TestFixture]
    public class ValidationTests
    {
        [Test]
        public void CanadaValdiationWithSpaceInPostalCode()
        {

            Assert.IsTrue(GeoData.Current.ValidatePostalCodeByCountry("CA", "V5B 2Y2"));
        }
        [Test]
        public void CanadaValdiationWithNoSpaceInPostalCode()
        {

            Assert.IsTrue(GeoData.Current.ValidatePostalCodeByCountry("CA", "V5B2Y2"));

        }
        [Test]
        public void USAValdiationWith5Digit()
        {

            Assert.IsTrue(GeoData.Current.ValidatePostalCodeByCountry("USA", "90210"));
        }
    }
}
