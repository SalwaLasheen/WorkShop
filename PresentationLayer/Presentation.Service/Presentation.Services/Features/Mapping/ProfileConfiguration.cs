namespace Presentation.Service.Features.Mapping
{
    public class ProfileConfiguration : Profile
    {
        public ProfileConfiguration()
        {
            CreateMap<SqlResponseEntity, SqlResponseDto>().ReverseMap();
            CreateMap<ActionLogEntity, ActionLogSqlDto>().ReverseMap();

        }
    }
}
