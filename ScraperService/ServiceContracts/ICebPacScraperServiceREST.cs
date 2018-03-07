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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICebPacScraperServiceREST" in both code and config file together.
    [ServiceContract]
    public interface ICebPacScraperServiceREST
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "CebPacScraper/SearchDateRange")]
        SearchResponse SearchRange(SearchRequest request);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "CebPacScraper/SearchDateSingle")]
        SearchResponse SearchFlightSingleDate(SearchRequest request);
    }
}