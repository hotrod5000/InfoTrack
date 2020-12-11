using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InfoTrack.Core
{
    public class ResultsScraper
    {
        string _input;

        string _key = "a href=\"/url?q=";

        public ResultsScraper(string input)
        {
            _input = input;
        }


        public List<string> GetSearchResults()
        {
            var ret = new List<string>();
            int count = 0;
            int i = 0;
            while ((i = _input.IndexOf(_key, i)) != -1)
            {
                i += _key.Length;
                var closeQuote = _input.IndexOf("\"", i+1);
                var captureTerm = _input.Substring(i, closeQuote - i);
                if(!captureTerm.Contains("google.com"))
                {
                    ret.Add(captureTerm);
                }
                
                count++;
            }

            return ret;
        }

        public int GetResultsCount()
        {
            var key = "a href=\"/url?q=";

            return CountStringOccurrences(key);

            //var regex = new Regex(@"<a\b[^>]*>(.*?)</a>");

            //return regex.Matches(_input).Count;


        }

        public int CountStringOccurrences(string pattern)
        {
            // Loop through all instances of the string 'text'.
            int count = 0;
            int i = 0;
            while ((i = _input.IndexOf(pattern, i)) != -1)
            {
                i += pattern.Length;
                count++;
            }
            return count;
        }


    }
}
