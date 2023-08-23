using Application.Mapper;
using Domain.Entity;

namespace Services.Dtos.CheckProfileStatus
{
    public class ActionLogSqlDto : IMapFrom<ActionLogEntity>
    {
        public string AppVersion { get; set; }
        public string OsVersion { get; set; }
        public bool? IsAndroid { get; set; }
        //TODO: Add MethodName as field
        //TODO: to be removed as Dial already exists
        public int? CreatedBy { get; set; } = 10925;
        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        //TODO: LATER to add field ChannelName as String (using Enum within Workshop.Common)
    }

    public enum Channels
    {
        Portal,
        MyOrange,
        OrangeCash,
    }
}
