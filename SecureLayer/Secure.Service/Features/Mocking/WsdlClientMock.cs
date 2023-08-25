namespace Secure.Service.Features.Mocking
{
    public class WsdlClientMock : IWsdlClient
    {
        private readonly IWsdlRepositry _repository;
        private readonly IMapper _mapper;
        public WsdlClientMock(IWsdlRepositry repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<CheckProfileStatusResponseDto> CallWSDLMock(CheckProfileStatusRequestDto requestDto)
        {
            var response = _repository.GetResponseByDial(requestDto.Dial).Result;
            //var mappingResponse= _mapper.Map<ResponseWsdl, CheckProfileStatusResponseDto>(response);
            //  return Task.FromResult( mappingResponse);
            return Task.FromResult(ReturnWsdlStatusOut(response.ErrorCode, response.ErrorMessage, response.Status, response.IsRnR, response.RnRText, response.BucketId, response.BucketName, response));
        }

        private CheckProfileStatusResponseDto ReturnWsdlStatusOut(string errorCode, string errorMessage, int? status, bool? isRnR, string rnRText, int? bucketId, string bucketName, ResponseWsdl response)
        {
            CheckProfileStatusResponseDto dto = new CheckProfileStatusResponseDto()
            {
                ErrorDoc = new ErrorDocDto
                {
                    ErrorCode = errorCode,
                    ErrorMessage = errorMessage,
                    Status = status != null ? status.ToString() : "0"
                },
                ResponseTime = DateTime.Now.TimeOfDay.ToString(),
                BucketInfo = new BucketInfoDto[] {
                    new BucketInfoDto
                {
                    CurrentBucketId = bucketId != null? bucketId.ToString():null,
                    CurrentBucketName = bucketName,
                    IsRnR= isRnR!=null? isRnR.ToString():"false",
                    RnRText= rnRText,
                    OptionsList=GetOptionsValue(response),

                    }
            }


            };
            return dto;
        }

        private static OptionsListDto[] GetOptionsValue(ResponseWsdl response)
        {
            var options = new List<OptionsListDto>();
            foreach (var option in response.OptionsList)
            {
                options.AddRange(new List<OptionsListDto>
                {
                    new OptionsListDto
                    {
                        OptionId = option.Id.ToString(),
                        OptionName=option.OptionName
                    }
                });
            }
            return options.ToArray();

        }

    }
}







