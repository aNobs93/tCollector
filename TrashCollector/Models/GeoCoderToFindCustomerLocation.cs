using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class GeoCoderToFindCustomerLocation
    {
        public string address { get; set; }
        public double longit { get; set; }
        public double latit { get; set; }

        public string mapAPICall = "https://maps.googleapis.com/maps/api/js?key=" + PrivateKeys.key1 + "&callback=initMap";
    }
}