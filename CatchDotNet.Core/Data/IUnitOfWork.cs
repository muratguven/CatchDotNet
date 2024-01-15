namespace CatchDotNet.Core.Data
{
    public interface IUnitOfWork<TDbContext> :IDisposable
    {
        int Commit();
        Task<int> CommitAsync();
        void Rollback();

        
    }
}
