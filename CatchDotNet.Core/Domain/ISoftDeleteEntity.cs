namespace CatchDotNet.Core.Domain
{
    public interface ISoftDeleteEntity
    {
        bool IsDeleted { get; set; }
    }
}
