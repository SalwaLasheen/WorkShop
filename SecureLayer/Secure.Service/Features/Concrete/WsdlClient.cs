namespace Secure.Service.Features.Concrete
{
    public class WsdlClient : IWsdlClient
    {
        public WsdlClient()
        {
                
        }
        //function to consume Real WSDl
        public async Task<checkDataProfileStatus_out> CallWSDLAsync(checkDataProfileStatus_in checkDataProfileStatus_In)
        {
            try
            {
                checkDataProfileStatus_V2_WSDL_PortTypeClient client = new();
                var response = await client.checkDataProfileStatus_V2Async(checkDataProfileStatus_In);
                return response.checkDataProfileStatus_out;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);

            }
        }

    }
}
