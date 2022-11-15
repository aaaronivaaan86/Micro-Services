using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PostalCodeService.Configuration;
using PostalCodeService.Models;

namespace PostalCodeService.Respositories
{
    public class PostalCodeRepositories : IPostalCodeRepositories
    {
        private readonly IMongoCollection<PostalCode> _postalCodeCollection;
        private readonly PostalCodeStoreDatabase postalCodeStore;
        public PostalCodeRepositories(IOptions<PostalCodeStoreDatabase> options )
        {
            this.postalCodeStore = options.Value;
            var mongoClient = new MongoClient(this.postalCodeStore.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(this.postalCodeStore.DatabaseName);

            _postalCodeCollection = mongoDatabase.GetCollection<PostalCode>(this.postalCodeStore.PostalCodeCollection);
        }
        public async Task<PostalCode> AddPostalCode(PostalCode postalCode)
        {
            await _postalCodeCollection.InsertOneAsync(postalCode);
            return postalCode;
        }

        public async Task<List<PostalCode>> GetPostalCodes()
        {
            return await _postalCodeCollection.Find(_ => true).ToListAsync();
        }

        public async Task RemovePostalCode(string id)
        {
            await _postalCodeCollection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
