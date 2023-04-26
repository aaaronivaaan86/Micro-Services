using Microsoft.VisualBasic.FileIO;

namespace PostalCodeService.Models
{
    public class FileUploadModel
    {
        public IFormFile FileDetails { get; set; }
        public FieldType FileType { get; set; }
    }
}
