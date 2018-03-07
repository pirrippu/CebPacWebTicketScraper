using AirlineTicketScraper.Models;
using AirlineTicketScraper.CebPacScraperService_1;
//using AirlineTicketScraper.CebPacScraperServiceSoln;
using AirlineScraper.BusinessLogic;
using AirlineScraper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirlineTicketScraper.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            SearchParametersModel model = new SearchParametersModel()
            {
                Origin = "MNL"
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult SearchFlights(SearchParametersModel model)
        {
            if (ModelState.IsValid)
            {
                CebPacScraperServiceBasicClient service = new CebPacScraperServiceBasicClient();
                SearchRequest request = new SearchRequest()
                {
                    Origin = model.Origin,
                    Destination = model.Destination,
                    EndDate = model.EndDate.ToString("MM/dd/yyyy"),
                    StartDate = model.StartDate.ToString("MM/dd/yyyy")
                };

                SearchResponse response = new SearchResponse();
                model.SearchResults = new List<SearchResultModel>();

                try
                {
                    response = service.SearchRange(request);
                }
                catch (Exception ex)
                {
                    model.Error = ex.ToString();
                }

                if (string.IsNullOrEmpty(response.Error))
                {
                    foreach (var result in response.SearchResults)
                    {
                        model.SearchResults.Add(new SearchResultModel()
                        {
                            Date = result.Date,
                            FlightNo = result.FlightNo,
                            Price = result.Price,
                            Time = result.Time,
                            URL = result.URL
                        });
                    }
                }
            }

            return View("Index", model);
        }
    }
}