using AirlineScraper.Model;
using ExcelLibrary.SpreadSheet;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace AirlineScraper.BusinessLogic
{
    //Copyright ©<year> <Company Name>
    //--------------------------------------------------
    //Author: <Full Name>
    //Date Created:
    //Description:
    //Revision History:
    //DATE		BY			Description
    //<Date>	<firstname.lastname>	<description of changes made>
    public class CebPacScraperBL
    {
        public static async Task AwaitTimer()
        {
            await Task.Delay(10000);
        }

        public static List<SearchResultsModel> SearchOneWayFlightsRange(string origin, string destination, string date1, string date2, ref string error)
        {
            List<SearchResultsModel> searchResults = new List<SearchResultsModel>();
            try
            {
                DateTime startDate = date1.ToDate();
                DateTime endDate = date2.ToDate();
                while (startDate <= endDate)
                {
                    System.Diagnostics.Debug.WriteLine("Data Date = " + startDate);
                    searchResults.AddRange(SearchOneWayFlights("mnl", destination, startDate.ToString("yyyy-MM-dd"), ref error));
                    startDate = startDate.AddDays(1);
                    //Thread.Sleep(2000);
                }
            }
            catch (Exception ex)
            {
                error = ex.ToString();
            }

            return searchResults;
        }

        public static async Task<List<SearchResultsModel>> SearchOneWayFlightsAsync(string origin, string destination, string date, string error)
        {
            List<SearchResultsModel> searchResults = new List<SearchResultsModel>();

            searchResults = SearchOneWayFlights(origin, destination, date, ref error);

            return searchResults;
        }

        public static List<SearchResultsModel> SearchOneWayFlights(string origin, string destination, string date, ref string error)
        {
            List<SearchResultsModel> searchResults = new List<SearchResultsModel>();
            ScrapingBrowser browser = new ScrapingBrowser();

            StringBuilder uri = new StringBuilder();
            uri.Append("https://beta.cebupacificair.com/Flight/InternalSelect?");
            uri.Append("o1=").Append(origin);
            uri.Append("&d1=").Append(destination);
            uri.Append("&o2=&d2=");
            uri.Append("&dd1=").Append(date);
            //uri.Append("&ADT=1&CHD=0&INF=0&s=true");

            try
            {
                WebPage resultPage = browser.NavigateToPage(new Uri(uri.ToString()));

                IEnumerable<HtmlNode> nodes = resultPage.Html.CssSelect("table#depart-table tbody tr");

                int counter = 0;
                foreach (HtmlNode node in nodes)
                {
                    if (counter == nodes.Count() - 1)
                    {
                        break;
                    }

                    //GET FLIGHTS
                    IEnumerable<HtmlNode> flightNoCol = node.CssSelect("th div span");
                    string flightNo = "";
                    foreach (var flights in flightNoCol)
                    {
                        flightNo += flights.InnerText.ToString().Trim();
                    }

                    //GET TIME
                    IEnumerable<HtmlNode> timeCol = (node.CssSelect("td").ToArray())[0].CssSelect("div div");
                    string time = "";
                    foreach (var val in timeCol)
                    {
                        time += Regex.Replace(val.FirstChild.InnerText.ToString(), @"\s+", "");
                        //time += val.InnerText.ToString().Trim();
                    }

                    //GET PRICE
                    string price = (node.CssSelect("td").ToArray())[4].CssSelect("div label").First().InnerText.ToString().Trim();

                    searchResults.Add(new SearchResultsModel()
                    {
                        FlightNo = flightNo,
                        Time = time,
                        Date = date.ToDate(),
                        Price = price,
                        URL = uri.ToString()
                    });

                    counter++;
                }
            }
            catch (Exception ex)
            {
                error = ex.ToString();
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }

            return searchResults;
        }

    }
}