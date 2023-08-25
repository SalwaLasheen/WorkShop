using CommonComponent.Application.Dtos.Request;
using CommonComponent.Application.Dtos.Response;
using CommonComponent.Service.Features.Interface;
using Presentation.Services.Features.Interface;
using Presentation.Services.Utilities.Attributes;

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