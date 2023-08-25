
namespace Presentation.Service.Features.Concrete
{
    public class GetProfileStatus : IGetProfileStatus
    {
        public IMapper _mapper;
        private readonly IFactoryClient _factoryClient;
        public GetProfileStatus(IMapper mapper, IFactoryClient factoryClient)
        {
            _mapper = mapper;
            _factoryClient = factoryClient;

        }
        public Task<CheckProfileStatusResponseDto> GetDataProfileStatus(CheckProfileStatusRequestDto requestDto)
        {
            return _factoryClient.ConsumeWsdlAPIAsync(requestDto);

        }
    }
}
