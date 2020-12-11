using System;
using System.IO;
using System.Linq;
using InfoTrack.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InfoTrack.CoreTests
{
    [TestClass]
    public class ResultsScraperTest
    {
        [TestMethod]
        [DeploymentItem(@"TestInputs\\input_2results.txt")]
        public void CanDetermineResultCount()
        {

            //arrange
            var input = File.ReadAllText("input_2results.txt");
            var sut = new ResultsScraper(input);
            //act
            var count = sut.GetResultsCount();
            Assert.AreEqual(135, count);

            
        }

        [TestMethod]
        [DeploymentItem(@"TestInputs\\input_2results.txt")]
        public void CanGetSearchResults()
        {

            //arrange
            var input = File.ReadAllText("input_2results.txt");
            var sut = new ResultsScraper(input);
            //act
            var searchResults = sut.GetSearchResults();

            //assert

            Assert.IsTrue(searchResults.Count == 2 && 
                searchResults.ToArray()[0] == "https://services.dps.ohio.gov/bmvonlineservices/search/title&amp;sa=U&amp;ved=2ahUKEwjLkeKe4sPtAhXxHjQIHcDvC_UQFjAAegQIARAB&amp;usg=AOvVaw3SAs6QWAvnQCDb7iIHhd3j" &&
                searchResults.ToArray()[1] == "https://www.propertyshark.com/info/property-title-search/&amp;sa=U&amp;ved=2ahUKEwjLkeKe4sPtAhXxHjQIHcDvC_UQFjAJegQIABAB&amp;usg=AOvVaw3c9T8ONX_VhdgvLZCZE5Ju");

            


        }

        [TestMethod]
        [DeploymentItem(@"TestInputs\\input_100results.txt")]
        public void CanGetSearchResults2()
        {

            //arrange
            var input = File.ReadAllText("input_100results.txt");
            var sut = new ResultsScraper(input);
            //act
            var searchResults = sut.GetSearchResults();

            File.WriteAllLines(".\\myoutput.txt", searchResults.ToArray());


            //assert

            Assert.IsTrue(searchResults.Count == 2 &&
                searchResults.ToArray()[0] == "https://services.dps.ohio.gov/bmvonlineservices/search/title&amp;sa=U&amp;ved=2ahUKEwjLkeKe4sPtAhXxHjQIHcDvC_UQFjAAegQIARAB&amp;usg=AOvVaw3SAs6QWAvnQCDb7iIHhd3j" &&
                searchResults.ToArray()[1] == "https://www.propertyshark.com/info/property-title-search/&amp;sa=U&amp;ved=2ahUKEwjLkeKe4sPtAhXxHjQIHcDvC_UQFjAJegQIABAB&amp;usg=AOvVaw3c9T8ONX_VhdgvLZCZE5Ju");




        }
    }
}
