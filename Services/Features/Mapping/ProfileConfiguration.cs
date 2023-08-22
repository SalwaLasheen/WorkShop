using AutoMapper;
using Domain.Entity;
using Services.Dtos.CheckProfileStatus;
using Services.Dtos.CheckProfileStatus.Request;
using Services.Dtos.CheckProfileStatus.Response;
using WsdlService;

namespace Services.Features.Mapping
{
    public class ProfileConfiguration : Profile
    {
        public ProfileConfiguration()
        {
            CreateMap<SqlResponseEntity, SqlResponseDto>().ReverseMap();
            CreateMap<ActionLogEntity, ActionLogSqlDto>().ReverseMap();
            CreateMap<MongoAuditLogEntity, MongoAuditLogDto>().ReverseMap();
            CreateMap<checkDataProfileStatus_in, CheckProfileStatusRequestDto>().ReverseMap()
                .ForMember(src => src.dial, conf => conf.MapFrom(dto => dto.DialField))
                  .ForMember(src => src.sourceId, conf => conf.MapFrom(dto => dto.SourceIdField))
                  .ForMember(src => src.langId, conf => conf.MapFrom(dto => dto.LangIdField));
            CreateMap<checkDataProfileStatus_out, CheckProfileStatusResponseDto>().ReverseMap()
                .ForMember(src => src.errorDoc, conf => conf.MapFrom(dto => dto.ErrorDoc))
             .ForMember(src => src.BucketInfo, conf => conf.MapFrom(dto => dto.BucketInfo));

            CreateMap<optionsList, OptionsListDto>().ReverseMap();
            CreateMap<BucketInfo, BucketInfoDto>().ReverseMap();
            CreateMap<errorDoc, ErrorDocDto>().ReverseMap();

        }
    }
}
