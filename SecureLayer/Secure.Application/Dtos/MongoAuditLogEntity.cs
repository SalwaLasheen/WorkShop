namespace Secure.Application.Dtos
{
    public class MongoAuditLogDto
    {
        public string ChannelName { get; set; }
        public string MethodName { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public string ResponseTime { get; set; } = DateTime.Now.TimeOfDay.ToString();
    }
}
