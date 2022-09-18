using AutoMapper;
using CVSite.Infrastructure;

namespace CVSite.Tests
{
    public static class TestHelpers
    {
        public static IMapper CreateTestAutoMapper()
        {
            var myProfile = new AutoMapProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            IMapper mapper = new Mapper(configuration);
            return mapper;
        }
    }
}