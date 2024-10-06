using CatchDotNet.Core.EntityFrameworkCore;

namespace CatchDotNet.WebApi.Features.Cases.Domains;

public interface ICategoryRepository : IEfCoreRepository<Category>
{
    /// <summary>
    /// Does the category exist .
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    Task<bool> ExistsAsync(string name);
}
