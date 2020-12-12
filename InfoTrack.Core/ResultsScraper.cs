using System;
using System.Collections.Generic;
using System.Linq;


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

        private bool ParentElementIsSpan(int position)
        {
            int b = _input.LastIndexOf('<', position);
            var parentElementStart = _input.LastIndexOf('<', b - 1);

            var parentElement = _input.Substring(parentElementStart, 20);

            if (parentElementStart > 0 && parentElement.StartsWith("<span", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            
            
            return false;

            
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
                if(!captureTerm.Contains("google.com") &&
                    !ParentElementIsSpan(i))
                {
                    //remove portion of url after the ampersand, and verify that 
                    //we didn't just add this same url (this de-dupes youtube links)
                    string part = captureTerm.Substring(0, captureTerm.IndexOf("&amp"));
                    if(ret.Count == 0 || string.Compare(ret.Last(), part, true) != 0)
                    {
                        ret.Add(part);
                    }
                    
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
