using PostalCodeService.Models;

namespace PostalCodeService.Services
{
    public interface IPostalCodeService
    {
        public Task<List<PostalCode>> GetPostalCodes();
        public Task<PostalCode> AddPostalCode(PostalCode postalCode);

        public Task<List<PostalCode>> AddPostalCodes(List<PostalCode> postalCodes);

        public Task<List<PostalCode>> GetPostalCodeByZip(string zipCode);

        public Task RemovePostalCode(string id);
    }
}
