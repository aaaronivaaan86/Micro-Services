namespace PostalCodeService.Configuration
{
    public class PostalCodeStoreDatabase
    {

        /// <summary>Gets or sets the connection string.</summary>
        /// <value>The connection string.</value>
        public string ConnectionString { get; set; }

        /// <summary>Gets or sets the name of the database.</summary>
        /// <value>The name of the database.</value>
        public string DatabaseName { get; set; }

        /// <summary>Gets or sets the name of the books collection.</summary>
        /// <value>The name of the books collection.</value>
        public string PostalCodeCollection { get; set; } 
    }
}
