using InfoTrack.Contracts;
using InfoTrack.Core;
using InfoTrack.Web.Models;
using System.Linq;
using System.Web.Mvc;

namespace InfoTrack.Web.Controllers
{
    public class ScrapeController : Controller
    {
        IResultsFetcher _resultsFetcher;
        public ScrapeController(IResultsFetcher resultsFetcher)
        {
            _resultsFetcher = resultsFetcher;
        }
        [HttpGet]
        public JsonResult GetSearchResults(string[] term, string url)
        {
            var searchResult = _resultsFetcher.Fetch(term);
            var scraper = new ResultsScraper(searchResult);
            var scraped = scraper.GetSearchResults();
            return Json(scraped
                .AsEnumerable()
                .Select((item, index) => new ResultsViewModel() 
                                            {
                                                Rank = index,
                                                Url = item,
                                                Match = index % 2 == 0}), JsonRequestBehavior.AllowGet);
            
        }
        
    }
}
