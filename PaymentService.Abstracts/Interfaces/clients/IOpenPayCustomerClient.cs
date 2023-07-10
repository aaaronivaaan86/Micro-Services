
using PaymentApiService.Domain.OpenPayModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApiService.Domain.Interfaces.clients
{
    public interface IOpenPayCustomerClient
    {
        public Task<List<OpenPayCustomer>> GetOpenPayCustomers();
        public Task<OpenPayCustomerRequest> GetOpenPayCustomer(string customerId);
        public Task<OpenPayCustomer> AddOpenPayCustomer(OpenPayCustomerRequest customer);
        public Task<bool> DeleteOpenPayCustomer(string customerId);
    }
}
