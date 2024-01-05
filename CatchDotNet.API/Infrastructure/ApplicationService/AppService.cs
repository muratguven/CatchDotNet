using AutoMapper;

namespace CatchDotNet.API.Infrastructure.ApplicationService
{
    public abstract class AppService: IAppService
    {
        protected IMapper Mapper { get; set; }

        public AppService(IMapper mapper)
        {
            Mapper = mapper;
        }

    }
}
