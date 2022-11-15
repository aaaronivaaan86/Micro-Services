using PostalCodeService.Models;

namespace PostalCodeService.Respositories
{
    public interface IPostalCodeRepositories
    {
        public Task<List<PostalCode>> GetPostalCodes();
        public Task<PostalCode> AddPostalCode(PostalCode postalCode);

        public Task RemovePostalCode(string id);
    }
}
