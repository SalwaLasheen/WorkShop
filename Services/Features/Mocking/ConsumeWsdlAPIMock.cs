using AutoMapper;
using Services.Dtos.CheckProfileStatus.Request;
using Services.Dtos.CheckProfileStatus.Response;
using Services.Features.Interface;
using System.Net.Http.Headers;
using System.Text;

namespace Services.Features.Mocking
{
    public class ConsumeWsdlAPIMock : IConsumeAPI
    {
        public IMapper _mapper;
        public ConsumeWsdlAPIMock(IMapper mapper)
        {

            _mapper = mapper;
        }

        public async Task<CheckProfileStatusResponseDto> ConsumeWsdlAPIAsync(CheckProfileStatusRequestDto requestDto)
        {
            try
            {
                using var client = new HttpClient();
                //Passing wsdl api base url  
                PassingUrl(client);
                //requestMessage
                HttpRequestMessage request = PassingRequest(requestDto, client);
                //Response
                var response = await HandlResponseOfWsdlAPI(client, request);
                return response;
            }
            catch (Exception)
            {

                throw;
            }

        }
        private static HttpRequestMessage PassingRequest(CheckProfileStatusRequestDto requestDto, HttpClient client)
        {
            var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(requestDto), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage
            {
                RequestUri = client.BaseAddress,
                Method = HttpMethod.Post,
                Content = content
            };
            return request;
        }

        private static void PassingUrl(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7283/Wsdl/CallWsdlServiceAsync");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private static async Task<CheckProfileStatusResponseDto> HandlResponseOfWsdlAPI(HttpClient client, HttpRequestMessage request)
        {
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var ObjResponse = response.Content.ReadAsStringAsync().Result;
                var responseDto = Newtonsoft.Json.JsonConvert.DeserializeObject<CheckProfileStatusResponseDto>(ObjResponse);
                return responseDto;
            }
            throw new Exception(response.ReasonPhrase);
        }
    }
}
