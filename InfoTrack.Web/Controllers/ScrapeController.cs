using InfoTrack.Contracts;
using InfoTrack.Core;
using InfoTrack.Web.Models;
using System;
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

            var list = scraped
                .AsEnumerable()
                .Select((item, index) => new ResultViewModel()
                {
                    Rank = index + 1,
                    Url = item,
                    Match = item.Contains(url),
                    MatchClass = item.Contains(url) ? "success" : "primary"
                });
            var viewModel = new ResultsListViewModel()
            {
                Summary = list.Count(x => x.Match) == 0 ? "none" : string.Join(",", list.Where(x => x.Match).Select(x => x.Rank)),
                Results = list
            };
            return Json(viewModel, JsonRequestBehavior.AllowGet);
            
        }
        
    }
}
