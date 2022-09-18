using AutoMapper;
using CVSite.Application.CV.Data;
using CVSite.Domain.Master;
using Profile = AutoMapper.Profile;

namespace CVSite.Infrastructure;

public class AutoMapProfile : Profile
{
    public AutoMapProfile()
    {
        CreateMap<CurriculumVitae, CurriculumVitaeDTO>();
        CreateMap<CurriculumVitae, CurriculumVitaeDetailsDTO>();
    }
}
