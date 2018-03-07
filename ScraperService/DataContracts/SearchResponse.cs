using AirlineScraper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ScraperService.DataContracts
{
    [DataContract]
    public class SearchResponse
    {
        [DataMember]
        public List<SearchResultsModel> SearchResults { get; set; }

        [DataMember]
        public string Error { get; set; }
    }
}