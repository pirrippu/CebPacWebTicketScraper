using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineScraper.Model
{
    public class SearchResultsModel
    {
        public string FlightNo { get; set; }
        public string Time { get; set; }
        public DateTime Date { get; set; }
        public string Price { get; set; }
        public string URL { get; set; }
    }
}
