using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfoTrack.Web.Models
{
    public class ResultsViewModel
    {
        public int Rank { get; set; }
        public string Url { get; set; }
        public bool Match { get; set; }
    }
}