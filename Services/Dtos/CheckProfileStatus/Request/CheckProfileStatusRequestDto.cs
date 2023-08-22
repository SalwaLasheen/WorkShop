using System.Text.Json.Serialization;

namespace Services.Dtos.CheckProfileStatus.Request
{
    public class CheckProfileStatusRequestDto
    {
        public string DialField { get; set; }

        public string SourceIdField { get; set; }
 
        public string LangIdField { get; set; }
   
        [JsonIgnore]
        public DateTime? RequestDate { get; set; } = DateTime.Now;
        [JsonIgnore]
        public int? CreatedBy { get; set; } = 10925;
    }
}
