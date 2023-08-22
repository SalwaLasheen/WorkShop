using Services.Dtos.CheckProfileStatus.Request;
using Services.Dtos.CheckProfileStatus.Response;

namespace Services.Features.Interface
{
    public interface ICallWsdlService
    {
        Task<CheckProfileStatusResponseDto> CallWsdlClientAsync(CheckProfileStatusRequestDto requestDto);
    }
}
