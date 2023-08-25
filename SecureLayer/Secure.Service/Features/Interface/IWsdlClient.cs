namespace Secure.Service.Features.Interface
{
    public interface IWsdlClient
    {
        Task<checkDataProfileStatus_out> CallWSDLAsync(checkDataProfileStatus_in checkDataProfileStatus_In) { return null; }
        Task<CheckProfileStatusResponseDto> CallWSDLMock(CheckProfileStatusRequestDto checkProfileStatusResponseDto) { return null; }
    }
}
