namespace CatchDotNet.API.Infrastructure.Domain
{
    public interface IModifiedDateEntity
    {
        DateTime? LastModified { get; set;}
    }
}
