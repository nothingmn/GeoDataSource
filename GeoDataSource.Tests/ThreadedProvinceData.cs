using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace GeoDataSource.Tests
{
    [TestFixture]
    public class ThreadedProvinceData
    {
        [Test]
        public void BasicThreadedQueries()
        {

            List<Task> tasks = new List<Task>();

            for (int x = 0; x <= 100; x++)
            {
                tasks.Add(
                    Task.Factory.StartNew(() =>
                        {
                            var states = GeoData.Current.ProvincesByCountry("USA");
                            foreach (var s in states)
                            {
                                Assert.IsNotNull(s);
                            }
                        })
                    );

            }
            Task.WaitAll(tasks.ToArray());
        }
    }
}
