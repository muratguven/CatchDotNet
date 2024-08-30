using CatchDotNet.Core.EntityFrameworkCore;

namespace CatchDotNet.WebApi.Features.Cases.Domains;

public interface IStatusRepository : IEfCoreRepository<Status>
{

}
