namespace Secure.Service.Features.Concrete
{
    public class WsdlServiceHelper : IWsdlServiceHelper
    {
        public readonly IWsdlClient _client;
      //  public readonly IServiceAudit<MongoAuditLogEntity> _ServiceAudit;
        public IMapper _mapper;
        public IConfiguration _configuration;
        public WsdlServiceHelper(IMapper mapper, IWsdlClient client, IConfiguration configuration)
        {
            _mapper = mapper;
            //_ServiceAudit = serviceAudit;
            _client = client;
            _configuration = configuration;
     
        }

        public async Task<CheckProfileStatusResponseDto> GetWsdlClientResponseAsync(CheckProfileStatusRequestDto requestDto)
        {
            try
            {
                var response = new CheckProfileStatusResponseDto(); 
               var isTestingFlage = _configuration.GetSection("IsTestingEnvironment").Value;
                bool isTetingEnv = isTestingFlage.ToLower() == "true";
              
                if (isTetingEnv)
                {
                     response = await GetMockWsdlResponse(requestDto);
                    if (response is null)
                    {
                        response= await GetWsdlResponse(requestDto);
                      //  _ServiceAudit.AddAuditLogMongo(response, requestDto);
                        return response;
                    }
                   // _ServiceAudit.AddAuditLogMongo(response, requestDto);
                    return response;
                }
                else
                {
                    response = await GetWsdlResponse(requestDto);
                  //  _ServiceAudit.AddAuditLogMongo(response, requestDto);
                    return response;
                }


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        private async Task<CheckProfileStatusResponseDto> GetWsdlResponse(CheckProfileStatusRequestDto requestDto)
        {
            Adapter adapter = new(_mapper);
            var statusInRequest = adapter.AdapterRequest(requestDto);
            var statusOutResponse = await _client.CallWSDLAsync(statusInRequest);
            var response = adapter.AdapterResponse(statusOutResponse);
            return response;
        }

        private async Task<CheckProfileStatusResponseDto> GetMockWsdlResponse(CheckProfileStatusRequestDto requestDto)
        {
            var response = await _client.CallWSDLMock(requestDto);
            return response;
        }
    }
}
