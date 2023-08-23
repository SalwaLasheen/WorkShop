using Application.Common;
using Application.Repository.Interface;
using AutoMapper;
using Domain.Entity;
using Services.Dtos.CheckProfileStatus;
using Services.Dtos.CheckProfileStatus.Request;
using Services.Dtos.CheckProfileStatus.Response;
using Services.Features.Interface;

namespace Services.Features.Concrete
{
    //TODO: to be moved to Workshop.Common as Utility class
    public class MongoServiceAudit : IServiceAudit
    {
        private readonly IMapper _mapper;
        public readonly IMongoRepository<MongoAuditLogEntity> _repositryLogMongo;
        public MongoServiceAudit(IMapper mapper, IMongoRepository<MongoAuditLogEntity> repositryLogMongo)
        {
            _mapper = mapper;
            _repositryLogMongo = repositryLogMongo;
        }

        public void AddAuditLogMongo(MongoAuditLogDto auditLogDto)
        {
            var actionLogMongoEntity = _mapper.Map<MongoAuditLogDto, MongoAuditLogEntity>(auditLogDto);
            _repositryLogMongo.InsertLogAsync(actionLogMongoEntity);
        }
        public void AddAuditLogMongo(CheckProfileStatusResponseDto response, CheckProfileStatusRequestDto requestDto)
        {
            string message = response.ErrorDoc?.ErrorMessage;
            string code = response.ErrorDoc?.ErrorCode;
            string status = response.ErrorDoc?.Status;
            string request = Converter.ToXML(requestDto);
            string serviceResponse = Converter.ToXML(response);
            var auditMongoDto = MapRequestAndResponseToAuditLogMongo(requestDto.DialField, message, code, status, request, serviceResponse, requestDto.RequestDate);
            AddAuditLogMongo(auditMongoDto);
        }
        private static MongoAuditLogDto MapRequestAndResponseToAuditLogMongo(string dial, string errorMessage, string errorCode, string status,
          string request, string response, DateTime? requestDate)
        {
            return new MongoAuditLogDto()
            {
                DialField = dial,
                ErrorMessage = errorMessage,
                ErrorCode = errorCode,
                Status = status,
                Request = request,
                Response = response,
                RequestDate = requestDate,
            };
        }

    }
}
