using PostalCodeService.Models;

namespace PostalCodeService.Services
{
    public interface IImportExelService
    {
        public Task<List<PostalCode>> ImportCSVProccess(IFormFile file); 


    }
}
