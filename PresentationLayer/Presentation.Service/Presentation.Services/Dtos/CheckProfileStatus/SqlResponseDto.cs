using CommonComponent.Application.Mapper;

namespace Presentation.Services.Dtos.CheckProfileStatus
{
    public class SqlResponseDto : IMapFrom<SqlResponseEntity>
    {
        public string Dial { get; set; }
        public string MethodName { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime? CreatedDate { get; set; }

    }
}
