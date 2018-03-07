using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineTicketScraper.Models
{
    public class SearchResultModel
    {
        public string FlightNo { get; set; }
        public string Time { get; set; }
        public DateTime Date { get; set; }
        public string Price { get; set; }
        public string URL { get; set; }
    }
}