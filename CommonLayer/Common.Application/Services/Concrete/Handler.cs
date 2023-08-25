using System.Text;
using System.Text.Json;

namespace CommonComponent.Service.Features.Concrete
{
    public class Handler
    {
        public static CheckProfileStatusResponseDto HandlResponse(HttpResponseMessage response)
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
        public static HttpRequestMessage HTTPRequestMessage(CheckProfileStatusRequestDto requestDto, HttpClient client)
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
    }
}