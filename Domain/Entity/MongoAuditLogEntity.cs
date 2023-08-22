using Domain.Entity.Shared;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entity
{
    [BsonCollection("MongoAuditLog")]
    public class MongoAuditLogEntity 
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public ObjectId Id { get; set; }
        public string DialField { get; set; }
        public string Status { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime? RequestDate { get; set; }


    }

}
