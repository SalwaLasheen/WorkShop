namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileStatusController : ControllerBase
    {
        private readonly IConsumeAPI _service;
        private readonly IServiceAudit _serviceAudit;
        public ProfileStatusController(IConsumeAPI service, IServiceAudit serviceAudit)
        {

            _service = service;
            _serviceAudit = serviceAudit;
        }
        [HttpPost("CallWsdlApiAsync")]
        [ServiceFilter(typeof(DeviceInformationAttribute))]
        public async Task<ActionResult<CheckProfileStatusResponseDto>> CallWsdlApiAsync(CheckProfileStatusRequestDto request)
        {
            var response = await _service.ConsumeWsdlAPIAsync(request);
            _serviceAudit.AddResponseLogSql(response, request.DialField);
            return Ok(response);

        }
    }

}