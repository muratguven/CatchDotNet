using AutoMapper;

namespace CatchDotNet.Core.ApplicationService
{
    public abstract class ApplicationService: IApplicationService
    {
        protected IMapper Mapper { get; set; }

        public ApplicationService(IMapper mapper)
        {
            Mapper = mapper;
        }

    }
}
