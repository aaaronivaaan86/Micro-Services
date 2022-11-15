using PostalCodeService.Models;

namespace PostalCodeService.Services
{
    public interface IPostalCodeService
    {
        public Task<List<PostalCode>> GetPostalCodes();
        public Task<PostalCode> AddPostalCode(PostalCode postalCode);

        public Task RemovePostalCode(string id);
    }
}
