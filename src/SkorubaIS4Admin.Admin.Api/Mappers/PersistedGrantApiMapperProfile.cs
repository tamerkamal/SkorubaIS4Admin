using AutoMapper;
using Skoruba.IdentityServer4.Admin.BusinessLogic.Dtos.Grant;
using SkorubaIS4Admin.Admin.Api.Dtos.PersistedGrants;

namespace SkorubaIS4Admin.Admin.Api.Mappers
{
    public class PersistedGrantApiMapperProfile : Profile
    {
        public PersistedGrantApiMapperProfile()
        {
            CreateMap<PersistedGrantDto, PersistedGrantApiDto>(MemberList.Destination);
            CreateMap<PersistedGrantDto, PersistedGrantSubjectApiDto>(MemberList.Destination);
            CreateMap<PersistedGrantsDto, PersistedGrantsApiDto>(MemberList.Destination);
            CreateMap<PersistedGrantsDto, PersistedGrantSubjectsApiDto>(MemberList.Destination);
        }
    }
}







