
namespace CatchDotNet.Core.Domain
{
    public abstract class AuditedEntity : Entity, ICreatedTimeEntity, IModifiedDateEntity, ISoftDeleteEntity
    {
        public virtual DateTime? CreatedDate { get; set; }
        public virtual DateTime? LastModified { get; set; }
        public bool IsDeleted { get; set; } = false;
    }

    public abstract class AuditedEntity<T>: Entity<T>, ICreatedTimeEntity, IModifiedDateEntity, ISoftDeleteEntity
    {
        public virtual DateTime? CreatedDate { get; set; }
        public virtual DateTime? LastModified { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
