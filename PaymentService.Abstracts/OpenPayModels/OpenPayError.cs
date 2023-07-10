using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApiService.Domain.OpenPayModels
{
    public class OpenPayError
    {
        [JsonProperty("http_code")]
        public int HttpCode { get; set; }

        [JsonProperty("error_code")]
        public int ErrorCode { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("request_id")]
        public string RequestId { get; set; }
    }
}
