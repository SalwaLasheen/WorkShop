using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsdlClient.Protocols;

namespace WsdlClient.Implementation
{
    internal class WsdlClient: IWsdlClient
    {
        //function to consume WSDl
        public async Task<checkDataProfileStatus_out> CallWSDLAsync(checkDataProfileStatus_in checkDataProfileStatus_In)
        {
            try
            {
                checkDataProfileStatus_V2_WSDL_PortTypeClient client = new checkDataProfileStatus_V2_WSDL_PortTypeClient();
                checkDataProfileStatus_V2Request request = new checkDataProfileStatus_V2Request();
                request.checkDataProfileStatus_in = checkDataProfileStatus_In;
                var response = await client.checkDataProfileStatus_V2Async(request);
                var responseResult = response.checkDataProfileStatus_out;
                return responseResult;

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            return null;
        }

    }
}
