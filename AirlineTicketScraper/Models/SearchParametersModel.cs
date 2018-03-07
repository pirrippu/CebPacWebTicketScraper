using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineTicketScraper.Models
{
    public class SearchParametersModel
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<SearchResultModel> SearchResults { get; set; }
        public string Error { get; set; }
    }
}