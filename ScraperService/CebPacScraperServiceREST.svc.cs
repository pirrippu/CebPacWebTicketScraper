using AirlineScraper.BusinessLogic;
using AirlineScraper.Model;
using ScraperService.DataContracts;
using ScraperService.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ScraperService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CebPacScraperServiceREST" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CebPacScraperServiceREST.svc or CebPacScraperServiceREST.svc.cs at the Solution Explorer and start debugging.
    public class CebPacScraperServiceREST : ICebPacScraperServiceREST
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

        ////public SearchResponse SearchRangeREST(string origin, string destination, string startDate, string endDate)
        //public SearchResponse SearchRangeREST(SearchRequest request)
        //{
        //    SearchResponse response = new SearchResponse();
        //    string error = "";

        //    //List<SearchResultsModel> searchResults = CebPacScraperBL.SearchOneWayFlightsRange(origin, destination, startDate, endDate, ref error);
        //    List<SearchResultsModel> searchResults = CebPacScraperBL.SearchOneWayFlightsRange(request.Origin, request.Destination, request.StartDate, request.EndDate, ref error);

        //    response.SearchResults = searchResults;
        //    response.Error = error;

        //    return response;
        //}
    }
}
