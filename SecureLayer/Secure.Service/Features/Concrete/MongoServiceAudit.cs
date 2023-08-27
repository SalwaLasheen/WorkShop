namespace Secure.Service.Features.Concrete
{
    public class MongoServiceAudit : IServiceAudit<MongoAuditLogDto>
    {
        private readonly IMapper _mapper;
        private readonly IMongoRepository<MongoAuditLogEntity> _repositryLogMongo;
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
            var channelName = Enum.GetName(typeof(Channels), Channels.OrangeCash).ToString();
            var methodName = Enum.GetName(typeof(Methods), Methods.CheckDataProfileStatus).ToString();
            string request = Converter.ToXML(requestDto);
            string serviceResponse = Converter.ToXML(response);
            var auditMongoDto = MapRequestAndResponseToAuditLogMongo(channelName, methodName, request, serviceResponse);
            AddAuditLogMongo(auditMongoDto);
        }
        private static MongoAuditLogDto MapRequestAndResponseToAuditLogMongo(string channelName, string methodName, string request, string response)
        {
            return new MongoAuditLogDto()
            {
                ChannelName = channelName,
                MethodName = methodName,
                CreatedDate = DateTime.Now,
                Request = request,
                Response = response,
                ResponseTime = DateTime.Now.ToString("ss.fff"),
            };
        }

    }
}
