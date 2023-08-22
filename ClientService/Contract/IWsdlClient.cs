using WsdlService;

namespace ClientService.Contract
{
    public interface IWsdlClient
    {
        Task<checkDataProfileStatus_out> CallWSDLAsync(checkDataProfileStatus_in checkDataProfileStatus_In);
  }
}
