namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileStatusController : ControllerBase
    {
        private readonly IGetProfileStatus _profileStatusService;
        private readonly IServiceAudit<ActionLogSqlDto> _serviceAudit;
        public ProfileStatusController(IGetProfileStatus profileStatusService, IServiceAudit<ActionLogSqlDto> serviceAudit)
        {

            _profileStatusService = profileStatusService;
            _serviceAudit = serviceAudit;
        }
        [HttpPost("CallWsdlApiAsync")]
        [ServiceFilter(typeof(DeviceInformationAttribute))]
        public async Task<ActionResult<CheckProfileStatusResponseDto>> CallWsdlApiAsync(CheckProfileStatusRequestDto request)
        {
            var response = await _profileStatusService.GetDataProfileStatus(request);
            _serviceAudit.AddResponseLogSql(response, request.Dial);
            return Ok(response);

        }
    }

}