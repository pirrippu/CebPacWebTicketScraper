using System;
using System.Collections.Generic;
using AirlineScraper.BusinessLogic;
using AirlineScraper.Model;
using ScrapySharp.Network;
using System.Threading.Tasks;

namespace ScraperTester
{
    class Program
    {
        static List<SearchResultsModel> searchResults = new List<SearchResultsModel>();

        static void Main(string[] args)
        {
            ScrapingBrowser browser = new ScrapingBrowser();

            string destination = Console.ReadLine();
            //DateTime date1 = (Console.ReadLine()).ToDate();
            //DateTime date2 = (Console.ReadLine()).ToDate();

            DateTime date1 = Convert.ToDateTime(Console.ReadLine()).Date;
            DateTime date2 = Convert.ToDateTime(Console.ReadLine()).Date;

            string error = "";

            for (DateTime dt = date1; dt <= date2;)
            {
                searchResults = new List<SearchResultsModel>();
                string date = dt.ToString("MM/dd/yyyy");
                GetOneWayFlights("mnl", destination, date, error).Wait();

                foreach (var result in searchResults)
                {
                    Console.WriteLine(result.FlightNo + "\t" + result.Time + "\t" + result.Price + "\t" + result.Date.ToShortDateString());
                }
                dt = dt.AddDays(1);
            }
            Console.ReadLine();
        }

        static async Task GetOneWayFlights(string origin, string destination, string date, string error)
        {
            searchResults = await CebPacScraperBL.SearchOneWayFlightsAsync(origin, destination, date, error);
        }
    }
}
