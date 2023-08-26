using System.Text.Json.Serialization;

namespace CommonComponent.Application.Dtos.Request
{
    public class CheckProfileStatusRequestDto
    {
        public string Dial { get; set; }

        public string SourceId { get; set; }

        public string LangId { get; set; }

        [JsonIgnore]
        public DateTime? CreatedDate { get; set; } = DateTime.Now;

    }
}
