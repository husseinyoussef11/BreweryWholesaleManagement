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
            //////use idbrewery from response to add beer
            AddBeerResponse addBeerResponse = new AddBeerResponse();
            Assert.AreEqual("Success",addBeerResponse.StatusCode.message);

            ////////Check count of beers before add then after add to make sure its added +1
            ///retreive fields by id to check if same values
            ///


        }
    }
}