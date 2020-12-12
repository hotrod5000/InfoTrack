using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTrack.Contracts
{
    public interface IResultsFetcher
    {
        string Fetch(IEnumerable<string> searchTerms);
    }
}
