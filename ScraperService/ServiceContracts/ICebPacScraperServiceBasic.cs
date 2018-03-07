using ScraperService.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ScraperService.ServiceContracts
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICebPacScraperService" in both code and config file together.
    [ServiceContract]
    public interface ICebPacScraperServiceBasic
    {
        [OperationContract]
        SearchResponse SearchRange(SearchRequest request);

        [OperationContract]
        SearchResponse SearchFlightSingleDate(SearchRequest request);

        //[OperationContract]
        //[WebInvoke(Method = "POST",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    UriTemplate = "CebPacScraper/")]
        //SearchResponse SearchRangeREST(SearchRequest request);
    }
}
