using System.Text.Json.Serialization;

namespace CommonComponent.Application.Dtos.Request
{
    public class CheckProfileStatusRequestDto
    {
        public string Dial { get; set; }

        public string SourceIdField { get; set; }

        public string LangIdField { get; set; }

        [JsonIgnore]
        public DateTime? CreatedDate { get; set; } = DateTime.Now;

    }
}
