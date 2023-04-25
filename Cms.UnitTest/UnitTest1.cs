using BreweryWholesaleManagement.Models.Cms.Brewery;
using Cms.UnitTest.Apis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cms.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAddBeer()
        {
            Calls calls = new Calls();
            var responseListBreweries = calls.CallApiListBreweries();
            //////Call addbeers then check response using assert.
        }
    }
}