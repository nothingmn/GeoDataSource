using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace GeoDataSource.Tests
{
    [TestFixture]
    public class UpdateTests
    {
        [Test]
        public void TestUpdateProcess()
        {
            //just make sure that this sucker doesnt throw an execption
            DataManager.Update().Wait();

        }
    }
}
