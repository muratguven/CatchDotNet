using CatchDotNet.Core.EntityFrameworkCore;

namespace CatchDotNet.WebApi.Features.Cases.Domains;

public interface ICategoryRepository : IEfCoreRepository<Category>
{

}
