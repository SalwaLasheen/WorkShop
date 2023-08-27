namespace Presentation.Services.Features.Interface
{
    public interface IGetProfileStatus
    {
        Task<CheckProfileStatusResponseDto> GetDataProfileStatus(CheckProfileStatusRequestDto requestDto);

    }
}
