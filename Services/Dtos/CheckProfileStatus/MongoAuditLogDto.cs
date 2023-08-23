using Application.Mapper;
using Domain.Entity;

namespace Services.Dtos.CheckProfileStatus
{
    public class MongoAuditLogDto : IMapFrom<MongoAuditLogEntity>
    {
        public string Id { get; set; }
        //TODO: Rename to Dial
        public string DialField { get; set; }
        public string Status { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime? RequestDate { get; set; }
        public DateTime? ResponseDate { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        //TODO: ResponsTime field to be added
        //TODO: LATER to add field ChannelName
    }
}
