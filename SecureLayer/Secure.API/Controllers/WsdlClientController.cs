using Secure.Application.Dtos;

namespace Secure.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WsdlClientController : ControllerBase
    {
        private readonly IWsdlServiceHelper _service;
        private readonly IServiceAudit<MongoAuditLogDto> _serviceAudit;

        public WsdlClientController(IWsdlServiceHelper service, IServiceAudit<MongoAuditLogDto> serviceAudit)
        {
            _service = service;
            _serviceAudit = serviceAudit;
        }
        [HttpPost("CallWsdlServiceAsync")]
        public async Task<ActionResult<CheckProfileStatusResponseDto>> CallWsdlServiceAsync(CheckProfileStatusRequestDto request)
        {
            var response = await _service.GetWsdlClientResponseAsync(request);
            _serviceAudit.AddAuditLogMongo(response, request);
            return Ok(response);

        }
    }
}