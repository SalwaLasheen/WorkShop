using CommonComponent.Application.Enums;
using System.Text.Json.Serialization;

namespace CommonComponent.Application.Dtos.Request
{
    public class CheckProfileStatusRequestDto
    {
        public string Dial { get; set; }

        public Channels Channel { get; set; }

        public Languages Language { get; set; }

        [JsonIgnore]
        public DateTime? CreatedDate { get; set; } = DateTime.Now;

    }
}
