using InfoTrack.Core;
using System.Linq;
using System.Web.Mvc;

namespace InfoTrack.Web.Controllers
{
    public class ScrapeController : Controller
    {
        [HttpGet]
        public JsonResult GetSearchResults(string[] term, string url)
        {
            var searchResult = new ResultsFetcher(@"https://www.google.com.au/search?num=100&q=").Fetch(term);
            var scraper = new ResultsScraper(searchResult);
            var scraped = scraper.GetSearchResults();
            return Json(scraped
                .AsEnumerable()
                .Select((item, index) => new { position = index, result = item }), JsonRequestBehavior.AllowGet);
            
        }
        
    }
}
