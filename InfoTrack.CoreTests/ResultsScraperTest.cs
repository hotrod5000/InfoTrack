using System;
using System.IO;
using System.Linq;
using InfoTrack.Core;
using InfoTrack.Core.ResultsScapers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InfoTrack.CoreTests
{
    [TestClass]
    public class ResultsScraperTest
    {

        [TestMethod]
        [DeploymentItem(@"TestInputs\\input_2results.txt")]
        public void CanGetSearchResults_2Results()
        {

            //arrange
            var input = File.ReadAllText("input_2results.txt");
            var sut = new ResultsScraper(input);
            //act
            var searchResults = sut.GetSearchResults();

            //assert

            Assert.IsTrue(searchResults.Count == 2 && 
                searchResults.ToArray()[0] == "https://services.dps.ohio.gov/bmvonlineservices/search/title" &&
                searchResults.ToArray()[1] == "https://www.propertyshark.com/info/property-title-search/");

            


        }

        [TestMethod]
        [DeploymentItem(@"TestInputs\\input_100results.txt")]
        public void CanGetSearchResults_100Results()
        {

            //arrange
            var input = File.ReadAllText("input_100results.txt");
            var sut = new ResultsScraper(input);
            //act
            var searchResults = sut.GetSearchResults();

            //assert

            Assert.IsTrue(searchResults.Count == 100);




        }

    }
}
