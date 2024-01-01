namespace CatchDotNet.API.Infrastructure.Domain
{
    public interface ISoftDeleteEntity
    {
        bool IsDeleted { get; set; }
    }
}
