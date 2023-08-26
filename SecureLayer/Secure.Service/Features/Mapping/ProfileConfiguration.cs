namespace Secure.Service.Features.Mapping
{
    public class ProfileConfiguration : Profile
    {
        public ProfileConfiguration()
        {
            CreateMap<MongoAuditLogEntity, MongoAuditLogDto>().ReverseMap();
            CreateMap<checkDataProfileStatus_in, CheckProfileStatusRequestDto>().ReverseMap()
                .ForMember(src => src.dial, conf => conf.MapFrom(dto => dto.Dial))
                  .ForMember(src => src.sourceId, conf => conf.MapFrom(dto => dto.SourceIdField))
                  .ForMember(src => src.langId, conf => conf.MapFrom(dto => dto.LangIdField));
            CreateMap<checkDataProfileStatus_out, CheckProfileStatusResponseDto>().ReverseMap()
                .ForMember(src => src.errorDoc, conf => conf.MapFrom(dto => dto.ErrorDoc))
             .ForMember(src => src.BucketInfo, conf => conf.MapFrom(dto => dto.BucketInfo));
            CreateMap<optionsList, OptionsListDto>().ReverseMap();
            CreateMap<BucketInfo, BucketInfoDto>().ReverseMap();
            CreateMap<errorDoc, ErrorDocDto>().ReverseMap();
            CreateMap<ResponseWsdl, CheckProfileStatusResponseDto>().ReverseMap()
                .ForMember(src => src.ErrorMessage, conf => conf.MapFrom(dto => dto.ErrorDoc))
             .ForMember(src => src.ErrorCode, conf => conf.MapFrom(dto => dto.ErrorDoc.ErrorCode))
              .ForMember(src => src.Status, conf => conf.MapFrom(dto => dto.ErrorDoc.Status))
             .ForMember(src => src.BucketId, conf => conf.MapFrom(dto => dto.BucketInfo.Select(x => x.CurrentBucketId).FirstOrDefault()))
            .ForMember(src => src.BucketName, conf => conf.MapFrom(dto => dto.BucketInfo.Select(x => x.CurrentBucketName).FirstOrDefault()))
            .ForMember(src => src.RnRText, conf => conf.MapFrom(dto => dto.BucketInfo.Select(x => x.RnRText).FirstOrDefault()))
            .ForMember(src => src.IsRnR, conf => conf.MapFrom(dto => dto.BucketInfo.Select(x => x.IsRnR).FirstOrDefault()))
            .ForMember(src => src.OptionsList, conf => conf.MapFrom(dto => dto.BucketInfo.Select(x => x.OptionsList).FirstOrDefault()));
        }
    }
}
