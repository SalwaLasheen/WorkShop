using AutoMapper;
using ClientService.Contract;
using Services.Dtos.CheckProfileStatus.Request;
using Services.Dtos.CheckProfileStatus.Response;
using Services.Features.Interface;
using WsdlService;

namespace Services.Features.Mocking
{
    public class CallWsdlServiceMocking : ICallWsdlService
    {


        public readonly IWsdlClient _client;
        public IMapper _mapper;
        public CallWsdlServiceMocking(IMapper mapper, IWsdlClient client)
        {
            _mapper = mapper;
            _client = client;
        }

        public async Task<CheckProfileStatusResponseDto> CallWsdlClientAsync(CheckProfileStatusRequestDto requestDto)
        {
            var statusInRequest = AdapterRequest(requestDto);
            var statusOutResponse = await _client.CallWSDLAsync(statusInRequest);
            var response = AdapterResponse(statusOutResponse);

            return response;
        }

        public checkDataProfileStatus_in AdapterRequest(CheckProfileStatusRequestDto request)
        {
            return _mapper.Map<CheckProfileStatusRequestDto, checkDataProfileStatus_in>(request);
        }
        public CheckProfileStatusResponseDto AdapterResponse(checkDataProfileStatus_out status_Out)
        {
            var response = _mapper.Map<checkDataProfileStatus_out, CheckProfileStatusResponseDto>(status_Out);
            return response;
        }

    }
}

