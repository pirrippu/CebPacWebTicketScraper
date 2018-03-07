using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ScraperService.DataContracts;
using ScraperService.ServiceContracts;
using AirlineScraper.Model;
using AirlineScraper.BusinessLogic;

namespace ScraperService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CebPacScraperServiceBasic" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CebPacScraperServiceBasic.svc or CebPacScraperServiceBasic.svc.cs at the Solution Explorer and start debugging.
    public class CebPacScraperServiceBasic : ICebPacScraperServiceBasic
    {
        public SearchResponse SearchRange(SearchRequest request)
        {
            SearchResponse response = new SearchResponse();
            string error = "";

            List<SearchResultsModel> searchResults = CebPacScraperBL.SearchOneWayFlightsRange(request.Origin, request.Destination, request.StartDate, request.EndDate, ref error);

            response.SearchResults = searchResults;
            response.Error = error;

            return response;
        }

        public SearchResponse SearchFlightSingleDate(SearchRequest request)
        {
            SearchResponse response = new SearchResponse();
            string error = "";

            List<SearchResultsModel> searchResults = CebPacScraperBL.SearchOneWayFlights(request.Origin, request.Destination, request.StartDate, ref error);

            response.SearchResults = searchResults;
            response.Error = error;

            return response;
        }
    }
}
