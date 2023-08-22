using Microsoft.AspNetCore.Mvc;
using Services.Dtos.CheckProfileStatus.Request;
using Services.Dtos.CheckProfileStatus.Response;
using Services.Features.Interface;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WsdlClientController : ControllerBase
    {
        private readonly ICallWsdlService _service;
        private readonly IServiceAudit _serviceAudit;
        public WsdlClientController(ICallWsdlService service, IServiceAudit serviceAudit)
        {
            _service = service;
            _serviceAudit = serviceAudit;
        }
        [HttpPost("CallWsdlServiceAsync")]
        public async Task<ActionResult<CheckProfileStatusResponseDto>> CallWsdlServiceAsync(CheckProfileStatusRequestDto request)
        {
            var response = await _service.CallWsdlClientAsync(request);
            _serviceAudit.AddAuditLogMongo(response, request);
            return Ok(response);

        }
    }
}