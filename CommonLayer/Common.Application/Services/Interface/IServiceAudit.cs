namespace CommonComponent.Service.Features.Interface
{
    public interface IServiceAudit<T> where T : class
    {
        void AddResponseLogSql(CheckProfileStatusResponseDto responseDto, string daial) { }
        void AddActionLog(T actionLogDto) { }
        void AddAuditLogMongo(CheckProfileStatusResponseDto response, CheckProfileStatusRequestDto requestDto) { }
    }
}
