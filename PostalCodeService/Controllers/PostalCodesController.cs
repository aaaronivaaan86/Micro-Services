using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostalCodeService.Models;
using PostalCodeService.Services;

namespace PostalCodeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostalCodesController : ControllerBase
    {
        private readonly IPostalCodeService postalCodeService;
        private readonly IImportExelService importExelService;

        public PostalCodesController(IPostalCodeService postalCodeService, IImportExelService importExelService )
        {
            this.postalCodeService = postalCodeService;
            this.importExelService = importExelService;
        }

        [HttpGet]
        public async Task<ActionResult> GetPostalCodeInfo()
        {
            var postalcodeList = await this.postalCodeService.GetPostalCodes();
            return Ok(postalcodeList);
        }


        [HttpGet("GetFakePostalCode")]
        public ActionResult<PostalCode> GetFakePostalCode()
        {
            return Ok(new PostalCode()
            {
                Id = "1",
                Name_State = "Campeche",
                IsActive = true,
            });
        }


        [HttpGet("GetPostalCodeByZipCode/{zipCode}")]
        public async Task<ActionResult> GetPostalCodeByZipCode([FromRoute] string zipCode)
        {
            if (string.IsNullOrEmpty(zipCode))
            {
                return BadRequest();
            }

            List<PostalCode> postalCodes = await this.postalCodeService.GetPostalCodeByZip(zipCode);

            if(postalCodes == null)
            {
                return NotFound();  
            }

            return Ok(postalCodes);
        }

        [HttpPost("AddPostalCode")]
        public async Task<ActionResult<PostalCode>> AddPostalCode(PostalCode postalCode)
        {
            var result = await this.postalCodeService.AddPostalCode(postalCode);  
            return Ok(result);  
        }

        [HttpPost("ImportCSV")]
        [DisableRequestSizeLimit]
        [RequestFormLimits(ValueLengthLimit = int.MaxValue, MultipartBodyLengthLimit = int.MaxValue)]

        public async Task<ActionResult> ImportCSV([FromForm] FileUploadModel file)
        {
            if (file == null)
            {
                return BadRequest();
            }

            Console.WriteLine($"file name {file.FileDetails.FileName}");
            Console.WriteLine($"file name {file.FileDetails.Length}");

            List<PostalCode>  postalCodes = await this.importExelService.ImportCSVProccess(file.FileDetails);

            if (postalCodes.Count()==0) {
                return Conflict($"Not content found in {file.FileDetails.FileName}");  
            }
            await this.postalCodeService.AddPostalCodes(postalCodes);  
            return Ok(new {success=true, message ="File import success", postalcodes = postalCodes });    
        }
    }
}
