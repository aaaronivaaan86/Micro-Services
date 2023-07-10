using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApiService.Domain.Configuration
{
    public class OpenPaySettings
    {
        /// <summary>Gets or sets the open pay identifier.</summary>
        /// <value>The open pay identifier.</value>
        public string OpenPayId { get; set; }

        /// <summary>Gets or sets the public key.</summary>
        /// <value>The public key.</value>
        public string PublicKey { get; set; }

        /// <summary>Gets or sets the private key.</summary>
        /// <value>The private key.</value>
        public string PrivateKey { get; set; }

        /// <summary>Gets or sets the open pay API URL.</summary>
        /// <value>The open pay API URL.</value>
        public string OpenPayApiUrl { get; set; }
    }
}
