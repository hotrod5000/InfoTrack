using InfoTrack.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InfoTrack.Core.ResultsFetchers
{
    public class ResultsFetcher : IResultsFetcher
    {
        string _baseUrl;
        public ResultsFetcher(string baseUrl)
        {
            _baseUrl = baseUrl;
        }
        public string Fetch(IEnumerable<string> searchTerms)
        {
            var web = new WebClient();
            var url = _baseUrl + string.Join("+", searchTerms);
            return web.DownloadString(url);
        }
    }
}

        