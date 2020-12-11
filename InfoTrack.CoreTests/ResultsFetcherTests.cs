using Microsoft.VisualStudio.TestTools.UnitTesting;
using InfoTrack.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTrack.Core.Tests
{
    [TestClass()]
    public class ResultsFetcherTests
    {
        public static int CountStringOccurrences(string text, string pattern)
        {
            // Loop through all instances of the string 'text'.
            int count = 0;
            int i = 0;
            while ((i = text.IndexOf(pattern, i)) != -1)
            {
                i += pattern.Length;
                count++;
            }
            return count;
        }
        [TestMethod()]
        public void FetchTest()
        {
            //arrange
            var sut = new ResultsFetcher(@"https://www.google.com.au/search?num=100&q=");
            //act
            var result = sut.Fetch(new List<string> { "online", "title", "search" });




        }
    }
}