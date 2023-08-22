using Application.Mapper;
using Domain.Entity;

namespace Services.Dtos.CheckProfileStatus.Response
{
    public class SqlResponseDto : IMapFrom<SqlResponseEntity>
    {
        public string Dial { get; set; }

        public string MethodName { get; set; }

        public string ResponseLogXml { get; set; }
        public int? CreatedBy { get; set; } = 10925;
        public DateTime? CreatedDate { get; set; } = DateTime.Now;

    }
}
