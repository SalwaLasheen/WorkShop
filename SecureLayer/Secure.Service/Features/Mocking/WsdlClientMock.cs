namespace Secure.Service.Features.Mocking
{
    public class WsdlClientMock : IWsdlClient
    {
        private readonly IWsdlRepositry _repository;
        private readonly IMapper _mapper;
        public WsdlClientMock( IWsdlRepositry repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public  Task<CheckProfileStatusResponseDto> CallWSDLMock(CheckProfileStatusRequestDto requestDto)
        {
            var response =  _repository.GetResponseByDial(requestDto.Dial).Result;
            //var mappingResponse= _mapper.Map<ResponseWsdl, CheckProfileStatusResponseDto>(response);
          //  return Task.FromResult( mappingResponse);
             return  Task.FromResult( ReturnWsdlStatusOut(response.ErrorCode, response.ErrorMessage, response.Status, response.IsRnR, response.RnRText, response, response.BucketId, response.BucketName));
        }

        private CheckProfileStatusResponseDto ReturnWsdlStatusOut(string errorCode, string errorMessage, int? status, bool? isRnR, string rnRText, ResponseWsdl response, int? bucketId, string bucketName)
        {
            CheckProfileStatusResponseDto dto = new CheckProfileStatusResponseDto()
            {
                ErrorDoc =
                {
                    ErrorCode = errorCode,
                    ErrorMessage = errorMessage,
                    Status = status.ToString()
                },
                ResponseTime = DateTime.Now.TimeOfDay.ToString(),
                BucketInfo = new BucketInfoDto[] {
                    new BucketInfoDto
                {
                    CurrentBucketId = bucketId.ToString(),
                    CurrentBucketName = bucketName,
                    IsRnR=isRnR.ToString(),
                    RnRText=rnRText,
                    OptionsList=new OptionsListDto[] {
                    new OptionsListDto() {
                    OptionId="1",
                    OptionName="2"
                    },

                },

                    }

            }


            };
            return dto;
            }

    }
}
    





