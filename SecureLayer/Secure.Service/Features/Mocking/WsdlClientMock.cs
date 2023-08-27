namespace Secure.Service.Features.Mocking
{
    public class WsdlClientMock : IWsdlClient
    {
        private readonly IWsdlRepositry _repository;
      //  private readonly IMapper _mapper;
        public WsdlClientMock(IWsdlRepositry repository)
        {
            _repository = repository;
           // _mapper = mapper;
        }

        public Task<CheckProfileStatusResponseDto> CallWSDLMock(CheckProfileStatusRequestDto requestDto)
        {
            var responseWsdls = _repository.GetResponseByDial(requestDto.Dial).Result;
            var response = responseWsdls?.FirstOrDefault();
            if (response is not null)
            {
                var responseDto = ReturnWsdlStatusOut(response.ErrorCode, response.ErrorMessage, response.Status, response.IsRnR, response.RnRText, response.BucketId, response.BucketName, responseWsdls);
                return Task.FromResult(responseDto);
            }
            return Task.FromResult(new CheckProfileStatusResponseDto());
        }

        private CheckProfileStatusResponseDto ReturnWsdlStatusOut(string errorCode, string errorMessage, int? status, bool? isRnR, string rnRText, int? bucketId, string bucketName, List<ResponseWsdl> responseWsdls)
        {
            CheckProfileStatusResponseDto responseDto = new()
            {
                ErrorDoc = new ErrorDocDto
                {
                    ErrorCode = errorCode,
                    ErrorMessage = errorMessage,
                    Status = status.ToString()
                },
                ResponseTime = DateTime.Now.ToString("ss.fff"),
                BucketInfo = new BucketInfoDto[] {
                    new BucketInfoDto
                {
                    CurrentBucketId = bucketId.ToString(),
                    CurrentBucketName = bucketName,
                    IsRnR= isRnR.ToString(),
                    RnRText= rnRText,
                    OptionsList=GetOptionsValue(responseWsdls),

                }
            }};
            return responseDto;
        }

        private  OptionsListDto[] GetOptionsValue(List<ResponseWsdl> responseWsdls)
        {
            var options = new List<OptionsListDto>();
            foreach (var response in responseWsdls)
            {
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

            }
            return options.ToArray();
        }
    }
}







