using Services.Dtos.CheckProfileStatus.Request;
using Services.Dtos.CheckProfileStatus.Response;

namespace Services.Features.Interface
{
    public interface IConsumeAPI
    {
        Task<CheckProfileStatusResponseDto> ConsumeWsdlAPIAsync(CheckProfileStatusRequestDto requestDto);

    }
}
