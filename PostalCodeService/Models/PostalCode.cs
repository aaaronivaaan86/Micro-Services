using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace PostalCodeService.Models
{
    public class PostalCode
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Code { get; set; }
        public string Name_State { get; set; }

        public string Name_Municipality { get; set; }

        public string Name_City { get; set; }

        public string ZipCode { get; set; }

        public string Settlement { get; set; }
        public string SettlementType { get; set; }


        public bool IsActive { get; set; }
    }
}
