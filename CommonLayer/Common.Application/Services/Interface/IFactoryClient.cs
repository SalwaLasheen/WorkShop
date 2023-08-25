using CommonComponent.Application.Dtos.Response;

namespace Common.Service.Features.Interface
{
    public interface IFactoryClient
    {
        Task<CheckProfileStatusResponseDto> ConsumeWsdlAPIAsync(CheckProfileStatusRequestDto requestDto);
    }
}
