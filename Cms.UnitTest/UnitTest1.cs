using Bogus;
using BreweryWholesaleManagement.Models.Cms.Brewery;
using Cms.UnitTest.Apis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
            Guid idBrewery = responseListBreweries.Breweries[0].Id;
            //////use idbrewery from response to add beer
            var resplistbeersBeforeadd = calls.CallApiListBeers(idBrewery);
            ///////
            var fakerAdd = new Faker<AddBeerRequest>()
      .RuleFor(u => u.AlcoholContent, f => 10)
      .RuleFor(u => u.IdBrewery, f => idBrewery)
      .RuleFor(u => u.Name, f => f.Random.Word())
      .RuleFor(u => u.Price, f => 20);
            var generatedRequestAdd = fakerAdd.Generate();
            var addBeerResponse = calls.CallApiAddBeer(generatedRequestAdd);
            var resplistbeersAfteradd = calls.CallApiListBeers(idBrewery);

            Assert.AreEqual("Success", addBeerResponse.StatusCode.message);
            Assert.AreEqual(resplistbeersBeforeadd.Beers.Count + 1, resplistbeersAfteradd.Beers.Count);

            ///retreive fields by id to check if same values



        }
    }
}