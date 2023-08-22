using Application.Common;
using Application.Repository.Interface;
using AutoMapper;
using Domain.Entity;
using Services.Dtos.CheckProfileStatus;
using Services.Dtos.CheckProfileStatus.Response;
using Services.Features.Interface;

namespace Services.Features.Concrete
{
    public class ServiceAudit : IServiceAudit
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
                ResponseLogXml = Converter.ToXML(responseDto)
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
