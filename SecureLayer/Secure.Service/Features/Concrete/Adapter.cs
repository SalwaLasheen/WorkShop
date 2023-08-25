namespace Secure.Service.Features.Concrete
{
    public class Adapter
    {
        private readonly IMapper _mapper;
        public Adapter(IMapper mapper)
        {
            _mapper = mapper;
        }
        public checkDataProfileStatus_in AdapterRequest(CheckProfileStatusRequestDto request)
        {
            return _mapper.Map<CheckProfileStatusRequestDto, checkDataProfileStatus_in>(request);
        }

        public CheckProfileStatusResponseDto AdapterResponse(checkDataProfileStatus_out status_Out)
        {
            var response = _mapper.Map<checkDataProfileStatus_out, CheckProfileStatusResponseDto>(status_Out);
            response.ResponseTime = DateTime.Now.TimeOfDay.ToString();
            return response;
        }
    }
}
