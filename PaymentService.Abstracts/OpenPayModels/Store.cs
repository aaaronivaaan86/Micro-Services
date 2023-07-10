using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApiService.Domain.OpenPayModels
{
    public class Store
    {
        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("barcode_url")]
        public Uri BarcodeUrl { get; set; }
    }
}
