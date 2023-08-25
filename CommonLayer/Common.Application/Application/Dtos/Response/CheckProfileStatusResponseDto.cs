using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CommonComponent.Application.Dtos.Response
{
    public class CheckProfileStatusResponseDto
    {
        public BucketInfoDto[] BucketInfo { get; set; }
        public ErrorDocDto ErrorDoc { get; set; }
        [NotMapped]
        [JsonIgnore]
        public string ResponseTime { get; set; } = DateTime.Now.TimeOfDay.ToString();
    }
    public class BucketInfoDto
    {
        public string CurrentBucketId { get; set; }
        public string CurrentBucketName { get; set; }
        public string IsRnR { get; set; }
        public string RnRText { get; set; }
        public OptionsListDto[] OptionsList { get; set; }

    }
    public class ErrorDocDto
    {
        public string Status { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
    public class OptionsListDto
    {
        public string OptionId { get; set; }
        public string OptionName { get; set; }
    }
}
