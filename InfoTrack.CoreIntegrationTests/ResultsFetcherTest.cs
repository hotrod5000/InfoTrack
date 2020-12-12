using Microsoft.VisualStudio.TestTools.UnitTesting;
using InfoTrack.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoTrack.Core.ResultsFetchers;

namespace InfoTrack.Core.IntegrationTests
{
    [TestClass()]
    public class ResultsFetcherTest
    {
        [TestMethod()]
        public void FetchTest()
        {
            //arrange
            var sut = new ResultsFetcher(@"https://www.google.com.au/search?num=100&q=");
            //act
            var result = sut.Fetch(new List<string> { "online", "title", "search" });

            //assert
            Assert.IsTrue(result.StartsWith("<!doctype html>"));

        }


    }
}