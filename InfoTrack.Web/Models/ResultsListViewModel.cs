using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfoTrack.Web.Models
{
    public class ResultsListViewModel
    {
        public string Summary { get; set; }
        public IEnumerable<ResultViewModel> Results { get; set; }
    }
}