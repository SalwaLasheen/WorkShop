using ClientService.Contract;
using WsdlService;

namespace ClientService.Implementation
{
    public class MockWsdlClient : IWsdlClient
    {
        // function with if else according to dial id
        public Task<checkDataProfileStatus_out> CallWSDLAsync(checkDataProfileStatus_in checkDataProfileStatus_In)
        {
            return checkDataProfileStatus_In.dial switch
            {
                "01200000001" => Task.FromResult(ReturnWsdlStatusOut("er0000", "Success", "0", "false", "xxxx", "1", "Subscribe")),
                "01200000002" => Task.FromResult(ReturnWsdlStatusOut("er2056", "Techincal Error", "1", "false", "xxxx", string.Empty, string.Empty)),
                "01200000003" => Task.FromResult(ReturnWsdlStatusOut("er0000", "Success", "0", "false", "xxxx", "7", "Renew", "19", "Change Package", "5100", "Go 100")),
                "01200000004" => Task.FromResult(ReturnWsdlStatusOut("er3000", "Not eligible", "1", "false", "xxxx", string.Empty, string.Empty, string.Empty, string.Empty, "5100", "Go 100")),
                _ => Task.FromResult(ReturnWsdlStatusOut("er0000", "Success", "0", "false", "xxxx", "1", "Subscribe")),
            };
        }

        private static checkDataProfileStatus_out ReturnWsdlStatusOut(string errCode, string errMessage, string status
             , string isRnr, string rnrText, string optionId, string optionName)
        {
            return new checkDataProfileStatus_out()
            {
                BucketInfo = new BucketInfo[]{
                     new BucketInfo {
                       IsRnR=isRnr,
                       RnRText=rnrText,
                       optionsList=new optionsList[]
                       {
                         new optionsList{
                            optionId=optionId,
                            optionName=optionName
                       } } } },
                errorDoc = new errorDoc
                {
                    status = status,
                    errorCode = errCode,
                    errorMessage = errMessage
                }
            };
        }

        private static checkDataProfileStatus_out ReturnWsdlStatusOut(string errCode, string errMessage,
            string status, string isRnr, string rnrText, string optionIdF, string optionNameF, string optionIdSec,
            string optionNameSec, string bucketId, string buctName)
        {
            return new checkDataProfileStatus_out()
            {
                BucketInfo = new BucketInfo[]{
                          new BucketInfo {
                                   IsRnR=isRnr,
                                    RnRText=rnrText,
                                    currentBucketId=bucketId,
                                    currentBucketName=buctName,
                                    optionsList=new optionsList[]
                                    {
                                        new optionsList{
                                            optionId=optionIdF,
                                            optionName=optionNameF,
                                        },
                                         new optionsList{
                                            optionId=optionIdSec,
                                            optionName=optionNameSec,
                                        }

                                    }
                          } },
                errorDoc = new errorDoc
                {
                    status = status,
                    errorCode = errCode,
                    errorMessage = errMessage
                }
            };
        }

    }
}

