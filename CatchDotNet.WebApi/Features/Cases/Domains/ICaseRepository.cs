using CatchDotNet.Core.EntityFrameworkCore;

namespace CatchDotNet.WebApi.Features.Cases.Domains;

public interface ICaseRepository : IEfCoreRepository<Case>
{

}
