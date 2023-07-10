using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApiService.Domain.OpenPayModels
{
    public class OpenPayCustomer
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("last_name")]
        public object LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("store")]
        public Store Store { get; set; }

        [JsonProperty("clabe")]
        public string Clabe { get; set; }

        [JsonProperty("creation_date")]
        public DateTimeOffset CreationDate { get; set; }

        [JsonProperty("external_id")]
        public object ExternalId { get; set; }
    }
}
