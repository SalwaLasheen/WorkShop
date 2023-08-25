using CommonComponent.Application.Mapper;

namespace Presentation.Service.Dtos.CheckProfileStatus
{
    public class ActionLogSqlDto : IMapFrom<ActionLogEntity>
    {
        public string Dial { get; set; }
        public string MethodName { get; set; }
        public string ChannelName { get; set; }
        public string AppVersion { get; set; }
        public string OsVersion { get; set; }
        public bool IsAndroid { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
    }
}
