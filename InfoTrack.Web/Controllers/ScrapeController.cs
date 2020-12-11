using InfoTrack.Core;
using System.Web.Mvc;

namespace InfoTrack.Web.Controllers
{
    public class ScrapeController : Controller
    {
        [HttpGet]
        public string GetSearchResults(string[] term, string url)
        {
            var searchResult = new ResultsFetcher(@"https://www.google.com.au/search?num=100&q=").Fetch(term);
            var scraper = new ResultsScraper(searchResult);
            var scraped = scraper.GetSearchResults();
            return string.Join(",", scraped);
            
        }
        
    }
}
