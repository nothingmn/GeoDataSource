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

        [Test]
        public void USAPhoneTest()
        {
            Assert.IsNotNull(PhoneManager.Current.AutoDetect("1(310) 652-4106"));
        }
        [Test]
        public void BCCanadaPhoneTest()
        {
            var phone = PhoneManager.Current.AutoDetect("1(604) 338 2512");
            Assert.AreEqual("Canada", phone.Country);
            StringAssert.StartsWith("British Columbia", phone.Comment);
        }

        [Test]
        public void MexicoPhoneTest()
        {
            var phone = PhoneManager.Current.AutoDetect("52-1-(81) 8309-6670");
            Assert.AreEqual("Mexico", phone.Country);
        }
        [Test]
        public void KenyaPhoneTest()
        {
            var phone = PhoneManager.Current.AutoDetect("254(700) 669024");
            Assert.AreEqual("Kenya", phone.Country);
        }

        [Test]
        public void Crappy_Input_Wont_Return_A_Good_ResultTest()
        {
            var phone = PhoneManager.Current.AutoDetect("254(70sdf0) 669!@#$%^&*()_024");
            Assert.IsNull(phone);
        }
    }
}
