using PostalCodeService.Models;
using PostalCodeService.Respositories;

namespace PostalCodeService.Services
{
    public class PostalCodeService : IPostalCodeService
    {
        private readonly IPostalCodeRepositories postalCodeRepositorie;

        public PostalCodeService(IPostalCodeRepositories postalCodeRepositorie)
        {
            this.postalCodeRepositorie = postalCodeRepositorie;
        }
        public Task<PostalCode> AddPostalCode(PostalCode postalCode)
        {
            return this.postalCodeRepositorie.AddPostalCode(postalCode);
        }

        public Task<List<PostalCode>> GetPostalCodes()
        {
            return this.postalCodeRepositorie.GetPostalCodes();
        }

        public async Task RemovePostalCode(string id)
        {
             await this.postalCodeRepositorie.RemovePostalCode(id);
        }
    }
}
