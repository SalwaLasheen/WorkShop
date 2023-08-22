using Application.Mapper;
using Domain.Entity;

namespace Services.Dtos.CheckProfileStatus
{
    public class ActionLogSqlDto : IMapFrom<ActionLogEntity>
    {
        public string AppVersion { get; set; }
        public string OsVersion { get; set; }
        public bool? IsAndroid { get; set; }
        public int? CreatedBy { get; set; } = 10925;
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
    }
}
