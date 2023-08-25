namespace Secure.Domain.Entity
{
    [BsonCollection("MongoAuditLog")]
    public class MongoAuditLogEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public ObjectId Id { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime? CreatedDate { get; set; }
        public string ResponseTime { get; set; }
    }

}
