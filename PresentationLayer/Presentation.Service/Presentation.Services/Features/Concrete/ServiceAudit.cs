namespace Presentation.Service.Features.Concrete
{
    public class ServiceAudit : IServiceAudit<ActionLogSqlDto>
    {
        private readonly IMapper _mapper;
        private readonly ISqlRepository<SqlResponseEntity> _repositryResponseSql;
        private readonly ISqlRepository<ActionLogEntity> _repositryLogSql;
        public ServiceAudit(IMapper mapper, ISqlRepository<SqlResponseEntity> repositryResponseSql, ISqlRepository<ActionLogEntity> repositryLogSql)
        {
            _mapper = mapper;
            _repositryLogSql = repositryLogSql;
            _repositryResponseSql = repositryResponseSql;
        }
        public void AddResponseLogSql(CheckProfileStatusResponseDto responseDto, string daial)
        {
            var sqlResponseDto = new SqlResponseDto()
            {
                Dial = daial,
                MethodName = "Check Data Profile Status",
                CreatedDate = DateTime.Now,
                ErrorCode = responseDto.ErrorDoc.ErrorCode,
                ErrorMessage = responseDto.ErrorDoc.ErrorMessage

            };
            var entity = _mapper.Map<SqlResponseDto, SqlResponseEntity>(sqlResponseDto);
            _repositryResponseSql.AddEntitylog(entity);
        }
        public void AddActionLog(ActionLogSqlDto actionLogDto)
        {
            var actionLog = _mapper.Map<ActionLogSqlDto, ActionLogEntity>(actionLogDto);
            _repositryLogSql.AddEntitylog(actionLog);
        }
    }
}
