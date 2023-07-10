using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PaymentApiService.Domain.Configuration;
using PaymentApiService.Domain.Interfaces.clients;
using PaymentApiService.Domain.OpenPayModels;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApiService.Infrastructure.Clients
{
    public class OpenPayCustomerClient : Domain.Interfaces.clients.IOpenPayCustomerClient
    {
        private readonly OpenPaySettings openPaySettings;
        private readonly string customersUrl;


        public OpenPayCustomerClient(IOptions<OpenPaySettings> openPaySettings)
        {
            this.openPaySettings = openPaySettings.Value;
            this.customersUrl = SetCustomersUrlApi();

        }

        public async Task<OpenPayCustomer> AddOpenPayCustomer(OpenPayCustomerRequest customer)
        {
            try
            {
                var options = new RestClientOptions(this.customersUrl)
                {
                    Authenticator = new HttpBasicAuthenticator(this.openPaySettings.PrivateKey, ""),
                };
                var client = new RestClient(options);
                var request = new RestRequest();
                // The cancellation token comes from the caller. You can still make a call without it.
                var response = await client.PostJsonAsync<OpenPayCustomerRequest, OpenPayCustomer>("", customer);
                return response;
            }
            catch (Exception ex)
            {

                throw new Exception($"Fail : {ex.Message}");
            }
        }

        public async Task<OpenPayCustomerRequest> GetOpenPayCustomer(string customerId)
        {
            try
            {
                string url = $"{this.customersUrl}/{customerId}";
                var options = new RestClientOptions(url)
                {
                    Authenticator = new HttpBasicAuthenticator(this.openPaySettings.PrivateKey, ""),
                };
                var client = new RestClient(options);
                var request = new RestRequest();
                // The cancellation token comes from the caller. You can still make a call without it.
                var customer = await client.GetJsonAsync<OpenPayCustomerRequest>("");
                RestResponse prof = await client.GetAsync(request);
                if (prof.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    var foo = JsonConvert.DeserializeObject<OpenPayError>(prof.Content);
                    throw new Exception();
                }

                //var customers = await client.GetAsync(request);

                return customer;
            }
            catch (Exception ex)
            {

                throw new Exception($"Fail : {ex.Message}");
            }
        }

        public async Task<List<OpenPayCustomer>> GetOpenPayCustomers()
        {
            try
            {
                var options = new RestClientOptions(this.customersUrl)
                {
                    Authenticator = new HttpBasicAuthenticator(this.openPaySettings.PrivateKey, ""),
                };
                var client = new RestClient(options);
                var request = new RestRequest();
                // The cancellation token comes from the caller. You can still make a call without it.
                var customers = await client.GetJsonAsync<List<OpenPayCustomer>>("");
                return customers;
            }
            catch (Exception ex)
            {

                throw new Exception($"Fail : {ex.Message}");
            }
        }


        public async Task<bool> DeleteOpenPayCustomer(string customerId)
        {
            try
            {
                string url = $"{this.customersUrl}/{customerId}";
                var options = new RestClientOptions(url)
                {
                    Authenticator = new HttpBasicAuthenticator(this.openPaySettings.PrivateKey, ""),
                };
                var client = new RestClient(options);
                var request = new RestRequest();
                // The cancellation token comes from the caller. You can still make a call without it.
                var deleteRequest = await client.DeleteAsync(request);

                if (deleteRequest.StatusCode != System.Net.HttpStatusCode.NoContent)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {

                throw new Exception($"Fail : {ex.Message}");
            }
        }


        private string SetCustomersUrlApi()
        {
            return $"{this.openPaySettings.OpenPayApiUrl}/{this.openPaySettings.OpenPayId}/customers";
        }
    }
}
