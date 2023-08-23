using AutoMapper;
using Services.Dtos.CheckProfileStatus.Request;
using Services.Dtos.CheckProfileStatus.Response;
using Services.Features.Interface;
using System.Text;
using System.Text.Json;

namespace Services.Features.Concrete
{
    //TODO: add separate API project for Secure Solution (to be added)
    //Business layer of WSDL [Ex: GetProfileStatusManager]
    public class ConsumeAPI : IConsumeAPI
    {
        public IMapper _mapper;
        private readonly IHttpClientFactory _httpClientFactory;
        public ConsumeAPI(IMapper mapper, IHttpClientFactory httpClientFactory)
        {
            _mapper = mapper;
            _httpClientFactory = httpClientFactory;
        }

        //GetDataProfileStatus
        public async Task<CheckProfileStatusResponseDto> ConsumeWsdlAPIAsync(CheckProfileStatusRequestDto requestDto)
        {
            try
            {
                //TODO: add Inilization of Mongo Log

                //TODO: adding Front or secure Urls within config files appSettings.JSON

                //TODO: add in Workshop.Common ServicesUtilities manager
                var httpClient = _httpClientFactory.CreateClient("WsdlService");
                //requestMessage 
                var request = HTTPRequestMessage(requestDto, httpClient);
                var httpResponseMessage = await httpClient.SendAsync(request);
                //TODO: add IsTestingEnvironment flag using appSettings.json
                /*
                 if(IsTestingEnvironment){
                    //get respones via mocking of WorkShopResponseDataAccess manager
                    if(mocking response == null)
                        //call the WSDL service using WSDL factory
                }
                //call the WSDL service using WSDL factory
                 */
                //Response
                //TODO: add in separate DAL DLL manager for Response [Ex: WorkShopResponseDataAccess]
                var response = HandlRespons(httpResponseMessage);
                return response;
            }
            catch (Exception ex)
            {
                throw new HttpRequestException(ex.InnerException.ToString());
            }

        }
        private static HttpRequestMessage HTTPRequestMessage(CheckProfileStatusRequestDto requestDto, HttpClient client)
        {
            var content = new StringContent(JsonSerializer.Serialize(requestDto), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage
            {
                RequestUri = client.BaseAddress,
                Method = HttpMethod.Post,
                Content = content
            };
            return request;
        }

        //TODO: check method naming "HandlRespons" to be "HandlResponse"
        private static CheckProfileStatusResponseDto HandlRespons(HttpResponseMessage response)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                if (response.IsSuccessStatusCode)
                {
                    var ObjResponse = response.Content.ReadAsStringAsync().Result;
                    var responseDto = JsonSerializer.Deserialize<CheckProfileStatusResponseDto>(ObjResponse, options);
                    return responseDto;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }
    }
}
