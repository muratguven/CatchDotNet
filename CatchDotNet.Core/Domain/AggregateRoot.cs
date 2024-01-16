using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchDotNet.Core.Domain
{
    public abstract class AggregateRoot : Entity
    {

    }

    public abstract class AggregateRoot<T> : Entity<T>
    {

    }
    public abstract class AuditedAggregateRoot : Entity,ICreatedTimeEntity, IModifiedDateEntity, ISoftDeleteEntity
    {
        public virtual DateTime? CreatedDate { get; set; }
        public virtual DateTime? LastModified { get; set; }
        public bool IsDeleted { get; set; } = false;
    }

    public abstract class AuditedAggregateRoot<T> : Entity<T>, ICreatedTimeEntity, IModifiedDateEntity, ISoftDeleteEntity
    {
        public virtual DateTime? CreatedDate { get; set; }
        public virtual DateTime? LastModified { get; set; }
        public bool IsDeleted { get; set; } = false;
    }

}
