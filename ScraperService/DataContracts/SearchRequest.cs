using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ScraperService.DataContracts
{
    [DataContract]
    public class SearchRequest
    {
        [DataMember]
        public string Origin { get; set; }

        [DataMember]
        public string Destination { get; set; }

        [DataMember]
        public string StartDate { get; set; }

        [DataMember]
        public string EndDate { get; set; }
    }
}