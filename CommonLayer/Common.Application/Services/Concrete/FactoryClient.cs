using Common.Service.Features.Interface;

namespace CommonComponent.Service.Features.Concrete
{
    public class FactoryClient : Handler, IFactoryClient
    {
        public IMapper _mapper;
        private readonly IHttpClientFactory _httpClientFactory;
        public FactoryClient(IMapper mapper, IHttpClientFactory httpClientFactory)
        {
            _mapper = mapper;
            _httpClientFactory = httpClientFactory;

        }

        public async Task<CheckProfileStatusResponseDto> ConsumeWsdlAPIAsync(CheckProfileStatusRequestDto requestDto)
        {
            try
            {

                var httpClient = _httpClientFactory.CreateClient("WsdlService");
                //requestMessage 
                var request = Handler.HTTPRequestMessage(requestDto, httpClient);
                var httpResponseMessage = await httpClient.SendAsync(request);
                //Response
                var response = Handler.HandlResponse(httpResponseMessage);
                return response;



            }
            catch (Exception ex)
            {
                throw new HttpRequestException(ex.InnerException.ToString());
            }

        }
    }
}
