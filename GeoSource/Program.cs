using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GeoDataSource;

namespace GeoSource
{
    class Program
    {
        static void Main(string[] args)
        {

            DataManager.Update().Wait();


            var geo = GeoData.Current;
            var cc = geo.Countries;

            var states = geo.ProvincesByCountry("USA");
            var provinces = geo.ProvincesByCountry("CA");
            
            //37/47
            var canada = cc[37];

            bool isValid = geo.ValidatePostalCodeByCountry(canada.Name, "V5B 2Y2");
            bool isValid2 = geo.ValidatePostalCodeByCountry(canada.Name, "V5B2Y2");
            bool isValidUS = geo.ValidatePostalCodeByCountry(geo.GetCountry("USA").Name, "90210");


        }
    }
}
