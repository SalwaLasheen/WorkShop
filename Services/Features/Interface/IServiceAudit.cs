using Services.Dtos.CheckProfileStatus;
using Services.Dtos.CheckProfileStatus.Request;
using Services.Dtos.CheckProfileStatus.Response;

namespace Services.Features.Interface
{
    public interface IServiceAudit
    {
        void AddResponseLogSql(CheckProfileStatusResponseDto responseDto, string daial) { }
        void AddActionLog(ActionLogSqlDto actionLogDto) { }
        void AddAuditLogMongo(CheckProfileStatusResponseDto response, CheckProfileStatusRequestDto requestDto) { }


    }
}
