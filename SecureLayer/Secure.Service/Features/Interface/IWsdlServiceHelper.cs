namespace Secure.Service.Features.Interface
{
    public interface IWsdlServiceHelper
    {
        Task<CheckProfileStatusResponseDto> GetWsdlClientResponseAsync(CheckProfileStatusRequestDto requestDto);
    }
}
